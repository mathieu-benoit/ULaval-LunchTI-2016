using System.Collections.Generic;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using ULaval.LunchTi.Models;
using ULaval.LunchTi.Services;

namespace ULaval.LunchTi.Controllers
{
    [Produces("application/json")]
    [Route("api/TodoItems")]
    public class TodoItemsApiController : Controller
    {
        private readonly ITodoItemsService _todoItemsService;

        public TodoItemsApiController(ITodoItemsService todoItemsService)
        {
            _todoItemsService = todoItemsService;
        }

        // GET: api/TodoItemsApi
        [HttpGet]
        public IEnumerable<TodoItemModel> GetTodoItemModel()
        {
            return _todoItemsService.GetAll();
        }

        // GET: api/TodoItemsApi/5
        [HttpGet("{id}", Name = "GetTodoItemModel")]
        public IActionResult GetTodoItemModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            var todoItemModel = _todoItemsService.Get(id);
            if (todoItemModel == null)
            {
                return HttpNotFound();
            }
            return Ok(todoItemModel);
        }

        // PUT: api/TodoItemsApi/5
        [HttpPut("{id}")]
        public IActionResult PutTodoItemModel(int id, [FromBody] TodoItemModel todoItemModel)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            if (id != todoItemModel.Id)
            {
                return HttpBadRequest();
            }
            try
            {
                _todoItemsService.Update(todoItemModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemModelExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }
            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/TodoItemsApi
        [HttpPost]
        public IActionResult PostTodoItemModel([FromBody] TodoItemModel todoItemModel)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            try
            {
                _todoItemsService.Create(todoItemModel);
            }
            catch (DbUpdateException)
            {
                if (TodoItemModelExists(todoItemModel.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetTodoItemModel", new { id = todoItemModel.Id }, todoItemModel);
        }

        // DELETE: api/TodoItemsApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItemModel(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            var todoItemModel = _todoItemsService.Get(id);
            if (!TodoItemModelExists(id))
            {
                return HttpNotFound();
            }
            _todoItemsService.Delete(id);
            return Ok(todoItemModel);
        }

        private bool TodoItemModelExists(int id)
        {
            return _todoItemsService.Get(id) != null;
        }
    }
}