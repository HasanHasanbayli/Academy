#pragma checksum "C:\Users\Hasan Hasanbayli\Desktop\Academy\Academy\Views\Courses\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55e20d48e2f7d9b639c17d04d14c6c6528859e14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Courses_Index), @"mvc.1.0.view", @"/Views/Courses/Index.cshtml")]
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
#line 1 "C:\Users\Hasan Hasanbayli\Desktop\Academy\Academy\Views\_ViewImports.cshtml"
using Academy.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hasan Hasanbayli\Desktop\Academy\Academy\Views\_ViewImports.cshtml"
using Academy.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55e20d48e2f7d9b639c17d04d14c6c6528859e14", @"/Views/Courses/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db5be04b577d59ed8f02d0845c4798ccb2d3669f", @"/Views/_ViewImports.cshtml")]
    public class Views_Courses_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Hasan Hasanbayli\Desktop\Academy\Academy\Views\Courses\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""site-section ftco-subscribe-1 site-blocks-cover pb-4"" style=""background-image: url('images/bg_1.jpg')"">
    <div class=""container"">
        <div class=""row align-items-end"">
            <div class=""col-lg-7"">
                <h2 class=""mb-0"">Courses</h2>
                <p>Lorem ipsum dolor sit amet consectetur adipisicing.</p>
            </div>
        </div>
    </div>
</div>

<div class=""custom-breadcrumns border-bottom"">
    <div class=""container"">
        <a href=""index.html"">Home</a>
        <span class=""mx-3 icon-keyboard_arrow_right""></span>
        <span class=""current"">Courses</span>
    </div>
</div>

<div class=""site-section"">
    <div class=""container"">
        <div class=""row"">
            ");
#nullable restore
#line 28 "C:\Users\Hasan Hasanbayli\Desktop\Academy\Academy\Views\Courses\Index.cshtml"
       Write(await Component.InvokeAsync("Courses"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 33 "C:\Users\Hasan Hasanbayli\Desktop\Academy\Academy\Views\Courses\Index.cshtml"
Write(await Component.InvokeAsync("Detail"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
