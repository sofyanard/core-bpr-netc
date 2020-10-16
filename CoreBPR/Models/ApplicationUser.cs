using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBPR.Models
{
    [Table("RefUser")]
    public class ApplicationUser
    {
        [Key]
        [Column("UserId")]
        [Required]
        [StringLength(20)]
        public string UserId { get; set; }

        [Column("FullName")]
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("GroupId")]
        public string GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual RefGroup RefGroup { get; set; }

        [Column("UnitId")]
        public string UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual RefUnit RefUnit { get; set; }

        [Column("Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column("Phone")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Column("ApprovalLimit")]
        public double? ApprovalLimit { get; set; }

        [Column("RekBukuBesar")]
        [StringLength(20)]
        public string RekBukuBesar { get; set; }

        [Column("IsActive")]
        [StringLength(1)]
        public string IsActive { get; set; }

        [Column("IsLogon")]
        [StringLength(1)]
        public string IsLogon { get; set; }

        [Column("IsRevoke")]
        [StringLength(1)]
        public string IsRevoke { get; set; }

        [Column("FalsePwdCount")]
        public int FalsePwdCount { get; set; }

        [Column("CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        [Column("CreatedBy")]
        [StringLength(20)]
        public string CreatedBy { get; set; }

        [Column("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }

        [Column("UpdatedBy")]
        [StringLength(20)]
        public string UpdatedBy { get; set; }

        [Column("ExpiredDate")]
        public DateTime? ExpiredDate { get; set; }

        [Column("LastLoginDate")]
        public DateTime? LastLoginDate { get; set; }

        [Column("LastLoginHost")]
        [StringLength(50)]
        public string LastLoginHost { get; set; }
    }

    public class ApplicationUserCreateModel
    {
        [Key]
        [Column("UserId")]
        [Required]
        [StringLength(20)]
        public string UserId { get; set; }

        [Column("FullName")]
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Column("GroupId")]
        [Required]
        public string GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual RefGroup RefGroup { get; set; }

        [Column("UnitId")]
        [Required]
        public string UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual RefUnit RefUnit { get; set; }

        [Column("Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column("Phone")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Column("ApprovalLimit")]
        public double? ApprovalLimit { get; set; }

        [Column("RekBukuBesar")]
        [StringLength(20)]
        public string RekBukuBesar { get; set; }
    }
}
