using Business.ServiceManager;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "products")]
    public class LastestProductsTagHelper : TagHelper
    {
        private readonly IServiceManager _manager;

        [HtmlAttributeName("number")]
        public int Number { get; set; }

        public LastestProductsTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");

            TagBuilder ul = new TagBuilder("ul");
            var products = _manager.ProductService.GetLastestProducts(Number, false);
            foreach (Product product in products)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("class", "block text-slate-600 py-1 hover:text-slate-500 focus:text-slate-500 text-sm");
                a.Attributes.Add("href",$"/product/get/{product.ProductId}");
                a.InnerHtml.AppendHtml($"{product.ProductName}");
                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(li);
            }

            div.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(div);
        }
    }
}