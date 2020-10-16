using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBPR.Models
{
    [Table("RefInitial")]
    public class ApplicationInitial
    {
        [Key]
        [Column("ParamKey")]
        public string ParamKey { get; set; }

        [Column("ParamValue")]
        public string ParamValue { get; set; }
    }
}
