using Ispit.Todo.Data;
using Ispit.Todo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ispit.Todo.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        public ApplicationDbContext _dbContext;
        public TasksController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //ViewBag.TodoId = id;

            var tasks = _dbContext.Task.ToList();

            if (tasks == null) return NotFound();

            return View(tasks);
        }

        public IActionResult Details(int id)
        {
            if (id == 0) return NotFound();

            var task = _dbContext.Task.FirstOrDefault(t => t.Id == id);

            if (task == null) return NotFound();

            return View(task);
        }

        public IActionResult Create(int id)
        {
            ViewData["TodoId"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tasks task)
        {

            Tasks newTask = new Tasks()
            {
                Title = task.Title,
                TodoId = task.TodoId,
                Description = task.Description,
                IsCompleted = false
            };

            _dbContext.Task.Add(newTask);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {     
            var tasks = _dbContext.Task.FirstOrDefault(t => t.Id == id);

            if (id == 0 || tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        [HttpPost]
        public IActionResult Edit(Tasks task)
        {

            Tasks dbTask = _dbContext.Task.FirstOrDefault(t => t.Id == task.Id);

            if (dbTask == null) return NotFound();

            dbTask.Title = task.Title;
            dbTask.TodoId = task.TodoId;
            dbTask.Description = task.Description;
            dbTask.IsCompleted = task.IsCompleted;
            dbTask.Id = task.Id;

            _dbContext.Update(dbTask);
            _dbContext.SaveChanges(true);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            var tasks = _dbContext.Task.FirstOrDefault(t => t.Id == id);

            if (id == 0 || tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var tasks = _dbContext.Task.FirstOrDefault(t => t.Id == id);

            if (id == 0 || tasks == null)
            {
                return NotFound();
            }

            _dbContext.Task.Remove(tasks);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
