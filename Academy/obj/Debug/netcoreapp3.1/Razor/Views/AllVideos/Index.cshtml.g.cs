#pragma checksum "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\AllVideos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc20d1f2b15254e2f715b96a62815270d21c2e41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AllVideos_Index), @"mvc.1.0.view", @"/Views/AllVideos/Index.cshtml")]
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
#line 1 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\_ViewImports.cshtml"
using Academy.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\_ViewImports.cshtml"
using Academy.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc20d1f2b15254e2f715b96a62815270d21c2e41", @"/Views/AllVideos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db5be04b577d59ed8f02d0845c4798ccb2d3669f", @"/Views/_ViewImports.cshtml")]
    public class Views_AllVideos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Videos>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\AllVideos\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""site-section ftco-subscribe-1 site-blocks-cover pb-4"" style=""background-image: url('images/bg_1.jpg')"">
    <div class=""container"">
        <div class=""row align-items-end"">
            <div class=""col-lg-7"">
                <h2 class=""mb-0"">Videos</h2>
                <p>Lorem ipsum dolor sit amet consectetur adipisicing.</p>
            </div>
        </div>
    </div>
</div>


<div class=""custom-breadcrumns border-bottom"">
    <div class=""container"">
        <a href=""index.html"">Home</a>
        <span class=""mx-3 icon-keyboard_arrow_right""></span>
        <span class=""current"">Videos</span>
    </div>
</div>

<div class=""row mb-5 justify-content-center text-center"">
    <div class=""col-lg-4 mb-5"">
        <h2 class=""section-title-underline mb-5"">
            <span>Videos</span>
        </h2>
    </div>
</div>
<div class=""container"">
    <div class=""row"">
");
#nullable restore
#line 36 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\AllVideos\Index.cshtml"
         foreach (Videos videos in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-4\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1138, "\"", 1158, 1);
#nullable restore
#line 39 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\AllVideos\Index.cshtml"
WriteAttributeValue("", 1145, videos.Video, 1145, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"video-1 mb-4\" data-fancybox=\"\" data-ratio=\"2\">\r\n                    <span class=\"play\">\r\n                        <span class=\"icon-play\"></span>\r\n                    </span>\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 1366, "\"", 1399, 2);
            WriteAttributeValue("", 1372, "images/videos/", 1372, 14, true);
#nullable restore
#line 43 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\AllVideos\Index.cshtml"
WriteAttributeValue("", 1386, videos.Image, 1386, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Image\" class=\"img-fluid\">\r\n                </a>\r\n            </div>\r\n");
#nullable restore
#line 46 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\AllVideos\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Videos>> Html { get; private set; }
    }
}
#pragma warning restore 1591