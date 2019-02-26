using System;
using HomesEngland.UseCase.CreateDocumentVersion.Models;

namespace HomesEngland.UseCase.GetDocumentVersions.Models
{
    public class AssetRegisterVersionOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public AssetRegisterVersionOutputModel(){}

        public AssetRegisterVersionOutputModel(IDocumentVersion documentVersion)
        {
            Id = documentVersion.Id;
            CreatedAt = documentVersion.ModifiedDateTime;
        }
    }
}
