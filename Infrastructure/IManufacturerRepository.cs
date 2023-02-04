using System;
using WebAPI.Domain;
using System.Collections.Generic;

namespace WebAPI.Infrastructure
{
    public interface IManufacturerRepository    
    {

        List<Manufacturer> getAll();
        Manufacturer getByID(int ID);
        Manufacturer add(Manufacturer manufacturer);
        Manufacturer update(Manufacturer manufacturer);
        void delete(int ID);

        
    }
}