using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tarefa>().HasKey(t => t.Id);
            modelBuilder.Entity<Tarefa>().HasOne(t => t.Lista);


            modelBuilder.Entity<Lista>().HasKey(t => t.Id);
            modelBuilder.Entity<Lista>().HasMany(t => t.Tarefas).WithOne(t => t.Lista);
        }
    }
}
