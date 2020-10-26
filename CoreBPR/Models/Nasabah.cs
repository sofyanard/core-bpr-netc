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

        [Column("NasabahType")]
        [Required]
        [StringLength(1)]
        public string NasabahType { get; set; }

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
        // [DataType(DataType.Currency)]
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

    public class NasabahPerorangan
    {
        [Key]
        // [Required]
        [StringLength(20)]
        [Display(Name = "No Nasabah")]
        public string NasabahId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nama Lengkap")]
        public string NamaLengkap { get; set; }

        [StringLength(50)]
        [Display(Name = "Nama Sesuai Identitas")]
        public string NamaIdentity { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Gender")]
        public string GenderId { get; set; }

        [ForeignKey("GenderId")]
        public virtual RefGender RefGender { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Tempat Lahir")]
        public string TempatLahir { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Lahir")]
        public DateTime? TanggalLahir { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Alamat Rumah")]
        public string HomeAddress { get; set; }

        [StringLength(10)]
        [Display(Name = "Kode Pos")]
        public string HomeZipCode { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Propinsi")]
        public string HomePropinsiId { get; set; }

        [ForeignKey("HomePropinsiId")]
        public virtual RefProvince HomeRefProvince { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Kota/Kabupaten")]
        public string HomeKotaId { get; set; }

        [ForeignKey("HomeKotaId")]
        public virtual RefCity HomeRefCity { get; set; }

        [StringLength(50)]
        [Display(Name = "Kecamatan")]
        public string HomeKecamatan { get; set; }

        [StringLength(50)]
        [Display(Name = "Kelurahan")]
        public string HomeKelurahan { get; set; }

        [StringLength(10)]
        [Display(Name = "Status Rumah")]
        public string HomeStatusId { get; set; }

        [ForeignKey("HomeStatusId")]
        public virtual RefHomeStatus RefHomeStatus { get; set; }

        [StringLength(20)]
        [Display(Name = "Telepon Rumah")]
        public string HomePhone { get; set; }

        [StringLength(20)]
        [Display(Name = "Telepon Mobile")]
        public string MobilePhone { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nama Ibu Kandung")]
        public string NamaIbuKandung { get; set; }

        [StringLength(10)]
        [Display(Name = "Kewarganegaraan")]
        public string CitizenId { get; set; }

        [ForeignKey("CitizenId")]
        public virtual RefCitizen RefCitizen { get; set; }

        [StringLength(10)]
        [Display(Name = "Marital Status")]
        public string MaritalId { get; set; }

        [ForeignKey("MaritalId")]
        public virtual RefMarital RefMarital { get; set; }

        [StringLength(10)]
        [Display(Name = "Pendidikan")]
        public string EducationId { get; set; }

        [ForeignKey("EducationId")]
        public virtual RefEducation RefEducation { get; set; }

        [StringLength(10)]
        [Display(Name = "Jenis Identitas")]
        public string JenisIdentityId { get; set; }

        [ForeignKey("JenisIdentityId")]
        public virtual RefJenisIdentity RefJenisIdentity { get; set; }

        [StringLength(50)]
        [Display(Name = "No Identitas")]
        public string IdentityNo { get; set; }

        [StringLength(50)]
        [Display(Name = "No NPWP")]
        public string NPWPNo { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Tanggungan")]
        public int? Tanggungan { get; set; }

        [StringLength(10)]
        [Display(Name = "Kode Harta")]
        public string KodeHartaId { get; set; }

        [ForeignKey("KodeHartaId")]
        public virtual RefYesNo KodeHartaRefYesNo { get; set; }
    }

    public class NasabahBadanUsaha
    {
        [Key]
        // [Required]
        [StringLength(20)]
        [Display(Name = "No Nasabah")]
        public string NasabahId { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Jenis Badan Usaha")]
        public string JenisBadanUsahaId { get; set; }

        [ForeignKey("JenisBadanUsahaId")]
        public virtual RefJenisBadanUsaha RefJenisBadanUsaha { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nama Badan Usaha")]
        public string NamaLengkap { get; set; }

        [StringLength(10)]
        [Display(Name = "Tempat Pendirian")]
        public string TempatLahir { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Pendirian")]
        public DateTime? TanggalLahir { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Alamat Kantor")]
        public string OfficeAddress { get; set; }

        [StringLength(10)]
        [Display(Name = "Kode Pos")]
        public string OfficeZipCode { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Propinsi")]
        public string OfficePropinsiId { get; set; }

        [ForeignKey("OfficePropinsiId")]
        public virtual RefProvince OfficeRefProvince { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Kota/Kabupaten")]
        public string OfficeKotaId { get; set; }

        [ForeignKey("OfficeKotaId")]
        public virtual RefCity OfficeRefCity { get; set; }

        [StringLength(50)]
        [Display(Name = "Kecamatan")]
        public string OfficeKecamatan { get; set; }

        [StringLength(50)]
        [Display(Name = "Kelurahan")]
        public string OfficeKelurahan { get; set; }

        [StringLength(10)]
        [Display(Name = "Status Kantor")]
        public string OfficeStatusId { get; set; }

        [ForeignKey("OfficeStatusId")]
        public virtual RefHomeStatus OfficeRefHomeStatus { get; set; }

        [StringLength(20)]
        [Display(Name = "Telepon Kantor")]
        public string OfficePhone { get; set; }

        [StringLength(20)]
        [Display(Name = "Fax Kantor")]
        public string OfficeFax { get; set; }

        [StringLength(50)]
        [Display(Name = "No NPWP")]
        public string NPWPNo { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(10)]
        [Display(Name = "Bidang Usaha")]
        public string BidangUsahaId { get; set; }

        [ForeignKey("BidangUsahaId")]
        public virtual RefBidangUsaha RefBidangUsaha { get; set; }

        [StringLength(50)]
        [Display(Name = "No APP")]
        public string APPNo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Tanggal APP")]
        public DateTime? APPDate { get; set; }

        [StringLength(50)]
        [Display(Name = "No Perubahan APP")]
        public string APPChangeNo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Perubahan APP")]
        public DateTime? APPChangeDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Notaris")]
        public string Notaris { get; set; }

        [StringLength(50)]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
    }

    public class NasabahList
    {
        [Key]
        [Required]
        [StringLength(20)]
        [Display(Name = "No Nasabah")]
        public string NasabahId { get; set; }

        [Required]
        [StringLength(1)]
        public string NasabahType { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nama")]
        public string NamaLengkap { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Lahir/Pendirian")]
        public DateTime? TanggalLahir { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Alamat")]
        public string Address { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Kota/Kabupaten")]
        public string KotaId { get; set; }

        [ForeignKey("KotaId")]
        public virtual RefCity RefCity { get; set; }

        [StringLength(50)]
        [Display(Name = "No Identitas/APP")]
        public string IdentityNo { get; set; }

        [StringLength(50)]
        [Display(Name = "No NPWP")]
        public string NPWPNo { get; set; }

        public string Action { get; set; }
    }

    public class NasabahJobnSpouse
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "No Nasabah")]
        public string NasabahId { get; set; }

        [StringLength(10)]
        [Display(Name = "Pekerjaan")]
        public string JobTypeId { get; set; }

        [ForeignKey("JobTypeId")]
        public virtual RefJobType RefJobType { get; set; }

        [StringLength(50)]
        [Display(Name = "Tempat Bekerja")]
        public string TempatBekerja { get; set; }

        [StringLength(10)]
        [Display(Name = "Bidang Usaha")]
        public string BidangUsahaId { get; set; }

        [ForeignKey("BidangUsahaId")]
        public virtual RefBidangUsaha RefBidangUsaha { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Alamat Kantor")]
        public string OfficeAddress { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Propinsi")]
        public string OfficePropinsiId { get; set; }

        [ForeignKey("OfficePropinsiId")]
        public virtual RefProvince OfficeRefProvince { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Kota/Kabupaten")]
        public string OfficeKotaId { get; set; }

        [ForeignKey("OfficeKotaId")]
        public virtual RefCity OfficeRefCity { get; set; }

        [StringLength(50)]
        [Display(Name = "Kecamatan")]
        public string OfficeKecamatan { get; set; }

        [StringLength(50)]
        [Display(Name = "Kelurahan")]
        public string OfficeKelurahan { get; set; }

        [StringLength(10)]
        [Display(Name = "Kode Pos")]
        public string OfficeZipCode { get; set; }

        [StringLength(20)]
        [Display(Name = "Telepon Kantor")]
        public string OfficePhone { get; set; }

        [Column("Income")]
        // [DataType(DataType.Currency)]
        [Display(Name = "Pendapatan")]
        public double? Income { get; set; }

        [StringLength(50)]
        [Display(Name = "Nama Pasangan")]
        public string SpouseName { get; set; }

        [StringLength(50)]
        [Display(Name = "Tempat Lahir")]
        public string SpouseTempatLahir { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Lahir")]
        public DateTime? SpouseTanggalLahir { get; set; }

        [StringLength(10)]
        [Display(Name = "Jenis Identitas")]
        public string SpouseJenisIdentityId { get; set; }

        [ForeignKey("SpouseJenisIdentityId")]
        public virtual RefJenisIdentity SpouseRefJenisIdentity { get; set; }

        [StringLength(50)]
        [Display(Name = "No Identitas")]
        public string SpouseIdentityNo { get; set; }

        [StringLength(10)]
        [Display(Name = "Pekerjaan")]
        public string SpouseJobTypeId { get; set; }

        [ForeignKey("SpouseJobTypeId")]
        public virtual RefJobType SpouseRefJobType { get; set; }

        [StringLength(10)]
        [Display(Name = "Pendidikan")]
        public string SpouseEducationId { get; set; }

        [ForeignKey("SpouseEducationId")]
        public virtual RefEducation SpouseRefEducation { get; set; }
    }

    public class NasabahLaporPerorangan
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "No Nasabah")]
        public string NasabahId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nama Pelaporan")]
        public string NamaPelaporan { get; set; }

        [StringLength(10)]
        [Display(Name = "Golongan Nasabah")]
        public string GolonganNasabahId { get; set; }

        [ForeignKey("GolonganNasabahId")]
        public virtual RefGolonganNasabah RefGolonganNasabah { get; set; }

        [StringLength(10)]
        [Display(Name = "Hubungan Dengan Bank")]
        public string HubunganBankId { get; set; }

        [ForeignKey("HubunganBankId")]
        public virtual RefHubunganBank RefHubunganBank { get; set; }

        [StringLength(10)]
        [Display(Name = "Sumber Penghasilan")]
        public string SourceIncomeId { get; set; }

        [ForeignKey("SourceIncomeId")]
        public virtual RefSourceIncome RefSourceIncome { get; set; }

        [StringLength(10)]
        [Display(Name = "BMPK Lebih")]
        public string BMPKLebih { get; set; }

        [ForeignKey("BMPKLebih")]
        public virtual RefYesNo BMPKLebihRefYesNo { get; set; }

        [StringLength(10)]
        [Display(Name = "BMPK Lampaui")]
        public string BMPKLampaui { get; set; }

        [ForeignKey("BMPKLampaui")]
        public virtual RefYesNo BMPKLampauiRefYesNo { get; set; }
    }

    public class NasabahLaporBadanUsaha
    {
        [Key]
        [StringLength(20)]
        [Display(Name = "No Nasabah")]
        public string NasabahId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nama Pelaporan")]
        public string NamaPelaporan { get; set; }

        [StringLength(10)]
        [Display(Name = "Golongan Nasabah")]
        public string GolonganNasabahId { get; set; }

        [ForeignKey("GolonganNasabahId")]
        public virtual RefGolonganNasabah RefGolonganNasabah { get; set; }

        [StringLength(10)]
        [Display(Name = "Hubungan Dengan Bank")]
        public string HubunganBankId { get; set; }

        [ForeignKey("HubunganBankId")]
        public virtual RefHubunganBank RefHubunganBank { get; set; }

        [StringLength(10)]
        [Display(Name = "Sumber Penghasilan")]
        public string SourceIncomeId { get; set; }

        [ForeignKey("SourceIncomeId")]
        public virtual RefSourceIncome RefSourceIncome { get; set; }

        [StringLength(10)]
        [Display(Name = "BMPK Lebih")]
        public string BMPKLebih { get; set; }

        [ForeignKey("BMPKLebih")]
        public virtual RefYesNo BMPKLebihRefYesNo { get; set; }

        [StringLength(10)]
        [Display(Name = "BMPK Lampaui")]
        public string BMPKLampaui { get; set; }

        [ForeignKey("BMPKLampaui")]
        public virtual RefYesNo BMPKLampauiRefYesNo { get; set; }

        [StringLength(10)]
        [Display(Name = "Go Public")]
        public string GoPublic { get; set; }

        [ForeignKey("GoPublic")]
        public virtual RefYesNo GoPublicRefYesNo { get; set; }

        [StringLength(10)]
        [Display(Name = "Rating")]
        public string Peringkat { get; set; }

        [StringLength(10)]
        [Display(Name = "Lembaga Rating")]
        public string LembagaRatingId { get; set; }

        [ForeignKey("LembagaRatingId")]
        public virtual RefLembagaRating RefLembagaRating { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Rating")]
        public DateTime? TanggalRating { get; set; }

        [StringLength(50)]
        [Display(Name = "Group Usaha")]
        public string GroupUsaha { get; set; }
    }
}
