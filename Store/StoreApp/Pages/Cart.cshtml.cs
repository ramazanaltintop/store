using Business.Coordinators;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceCoordinator _coordinator;

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        public CartModel(IServiceCoordinator coordinator, Cart cart)
        {
            _coordinator = coordinator;
            Cart = cart;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _coordinator.ProductService.GetOneProduct(productId, false);
            if (product is not null)
            {
                Cart.AddItem(product, 1);
            }
            return Page();
        }

        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
            return Page();
        }
    }
}