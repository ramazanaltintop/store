using Business.ServiceManager;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IServiceManager _manager;

        public RoleController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.AuthService.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] RoleDtoForInsertion roleDto)
        {
            if (ModelState.IsValid)
            {
                _manager.AuthService.CreateOneRole(roleDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet("update/{name}")]
        public async Task<IActionResult> Update([FromRoute(Name = "Name")] string Name)
        {
            var role = await _manager.AuthService.GetOneRoleForUpdate(Name);
            return View(role);
        }
    }
}