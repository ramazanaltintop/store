using Business.ServiceManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.OrderService.Orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Complete([FromForm] int id)
        {
            _manager.OrderService.Complete(id);
            return RedirectToAction("Index");
        }
    }
}