using System;
using WebAPI.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Infrastructure
{
    public class MachineRepository: IMachineRepository    
    {
        private readonly MyContext _context;

        public MachineRepository(MyContext context)
        {
            _context = context;
        }

        public List<Machine> getAll()
        {
            return _context.Machine.ToList();
        }

        public Machine getByID(int ID)
        {
            var machine = _context.Machine
                                    .Include(x => x.Manufacturer)
                                    .FirstOrDefault(x => x.ID == ID);

            if(machine == null)
                throw new Exception("Machine not found");
            
            return machine;
        }

        public Machine add(Machine machine)
        {
            _context.Machine.Add(machine);
            _context.SaveChanges();
            return machine;
        }

        public Machine update(Machine machine)
        {
            var oldEntity = getByID(machine.ID);    
            _context.Entry(oldEntity).CurrentValues.SetValues(machine);
            _context.SaveChanges();
            return oldEntity;

        }

        public void delete(int ID)
        {
            var oldEntity = getByID(ID);             
            _context.Remove(oldEntity);
            _context.SaveChanges();
        }
    }
}