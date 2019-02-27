using System;
using HomesEngland.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomesEngland.Gateway
{
    /// <summary>
    /// Has all of the database annotations to interact with the database
    /// </summary>
    [Table("assets")]
    public class DocumentEntity : IDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("modifieddatetime")]
        public DateTime ModifiedDateTime { get; set; }

        

        [Column("assetregisterversionid")]
        public int? DocumentVersionId { get; set; }

        [ForeignKey("AssetRegisterVersionId")]
        public virtual DocumentVersionEntity DocumentVersion { get; set; }

        public DocumentEntity() { }
        public DocumentEntity(IDocument request)
        {
           

            DocumentVersionId = request.DocumentVersionId;
        }
    }
}
