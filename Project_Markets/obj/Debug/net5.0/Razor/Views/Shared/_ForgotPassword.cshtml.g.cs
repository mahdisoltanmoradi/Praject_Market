#pragma checksum "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_ForgotPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18019c22ca4872baa8761104cd712d311d757639"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ForgotPassword), @"mvc.1.0.view", @"/Views/Shared/_ForgotPassword.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18019c22ca4872baa8761104cd712d311d757639", @"/Views/Shared/_ForgotPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ForgotPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.User.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div style=\"direction:rtl; padding:20px\">\r\n        <h2>");
#nullable restore
#line 4 "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_ForgotPassword.cshtml"
       Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" عزیز</h2>\r\n        <p>جهت بازیابی حساب کاربری خود روی لینک زیر کلیک کنید</p>\r\n        <p>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 209, "\"", 290, 2);
            WriteAttributeValue("", 216, "https://localhost:5002/Account/ResetForgotPassword?token=", 216, 57, true);
#nullable restore
#line 7 "D:\programing\Core\Project_Markets\Project_Markets\Views\Shared\_ForgotPassword.cshtml"
WriteAttributeValue("", 273, Model.ActiveCode, 273, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">بازیابی کلمه عبور</a>\r\n        </p>\r\n    </div>  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.User.User> Html { get; private set; }
    }
}
#pragma warning restore 1591