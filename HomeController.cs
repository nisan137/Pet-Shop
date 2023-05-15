using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopApp.Models;
using PetShopApp.Repositories;

namespace PetShopApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Animal> _repository;

        public HomeController(IRepository<Animal> repository) => _repository = repository;
        public IActionResult Index()
        {
            return View(_repository.GetAll().OrderByDescending(a => a.Comments!.Count()).Take(2).ToList());
        }
    }
}
