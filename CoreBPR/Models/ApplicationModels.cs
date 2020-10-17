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

    [Table("RefMenu")]
    public class RefMenu
    {
        [Key]
        [Column("MenuId")]
        public string MenuId { get; set; }

        [Column("MenuName")]
        public string MenuName { get; set; }

        [Column("Level")]
        public int Level { get; set; }

        [Column("Parent")]
        public string Parent { get; set; }

        [ForeignKey("Parent")]
        public virtual RefMenu ParentRefMenu { get; set; }

        [Column("Controller")]
        public string Controller { get; set; }

        [Column("Action")]
        public string Action { get; set; }

        [Column("Param")]
        public string Param { get; set; }
    }

    [Table("RefGroupMenu")]
    public class RefGroupMenu
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("GroupId")]
        public string GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual RefGroup RefGroup { get; set; }

        [Column("MenuId")]
        public string MenuId { get; set; }

        [ForeignKey("MenuId")]
        public virtual RefMenu RefMenu { get; set; }
    }

    public class ApplicationMenuChild
    {
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Param { get; set; }
    }

    public class ApplicationMenu
    {
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public List<ApplicationMenuChild> Children { get; set; }

        public ApplicationMenu()
        {
            this.Children = new List<ApplicationMenuChild>();
        }
    }
}
