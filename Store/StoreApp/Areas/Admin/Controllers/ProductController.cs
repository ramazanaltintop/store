using Business.Coordinators;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.Categories = GetAllCategoriesSelectList();
            return View();
        }

        private SelectList GetAllCategoriesSelectList()
        {
            return new SelectList(
                _coordinator.CategoryService.GetAllCategories(false),
                "CategoryId",
                "CategoryName",
                "1"
            );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ProductDtoForInsertion productDto)
        {
            if (ModelState.IsValid)
            {
                _coordinator.ProductService.CreateOneProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetAllCategoriesSelectList();
            return View(_coordinator.ProductService.GetOneProductForUpdate(id, false));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] ProductDtoForUpdate productDto)
        {
            if (ModelState.IsValid)
            {
                _coordinator.ProductService.UpdateOneProduct(productDto);
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