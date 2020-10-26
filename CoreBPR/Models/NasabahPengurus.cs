using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBPR.Models
{
    [Table("NasabahPengurus")]
    public class NasabahPengurus
    {
        [Key]
        [Column("PengurusId")]
        public int PengurusId { get; set; }

        [Column("NasabahId")]
        public string NasabahId { get; set; }

        [Column("PengurusName")]
        [Required]
        [StringLength(50)]
        [Display(Name = "Nama")]
        public string PengurusName { get; set; }

        [Column("GenderPlusId")]
        [StringLength(10)]
        [Display(Name = "Gender")]
        public string GenderPlusId { get; set; }

        [ForeignKey("GenderPlusId")]
        public virtual RefGenderPlus RefGenderPlus { get; set; }

        [Column("JabatanId")]
        [StringLength(10)]
        [Display(Name = "Jabatan")]
        public string JabatanId { get; set; }

        [ForeignKey("JabatanId")]
        public virtual RefJabatan RefJabatan { get; set; }

        [Column("PercentSaham")]
        [Display(Name = "Persen Saham")]
        public double? PercentSaham { get; set; }

        [Column("JenisIdentityId")]
        [StringLength(10)]
        [Display(Name = "Jenis Identitas")]
        public string JenisIdentityId { get; set; }

        [ForeignKey("JenisIdentityId")]
        public virtual RefJenisIdentity RefJenisIdentity { get; set; }

        [Column("IdentityNo")]
        [StringLength(50)]
        [Display(Name = "No Identitas")]
        public string IdentityNo { get; set; }

        [Column("Address")]
        [StringLength(100)]
        [Display(Name = "Alamat")]
        public string Address { get; set; }

        [Column("ZipCode")]
        [StringLength(10)]
        [Display(Name = "Kode Pos")]
        public string ZipCode { get; set; }

        [Column("PropinsiId")]
        [StringLength(10)]
        [Display(Name = "Propinsi")]
        public string PropinsiId { get; set; }

        [ForeignKey("PropinsiId")]
        public virtual RefProvince RefProvince { get; set; }

        [Column("KotaId")]
        [StringLength(10)]
        [Display(Name = "Kota/Kabupaten")]
        public string KotaId { get; set; }

        [ForeignKey("KotaId")]
        public virtual RefCity RefCity { get; set; }

        [Column("Kecamatan")]
        [StringLength(50)]
        public string Kecamatan { get; set; }

        [Column("Kelurahan")]
        [StringLength(50)]
        public string Kelurahan { get; set; }

        [Column("IsActive")]
        [StringLength(1)]
        [Display(Name = "Active")]
        public string IsActive { get; set; }
    }
}
