using Microsoft.AspNetCore.Mvc;
using DotNetProject.Data;
using DotNetProject.Models;

namespace DotNetProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        // List all tasks
        public IActionResult Index()
        {
            var tasks = _context.TaskItems.ToList();
            return View(tasks);
        }

        // Show details of a task
        public IActionResult Details(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // Show create form
        public IActionResult Create() => View();

        // Save new task to DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.TaskItems.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // Show edit form
        public IActionResult Edit(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // Update task
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.Update(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // Show delete confirmation form
        public IActionResult Delete(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST: Delete from DB
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task == null) return NotFound();

            _context.TaskItems.Remove(task);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
