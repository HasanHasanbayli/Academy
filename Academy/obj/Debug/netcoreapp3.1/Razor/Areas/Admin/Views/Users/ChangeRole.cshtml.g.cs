#pragma checksum "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Areas\Admin\Views\Users\ChangeRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96f8322c639c979504390f188c1112bade3b333b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_ChangeRole), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/ChangeRole.cshtml")]
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
#line 1 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Areas\Admin\Views\_ViewImports.cshtml"
using Academy.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Areas\Admin\Views\_ViewImports.cshtml"
using Academy.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96f8322c639c979504390f188c1112bade3b333b", @"/Areas/Admin/Views/Users/ChangeRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db5be04b577d59ed8f02d0845c4798ccb2d3669f", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Users_ChangeRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Areas\Admin\Views\Users\ChangeRole.cshtml"
  
    ViewData["Title"] = "ChangeRole";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row m-3\">\r\n    <div class=\"col-6\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96f8322c639c979504390f188c1112bade3b333b3987", async() => {
                WriteLiteral("\r\n            <label");
                BeginWriteAttribute("class", " class=\"", 223, "\"", 231, 0);
                EndWriteAttribute();
                WriteLiteral(" style=\"font-size:30px\">Roles</label>\r\n");
#nullable restore
#line 11 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Areas\Admin\Views\Users\ChangeRole.cshtml"
             foreach (var item in Model.Roles)
            {
                if (item == Model.Role)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"form-group\">\r\n                        <input type=\"radio\" checked");
                BeginWriteAttribute("value", " value=\"", 491, "\"", 504, 1);
#nullable restore
#line 16 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Areas\Admin\Views\Users\ChangeRole.cshtml"
WriteAttributeValue("", 499, item, 499, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"font-size:large\" name=\"Role\"> ");
#nullable restore
#line 16 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Areas\Admin\Views\Users\ChangeRole.cshtml"
                                                                                                  Write(item);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 18 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Areas\Admin\Views\Users\ChangeRole.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"form-group\">\r\n                        <input type=\"radio\"");
                BeginWriteAttribute("value", " value=\"", 727, "\"", 740, 1);
#nullable restore
#line 22 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Areas\Admin\Views\Users\ChangeRole.cshtml"
WriteAttributeValue("", 735, item, 735, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"Role\">");
#nullable restore
#line 22 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Areas\Admin\Views\Users\ChangeRole.cshtml"
                                                                 Write(item);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 24 "C:\Users\Hasan Hasanbayli\Desktop\Docs\Academy\Academy\Areas\Admin\Views\Users\ChangeRole.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("            <button type=\"submit\" class=\"btn btn-primary my-1\">Change Role</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n<!-- Default unchecked -->\r\n\r\n\r\n<!-- Default checked -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
