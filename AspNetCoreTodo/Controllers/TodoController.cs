using System.Data;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {

        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<IdentityUser> _userManager;

        public TodoController(ITodoItemService todoItemService, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if(currentUser == null) 
                return Challenge();

            // Get todo items from the database
            var items = await _todoItemService.GetIncompleteItemsAsync(currentUser);
            //Put items into a model
            var model = new TodoViewModel()
            {
                Items = items
            };

            //Render view using the model
            return View(model);

        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();                

            bool successful = await _todoItemService.AddItemAsync(newItem, currentUser);

            if (!successful)
                return BadRequest("Could not add item");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
                return RedirectToAction("Index");

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            bool successful = await _todoItemService.MarkDoneAsync(id, currentUser);
            if (!successful)
                return BadRequest("Could not mark item as done");

            return RedirectToAction("Index");

        }

    }


}