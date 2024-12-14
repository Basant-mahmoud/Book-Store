using Book_Store.Models.Domain;
using Book_Store.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService) { 
        _genreService = genreService;
        }
        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre model)
        {
            if (!ModelState.IsValid) { 
                return View(model);
            }
            var res=_genreService.Add(model);
            if (res == true) 
            {
                TempData["msg"] = "Added Sucessfly";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has accure in server side";
            return View(model);

        }
        [HttpPost]
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _genreService.Update(model);
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
            var res=_genreService.GetById(id);
            return View(res);   
        }
        public IActionResult Delete(int  id)
        {
              
            var res = _genreService.Delete(id);
            if (res)
            {
                TempData["msg"] = "Deleted Sucessfly";
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Deletion Failed. Genre not found.";
            return RedirectToAction("GetAll");


        }
        public IActionResult GetAll ()
        {

            var data = _genreService.GetAll();
            
            return View(data);

        }
    }
}
