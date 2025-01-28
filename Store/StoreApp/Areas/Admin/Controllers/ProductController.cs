using Business.Coordinators;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceCoordinator _coordinator;

        public ProductController(IServiceCoordinator coordinator)
        {
            _coordinator = coordinator;
        }

        public IActionResult Index()
        {
            return View(_coordinator.ProductService.GetAllProducts(false));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _coordinator.ProductService.CreateOneProduct(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            return View(_coordinator.ProductService.GetOneProduct(id, false));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                _coordinator.ProductService.UpdateOneProduct(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _coordinator.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }
    }
}