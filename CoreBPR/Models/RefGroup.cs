using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CoreBPR.Models
{
    [Table("RefGroup")]
    public class RefGroup
    {
        [Key]
        [Column("GroupId")]
        [Required]
        [StringLength(20)]
        public string GroupId { get; set; }

        [Column("GroupName")]
        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }

        [Column("IsActive")]
        [StringLength(1)]
        public string IsActive { get; set; }
    }
}
