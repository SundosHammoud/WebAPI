using System;

namespace WebAPI.Application.Models
{
    public class MachineModel
    {      
        public int ID {get; set;}

        public string Name {get; set;}
        
        public double Price {get; set;}

        public DateTime? LastMaintenance {get; set;}        
           
        public int ManufacturerID {get; set;}

        public ManufacturerModel Manufacturer {get; set;}
    }
}