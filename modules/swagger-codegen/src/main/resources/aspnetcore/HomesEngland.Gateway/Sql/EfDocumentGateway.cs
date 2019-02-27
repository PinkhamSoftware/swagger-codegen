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
using HomesEngland.Gateway.Migrations;
using Microsoft.EntityFrameworkCore;

namespace HomesEngland.Gateway.Sql
{
    public class EfDocumentGateway : IGateway<IDocument, int>, IDocumentReader, IDocumentCreator//,todo re-add document searcher IAssetSearcher
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
                IDocument foundDocument = context.Documents.Find(assetEntity.Id);
                return Task.FromResult(foundDocument);
            }
        }

        public Task<IDocument> ReadAsync(int index)
        {
            using (var context = new DocumentContext(_databaseUrl))
            {
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                IDocument entity = context.Documents.Find(index);

                return Task.FromResult(entity);
            }
        }

        public Task<IPagedResults<IDocument>> Search(IDocumentPagedSearchQuery searchRequest, CancellationToken cancellationToken)
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

        private IQueryable<DocumentEntity> GenerateFilteringCriteria(DocumentContext context, IDocumentSearchQuery searchRequest)
        {
            IQueryable<DocumentEntity> queryable = context.Documents;

            if(!searchRequest.DocumentVersionId.HasValue)
                throw new ArgumentNullException("DocumentVersionId is null");

            queryable = queryable.Where(w => w.DocumentVersionId.Equals(searchRequest.DocumentVersionId));

            queryable = queryable.OrderByDescending(w => w.Id);

            return queryable;
        }
    }
}
