#pragma checksum "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abf6ad70b25b1c6b90dc00f06da0d1c11be1b80e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Factura_Index), @"mvc.1.0.view", @"/Views/Factura/Index.cshtml")]
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
#line 1 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\_ViewImports.cshtml"
using Consultorio.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\_ViewImports.cshtml"
using Consultorio.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abf6ad70b25b1c6b90dc00f06da0d1c11be1b80e", @"/Views/Factura/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ec2083f7fab0cf3bedd515bf733f4f08ae80541", @"/Views/_ViewImports.cshtml")]
    public class Views_Factura_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Consultorio.WebUI.Models.FacturaViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        <h2>Facturas</h2>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        <div id=\"index\">\r\n            <p>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "abf6ad70b25b1c6b90dc00f06da0d1c11be1b80e4526", async() => {
                WriteLiteral("Nuevo");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("            </p>\r\n            <table class=\"table table-striped thead-dark\" id=\"DataTable\">\r\n                <thead>\r\n                    <tr>\r\n                        <th>\r\n                            ");
#nullable restore
#line 22 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.fact_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 25 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.fact_Fecha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 28 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.paci_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 31 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.empe_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 34 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.meto_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>Acciones</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 40 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 44 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.fact_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 47 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.fact_Fecha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 50 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.paci_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 53 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.empe_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 56 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.meto_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 59 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                           Write(Html.ActionLink("Editar", "Edit", new { id=item.fact_Id  }, new { @class = "btn btn-outline-warning" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                ");
#nullable restore
#line 60 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                           Write(Html.ActionLink("Detalles", "Details", new { id=item.fact_Id  }, new { @class = "btn btn-outline-dark" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                ");
#nullable restore
#line 61 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                           Write(Html.ActionLink("Eliminar", "Delete", new { id=item.fact_Id }, new { @class = "btn btn-outline-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 64 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Factura\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n");
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Consultorio.WebUI.Models.FacturaViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591