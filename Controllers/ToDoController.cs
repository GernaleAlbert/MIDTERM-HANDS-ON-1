using Microsoft.AspNetCore.Mvc;
using ToDoList_GERNALE.Models;
using ToDoList_GERNALE.Services;

namespace ToDoList_GERNALE.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var items = _service.GetAll();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ToDoItem item)
        {
            if (ModelState.IsValid)
            {
                _service.Add(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(ToDoItem item)
        {
            if (ModelState.IsValid)
            {
                _service.Update(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public IActionResult Delete(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
