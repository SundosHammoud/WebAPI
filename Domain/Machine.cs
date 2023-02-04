using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Domain
{
    public class Machine
    {
        [Key]
        public int ID {get; set;}

        [StringLength(50)]
        public string Name {get; set;}
        
        public double Price {get; set;}

        public DateTime? LastMaintenance {get; set;}
        
        [ForeignKey("Manufacturer")]    
        public int ManufacturerID {get; set;}
        public Manufacturer Manufacturer {get; set;}
    }
}