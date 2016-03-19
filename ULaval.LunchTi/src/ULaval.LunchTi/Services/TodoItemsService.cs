using System.Collections.Generic;
using System.Linq;
using ULaval.LunchTi.Models;

namespace ULaval.LunchTi.Services
{
    public class TodoItemsService : ITodoItemsService
    {
        private readonly ULavalLunchTiContext _context;

        public TodoItemsService(ULavalLunchTiContext context)
        {
            _context = context;
        }

        public void Create(TodoItemModel todoItemModel)
        {
            _context.TodoItems.Add(todoItemModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var todoItemModel = _context.TodoItems.Single(m => m.Id == id);
            _context.TodoItems.Remove(todoItemModel);
            _context.SaveChanges();
        }

        public TodoItemModel Get(int id)
        {
            return _context.TodoItems.Single(m => m.Id == id);
        }

        public IEnumerable<TodoItemModel> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        public void Update(TodoItemModel todoItemModel)
        {
            _context.Update(todoItemModel);
            _context.SaveChanges();
        }
    }
}
