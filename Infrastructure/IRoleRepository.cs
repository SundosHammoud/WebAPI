using System;
using WebAPI.Domain;
using System.Collections.Generic;

namespace WebAPI.Infrastructure
{
    public interface IRoleRepository    
    {

        List<Role> getAll();
        Role getByID(int ID);
        Role add(Role Role);
        Role update(Role Role);
        void delete(int ID);
        
    }
}