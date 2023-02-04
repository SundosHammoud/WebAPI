using System;
using WebAPI.Domain;
using System.Collections.Generic;
using WebAPI.Application.Models;

namespace WebAPI.Service
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