using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBPR.Models
{
    [Table("RefCitizen")]
    public class RefCitizen
    {
        [Key]
        [Column("CitizenId")]
        public string CitizenId { get; set; }

        [Column("CitizenName")]
        public string CitizenName { get; set; }
    }

    [Table("RefEducation")]
    public class RefEducation
    {
        [Key]
        [Column("EducationId")]
        public string EducationId { get; set; }

        [Column("EducationName")]
        public string EducationName { get; set; }
    }

    [Table("RefJenisIdentity")]
    public class RefJenisIdentity
    {
        [Key]
        [Column("JenisIdentityId")]
        public string JenisIdentityId { get; set; }

        [Column("JenisIdentityName")]
        public string JenisIdentityName { get; set; }
    }

    [Table("RefJenisBadanUsaha")]
    public class RefJenisBadanUsaha
    {
        [Key]
        [Column("JenisBadanUsahaId")]
        public string JenisBadanUsahaId { get; set; }

        [Column("JenisBadanUsahaName")]
        public string JenisBadanUsahaName { get; set; }
    }

    [Table("RefBidangUsaha")]
    public class RefBidangUsaha
    {
        [Key]
        [Column("BidangUsahaId")]
        public string BidangUsahaId { get; set; }

        [Column("BidangUsahaName")]
        public string BidangUsahaName { get; set; }
    }

    [Table("RefJobType")]
    public class RefJobType
    {
        [Key]
        [Column("JobTypeId")]
        public string JobTypeId { get; set; }

        [Column("JobTypeName")]
        public string JobTypeName { get; set; }
    }

    [Table("RefGolonganNasabah")]
    public class RefGolonganNasabah
    {
        [Key]
        [Column("GolonganNasabahId")]
        public string GolonganNasabahId { get; set; }

        [Column("GolonganNasabahName")]
        public string GolonganNasabahName { get; set; }
    }

    [Table("RefHubunganBank")]
    public class RefHubunganBank
    {
        [Key]
        [Column("HubunganBankId")]
        public string HubunganBankId { get; set; }

        [Column("HubunganBankName")]
        public string HubunganBankName { get; set; }
    }

    [Table("RefLembagaRating")]
    public class RefLembagaRating
    {
        [Key]
        [Column("LembagaRatingId")]
        public string LembagaRatingId { get; set; }

        [Column("LembagaRatingName")]
        public string LembagaRatingName { get; set; }
    }
}
