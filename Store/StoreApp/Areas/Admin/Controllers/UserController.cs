using Business.ServiceManager;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View(_manager.AuthService.GetAllUsers());
        }

        public IActionResult Create()
        {
            return View(new UserDtoForCreation()
            {
                Roles = new HashSet<string>(_manager
                    .AuthService
                    .Roles
                    .Select(r => r.Name)
                    .ToList()
                )
            });
        }
    }
}