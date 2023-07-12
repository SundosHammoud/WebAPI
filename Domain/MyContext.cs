using System;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Domain
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Manufacturer> Manufacturer {get; set;} 
        public DbSet<Machine> Machine {get; set;} 
        public DbSet<User> User {get; set;} 
        public DbSet<Role> Role {get; set;} 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
            .HasMany(e => e.Users)
            .WithOne(e => e.Role)
            .HasForeignKey(e => e.RoleID)
            .HasPrincipalKey(e => e.ID);
        }
    }
}