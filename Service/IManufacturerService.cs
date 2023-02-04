using System;
using ceconsoftAPI.Domain;
using System.Collections.Generic;
using ceconsoftAPI.Application.Models;

namespace ceconsoftAPI.Service
{
    public interface IManufacturerService    
    {

        List<ManufacturerModel> getAll();
        ManufacturerModel getByID(int ID);
        ManufacturerModel add(ManufacturerModel manufacturer);
        ManufacturerModel update(ManufacturerModel manufacturer);
        void delete(int ID);
    }
}