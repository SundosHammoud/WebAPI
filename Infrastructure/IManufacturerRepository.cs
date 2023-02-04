using System;
using ceconsoftAPI.Domain;
using System.Collections.Generic;

namespace ceconsoftAPI.Infrastructure
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