using Business.Coordinators;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IServiceCoordinator _coordinator;

        public ProductSummaryViewComponent(IServiceCoordinator coordinator)
        {
            _coordinator = coordinator;
        }

        public string Invoke()
        {
            return _coordinator.ProductService.GetAllProducts(false).Count().ToString();
        }
    }
}