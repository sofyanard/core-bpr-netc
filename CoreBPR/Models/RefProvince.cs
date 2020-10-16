using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBPR.Models
{
    [Table("RefProvince")]
    public class RefProvince
    {
        [Key]
        [Column("ProvinceId")]
        public string ProvinceId { get; set; }

        [Column("ProvinceName")]
        public string ProvinceName { get; set; }
    }
}
