using Business.ServiceManager;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            var role = await _manager.AuthService.GetOneRoleForUpdate(id);
            return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] string id)
        {
            var role = await _manager.AuthService.DeleteOneRole(id);
            if (role.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}