#pragma checksum "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\Home\onlinePayment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e5c37ca2d88508ceefe6b3a288f962e5404c6b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_onlinePayment), @"mvc.1.0.view", @"/Views/Home/onlinePayment.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e5c37ca2d88508ceefe6b3a288f962e5404c6b8", @"/Views/Home/onlinePayment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_onlinePayment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\Home\onlinePayment.cshtml"
  
    ViewData["Title"] = "نتیجه پرداخت";

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
<!-- Order/Payment Success-->
<div class=""order-success-wrapper"">
    <div class=""content"">
        <i class=""lni lni-checkmark-circle""></i>
");
#nullable restore
#line 16 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\Home\onlinePayment.cshtml"
         if (ViewBag.IsSuccess == true)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h2>پرداخت با موفقیت انجام شد</h2>\r\n            <p>کد پیگیری :");
#nullable restore
#line 19 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\Home\onlinePayment.cshtml"
                     Write(ViewBag.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <a class=\"btn btn-warning mt-3\" href=\"/UserPanel/Wallet\">ورود به کیف پول</a>\r\n");
#nullable restore
#line 21 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\Home\onlinePayment.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h2> پرداخت با شکست مواجه شد</h2>\r\n            <a class=\"btn btn-warning mt-3\" href=\"/UserPanel/Wallet\">ورود به کیف پول</a>\r\n");
#nullable restore
#line 26 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\Home\onlinePayment.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
