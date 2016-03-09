using System.Linq;
using Microsoft.AspNet.Mvc;
using ULaval.LunchTi.Models;

namespace ULaval.LunchTi.Controllers
{
    public class TodoItemsController : Controller
    {
        private ULavalLunchTiContext _context;

        public TodoItemsController(ULavalLunchTiContext context)
        {
            _context = context;
        }

        // GET: TodoItemModels
        public IActionResult Index()
        {
            return View(_context.TodoItemModel.ToList());
        }

        // GET: TodoItemModels/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TodoItemModel todoItemModel = _context.TodoItemModel.Single(m => m.Id == id);
            if (todoItemModel == null)
            {
                return HttpNotFound();
            }

            return View(todoItemModel);
        }

        // GET: TodoItemModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoItemModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoItemModel todoItemModel)
        {
            if (ModelState.IsValid)
            {
                _context.TodoItemModel.Add(todoItemModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoItemModel);
        }

        // GET: TodoItemModels/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TodoItemModel todoItemModel = _context.TodoItemModel.Single(m => m.Id == id);
            if (todoItemModel == null)
            {
                return HttpNotFound();
            }
            return View(todoItemModel);
        }

        // POST: TodoItemModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TodoItemModel todoItemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(todoItemModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoItemModel);
        }

        // GET: TodoItemModels/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TodoItemModel todoItemModel = _context.TodoItemModel.Single(m => m.Id == id);
            if (todoItemModel == null)
            {
                return HttpNotFound();
            }

            return View(todoItemModel);
        }

        // POST: TodoItemModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            TodoItemModel todoItemModel = _context.TodoItemModel.Single(m => m.Id == id);
            _context.TodoItemModel.Remove(todoItemModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
