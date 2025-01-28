using Business.Coordinators;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServiceCoordinator _coordinator;

        public CategoryController(IServiceCoordinator coordinator)
        {
            _coordinator = coordinator;
        }

        public IActionResult Index()
        {
            return View(_coordinator.CategoryService.GetAllCategories(false));
        }
    }
}