using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace MyRentKit.Models
{
    public class Equipment
    {
        public int ID { get; set; }

        [StringLength(33, MinimumLength=3)]
        public string Title { get; set; }
        public string Category { get; set; }

        [Range(1,900)]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Required]
        [StringLength(28)]
        public string State { get; set; }
    }

    public class EquipmentDBContext : DbContext
    {
        public DbSet<Equipment> Equipments {get; set;}

    }

}