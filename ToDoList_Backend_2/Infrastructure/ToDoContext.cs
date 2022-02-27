using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList_Backend_2.Models;

namespace ToDoList_Backend_2.Infrastructure
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            :base(options)
        {

        }

        public DbSet<TodoList> ToDoList { get; set; }
    }
}
