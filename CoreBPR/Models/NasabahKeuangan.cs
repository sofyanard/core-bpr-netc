using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBPR.Models
{
    [Table("NasabahKeuangan")]
    public class NasabahKeuangan
    {
        [Key]
        [Column("KeuanganId")]
        public int KeuanganId { get; set; }

        [Column("NasabahId")]
        public string NasabahId { get; set; }

        [Required]
        [Column("Periode")]
        [DataType(DataType.Date)]
        [Display(Name = "Periode")]
        public DateTime Periode { get; set; }

        [Column("Kas")]
        [Display(Name = "Kas")]
        public double? Kas { get; set; }

        [Column("Piutang")]
        [Display(Name = "Piutang")]
        public double? Piutang { get; set; }

        [Column("Investasi")]
        [Display(Name = "Investasi")]
        public double? Investasi { get; set; }

        [Column("AsetLancarLain")]
        [Display(Name = "Aset Lancar Lain")]
        public double? AsetLancarLain { get; set; }

        [Column("AsetTidakLancar")]
        [Display(Name = "Aset Non Lancar Lain")]
        public double? AsetTidakLancar { get; set; }

        [Column("PinjamanPendek")]
        [Display(Name = "Pinjaman Jangka Pendek")]
        public double? PinjamanPendek { get; set; }

        [Column("UtangUsahaPendek")]
        [Display(Name = "Utang Usaha Jangka Pendek")]
        public double? UtangUsahaPendek { get; set; }

        [Column("LiabilitasPendekLain")]
        [Display(Name = "Liabilitas Jangka Pendek Lain")]
        public double? LiabilitasPendekLain { get; set; }

        [Column("PinjamanPanjang")]
        [Display(Name = "Pinjaman Jangka Panjang")]
        public double? PinjamanPanjang { get; set; }

        [Column("UtangUsahaPanjang")]
        [Display(Name = "Utang Usaha Jangka Panjang")]
        public double? UtangUsahaPanjang { get; set; }

        [Column("LiabilitasPanjangLain")]
        [Display(Name = "Liabilitas Jangka Panjang Lain")]
        public double? LiabilitasPanjangLain { get; set; }

        [Column("Modal")]
        [Display(Name = "Modal")]
        public double? Modal { get; set; }

        [Column("PendapatanOperasi")]
        [Display(Name = "Pendapatan Operasional")]
        public double? PendapatanOperasi { get; set; }

        [Column("BebanOperasi")]
        [Display(Name = "Beban Operasional")]
        public double? BebanOperasi { get; set; }

        [Column("PendapatanNonOperasi")]
        [Display(Name = "Pendapatan Non Operasional")]
        public double? PendapatanNonOperasi { get; set; }

        [Column("BebanNonOperasi")]
        [Display(Name = "Beban Non Operasional")]
        public double? BebanNonOperasi { get; set; }

        [Column("LabaBruto")]
        [Display(Name = "Laba Bruto")]
        public double? LabaBruto { get; set; }

        [Column("LabaSebelumPajak")]
        [Display(Name = "Laba Sebelum Pajak")]
        public double? LabaSebelumPajak { get; set; }

        [Column("LabaTahunBerjalan")]
        [Display(Name = "Laba Tahun Berjalan")]
        public double? LabaTahunBerjalan { get; set; }
    }
}
