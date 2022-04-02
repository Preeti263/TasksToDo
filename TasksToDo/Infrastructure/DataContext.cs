using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksToDo.Models;

namespace TasksToDo.Infrastructure
{
public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Users> Users { get; set; }

    public DbSet<Models.TaskToDo> Tasks { get; set; }
   
        protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Users>()
           
            .HasData(
                new Users {UserId = 111, Pwd = "Pwd101"},
                new Users {UserId = 222, Pwd = "Pwd102"},
                new Users {UserId = 333, Pwd = "Pwd103"}
            );
        builder.Entity<TaskToDo>()
            .HasNoKey();


    }
}
}

    

