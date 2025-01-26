using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetAllProducts());
        }

        public IActionResult Get(int id)
        {
            return View(_productService.GetProductById(id));
        }
    }
}