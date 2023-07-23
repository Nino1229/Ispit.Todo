using Microsoft.AspNetCore.Mvc;
using Ispit.Todo.Models;
using Ispit.Todo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Todo.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        public ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public TodoController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            var todos = _dbContext.TodoList.ToList();

            return View(todos);
        }
    }
}
