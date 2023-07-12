using System;
using WebAPI.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Infrastructure
{
    public class RoleRepository: IRoleRepository    
    {
        private readonly MyContext _context;

        public RoleRepository(MyContext context)
        {
            _context = context;
        }

        public List<Role> getAll()
        {
            return _context.Role.Include(x => x.Users).ToList();
        }

        public Role getByID(int ID)
        {
            var role = _context.Role
                                    .Include(x => x.Users)
                                    .FirstOrDefault(x => x.ID == ID);

            if(role == null)
                throw new Exception("role not found");
            
            return role;
        }

        public Role add(Role role)
        {
            Role duplicatedRole = _context.Role.FirstOrDefault(x => x.Name.ToLower() == role.Name.ToLower());
            if(duplicatedRole != null)
                throw new Exception("duplicated role");
            _context.Role.Add(role);
            _context.SaveChanges();
            return role;
        }

        public Role update(Role role)
        {
            Role duplicatedRole = _context.Role.FirstOrDefault(x => x.ID != role.ID && x.Name.ToLower() == role.Name.ToLower());
            if(duplicatedRole != null)
                throw new Exception("duplicated role");

            var oldEntity = getByID(role.ID);    
            _context.Entry(oldEntity).CurrentValues.SetValues(role);
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