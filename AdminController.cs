using Microsoft.AspNetCore.Mvc;
using PetShopApp.Models;
using PetShopApp.Repositories;
using PetShopApp.Services;

namespace PetShopApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<Animal> _animalRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IPictureReader _pictureReader;

        public AdminController(IRepository<Animal> repository, IPictureReader pictureReader, IRepository<Category> repository1)
        {
            _animalRepository = repository;
            _categoryRepository = repository1;
            _pictureReader = pictureReader;
        }

        public IActionResult Index(Category? category)
        {
            ViewBag.catecories = _categoryRepository.GetAll();
            if (category != null && category.Id > 0)
            {
                return View(_animalRepository.GetAll().Where(a => a.CategoryId == category.Id));
            }
            return View(_animalRepository.GetAll().ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            if (!ModelState.IsValid)
                return View();

            if (animal.AnimalPhoto != null)
            {
                animal.PhotoUrl = _pictureReader.FileReader(animal.AnimalPhoto);
            }
            _animalRepository.Add(animal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var a = _animalRepository.Get(id);
            return View(a);
        }

        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            if (!ModelState.IsValid)
                return View();

            if (animal.AnimalPhoto != null)
            {
                animal.PhotoUrl = _pictureReader.FileReader(animal.AnimalPhoto);
            }
            _animalRepository.Update(animal);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var a = _animalRepository.Get(id);
            if (a == null)
                return Content("Error,\nPlease try later ;)");
            _animalRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
