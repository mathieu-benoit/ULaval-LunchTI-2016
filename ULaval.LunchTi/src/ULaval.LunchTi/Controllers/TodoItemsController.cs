using Microsoft.AspNet.Mvc;
using ULaval.LunchTi.Models;
using ULaval.LunchTi.Services;

namespace ULaval.LunchTi.Controllers
{
    public class TodoItemsController : Controller
    {
        private readonly ITodoItemsService _todoItemsService;

        public TodoItemsController(ITodoItemsService todoItemsService)
        {
            _todoItemsService = todoItemsService;
        }

        // GET: TodoItemModels
        public IActionResult Index()
        {
            return View(_todoItemsService.GetAll());
        }

        // GET: TodoItemModels/Details/5
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var todoItemModel = _todoItemsService.Get(id.Value);
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
                _todoItemsService.Create(todoItemModel);
                return RedirectToAction("Index");
            }
            return View(todoItemModel);
        }

        // GET: TodoItemModels/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var todoItemModel = _todoItemsService.Get(id.Value);
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
                _todoItemsService.Update(todoItemModel);
                return RedirectToAction("Index");
            }
            return View(todoItemModel);
        }

        // GET: TodoItemModels/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var todoItemModel = _todoItemsService.Get(id.Value);
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
            _todoItemsService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
