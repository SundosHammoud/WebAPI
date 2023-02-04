using System;
using Microsoft.EntityFrameworkCore;

namespace ceconsoftAPI.Domain
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Manufacturer> Manufacturer {get; set;} 
        public DbSet<Machine> Machine {get; set;} 
    }
}