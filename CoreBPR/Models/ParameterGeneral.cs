using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBPR.Models
{
    [Table("RefGender")]
    public class RefGender
    {
        [Key]
        [Column("GenderId")]
        public string GenderId { get; set; }

        [Column("GenderName")]
        public string GenderName { get; set; }
    }

    [Table("RefGenderPlus")]
    public class RefGenderPlus
    {
        [Key]
        [Column("GenderPlusId")]
        public string GenderPlusId { get; set; }

        [Column("GenderPlusName")]
        public string GenderPlusName { get; set; }
    }

    [Table("RefHomeStatus")]
    public class RefHomeStatus
    {
        [Key]
        [Column("HomeStatusId")]
        public string HomeStatusId { get; set; }

        [Column("HomeStatusName")]
        public string HomeStatusName { get; set; }
    }

    [Table("RefMarital")]
    public class RefMarital
    {
        [Key]
        [Column("MaritalId")]
        public string MaritalId { get; set; }

        [Column("MaritalName")]
        public string MaritalName { get; set; }
    }

    [Table("RefYesNo")]
    public class RefYesNo
    {
        [Key]
        [Column("YesNoId")]
        public string YesNoId { get; set; }

        [Column("YesNoName")]
        public string YesNoName { get; set; }
    }

    [Table("RefSourceIncome")]
    public class RefSourceIncome
    {
        [Key]
        [Column("SourceIncomeId")]
        public string SourceIncomeId { get; set; }

        [Column("SourceIncomeName")]
        public string SourceIncomeName { get; set; }
    }

    [Table("RefDocumentType")]
    public class RefDocumentType
    {
        [Key]
        [Column("DocTypeId")]
        public string DocTypeId { get; set; }

        [Column("DocTypeName")]
        public string DocTypeName { get; set; }
    }
}
