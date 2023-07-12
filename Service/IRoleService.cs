using System;
using WebAPI.Domain;
using System.Collections.Generic;
using WebAPI.Application.Models;

namespace WebAPI.Service
{
    public interface IRoleService    
    {

        List<RoleModel> getAll();
        RoleModel getByID(int ID);
        RoleModel add(RoleModel user);
        RoleModel update(RoleModel user);
        void delete(int ID);
    }
}