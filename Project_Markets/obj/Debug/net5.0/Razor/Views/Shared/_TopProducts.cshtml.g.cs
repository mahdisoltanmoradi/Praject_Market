#pragma checksum "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_TopProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b70d34f3c4e5766472edcd816ec0aafb7d06fb09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TopProducts), @"mvc.1.0.view", @"/Views/Shared/_TopProducts.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b70d34f3c4e5766472edcd816ec0aafb7d06fb09", @"/Views/Shared/_TopProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TopProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.Product.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""top-products-area clearfix py-3"">
    <div class=""container"">
        <div class=""section-heading d-flex align-items-center justify-content-between"">
            <h6 class=""ml-1"">محصولات برتر</h6><a class=""btn btn-danger btn-sm"" href=""shop-grid.html"">مشاهده همه</a>
        </div>
        <div class=""row g-3"">
            <!-- Single Top Product Card-->
");
#nullable restore
#line 10 "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_TopProducts.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-6 col-md-4 col-lg-3"">
                    <div class=""card top-product-card"">
                        <div class=""card-body mt-4"">
                            <span class=""badge badge-success"">فروش</span>
                            <a id=""get-product-link"" class=""wishlist-btn""");
            BeginWriteAttribute("onclick", " onclick=\"", 793, "\"", 824, 3);
            WriteAttributeValue("", 803, "setFavorite(", 803, 12, true);
#nullable restore
#line 16 "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_TopProducts.cshtml"
WriteAttributeValue("", 815, item.Id, 815, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 823, ")", 823, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <i class=\"lni lni-heart\"></i>\r\n                            </a>\r\n                            <a class=\"product-thumbnail d-block\"");
            BeginWriteAttribute("href", " href=\"", 989, "\"", 1032, 2);
            WriteAttributeValue("", 996, "/Product/ProductInformation/", 996, 28, true);
#nullable restore
#line 19 "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_TopProducts.cshtml"
WriteAttributeValue("", 1024, item.Id, 1024, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <img class=\"mb-2\" style=\"border-radius:10px\"");
            BeginWriteAttribute("src", " src=\"", 1112, "\"", 1162, 2);
            WriteAttributeValue("", 1118, "/ImageProductCategory/", 1118, 22, true);
#nullable restore
#line 20 "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_TopProducts.cshtml"
WriteAttributeValue("", 1140, item.ProductImageName, 1140, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1163, "\"", 1169, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </a>\r\n                            <a class=\"product-title d-block text-left\"");
            BeginWriteAttribute("href", " href=\"", 1277, "\"", 1320, 2);
            WriteAttributeValue("", 1284, "/Product/ProductInformation/", 1284, 28, true);
#nullable restore
#line 22 "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_TopProducts.cshtml"
WriteAttributeValue("", 1312, item.Id, 1312, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 22 "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_TopProducts.cshtml"
                                                                                                              Write(item.ProductTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            <p class=\"sale-price text-left\">36 تومان <span class=\"real-price\"> ");
#nullable restore
#line 23 "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_TopProducts.cshtml"
                                                                                          Write(item.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" تومان</span></p>
                            <div class=""product-rating text-left"">
                                <i class=""lni lni-star-filled""></i>
                                <i class=""lni lni-star-filled""></i>
                                <i class=""lni lni-star-filled""></i>
                                <i class=""lni lni-star-filled""></i>
                                <i class=""lni lni-star-filled""></i>
                            </div>
                            <a class=""btn btn-success btn-sm add2cart-notify""");
            BeginWriteAttribute("href", " href=\"", 2004, "\"", 2047, 2);
            WriteAttributeValue("", 2011, "/Product/ProductInformation/", 2011, 28, true);
#nullable restore
#line 31 "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_TopProducts.cshtml"
WriteAttributeValue("", 2039, item.Id, 2039, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <i class=\"lni lni-plus\"></i>\r\n                            </a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 37 "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_TopProducts.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        function setFavorite(id) {

            //$.post(`/Product/favoriteProduct?productId=${id}`, () => {
            //    alert('این محصول به لیست علاقه مندی های شما اضافه شد');
            //    $('#get-product-link').find(""i"").toggleClass(""lni lni-heart lni lni-heart-filled"");
            //})

            $.ajax({
                url: `/Product/favoriteProduct?productId=${id}`,
                method: 'POST',
                contentType: ""application/json; charset=utf-8"",
                success: function () {
                    alert('این محصول به لیست علاقه مندی های شما اضافه شد');
                    $('#get-product-link').find(""i"").toggleClass(""lni lni-heart lni lni-heart-filled"");
                },
                error: function () {
                    alert('خطایی رخ داد');
                }
            }).done(function (res) {
                debugger;

            });
        }
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities.Product.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
