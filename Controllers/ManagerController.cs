using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class ManagerController : Controller
    {
        private ManagerContext context { get; set; }

        public ManagerController(ManagerContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Action = "Details";
            ViewBag.Categories = context.Categories.OrderBy(g => g.CategoryName).ToList();
            var manager = context.Managers.Find(id);
            return View("Detail", manager);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(g => g.CategoryName).ToList();
            return View("Edit", new Manager());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(g => g.CategoryName).ToList();
            var manager = context.Managers.Find(id);
            return View("Edit", manager);
        }

        [HttpPost]
        public IActionResult Edit(Manager manager)
        {
            if (ModelState.IsValid){ 
                if(manager.ManagerId == 0)
                {
                    context.Managers.Add(manager);
                } else
                {
                    context.Managers.Update(manager);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            } else
            {
                ViewBag.Categories = context.Categories.OrderBy(g => g.CategoryName).ToList();
                ViewBag.Action = (manager.ManagerId == 0 ? "Add" : "Edit");
                return View(manager);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var manager = context.Managers.Find(id);
            ViewBag.Action = "Delete";
            return View(manager);
        }

        [HttpPost]
        public IActionResult Delete(Manager manager)
        {
            context.Managers.Remove(manager);
            context.SaveChanges();
            ViewBag.Action = "Delete";
            return RedirectToAction("Index", "Home");
        }
    }
}
