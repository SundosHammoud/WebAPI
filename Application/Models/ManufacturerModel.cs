using System;
using System.Collections.Generic;

namespace WebAPI.Application.Models
{
    public class ManufacturerModel
    {        
        public int ID {get; set;}

        public string Name {get; set;}
        
        public string Location {get; set;}

        public List<MachineModel> Machines {get; set;}
    }
}