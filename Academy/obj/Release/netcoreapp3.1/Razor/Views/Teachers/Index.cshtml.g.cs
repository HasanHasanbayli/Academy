#pragma checksum "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Teachers\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2721e23901c31a2b7221a5463fd1be5570dd3363"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teachers_Index), @"mvc.1.0.view", @"/Views/Teachers/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2721e23901c31a2b7221a5463fd1be5570dd3363", @"/Views/Teachers/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db5be04b577d59ed8f02d0845c4798ccb2d3669f", @"/Views/_ViewImports.cshtml")]
    public class Views_Teachers_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Teacher>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Teachers\Index.cshtml"
  
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
                <h2 class=""mb-0"">Teachers</h2>
                <p>Lorem ipsum dolor sit amet consectetur adipisicing.</p>
            </div>
        </div>
    </div>
</div>


<div class=""custom-breadcrumns border-bottom"">
    <div class=""container"">
        <a href=""#"">Home</a>
        <span class=""mx-3 icon-keyboard_arrow_right""></span>
        <span class=""current"">Teachers</span>
    </div>
</div>

<div class=""site-section"">
    <div class=""container"">
        <div class=""row mb-5 justify-content-center text-center"">
            <div class=""col-lg-4 mb-5"">
                <h2 class=""section-title-underline mb-5"">
                    <span>Our Teachers</span>
                </h2>
            </div>
        </div>
        <div class=""row"">
");
#nullable restore
#line 37 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Teachers\Index.cshtml"
             foreach (Teacher teacher in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-4 col-md-6 mb-5 mb-lg-5\">\r\n\r\n                    <div class=\"feature-1 border person text-center\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1351, "\"", 1387, 2);
            WriteAttributeValue("", 1357, "images/teachers/", 1357, 16, true);
#nullable restore
#line 42 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Teachers\Index.cshtml"
WriteAttributeValue("", 1373, teacher.Image, 1373, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Image\" class=\"img-fluid\">\r\n                        <div class=\"feature-1-content\">\r\n                            <h2>");
#nullable restore
#line 44 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Teachers\Index.cshtml"
                           Write(teacher.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                            <p class=\"position mb-3 d-block\">");
#nullable restore
#line 45 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Teachers\Index.cshtml"
                                                        Write(teacher.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p>");
#nullable restore
#line 46 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Teachers\Index.cshtml"
                          Write(teacher.About);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 50 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Views\Teachers\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
    </div>
</div>

<div class=""site-section ftco-subscribe-1"" style=""background-image: url('images/bg_1.jpg')"">
    <div class=""container"">
        <div class=""row align-items-center"">
            <div class=""col-lg-7"">
                <h2>Subscribe to us!</h2>
                <p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia,</p>
            </div>
            <div class=""col-lg-5"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2721e23901c31a2b7221a5463fd1be5570dd33637906", async() => {
                WriteLiteral("\r\n                    <input type=\"text\" class=\"rounded form-control mr-2 py-3\" placeholder=\"Enter your email\">\r\n                    <button class=\"btn btn-primary rounded py-3 px-4\" type=\"submit\">Send</button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Teacher>> Html { get; private set; }
    }
}
#pragma warning restore 1591