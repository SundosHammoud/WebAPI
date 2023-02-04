using System;
using WebAPI.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Infrastructure
{
    public class ManufacturerRepository: IManufacturerRepository    
    {
        private readonly MyContext _context;

        public ManufacturerRepository(MyContext context)
        {
            _context = context;
        }

        public List<Manufacturer> getAll()
        {
            return _context.Manufacturer.ToList();
        }

        public Manufacturer getByID(int ID)
        {
            var manufacturer = _context.Manufacturer
                                    .Include(x => x.Machines)
                                    .FirstOrDefault(x => x.ID == ID);

            if(manufacturer == null)
                throw new Exception("Manufacturer not found");
            
            return manufacturer;
        }

        public Manufacturer add(Manufacturer manufacturer)
        {
            _context.Manufacturer.Add(manufacturer);
            _context.SaveChanges();
            return manufacturer;
        }

        public Manufacturer update(Manufacturer manufacturer)
        {
            var oldEntity = getByID(manufacturer.ID);    
            _context.Entry(oldEntity).CurrentValues.SetValues(manufacturer);
            _context.SaveChanges();
            return oldEntity;

        }

        public void delete(int ID)
        {
            var oldEntity = getByID(ID); 
            if(oldEntity.Machines.Count > 0)
                throw new Exception("This manufacturer has machines, please delete the machines first"); 
            
            _context.Remove(oldEntity);
            _context.SaveChanges();
        }

        
    }
}