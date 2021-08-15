using EntityFrameworkPart_1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkPart_1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGenericRepository<Employee> context;
        public EmployeeController(IGenericRepository<Employee> context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.GetAll());
        }
        public IActionResult Details(int id)
        {
            return View(context.GetById(id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee newrec)
        {
            if (ModelState.IsValid)
            {
                context.Add(newrec);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newrec);
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(context.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Employee updaterec)
        {
            if (ModelState.IsValid)
            {
                context.Update(updaterec);
                return RedirectToAction("Index");
            }
            else
            {
                return View(updaterec);
            }

        }
        public IActionResult Delete(int id)
        {
            context.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
