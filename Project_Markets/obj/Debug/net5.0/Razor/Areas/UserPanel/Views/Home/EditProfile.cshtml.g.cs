#pragma checksum "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Areas\UserPanel\Views\Home\EditProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b78e3a839ee9ed6acd00785b7d2a96eb2a4ae81c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserPanel_Views_Home_EditProfile), @"mvc.1.0.view", @"/Areas/UserPanel/Views/Home/EditProfile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b78e3a839ee9ed6acd00785b7d2a96eb2a4ae81c", @"/Areas/UserPanel/Views/Home/EditProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Areas/UserPanel/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_UserPanel_Views_Home_EditProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Data.DTOs.EditProfileViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control-file"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "file", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "email", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Areas\UserPanel\Views\Home\EditProfile.cshtml"
  
    ViewData["Title"] = "EditProfile";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"`
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
        <div class=""back-button""><a href=""profile.html""><i class=""lni lni-arrow-right""></i></a></div>
        <!-- Page Title-->
        <div class=""page-heading"">
            <h6 class=""mb-0"">ویرایش نمایه</h6>
        </div>
        <!-- Navbar Toggler-->
        <div class=""suha-navbar-toggler d-flex justify-content-between flex-wrap"" id=""suhaNavbarToggler""><span></span><span></span><span></span></div>
    </div>
</div>
<!-- Sidenav Black Overlay-->
<div class=""sidenav-black-overlay""></div>
<!-- Side Nav Wrapper-->
<div class=""suha-sidenav-wrapper"" id=""sidenavWrapper"">
    <!-- Sidenav Profile-->
    <div class=""sidenav-profile"">
");
            WriteLiteral("        <div class=\"user-profile\"><img src=\"img/bg-img/9.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 1171, "\"", 1177, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div>
        <div class=""user-info"">
            <h6 class=""user-name mb-0"">نیلوفر</h6>
            <p class=""available-balance"">حساب شما <span><span class=""counter"">350000</span></span><span> تومان</span></p>
        </div>
    </div>
    <!-- Sidenav Nav-->
    <ul class=""sidenav-nav pl-0"">
        <li><a href=""profile.html""><i class=""lni lni-user""></i>پروفایل من</a></li>
        <li><a href=""notifications.html""><i class=""lni lni-alarm lni-tada-effect""></i>اطلاعیه ها <span class=""ml-3 badge badge-warning"">3</span></a></li>
        <li class=""suha-dropdown-menu"">
            <a href=""#""><i class=""lni lni-cart""></i>صفحات خرید</a>
            <ul>
                <li><a href=""shop-grid.html"">- فروشگاه شبکه</a></li>
                <li><a href=""shop-list.html"">- لیست فروشگاه</a></li>
                <li><a href=""single-product.html"">- مشخصات محصول</a></li>
                <li><a href=""featured-products.html"">- محصولات برجسته</a></li>
                <li><a href=""flash-sale.html"">- فروش فلش</");
            WriteLiteral(@"a></li>
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
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b78e3a839ee9ed6acd00785b7d2a96eb2a4ae81c9619", async() => {
                WriteLiteral(@"
                <!-- User Information-->
                <div class=""card user-info-card"">
                    <div class=""card-body p-4 d-flex align-items-center"">
                            <div class=""user-profile mr-3 "">
                                <img");
                BeginWriteAttribute("src", " src=\"", 3479, "\"", 3534, 2);
                WriteAttributeValue("", 3485, "/ImageProductCategory/UserImage/", 3485, 32, true);
#nullable restore
#line 74 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Areas\UserPanel\Views\Home\EditProfile.cshtml"
WriteAttributeValue("", 3517, Model.AvatarName, 3517, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-fluid w-100 h-100\"");
                BeginWriteAttribute("alt", " alt=\"", 3565, "\"", 3571, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <div class=\"change-user-thumb\">\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b78e3a839ee9ed6acd00785b7d2a96eb2a4ae81c10950", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 76 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Areas\UserPanel\Views\Home\EditProfile.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UserAvatar);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <button><i class=""lni lni-pencil""></i></button>
                                </div>
                            </div>
                        <div class=""user-info"">
                            <p class=""mb-0 text-white"">ویرایش پروفایل</p>
                            <h5 class=""mb-0"">");
#nullable restore
#line 82 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Areas\UserPanel\Views\Home\EditProfile.cshtml"
                                        Write(Model.UserName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <!-- User Meta Data-->\r\n                <div class=\"card user-data-card\">\r\n                    <div class=\"card-body\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b78e3a839ee9ed6acd00785b7d2a96eb2a4ae81c13674", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 89 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Areas\UserPanel\Views\Home\EditProfile.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.AvatarName);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <div class=\"mb-3\">\r\n                            <div class=\"title mb-2\"><i class=\"lni lni-user\"></i><span>نام کاربری</span></div>\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b78e3a839ee9ed6acd00785b7d2a96eb2a4ae81c15605", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 92 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Areas\UserPanel\Views\Home\EditProfile.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UserName);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </div>\r\n                        <div class=\"mb-3\">\r\n                            <div class=\"title mb-2\"><i class=\"lni lni-envelope\"></i><span>آدرس ایمیل</span></div>\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b78e3a839ee9ed6acd00785b7d2a96eb2a4ae81c17660", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 96 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Areas\UserPanel\Views\Home\EditProfile.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Email);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </div>\r\n                        <div class=\"mb-3\">\r\n                            <div class=\"title mb-2\"><i class=\"lni lni-map-marker\"></i><span>محل سکونت</span></div>\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b78e3a839ee9ed6acd00785b7d2a96eb2a4ae81c19713", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 100 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Areas\UserPanel\Views\Home\EditProfile.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.lifeLocation);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </div>\r\n                        <button class=\"btn btn-success w-100\" type=\"submit\">ویرایش اطلاعات</button>\r\n                    </div>\r\n                </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
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
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Data.DTOs.EditProfileViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
