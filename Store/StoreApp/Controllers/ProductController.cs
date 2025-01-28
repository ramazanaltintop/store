using Business.Coordinators;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
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

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            return View(_coordinator.ProductService.GetOneProduct(id, false));
        }
    }
}