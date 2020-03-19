using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.EF
{
    public class TodoContext : DbContext
    {
        //Model Names
        public DbSet<Todo.EF.Models.Todo> Todo { get; set; }
        public DbSet<Todo.EF.Models.User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Todo;Integrated Security=true");
            }
        }
    }
}
