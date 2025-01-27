using Business.Coordinators;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly IServiceCoordinator _coordinator;

        public CategoriesMenuViewComponent(IServiceCoordinator coordinator)
        {
            _coordinator = coordinator;
        }

        public IViewComponentResult Invoke()
        {
            return View(_coordinator.CategoryService.GetAllCategories());
        }
    }
}