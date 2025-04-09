using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApplication.Models;

namespace ToDoApplication.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;
        public ToDoController(ToDoContext context)
        {
            _context = context;
        }

       /// <summary>
       /// Display the overview screen with filter and sort options
       /// </summary>
       /// <param name="sortBy"></param>
       /// <param name="filterBy"></param>
       /// <returns></returns>
        public async Task<IActionResult> Overview(string sortBy, string filterBy)
        {
            var todos = _context.ToDoItems.AsQueryable();

            // Apply filtering based on the filterBy parameter
            if (!string.IsNullOrEmpty(filterBy))
            {
                switch (filterBy.ToLower())
                {
                    case "completed":
                        todos = todos.Where(t => t.IsCompleted);
                        break;
                    case "notcompleted":
                        todos = todos.Where(t => !t.IsCompleted);
                        break;
                }
            }

            // Apply sorting based on the sortBy parameter
            switch (sortBy?.ToLower())
            {
                case "title":
                    todos = todos.OrderBy(t => t.Title);
                    break;
                case "title_desc":
                    todos = todos.OrderByDescending(t => t.Title);
                    break;
                case "description":
                    todos = todos.OrderBy(t => t.Description);
                    break;
                case "description_desc":
                    todos = todos.OrderByDescending(t => t.Description);
                    break;
                default:
                    todos = todos.OrderBy(t => t.Id); // Default sorting by ID
                    break;
            }

            return View(await todos.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new ToDo item.
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(ToDo todo)
        {
            if (ModelState.IsValid)
            { 
                _context.ToDoItems.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Overview");
            }
            return View(todo);
        }

        /// <summary>
        /// Edits an existing ToDo item by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            var todo = await _context.ToDoItems.FirstOrDefaultAsync(x=> x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        /// <summary>
        /// Updates an existing ToDo item.
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                _context.ToDoItems.Update(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Overview");
            }
            return View(todo);
        }

        /// <summary>
        /// Deletes an existing item by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        /// <summary>
        /// Deletes a ToDo item.
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todoId = await _context.ToDoItems.FindAsync(id);
            if (todoId != null)
            {
                 _context.ToDoItems.Remove(todoId);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Overview");
        }
    }
}
