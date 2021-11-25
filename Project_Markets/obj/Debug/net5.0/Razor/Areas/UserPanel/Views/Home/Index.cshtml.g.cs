#pragma checksum "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7094cf9e6d09c290240f11d4f409c780efa72a26"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserPanel_Views_Home_Index), @"mvc.1.0.view", @"/Areas/UserPanel/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Home\Index.cshtml"
using Common.Utilities.Convertors;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7094cf9e6d09c290240f11d4f409c780efa72a26", @"/Areas/UserPanel/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Areas/UserPanel/Views/_ViewImports.cshtml")]
    public class Areas_UserPanel_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Data.DTOs.InformationUserViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";

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
            BeginWriteAttribute("alt", " alt=\"", 562, "\"", 568, 0);
            EndWriteAttribute();
            WriteLiteral(@"></a></div>
        <!-- Search Form-->
        <div class=""top-search-form"">
            <p>اطلاعات کاربری</p>
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
            BeginWriteAttribute("alt", " alt=\"", 1162, "\"", 1168, 0);
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
<div class=""page-content-wrapper"">
    <div class=""container"">
        <!-- Profile Wrapper-->
        <div class=""profile-wrapper-area py-3"">
            <!-- User Information-->
            <div class=""card user-info-card"">
             ");
            WriteLiteral("   <div class=\"card-body p-4 d-flex align-items-center\">\r\n                    <div class=\"user-profile mr-3\"><img");
            BeginWriteAttribute("src", " src=\"", 3330, "\"", 3385, 2);
            WriteAttributeValue("", 3336, "/ImageProductCategory/UserImage/", 3336, 32, true);
#nullable restore
#line 72 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Home\Index.cshtml"
WriteAttributeValue("", 3368, Model.UserAvatar, 3368, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid w-100 h-100\"");
            BeginWriteAttribute("alt", " alt=\"", 3416, "\"", 3422, 0);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                    <div class=\"user-info\">\r\n                        <p class=\"mb-0 text-white\"> </p>\r\n                        <h5 class=\"mb-0\">");
#nullable restore
#line 75 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Home\Index.cshtml"
                                    Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                    </div>
                </div>
            </div>
            <!-- User Meta Data-->
            <div class=""card user-data-card"">
                <div class=""card-body"">
                    <div class=""single-profile-data d-flex align-items-center justify-content-between"">
                        <div class=""title d-flex align-items-center""><i class=""lni lni-user""></i><span>نام کاربری</span></div>
                        <div class=""data-content"">");
#nullable restore
#line 84 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Home\Index.cshtml"
                                             Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    </div>

                    <div class=""single-profile-data d-flex align-items-center justify-content-between"">
                        <div class=""title d-flex align-items-center""><i class=""lni lni-envelope""></i><span>آدرس ایمیل</span></div>
                        <div class=""data-content"">");
#nullable restore
#line 89 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Home\Index.cshtml"
                                             Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    </div>
                    <div class=""single-profile-data d-flex align-items-center justify-content-between"">
                        <div class=""title d-flex align-items-center""><i class=""lni lni-map-marker""></i><span>تاریخ عضویت در سایت:</span></div>
                        <div class=""data-content"">");
#nullable restore
#line 93 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Home\Index.cshtml"
                                             Write(Model.RegisterDate.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    </div>
                    <div class=""single-profile-data d-flex align-items-center justify-content-between"">
                        <div class=""title d-flex align-items-center""><i class=""lni lni-star""></i><span>سفارش من</span></div>
                        <div class=""data-content""><a class=""btn btn-danger btn-sm""");
            BeginWriteAttribute("href", " href=\"", 5143, "\"", 5150, 0);
            EndWriteAttribute();
            WriteLiteral(@">نمایش</a></div>
                    </div>
                    <!-- Edit Profile-->
                    <div class=""edit-profile-btn mt-3""><a class=""btn btn-info w-100"" href=""/UserPanel/EditProfile""><i class=""lni lni-pencil mr-2""></i>ویرایش اطلاعات</a></div>

                </div>
            </div>
            <p></p>
            <!-- Cart Amount Area-->
            <div class=""card cart-amount-area"">
                <div class=""card-body d-flex align-items-center justify-content-between"">
                    <h5 class=""total-price mb-0 text-center"">موجودی حساب</h5>
                    <h5 class=""total-price mb-0 text-center""><span class=""counter"">");
#nullable restore
#line 109 "D:\programing\Core\Project_Markets\Project_Markets\Areas\UserPanel\Views\Home\Index.cshtml"
                                                                              Write(Model.Wallet);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span> تومان</h5>

                </div>
                <div class=""edit-profile-btn mt-3""><a class=""btn btn-outline-primary w-100"" href=""/UserPanel/Wallet""><i class=""lni lni-credit-cards mr-2""></i>کیف پول</a></div>
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
                <li><a href=""");
            WriteLiteral("settings.html\"><i class=\"lni lni-cog\"></i>تنظیمات</a></li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Data.DTOs.InformationUserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591