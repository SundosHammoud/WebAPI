using System;
using WebAPI.Domain;
using System.Collections.Generic;

namespace WebAPI.Infrastructure
{
    public interface IMachineRepository    
    {

        List<Machine> getAll();
        Machine getByID(int ID);
        Machine add(Machine machine);
        Machine update(Machine machine);
        void delete(int ID);

        
    }
}