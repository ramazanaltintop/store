namespace StoreApp.Infrastructure.Extensions
{
    public static class RouteExtension
    {
        public static void ConfigureRoute(this IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
            );

            routeBuilder.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );
        }
    }
}