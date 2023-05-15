using Microsoft.AspNetCore.Mvc;
using PetShopApp.Models;
using PetShopApp.Repositories;

namespace PetShopApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IRepository<Animal> _animalRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Comment> _commentRepository;

        public CatalogController(IRepository<Animal> repository, IRepository<Category> categoryrepository, IRepository<Comment> commentRepository)
        {
            _animalRepository = repository;
            _categoryRepository = categoryrepository;
            _commentRepository = commentRepository;
        }

        public IActionResult Index(Category? category)
        {
            ViewBag.catecories = _categoryRepository.GetAll();
            if (category != null && category.Id > 0)
            {
                return View(_animalRepository.GetAll().Where(a => a.CategoryId == category.Id));
            }
            var catalog = _animalRepository.GetAll().ToList();
            if (catalog == null)
                return RedirectToAction("Index", "Home");
            return View(catalog);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_animalRepository.Get(id));
        }

        public IActionResult AddComment(Comment comment)
        {
            if (!ModelState.IsValid)
                return View("Details", _animalRepository.Get(comment.AnimalId));
            _commentRepository.Add(comment);
            return RedirectToAction("Details", new {id = comment!.AnimalId});
        }
    }
}
