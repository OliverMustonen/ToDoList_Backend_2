using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList_Backend_2.Infrastructure;
using ToDoList_Backend_2.Models;

namespace ToDoList_Backend_2.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext context;

        public ToDoController(ToDoContext context)
        {
            this.context = context;
        }

        //GET /
        public async Task<ActionResult> Index()
        {
            IQueryable<TodoList> items = from i in context.ToDoList orderby i.Id select i;

            List<TodoList> todoList = await items.ToListAsync();

            return View(todoList);
        }

        // GET /todo/create /
        public IActionResult Create() => View();

        // POST /todo/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TodoList item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The todo has been added!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        //GET /todo/edit/
        public async Task<ActionResult> Edit(int id)
        {
            TodoList item = await context.ToDoList.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST /todo/edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TodoList item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The todo has been updated!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        //GET /todo/delete/
        public async Task<ActionResult> Delete(int id)
        {
            TodoList item = await context.ToDoList.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The todo does not exist!";
            }
            
            else
            {
                context.ToDoList.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The todo has been deleted!";
            }
            return RedirectToAction("Index");
        }

        //GET /Details
        public async Task<ActionResult> Details(int id)
        {
            TodoList item = await context.ToDoList.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
    }
}
