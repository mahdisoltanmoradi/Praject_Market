#pragma checksum "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd4b16cb37fc0d07f5030c736662cee5ccc6ad62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd4b16cb37fc0d07f5030c736662cee5ccc6ad62", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.Product.Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Basket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "Index";

    var favirotes = ViewData["Favorites"] as List<Entities.User.FavoriteUser>;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Preloader-->
<div class=""preloader"" id=""preloader"">
    <div class=""spinner-grow text-secondary"" role=""status"">
        <div class=""sr-only"">بارگذاری...</div>
    </div>
</div>
<!-- Header Area-->
<div class=""header-area"" id=""headerArea"">
    <div class=""container h-100 d-flex align-items-center justify-content-between"">
        <!-- Back Button-->
        <div class=""back-button""><a href=""catagory.html""><i class=""lni lni-arrow-right""></i></a></div>
        <!-- Page Title-->
        <div class=""page-heading"">
            <h6 class=""mb-0"">تن پوش</h6>
        </div>
        <!-- Filter Option-->
        <div class=""filter-option"" id=""suhaNavbarToggler""><i class=""lni lni-cog""></i></div>
    </div>
</div>
<!-- Sidenav Black Overlay-->
<div class=""sidenav-black-overlay""></div>
<!-- Side Nav Wrapper-->
<div class=""suha-sidenav-wrapper filter-nav"" id=""sidenavWrapper"">
    <!-- Catagory Sidebar Area-->
    <div class=""catagory-sidebar-area"">
        <!-- Catagory-->
        <div clas");
            WriteLiteral(@"s=""widget catagory mb-4"">
            <h6 class=""widget-title mb-3"">نام تجاری محصول</h6>
            <div class=""widget-desc"">
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""zara"" type=""checkbox""");
            BeginWriteAttribute("checked", " checked=\"", 1483, "\"", 1493, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <label class=""form-check-label font-weight-bold"" for=""zara"">زارا</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""Gucci"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""Gucci"">گوچی</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""Addidas"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""Addidas"">آدیداس</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""Nike"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""Nike"">نایک</label>
                </div>
                <!-- Single Checkbox-->
         ");
            WriteLiteral(@"       <div class=""form-check"">
                    <input class=""form-check-input"" id=""Denim"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""Denim"">جین</label>
                </div>
            </div>
        </div>
        <!-- Color-->
        <div class=""widget color mb-4"">
            <h6 class=""widget-title mb-3"">خانواده رنگی</h6>
            <div class=""widget-desc"">
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""Purple"" type=""checkbox""");
            BeginWriteAttribute("checked", " checked=\"", 3112, "\"", 3122, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <label class=""form-check-label font-weight-bold"" for=""Purple"">رنگ بنفش</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""Black"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""Black"">سیاه</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""White"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""White"">سفید</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""Red"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""Red"">قرمز</label>
                </div>
                <!-- Single Checkbox-->
           ");
            WriteLiteral(@"     <div class=""form-check"">
                    <input class=""form-check-input"" id=""Pink"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""Pink"">رنگ صورتی</label>
                </div>
            </div>
        </div>
        <!-- Size-->
        <div class=""widget size mb-4"">
            <h6 class=""widget-title mb-3"">اندازه</h6>
            <div class=""widget-desc"">
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""XtraLarge"" type=""checkbox""");
            BeginWriteAttribute("checked", " checked=\"", 4738, "\"", 4748, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <label class=""form-check-label font-weight-bold"" for=""XtraLarge"">بزرگ</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""Large"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""Large"">بزرگ</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""medium"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""medium"">متوسط</label>
                </div>

                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""ExtraSmall"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""ExtraSmall"">بسیار کوچک</label>
                </div>
            </div>
        ");
            WriteLiteral(@"</div>
        <!-- Ratings-->
        <div class=""widget ratings mb-4"">
            <h6 class=""widget-title mb-3"">رتبه بندی</h6>
            <div class=""widget-desc"">
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""5star"" type=""checkbox""");
            BeginWriteAttribute("checked", " checked=\"", 6107, "\"", 6117, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <label class=""form-check-label font-weight-bold"" for=""5star"">5 ستاره</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""4star"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""4star"">4 ستاره</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""3star"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""3star"">3 ستاره</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""2star"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""2star"">2 ستاره</label>
                </div>
                <!-- Single Checkbox-->
");
            WriteLiteral(@"                <div class=""form-check"">
                    <input class=""form-check-input"" id=""1star"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""1star"">1 ستاره</label>
                </div>
            </div>
        </div>
        <!-- Payment Type-->
        <div class=""widget payment-type mb-4"">
            <h6 class=""widget-title mb-3"">نوع پرداخت</h6>
            <div class=""widget-desc"">
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""cod"" type=""checkbox""");
            BeginWriteAttribute("checked", " checked=\"", 7758, "\"", 7768, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                    <label class=""form-check-label font-weight-bold"" for=""cod"">پرداخت نقدی هنگام تحویل</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""paypal"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""paypal"">پی پال</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""checkpayment"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""checkpayment"">پرداخت رانظر کنید</label>
                </div>
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""payonner"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""payonner"">پیونر</label>
                </div>");
            WriteLiteral(@"
                <!-- Single Checkbox-->
                <div class=""form-check"">
                    <input class=""form-check-input"" id=""mobbanking"" type=""checkbox"">
                    <label class=""form-check-label font-weight-bold"" for=""mobbanking"">بانکداری موبایل</label>
                </div>
            </div>
        </div>
        <!-- Apply Filter-->
        <div class=""apply-filter-btn""><a class=""btn btn-success""");
            BeginWriteAttribute("href", " href=\"", 9229, "\"", 9236, 0);
            EndWriteAttribute();
            WriteLiteral(@">اعمال محدودیت</a></div>
    </div>
    <!-- Go Back Button-->
    <div class=""go-home-btn"" id=""goHomeBtn""><i class=""lni lni-arrow-right""></i></div>
</div>
<div class=""page-content-wrapper"">
    <!-- Catagory Single Image-->
    <div class=""catagory-single-img"" style=""background-image: url('/img/bg-img/5.jpg')""></div>
    <!-- Top Products-->
    <div class=""top-products-area py-3"">
        <div class=""container"">
            <div class=""section-heading d-flex align-items-center justify-content-between"">
                <h6 class=""ml-1"">محصولات دیگر</h6>
            </div>
            <div class=""row g-3"">
                <!-- Single Top Product Card-->
               
");
#nullable restore
#line 202 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
                     foreach (var product in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""col-6 col-md-4 col-lg-3"">
                            <div class=""card top-product-card"">
                                <div class=""card-body mb-3 mt-3 text-left"">
                                    <span class=""badge badge-success"">فروش</span>
                                    <a");
            BeginWriteAttribute("id", " id=\"", 10334, "\"", 10372, 1);
#nullable restore
#line 208 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
WriteAttributeValue("", 10339, "get-product-link-"+product.Id, 10339, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"wishlist-btn\"");
            BeginWriteAttribute("onclick", " onclick=\"", 10394, "\"", 10428, 3);
            WriteAttributeValue("", 10404, "setFavorite(", 10404, 12, true);
#nullable restore
#line 208 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
WriteAttributeValue("", 10416, product.Id, 10416, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 10427, ")", 10427, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 209 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
                                         if (favirotes.Any(a => a.ProductId == product.Id))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <i class=\"lni lni-heart-filled\"></i>\r\n");
#nullable restore
#line 212 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <i class=\"lni lni-heart\"></i>\r\n");
#nullable restore
#line 216 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </a>\r\n                                    <p></p>\r\n                                    <a class=\"product-thumbnail d-block\"");
            BeginWriteAttribute("href", " href=\"", 11061, "\"", 11107, 2);
            WriteAttributeValue("", 11068, "/Product/ProductInformation/", 11068, 28, true);
#nullable restore
#line 220 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
WriteAttributeValue("", 11096, product.Id, 11096, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <img class=\"mb-2\" style=\"border-radius:20px\"");
            BeginWriteAttribute("src", " src=\"", 11195, "\"", 11248, 2);
            WriteAttributeValue("", 11201, "/ImageProductCategory/", 11201, 22, true);
#nullable restore
#line 221 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
WriteAttributeValue("", 11223, product.ProductImageName, 11223, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 11249, "\"", 11255, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    </a>\r\n                                    <a class=\"product-title d-block\"");
            BeginWriteAttribute("href", " href=\"", 11369, "\"", 11415, 2);
            WriteAttributeValue("", 11376, "/Product/ProductInformation/", 11376, 28, true);
#nullable restore
#line 223 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
WriteAttributeValue("", 11404, product.Id, 11404, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 223 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
                                                                                                               Write(product.ProductTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    <p class=\"sale-price\">");
#nullable restore
#line 224 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
                                                     Write(product.ProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان <span class=\"real-price\"> ");
#nullable restore
#line 224 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
                                                                                                           Write(product.DeleteProductPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span></p>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd4b16cb37fc0d07f5030c736662cee5ccc6ad6220764", async() => {
                WriteLiteral("\r\n                                        <button type=\"submit\"");
                BeginWriteAttribute("value", " value=\"", 11764, "\"", 11783, 1);
#nullable restore
#line 226 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"
WriteAttributeValue("", 11772, product.Id, 11772, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"ProductId\" class=\"btn btn-success btn-sm add2cart-notify\" href=\"#\">\r\n                                            <i class=\"lni lni-plus\"></i>\r\n                                        </button>\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 233 "D:\programing\Core\Project_Markets\Project_Markets\Views\Product\Index.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>
    </div>
</div>
<!-- Internet Connection Status-->
<div class=""internet-connection-status"" id=""internetStatus""></div>
<!-- Footer Nav-->
<div class=""footer-nav-area"" id=""footerNav"">
    <div class=""container h-100 px-0"">
        <div class=""suha-footer-nav h-100"">
            <ul class=""h-100 d-flex align-items-center justify-content-between pl-0"">
                <li class=""active""><a href=""home.html""><i class=""lni lni-home""></i>خانه</a></li>
                <li><a href=""message.html""><i class=""lni lni-life-ring""></i>حمایت کردن</a></li>
                <li><a href=""cart.html""><i class=""lni lni-shopping-basket""></i>سبد خرید</a></li>
                <li><a href=""pages.html""><i class=""lni lni-heart""></i>صفحات</a></li>
                <li><a href=""settings.html""><i class=""lni lni-cog""></i>تنظیمات</a></li>
            </ul>
        </div>
    </div>
</div>

");
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
                success: function (data) {
                    alert(data.msg)

                    if (data.success)
                        $('#get-product-link-' + id).find(""i"").toggleClass(""lni lni-heart lni lni-heart-filled"");
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
            WriteLiteral("\r\n");
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
