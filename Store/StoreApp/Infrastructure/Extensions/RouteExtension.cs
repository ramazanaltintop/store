namespace StoreApp.Infrastructure.Extensions
{
    public static class RouteExtension
    {
        public static void AddCustomRoutes(this IEndpointRouteBuilder routeBuilder)
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

            routeBuilder.MapRazorPages();

            routeBuilder.MapControllers();
        }
    }
}