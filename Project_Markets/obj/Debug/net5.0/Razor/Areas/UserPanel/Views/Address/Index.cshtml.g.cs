#pragma checksum "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Address\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "318ac74d607a41192e7d827afc1eb025e9a60606"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserPanel_Views_Address_Index), @"mvc.1.0.view", @"/Areas/UserPanel/Views/Address/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"318ac74d607a41192e7d827afc1eb025e9a60606", @"/Areas/UserPanel/Views/Address/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Areas/UserPanel/Views/_ViewImports.cshtml")]
    public class Areas_UserPanel_Views_Address_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Data.DTOs.Address.UserAddressDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("add-address"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddNewAddress", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Address", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "UserPanel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Address\Index.cshtml"
  
    ViewData["Title"] = "آدرس ها";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""preloader"" id=""preloader"">
    <div class=""spinner-grow text-secondary"" role=""status"">
        <div class=""sr-only"">بارگذاری...</div>
    </div>
</div>
<!-- Header Area-->
<div class=""header-area"" id=""headerArea"">
    <div class=""container h-100 d-flex align-items-center justify-content-between"">
        <!-- Logo Wrapper-->
        <div class=""logo-wrapper""><a href=""home.html""><img src=""img/core-img/logo-small.png""");
            BeginWriteAttribute("alt", " alt=\"", 539, "\"", 545, 0);
            EndWriteAttribute();
            WriteLiteral(@"></a></div>
        <!-- Search Form-->
        <div class=""top-search-form"">
            <p>همه آدرس ها</p>
        </div>
        <!-- Navbar Toggler-->
        <div class=""suha-navbar-toggler d-flex flex-wrap"" id=""suhaNavbarToggler""><span></span><span></span><span></span></div>
    </div>
</div>
<!-- Sidenav Black Overlay-->
<div class=""sidenav-black-overlay""></div>
<!-- Side Nav Wrapper-->
<div class=""suha-sidenav-wrapper"" id=""sidenavWrapper"">
    <!-- Sidenav Profile-->
    <div class=""sidenav-profile"">
        <div class=""user-profile""><img src=""img/bg-img/9.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 1136, "\"", 1142, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div>
        <div class=""user-info"">
            <h6 class=""user-name mb-0"">نیلوفر</h6>
            <p class=""available-balance"">حساب شما <span><span class=""counter"">350000</span></span><span> تومان</span></p>
        </div>
    </div>
    <!-- Sidenav Nav-->
    <ul class=""sidenav-nav pl-0"">
        <li><a href=""/UserPanel/Index""><i class=""lni lni-user""></i>پروفایل من</a></li>
        <li><a href=""notifications.html""><i class=""lni lni-alarm lni-tada-effect""></i>اطلاعیه ها <span class=""ml-3 badge badge-warning"">3</span></a></li>
        <li class=""suha-dropdown-menu"">
            <a href=""#""><i class=""lni lni-cart""></i>صفحات خرید</a>
            <ul>
                <li><a href=""shop-grid.html"">- فروشگاه شبکه</a></li>
                <li><a href=""shop-list.html"">- لیست فروشگاه</a></li>
                <li><a href=""single-product.html"">- مشخصات محصول</a></li>
                <li><a href=""featured-products.html"">- محصولات برجسته</a></li>
                <li><a href=""flash-sale.html"">- فروش ف");
            WriteLiteral(@"لش</a></li>
            </ul>
        </li>
        <li><a href=""pages.html""><i class=""lni lni-empty-file""></i>تمام صفحات</a></li>
        <li class=""suha-dropdown-menu"">
            <a href=""wishlist-grid.html""><i class=""lni lni-heart""></i>علاقه مندی های من</a>
            <ul>
                <li><a href=""wishlist-grid.html"">- شبکه مورد علاقه</a></li>
                <li><a href=""wishlist-list.html"">- لیست دلخواه</a></li>
            </ul>
        </li>
        <li><a href=""settings.html""><i class=""lni lni-cog""></i>تنظیمات</a></li>
        <li><a href=""intro.html""><i class=""lni lni-power-switch""></i>خروج از سیستم</a></li>
    </ul>
    <!-- Go Back Button-->
    <div class=""go-home-btn"" id=""goHomeBtn""><i class=""lni lni-arrow-right""></i></div>
</div>
<div class=""card cart-amount-area"">
    <div style=""margin:3rem;box-sizing:border-box"" class=""card-body d-flex align-items-center justify-content-between"">
        

    </div>
    <div class=""checkout-section shadow-around"">
        <div ");
            WriteLiteral("class=\"checkout-section-content\">\r\n            <div class=\"row mx-0\">\r\n\r\n");
#nullable restore
#line 73 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Address\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col-xl-3 col-lg-4 col-sm-6 mb-3"">
                        <div class=""custom-control custom-radio"">
                            <input type=""radio"" id=""customRadio2"" name=""customRadio"" class=""custom-control-input"">
                            <label class=""custom-control-label address-select"" for=""customRadio2"">
                                <span class=""head-address-select"">به این آدرس ارسال شود</span>
                                <span> ");
#nullable restore
#line 80 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Address\Index.cshtml"
                                  Write(item.PostalAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                                <span>\r\n                                    <i class=\"fa fa-user\"></i>\r\n                                    ");
#nullable restore
#line 83 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Address\Index.cshtml"
                               Write(item.ReciverName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </span>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 4077, "\"", 4116, 2);
            WriteAttributeValue("", 4084, "/UserPanel/Address/Edit/", 4084, 24, true);
#nullable restore
#line 85 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Address\Index.cshtml"
WriteAttributeValue("", 4108, item.Id, 4108, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""color:aqua"" class=""link--with-border-bottom edit-address-btn"" data-toggle=""modal"" data-target=""#editAddressModal"">

                                    <i class=""fa fa-edit""></i>
                                </a>
                                <span style=""width:10px""> </span>
                                <a");
            BeginWriteAttribute("href", " href=\"", 4446, "\"", 4487, 2);
            WriteAttributeValue("", 4453, "/UserPanel/Address/Delete/", 4453, 26, true);
#nullable restore
#line 90 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Address\Index.cshtml"
WriteAttributeValue("", 4479, item.Id, 4479, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""color:red"" class=""link--with-border-bottom Delete-address-btn"" data-toggle=""modal"" data-target=""#editAddressModal"">

                                    <i class=""fa fa-remove""></i>
                                </a>
                            </label>
                        </div>
                    </div>
");
#nullable restore
#line 97 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Address\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"col-xl-3 col-lg-4 col-sm-6 mb-3\">\r\n                    <div class=\"custom-control custom-radio\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "318ac74d607a41192e7d827afc1eb025e9a6060611470", async() => {
                WriteLiteral("\r\n                            <i class=\"fa fa-plus\"></i>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>
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
                <li class=""active""><a href=""/""><i class=""lni lni-home""></i>خانه</a></li>
                <li><a href=""#""><i class=""lni lni-life-ring""></i>ارتباط با ما</a></li>
                <li><a href=""/UserPanel/Wallet""><i class=""lni lni-shopping-basket""></i>سبد خرید</a></li>
                <li><a href=""pages.html""><i class=""lni lni-heart""></i>درباره ما</a></li>
                <li><a href=""settings.html""><i class=""lni lni-cog""></i>تنظیمات</a></li>
            </ul>
        </div>
    </div>
</div>


");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Data.DTOs.Address.UserAddressDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
