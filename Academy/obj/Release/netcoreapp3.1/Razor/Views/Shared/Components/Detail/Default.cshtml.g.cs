#pragma checksum "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Shared\Components\Detail\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07b03bb0eb165a3646ba0bbc49479d1d3ccb9a7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Detail_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Detail/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07b03bb0eb165a3646ba0bbc49479d1d3ccb9a7c", @"/Views/Shared/Components/Detail/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db5be04b577d59ed8f02d0845c4798ccb2d3669f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Detail_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Detail>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Shared\Components\Detail\Default.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Shared\Components\Detail\Default.cshtml"
 if (@Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"section-bg style-1\" style=\"background-image: url(\'images/hero_1.jpg\');\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n");
#nullable restore
#line 10 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Shared\Components\Detail\Default.cshtml"
                 foreach (Detail detail in Model.Take(3))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-lg-4 col-md-6 mb-5 mb-lg-0\">\r\n                        <span");
            BeginWriteAttribute("class", " class=\"", 411, "\"", 431, 1);
#nullable restore
#line 13 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Shared\Components\Detail\Default.cshtml"
WriteAttributeValue("", 419, detail.Icon, 419, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></span>\r\n                        <h3>");
#nullable restore
#line 14 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Shared\Components\Detail\Default.cshtml"
                       Write(detail.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <p>\r\n                            ");
#nullable restore
#line 16 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Shared\Components\Detail\Default.cshtml"
                       Write(detail.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                    </div>\r\n");
#nullable restore
#line 19 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Shared\Components\Detail\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 23 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Shared\Components\Detail\Default.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Detail>> Html { get; private set; }
    }
}
#pragma warning restore 1591
