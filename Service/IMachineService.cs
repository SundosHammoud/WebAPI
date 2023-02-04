using System;
using WebAPI.Domain;
using System.Collections.Generic;
using WebAPI.Application.Models;

namespace WebAPI.Service
{
    public interface IMachineService    
    {

        List<MachineModel> getAll();
        MachineModel getByID(int ID);
        MachineModel add(MachineModel Machine);
        MachineModel update(MachineModel Machine);
        void delete(int ID);
    }
}