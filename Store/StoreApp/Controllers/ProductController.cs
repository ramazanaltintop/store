using Business.ServiceManager;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters parameters)
        {
            var products = _manager.ProductService.GetAllProductsWithDetails(parameters);
            var pagination = new Pagination()
            {
                CurrentPage = parameters.PageNumber,
                ItemsPerPage = parameters.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };
            ViewData["Title"] = "Products";
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination
            });
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            ViewData["Title"] = model?.ProductName;
            return View(model);
        }
    }
}