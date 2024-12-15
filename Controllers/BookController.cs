using Book_Store.Models.Domain;
using Book_Store.Repositories.Abstract;
using Book_Store.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book_Store.Controllers
{
    public class BookController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly IGenreService _GenreService;
        private readonly IPublisherService _publisherService;
        public BookController(IAuthorService authorService, IBookService bookService, IGenreService GenreService, IPublisherService publisherService)
        {
            _authorService = authorService;
            _bookService = bookService;
            _GenreService= GenreService;
            _publisherService= publisherService;
        }
        

        public IActionResult Add()
        {
            var model=new Book();
            model.Authorlist = _authorService.GetAll()
      .Select(a => new SelectListItem
      {
          Text = a.AuthorName,
          Value = a.Id.ToString()
      })
      .ToList();
           model.Genrelist = _GenreService.GetAll()
          .Select(a => new SelectListItem
           {
              Text = a.Name,
               Value = a.Id.ToString()
            })
          .ToList();

            model.Publisherlist = _publisherService.GetAll()
         .Select(a => new SelectListItem
         {
             Text = a.PublisherName,
             Value = a.Id.ToString()
         })
         .ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.Authorlist = _authorService.GetAll()
    .Select(a => new SelectListItem
    {
        Text = a.AuthorName,
        Value = a.Id.ToString(),
        Selected = a.Id == model.AutherId
    })
    .ToList();
            model.Genrelist = _GenreService.GetAll()
           .Select(a => new SelectListItem
           {
               Text = a.Name,
               Value = a.Id.ToString(),
               Selected = a.Id == model.GenreId
           })
           .ToList();

            model.Publisherlist = _publisherService.GetAll()
         .Select(a => new SelectListItem
         {
             Text = a.PublisherName,
             Value = a.Id.ToString(),
             Selected = a.Id == model.PublisherId
         })
         .ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _bookService.Add(model);
            if (res == true)
            {
                TempData["msg"] = "Added Sucessfly";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has accure in server side";
            return View(model);

        }
        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.Authorlist = _authorService.GetAll()
 .Select(a => new SelectListItem
 {
     Text = a.AuthorName,
     Value = a.Id.ToString(),
     Selected = a.Id == model.AutherId
 })
 .ToList();
            model.Genrelist = _GenreService.GetAll()
           .Select(a => new SelectListItem
           {
               Text = a.Name,
               Value = a.Id.ToString(),
               Selected = a.Id == model.GenreId
           })
           .ToList();

            model.Publisherlist = _publisherService.GetAll()
         .Select(a => new SelectListItem
         {
             Text = a.PublisherName,
             Value = a.Id.ToString(),
             Selected = a.Id == model.PublisherId
         })
         .ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _bookService.Update(model);
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
            var model = _bookService.GetById(id);
            model.Authorlist = _authorService.GetAll()
 .Select(a => new SelectListItem
 {
     Text = a.AuthorName,
     Value = a.Id.ToString(),
     Selected = a.Id == model.AutherId
 })
 .ToList();
            model.Genrelist = _GenreService.GetAll()
           .Select(a => new SelectListItem
           {
               Text = a.Name,
               Value = a.Id.ToString(),
               Selected = a.Id == model.GenreId
           })
           .ToList();

            model.Publisherlist = _publisherService.GetAll()
         .Select(a => new SelectListItem
         {
             Text = a.PublisherName,
             Value = a.Id.ToString(),
             Selected = a.Id == model.PublisherId
         })
         .ToList();
            return View(model);
        }
        public IActionResult Delete(int id)
        {

            var res = _bookService.Delete(id);
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

            var data = _bookService.GetAll();

            return View(data);

        }
    }
}
