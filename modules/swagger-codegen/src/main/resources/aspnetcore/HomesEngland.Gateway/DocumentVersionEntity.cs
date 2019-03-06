using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HomesEngland.Domain;
using HomesEngland.UseCase.CreateDocumentVersion.Models;

namespace HomesEngland.Gateway
{
    [Table("assetregisterversions")]
    public class DocumentVersionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("modifieddatetime")]
        public DateTime ModifiedDateTime { get; set; }
        
        public virtual IList<DocumentEntity> Assets { get; set; }

        public DocumentVersionEntity() { }

        public DocumentVersionEntity(IDocumentVersion documentVersion)
        {
            Id = documentVersion.Id;
            ModifiedDateTime = documentVersion.ModifiedDateTime;
            Assets = documentVersion.Documents?.Select(s=> new DocumentEntity(s)).ToList();
        }
    }
}
