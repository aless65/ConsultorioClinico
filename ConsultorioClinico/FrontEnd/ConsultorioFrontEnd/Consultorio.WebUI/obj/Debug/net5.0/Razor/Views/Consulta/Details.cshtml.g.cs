#pragma checksum "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90c4f3b0c77215ea61e5875cafa9d0e2983e3614"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Consulta_Details), @"mvc.1.0.view", @"/Views/Consulta/Details.cshtml")]
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
#line 1 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\_ViewImports.cshtml"
using Consultorio.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\_ViewImports.cshtml"
using Consultorio.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90c4f3b0c77215ea61e5875cafa9d0e2983e3614", @"/Views/Consulta/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ec2083f7fab0cf3bedd515bf733f4f08ae80541", @"/Views/_ViewImports.cshtml")]
    public class Views_Consulta_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Consultorio.WebUI.Models.ConsultaViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>ConsultaViewModel</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cons_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayFor(model => model.cons_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cons_Inicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayFor(model => model.cons_Inicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cons_Final));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayFor(model => model.cons_Final));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.paci_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayFor(model => model.paci_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.consltro_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayFor(model => model.consltro_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cons_Costo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayFor(model => model.cons_Costo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cons_UsuCreacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayFor(model => model.cons_UsuCreacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cons_FechaCreacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayFor(model => model.cons_FechaCreacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cons_UsuModificacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayFor(model => model.cons_UsuModificacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cons_FechaModificacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayFor(model => model.cons_FechaModificacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 75 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cons_Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 78 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
       Write(Html.DisplayFor(model => model.cons_Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 83 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Consulta\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90c4f3b0c77215ea61e5875cafa9d0e2983e361413044", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Consultorio.WebUI.Models.ConsultaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
