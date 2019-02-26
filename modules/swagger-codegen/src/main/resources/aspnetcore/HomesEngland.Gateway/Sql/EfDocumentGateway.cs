using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Domain.Impl;
using HomesEngland.Gateway.AssetRegisterVersions;
using HomesEngland.Gateway.Assets;
using HomesEngland.Gateway.Assets.Developer;
using HomesEngland.Gateway.Assets.Region;
using HomesEngland.Gateway.Migrations;
using Microsoft.EntityFrameworkCore;

namespace HomesEngland.Gateway.Sql
{
    public class EfDocumentGateway : IGateway<IDocument, int>, IDocumentReader, IDocumentCreator, IAssetSearcher, IAssetAggregator, IAssetRegionLister, IAssetDeveloperLister
    {
        private readonly string _databaseUrl; 

        public EfDocumentGateway(string databaseUrl)
        {
            _databaseUrl = databaseUrl;
        }

        public Task<IDocument> CreateAsync(IDocument entity)
        {
            var assetEntity = new DocumentEntity(entity);

            using (var context = new DocumentContext(_databaseUrl))
            {
                context.Add(assetEntity);
                context.SaveChanges();
                entity.Id = assetEntity.Id;
                IDocument foundDocument = context.Assets.Find(assetEntity.Id);
                return Task.FromResult(foundDocument);
            }
        }

        public Task<IDocument> ReadAsync(int index)
        {
            using (var context = new DocumentContext(_databaseUrl))
            {
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                IDocument entity = context.Assets.Find(index);

                return Task.FromResult(entity);
            }
        }

        public Task<IPagedResults<IDocument>> Search(IAssetPagedSearchQuery searchRequest, CancellationToken cancellationToken)
        {
            using (var context = new DocumentContext(_databaseUrl))
            {
                var queryable = GenerateFilteringCriteria(context, searchRequest);

                queryable = queryable.Skip((searchRequest.Page.Value - 1) * searchRequest.PageSize.Value)
                    .Take(searchRequest.PageSize.Value);

                IEnumerable<IDocument> results = queryable.ToList();

                int totalCount = GenerateFilteringCriteria(context, searchRequest).Select(s => s.Id).Count();
                IPagedResults<IDocument> pagedResults = new PagedResults<IDocument>
                {
                    Results = results.ToList(),
                    TotalCount = totalCount,
                    NumberOfPages = (int) Math.Ceiling(totalCount / (decimal) searchRequest.PageSize.Value)
                };

                return Task.FromResult(pagedResults);
            }
        }

        private IQueryable<DocumentEntity> GenerateFilteringCriteria(DocumentContext context, IAssetSearchQuery searchRequest)
        {
            IQueryable<DocumentEntity> queryable = context.Assets;

            if(!searchRequest.AssetRegisterVersionId.HasValue)
                throw new ArgumentNullException("AssetRegisterVersionId is null");

            queryable = queryable.Where(w => w.AssetRegisterVersionId.Equals(searchRequest.AssetRegisterVersionId));

            if (!string.IsNullOrEmpty(searchRequest.Address) && !string.IsNullOrWhiteSpace(searchRequest.Address))
            {
                queryable = queryable.Where(w =>
                    EF.Functions.Like(w.Address.ToLower(), $"%{searchRequest.Address}%".ToLower()));
            }

            if(!string.IsNullOrEmpty(searchRequest.Region) && !string.IsNullOrWhiteSpace(searchRequest.Region))
            {
                queryable = queryable.Where(w => EF.Functions.Like(w.ImsOldRegion.ToLower(), $"%{searchRequest.Region}%".ToLower()));
            }

            if (!string.IsNullOrEmpty(searchRequest.Developer) && !string.IsNullOrWhiteSpace(searchRequest.Developer))
            {
                queryable = queryable.Where(w => EF.Functions.Like(w.DevelopingRslName.ToLower(), $"%{searchRequest.Developer}%".ToLower()));
            }

            if (searchRequest.SchemeId.HasValue && searchRequest?.SchemeId.Value > 0)
            {
                queryable = queryable.Where(w => w.SchemeId.HasValue && w.SchemeId == searchRequest.SchemeId.Value);
            }

            queryable = queryable.OrderByDescending(w => w.SchemeId);

            return queryable;
        }

        public Task<IAssetAggregation> Aggregate(IAssetSearchQuery searchRequest, CancellationToken cancellationToken)
        {
            using (var context = new DocumentContext(_databaseUrl))
            {
                var filteringCriteria = GenerateFilteringCriteria(context, searchRequest);

                var aggregatedData = filteringCriteria.Select(s => new
                {
                    AssetValue = s.AgencyFairValue,
                    MoneyPaidOut = s.AgencyEquityLoan,
                    SchemeId = s.SchemeId,
                });

                decimal? uniqueCount = aggregatedData?.Select(w => w.SchemeId).Distinct().Count();
                decimal? moneyPaidOut = aggregatedData?.Select(w => w.MoneyPaidOut).Sum(s => s);
                decimal? assetValue = aggregatedData?.Select(w => w.AssetValue).Sum(s => s);

                IAssetAggregation assetAggregates = new AssetAggregation
                {
                    UniqueRecords = uniqueCount,
                    AssetValue = assetValue,
                    MoneyPaidOut = moneyPaidOut,
                    MovementInAssetValue = assetValue - moneyPaidOut
                };
                return Task.FromResult(assetAggregates);
            }
        }

        public Task<IList<AssetRegion>> ListRegionsAsync(CancellationToken cancellationToken)
        {
            using (var context = new DocumentContext(_databaseUrl))
            {
                IList<AssetRegion> results = context.Assets.Select(s => new AssetRegion
                {
                    Name = s.ImsOldRegion
                }).Distinct().ToList();

                return Task.FromResult(results);
            }
        }

        public Task<IList<AssetDeveloper>> ListDevelopersAsync(CancellationToken cancellationToken)
        {
            using (var context = new DocumentContext(_databaseUrl))
            {
                IList<AssetDeveloper> results = context.Assets.Select(s => new AssetDeveloper
                {
                    Name = s.DevelopingRslName
                }).Distinct().ToList();

                return Task.FromResult(results);
            }
        }
    }
}
