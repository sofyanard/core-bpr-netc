using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBPR.Models
{
    [Table("RefUnit")]
    public class RefUnit
    {
        [Key]
        [Column("UnitId")]
        [Required]
        [StringLength(10)]
        public string UnitId { get; set; }

        [Column("UnitName")]
        [Required]
        [StringLength(50)]
        public string UnitName { get; set; }

        [Column("KodeBPR")]
        [StringLength(10)]
        public string KodeBPR { get; set; }

        [Column("Address")]
        [StringLength(100)]
        public string Address { get; set; }

        [Column("ProvinceId")]
        public string ProvinceId { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual RefProvince RefProvince { get; set; }

        [Column("CityId")]
        public string CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual RefCity RefCity { get; set; }

        [Column("IsActive")]
        [StringLength(1)]
        public string IsActive { get; set; }
    }
}
