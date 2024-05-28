using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCreateStrategyApp
{
    public class PersonAppContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-ISC66B9\\MSSQLSERVER2022;Initial Catalog=persons;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TPH table per hierarchy
            // modelBuilder.Entity<Person>().UseTphMappingStrategy();

            // TPT table per type
            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<Admin>().ToTable("Admins");
            //modelBuilder.Entity<Guest>().ToTable("Guests");
            //modelBuilder.Entity<Person>().UseTptMappingStrategy();

            // TPC table per class
            modelBuilder.Entity<Person>().UseTpcMappingStrategy();
        }
    }
}
