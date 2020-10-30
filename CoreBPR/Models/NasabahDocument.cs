using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace CoreBPR.Models
{
    [Table("NasabahDocument")]
    public class NasabahDocument
    {
        [Key]
        [Column("DocumentId")]
        public int DocumentId { get; set; }

        [Column("NasabahId")]
        public string NasabahId { get; set; }

        [Column("DocTypeId")]
        [Display(Name = "Document Type")]
        public string DocTypeId { get; set; }

        [ForeignKey("DocTypeId")]
        public virtual RefDocumentType RefDocumentType { get; set; }

        [Column("Caption")]
        [Display(Name = "Caption")]
        [StringLength(50)]
        public string Caption { get; set; }

        [Column("FileName")]
        [Display(Name = "File Name")]
        [StringLength(50)]
        public string FileName { get; set; }
    }

    public class NasabahDocumentUploadModel
    {
        [Key]
        public int DocumentId { get; set; }

        public string NasabahId { get; set; }

        [Display(Name = "Document Type")]
        public string DocTypeId { get; set; }

        [ForeignKey("DocTypeId")]
        public virtual RefDocumentType RefDocumentType { get; set; }

        [Required]
        [Display(Name = "Caption")]
        [StringLength(50)]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "File")]
        public IFormFile FileUpload { get; set; }
    }
}
