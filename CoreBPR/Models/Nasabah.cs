using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBPR.Models
{
    [Table("Nasabah")]
    public class Nasabah
    {
        [Key]
        [Column("NasabahId")]
        [Required]
        [StringLength(20)]
        public string NasabahId { get; set; }

        [Column("NamaLengkap")]
        [Required]
        [StringLength(50)]
        public string NamaLengkap { get; set; }

        [Column("NamaIdentity")]
        [StringLength(50)]
        public string NamaIdentity { get; set; }

        [Column("GenderId")]
        [StringLength(10)]
        public string GenderId { get; set; }

        [ForeignKey("GenderId")]
        public virtual RefGender RefGender { get; set; }

        [Column("TempatLahir")]
        [StringLength(10)]
        public string TempatLahir { get; set; }

        [Column("TanggalLahir")]
        [DataType(DataType.Date)]
        public DateTime? TanggalLahir { get; set; }

        [Column("HomeAddress")]
        [StringLength(100)]
        public string HomeAddress { get; set; }

        [Column("HomeZipCode")]
        [StringLength(10)]
        public string HomeZipCode { get; set; }

        [Column("HomePropinsiId")]
        [StringLength(10)]
        public string HomePropinsiId { get; set; }

        [ForeignKey("HomePropinsiId")]
        public virtual RefProvince HomeRefProvince { get; set; }

        [Column("HomeKotaId")]
        [StringLength(10)]
        public string HomeKotaId { get; set; }

        [ForeignKey("HomeKotaId")]
        public virtual RefCity HomeRefCity { get; set; }

        [Column("HomeKecamatan")]
        [StringLength(50)]
        public string HomeKecamatan { get; set; }

        [Column("HomeKelurahan")]
        [StringLength(50)]
        public string HomeKelurahan { get; set; }

        [Column("HomeStatusId")]
        [StringLength(10)]
        public string HomeStatusId { get; set; }

        [ForeignKey("HomeStatusId")]
        public virtual RefHomeStatus RefHomeStatus { get; set; }

        [Column("HomePhone")]
        [StringLength(20)]
        public string HomePhone { get; set; }

        [Column("MobilePhone")]
        [StringLength(20)]
        public string MobilePhone { get; set; }

        [Column("NamaIbuKandung")]
        [StringLength(50)]
        public string NamaIbuKandung { get; set; }

        [Column("CitizenId")]
        [StringLength(10)]
        public string CitizenId { get; set; }

        [ForeignKey("CitizenId")]
        public virtual RefCitizen RefCitizen { get; set; }

        [Column("MaritalId")]
        [StringLength(10)]
        public string MaritalId { get; set; }

        [ForeignKey("MaritalId")]
        public virtual RefMarital RefMarital { get; set; }

        [Column("EducationId")]
        [StringLength(10)]
        public string EducationId { get; set; }

        [ForeignKey("EducationId")]
        public virtual RefEducation RefEducation { get; set; }

        [Column("JenisIdentityId")]
        [StringLength(10)]
        public string JenisIdentityId { get; set; }

        [ForeignKey("JenisIdentityId")]
        public virtual RefJenisIdentity RefJenisIdentity { get; set; }

        [Column("IdentityNo")]
        [StringLength(50)]
        public string IdentityNo { get; set; }

        [Column("NPWPNo")]
        [StringLength(50)]
        public string NPWPNo { get; set; }

        [Column("Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column("Tanggungan")]
        public int? Tanggungan { get; set; }

        [Column("KodeHartaId")]
        [StringLength(10)]
        public string KodeHartaId { get; set; }

        [ForeignKey("KodeHartaId")]
        public virtual RefYesNo KodeHartaRefYesNo { get; set; }

        [Column("JenisBadanUsahaId")]
        [StringLength(10)]
        public string JenisBadanUsahaId { get; set; }

        [ForeignKey("JenisBadanUsahaId")]
        public virtual RefJenisBadanUsaha RefJenisBadanUsaha { get; set; }

        [Column("BidangUsahaId")]
        [StringLength(10)]
        public string BidangUsahaId { get; set; }

        [ForeignKey("BidangUsahaId")]
        public virtual RefBidangUsaha RefBidangUsaha { get; set; }

        [Column("APPNo")]
        [StringLength(50)]
        public string APPNo { get; set; }

        [Column("APPDate")]
        [DataType(DataType.Date)]
        public DateTime? APPDate { get; set; }

        [Column("APPChangeNo")]
        [StringLength(50)]
        public string APPChangeNo { get; set; }

        [Column("APPChangeDate")]
        [DataType(DataType.Date)]
        public DateTime? APPChangeDate { get; set; }

        [Column("Notaris")]
        [StringLength(50)]
        public string Notaris { get; set; }

        [Column("OfficeAddress")]
        [StringLength(100)]
        public string OfficeAddress { get; set; }

        [Column("OfficeZipCode")]
        [StringLength(10)]
        public string OfficeZipCode { get; set; }

        [Column("OfficePropinsiId")]
        [StringLength(10)]
        public string OfficePropinsiId { get; set; }

        [ForeignKey("OfficePropinsiId")]
        public virtual RefProvince OfficeRefProvince { get; set; }

        [Column("OfficeKotaId")]
        [StringLength(10)]
        public string OfficeKotaId { get; set; }

        [ForeignKey("OfficeKotaId")]
        public virtual RefCity OfficeRefCity { get; set; }

        [Column("OfficeKecamatan")]
        [StringLength(50)]
        public string OfficeKecamatan { get; set; }

        [Column("OfficeKelurahan")]
        [StringLength(50)]
        public string OfficeKelurahan { get; set; }

        [Column("OfficePhone")]
        [StringLength(20)]
        public string OfficePhone { get; set; }

        [Column("OfficeFax")]
        [StringLength(20)]
        public string OfficeFax { get; set; }

        [Column("OfficeStatusId")]
        [StringLength(10)]
        public string OfficeStatusId { get; set; }

        [ForeignKey("OfficeStatusId")]
        public virtual RefHomeStatus OfficeRefHomeStatus { get; set; }

        [Column("ContactPerson")]
        [StringLength(50)]
        public string ContactPerson { get; set; }

        [Column("JobTypeId")]
        [StringLength(10)]
        public string JobTypeId { get; set; }

        [ForeignKey("JobTypeId")]
        public virtual RefJobType RefJobType { get; set; }

        [Column("TempatBekerja")]
        [StringLength(50)]
        public string TempatBekerja { get; set; }

        [Column("Income")]
        [DataType(DataType.Currency)]
        public double? Income { get; set; }

        [Column("SpouseName")]
        [StringLength(50)]
        public string SpouseName { get; set; }

        [Column("SpouseTempatLahir")]
        [StringLength(50)]
        public string SpouseTempatLahir { get; set; }

        [Column("SpouseTanggalLahir")]
        [DataType(DataType.Date)]
        public DateTime? SpouseTanggalLahir { get; set; }

        [Column("SpouseJenisIdentityId")]
        [StringLength(10)]
        public string SpouseJenisIdentityId { get; set; }

        [ForeignKey("SpouseJenisIdentityId")]
        public virtual RefJenisIdentity SpouseRefJenisIdentity { get; set; }

        [Column("SpouseIdentityNo")]
        [StringLength(50)]
        public string SpouseIdentityNo { get; set; }

        [Column("SpouseJobTypeId")]
        [StringLength(10)]
        public string SpouseJobTypeId { get; set; }

        [ForeignKey("SpouseJobTypeId")]
        public virtual RefJobType SpouseRefJobType { get; set; }

        [Column("SpouseEducationId")]
        [StringLength(10)]
        public string SpouseEducationId { get; set; }

        [ForeignKey("SpouseEducationId")]
        public virtual RefEducation SpouseRefEducation { get; set; }

        [Column("NamaPelaporan")]
        [StringLength(50)]
        public string NamaPelaporan { get; set; }

        [Column("SourceIncomeId")]
        [StringLength(10)]
        public string SourceIncomeId { get; set; }

        [ForeignKey("SourceIncomeId")]
        public virtual RefSourceIncome RefSourceIncome { get; set; }

        [Column("GolonganNasabahId")]
        [StringLength(10)]
        public string GolonganNasabahId { get; set; }

        [ForeignKey("GolonganNasabahId")]
        public virtual RefGolonganNasabah RefGolonganNasabah { get; set; }

        [Column("HubunganBankId")]
        [StringLength(10)]
        public string HubunganBankId { get; set; }

        [ForeignKey("HubunganBankId")]
        public virtual RefHubunganBank RefHubunganBank { get; set; }

        [Column("BMPKLebih")]
        [StringLength(10)]
        public string BMPKLebih { get; set; }

        [ForeignKey("BMPKLebih")]
        public virtual RefYesNo BMPKLebihRefYesNo { get; set; }

        [Column("BMPKLampaui")]
        [StringLength(10)]
        public string BMPKLampaui { get; set; }

        [ForeignKey("BMPKLampaui")]
        public virtual RefYesNo BMPKLampauiRefYesNo { get; set; }

        [Column("GoPublic")]
        [StringLength(10)]
        public string GoPublic { get; set; }

        [ForeignKey("GoPublic")]
        public virtual RefYesNo GoPublicRefYesNo { get; set; }

        [Column("Peringkat")]
        [StringLength(10)]
        public string Peringkat { get; set; }

        [Column("LembagaRatingId")]
        [StringLength(10)]
        public string LembagaRatingId { get; set; }

        [ForeignKey("LembagaRatingId")]
        public virtual RefLembagaRating RefLembagaRating { get; set; }

        [Column("TanggalRating")]
        [DataType(DataType.Date)]
        public DateTime? TanggalRating { get; set; }

        [Column("GroupUsaha")]
        [StringLength(50)]
        public string GroupUsaha { get; set; }

        [Column("CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        [Column("CreatedUnitId")]
        [StringLength(20)]
        public string CreatedUnitId { get; set; }

        [Column("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }

        [Column("UpdatedUserId")]
        [StringLength(20)]
        public string UpdatedUserId { get; set; }
    }
}
