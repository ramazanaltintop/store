using Business.ServiceManager;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Components
{
    public class RoleSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public RoleSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager
                .AuthService
                .Roles
                .Count()
                .ToString();
        }
    }
}