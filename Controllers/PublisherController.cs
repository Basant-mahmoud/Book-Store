using Book_Store.Models.Domain;
using Book_Store.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _publisherService.Add(model);
            if (res == true)
            {
                TempData["msg"] = "Added Sucessfly";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has accure in server side";
            return View(model);

        }
        [HttpPost]
        public IActionResult Update(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _publisherService.Update(model);
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
            var res = _publisherService.GetById(id);
            return View(res);
        }
        public IActionResult Delete(int id)
        {

            var res = _publisherService.Delete(id);
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

            var data = _publisherService.GetAll();

            return View(data);

        }
    }
}
