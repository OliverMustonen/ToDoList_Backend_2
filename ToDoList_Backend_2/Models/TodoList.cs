using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList_Backend_2.Models
{
    public class TodoList
    {
        
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

    }
}
