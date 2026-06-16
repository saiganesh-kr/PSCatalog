using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClassRegistration.Models;

namespace ClassRegistration.Controllers
{
    public class ClassController : Controller
    {
        private ClassContext context { get; set; }

        public ClassController(ClassContext ctx) => context = ctx;

        private void LoadDepartments(string? selected = null)
        {
            ViewBag.Departments = new SelectList(
                new[] { "Computer Science", "Health Informatica", "Match", "Chemistry" },
                selected);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            LoadDepartments();
            return View("Edit", new GSUClass());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var gsuClass = context.GSUClasses.Find(id);
            LoadDepartments(gsuClass?.Department);
            return View(gsuClass);
        }

        [HttpPost]
        public IActionResult Edit(GSUClass gsuClass)
        {
            if (ModelState.IsValid)
            {
                if (gsuClass.CourseId == 0)
                    context.GSUClasses.Add(gsuClass);
                else
                    context.GSUClasses.Update(gsuClass);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Action = (gsuClass.CourseId == 0) ? "Add" : "Edit";
            LoadDepartments(gsuClass.Department);
            return View(gsuClass);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var gsuClass = context.GSUClasses.Find(id);
            return View(gsuClass);
        }

        [HttpPost]
        public IActionResult Delete(GSUClass gsuClass)
        {
            context.GSUClasses.Remove(gsuClass);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
