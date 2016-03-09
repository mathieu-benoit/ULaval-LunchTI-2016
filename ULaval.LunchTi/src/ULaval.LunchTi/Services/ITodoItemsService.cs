using System.Collections.Generic;
using ULaval.LunchTi.Models;

namespace ULaval.LunchTi.Services
{
    public interface ITodoItemsService
    {
        TodoItemModel Get(int id);
        IEnumerable<TodoItemModel> GetAll();
        void Delete(int id);
        void Update(TodoItemModel todoItemModel);
        void Create(TodoItemModel todoItemModel);
    }
}
