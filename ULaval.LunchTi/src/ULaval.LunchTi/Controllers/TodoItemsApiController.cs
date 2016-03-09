using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using ULaval.LunchTi.Models;

namespace ULaval.LunchTi.Controllers
{
    [Produces("application/json")]
    [Route("api/TodoItems")]
    public class TodoItemsApiController : Controller
    {
        private ULavalLunchTiContext _context;

        public TodoItemsApiController(ULavalLunchTiContext context)
        {
            _context = context;
        }

        // GET: api/TodoItemsApi
        [HttpGet]
        public IEnumerable<TodoItemModel> GetTodoItemModel()
        {
            return _context.TodoItemModel;
        }

        // GET: api/TodoItemsApi/5
        [HttpGet("{id}", Name = "GetTodoItemModel")]
        public IActionResult GetTodoItemModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            TodoItemModel todoItemModel = _context.TodoItemModel.Single(m => m.Id == id);

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

            _context.Entry(todoItemModel).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
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

            _context.TodoItemModel.Add(todoItemModel);
            try
            {
                _context.SaveChanges();
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

            TodoItemModel todoItemModel = _context.TodoItemModel.Single(m => m.Id == id);
            if (todoItemModel == null)
            {
                return HttpNotFound();
            }

            _context.TodoItemModel.Remove(todoItemModel);
            _context.SaveChanges();

            return Ok(todoItemModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoItemModelExists(int id)
        {
            return _context.TodoItemModel.Count(e => e.Id == id) > 0;
        }
    }
}