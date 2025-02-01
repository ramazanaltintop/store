using Business.ServiceManager;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.ProductService.GetAllProducts(false));
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            return View(_manager.ProductService.GetOneProduct(id, false));
        }
    }
}