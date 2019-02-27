using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Gateway.AssetRegisterVersions;
using HomesEngland.Gateway.Migrations;
using HomesEngland.UseCase.CreateDocumentVersion.Models;

namespace HomesEngland.Gateway.Sql
{
    public class EFDocumentVersionGateway : IDocumentVersionCreator, IDocumentVersionSearcher
    {
        private readonly string _databaseUrl;

        public EFDocumentVersionGateway(string databaseUrl)
        {
            _databaseUrl = databaseUrl;
        }

        public async Task<IDocumentVersion> CreateAsync(IDocumentVersion documentVersion, CancellationToken cancellationToken)
        {
            DocumentVersionEntity documentVersionEntity = new DocumentVersionEntity(documentVersion);

            Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Start Associate Entities with Asset Register Version");

            documentVersionEntity.Assets = documentVersionEntity.Assets?.Select(s =>
            {
                s.DocumentVersion = documentVersionEntity;
                return s;
            }).ToList();

            Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Finish Associate Entities with Asset Register Version");

            using (var context = new DocumentContext(_databaseUrl))
            {
                Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Start Add async");
                await context.DocumentVersions.AddAsync(documentVersionEntity).ConfigureAwait(false);
                Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Finish Add async");
                Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Start Save Changes async");
                await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Finish Save Changes async");
                Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Start Marshall Data");
                IDocumentVersion result = new DocumentVersion
                {
                    Id = documentVersionEntity.Id,
                    ModifiedDateTime = documentVersionEntity.ModifiedDateTime,
                    Assets = documentVersionEntity.Assets?.Select(s=> new Document(s) as IDocument).ToList()
                };
                Console.WriteLine($"{DateTime.UtcNow.TimeOfDay.ToString("g")}: Finish Marshall Data");
                return result;
            }
        }

        public Task<IPagedResults<IDocumentVersion>> Search(IPagedQuery searchRequest, CancellationToken cancellationToken)
        {
            using (var context = new DocumentContext(_databaseUrl))
            {
                IQueryable<DocumentVersionEntity> queryable = context.DocumentVersions;

                queryable = queryable.OrderByDescending(o=> o.Id)
                            .Skip((searchRequest.Page.Value - 1) * searchRequest.PageSize.Value)
                            .Take(searchRequest.PageSize.Value);

                IEnumerable<DocumentVersionEntity> results = queryable.ToList();

                int totalCount = context.DocumentVersions.Select(s => s.Id).Count();
                IPagedResults<IDocumentVersion> pagedResults = new PagedResults<IDocumentVersion>
                {
                    Results = results.Select(s=> new DocumentVersion
                    {
                        Id = s.Id,
                        ModifiedDateTime = s.ModifiedDateTime
                    } as IDocumentVersion).ToList(),
                    TotalCount = totalCount,
                    NumberOfPages = (int)Math.Ceiling(totalCount / (decimal)searchRequest.PageSize.Value)
                };
                return Task.FromResult(pagedResults);
            }
        }
    }
}
