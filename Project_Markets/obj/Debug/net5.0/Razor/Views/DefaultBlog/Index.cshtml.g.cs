#pragma checksum "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\DefaultBlog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1403d8782d9e7d57c9ad1cea9b6bab9ebb5709a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DefaultBlog_Index), @"mvc.1.0.view", @"/Views/DefaultBlog/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1403d8782d9e7d57c9ad1cea9b6bab9ebb5709a", @"/Views/DefaultBlog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_DefaultBlog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.Blog.Blogs>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\DefaultBlog\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""header-area"" id=""headerArea"">
    <div class=""container h-100 d-flex align-items-center justify-content-between"">
        <!-- Back Button-->
        <div class=""back-button""><a href=""/""><i class=""lni lni-arrow-right""></i></a></div>
        <!-- Page Title-->
        <div class=""page-heading"">
            <h6 class=""mb-0"">لیست وبلاگ</h6>
        </div>
        <!-- Navbar Toggler-->
        <div class=""suha-navbar-toggler d-flex justify-content-between flex-wrap"" id=""suhaNavbarToggler""><span></span><span></span><span></span></div>
    </div>
</div>

<div class=""top-products-area py-3"">
    <div class=""container"">
        <div class=""section-heading d-flex align-items-center justify-content-between"">
            <h6 class=""ml-1"">لیست وبلاگ</h6>
            <!-- Layout Options-->
            <div class=""layout-options""><a href=""blog-grid.html""><i class=""lni lni-grid-alt""></i></a><a class=""active"" href=""blog-list.html""><i class=""lni lni-radio-button""></i></a></div>
        </div>");
            WriteLiteral("\r\n        <!-- Search Form-->\r\n        <div class=\"top-search-form\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a1403d8782d9e7d57c9ad1cea9b6bab9ebb5709a5001", async() => {
                WriteLiteral("\r\n                <input class=\"form-control\"name=\"filterBlogs\" type=\"search\" placeholder=\"جستوجو\">\r\n                <button type=\"submit\"><i class=\"fa fa-search\"></i></button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <div class=\"product-section w-100 d-flex justify-content-center align-items-center text-center  flex-wrap col-12\">\r\n");
#nullable restore
#line 34 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\DefaultBlog\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <!-- Single Blog Card-->
                <div class=""col-12 col-md-4 px-1 my-2"">
                    <div class=""card blog-card list-card"">
                        <!-- Post Image-->
                        <div class=""post-img col-12 w-100 h-100""><img class=""card-img img-fluid"" style=""width:300px; height:200px""");
            BeginWriteAttribute("src", " src=\"", 1951, "\"", 1984, 2);
            WriteAttributeValue("", 1957, "/img/bg-img/", 1957, 12, true);
#nullable restore
#line 40 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\DefaultBlog\Index.cshtml"
WriteAttributeValue("", 1969, item.ImageName, 1969, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1985, "\"", 1991, 0);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                        <!-- Post Bookmark--><a class=\"post-bookmark\" href=\"#\"><i class=\"lni lni-bookmark\"></i></a>\r\n                        <!-- Read More Button--><a class=\"btn btn-danger btn-sm read-more-btn\"");
            BeginWriteAttribute("href", " href=\"", 2212, "\"", 2259, 2);
            WriteAttributeValue("", 2219, "/DefaultBlog/GetBlogInformation/", 2219, 32, true);
#nullable restore
#line 42 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\DefaultBlog\Index.cshtml"
WriteAttributeValue("", 2251, item.Id, 2251, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">بیشتر بخوانید</a>
                        <!-- Post Content-->
                        <div class=""post-content"">
                            <div class=""bg-shapes"">
                                <div class=""circle1""></div>
                                <div class=""circle2""></div>
                                <div class=""circle3""></div>
                                <div class=""circle4""></div>
                            </div>
                            <!-- Post Catagory--><a class=""post-catagory d-block"">عنوان</a>
                            <!-- Post Title--><a class=""post-title d-block"" href=""blog-details.html"">");
#nullable restore
#line 52 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\DefaultBlog\Index.cshtml"
                                                                                                Write(item.BlogTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                            <!-- Post Meta-->
                            <div class=""post-meta d-flex align-items-center justify-content-between flex-wrap""><a href=""#""><i class=""lni lni-user""></i>یاسین</a><span><i class=""lni lni-timer""></i>2 دقیقه</span></div>
                        </div>
                    </div>
                </div>
                <!-- end Single Blog Card-->
");
#nullable restore
#line 59 "C:\Users\soltanmoradi\source\repos\Praject_Market\Project_Markets\Views\DefaultBlog\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities.Blog.Blogs>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
