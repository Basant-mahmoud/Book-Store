using Book_Store.Models.Domain;
using Book_Store.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _authorService.Add(model);
            if (res == true)
            {
                TempData["msg"] = "Added Sucessfly";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has accure in server side";
            return View(model);

        }
        [HttpPost]
        public IActionResult Update(Author model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _authorService.Update(model);
            if (res == true)
            {
                TempData["msg"] = "Updated Sucessfly";
                return RedirectToAction(nameof(GetAll));
            }
            TempData["msg"] = "Error has accure in server side";
            return View(model);

        }
        public IActionResult Update(int id)
        {
            var res = _authorService.GetById(id);
            return View(res);
        }
        public IActionResult Delete(int id)
        {

            var res = _authorService.Delete(id);
            if (res)
            {
                TempData["msg"] = "Deleted Sucessfly";
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Deletion Failed. not found.";
            return RedirectToAction("GetAll");


        }
        public IActionResult GetAll()
        {

            var data = _authorService.GetAll();

            return View(data);

        }
    }
}
