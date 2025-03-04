using Business.ServiceManager;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Components
{
    public class OrdersInProgressViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public OrdersInProgressViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager
                .OrderService
                .NumberOfInProgress
                .ToString();
        }
    }
}