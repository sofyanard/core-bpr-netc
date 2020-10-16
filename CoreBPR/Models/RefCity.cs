using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBPR.Models
{
    [Table("RefCity")]
    public class RefCity
    {
        [Key]
        [Column("CityId")]
        public string CityId { get; set; }

        [Column("ProvinceId")]
        public string ProvinceId { get; set; }
        
        [ForeignKey("ProvinceId")]
        public virtual RefProvince RefProvince { get; set; }

        [Column("CityName")]
        public string CityName { get; set; }
    }
}
