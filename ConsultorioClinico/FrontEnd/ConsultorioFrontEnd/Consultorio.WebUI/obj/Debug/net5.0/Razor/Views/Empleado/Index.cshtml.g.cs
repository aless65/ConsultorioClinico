#pragma checksum "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "30a427b6889f58eea3e285c39883bf21899aed7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Empleado_Index), @"mvc.1.0.view", @"/Views/Empleado/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30a427b6889f58eea3e285c39883bf21899aed7b", @"/Views/Empleado/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ec2083f7fab0cf3bedd515bf733f4f08ae80541", @"/Views/_ViewImports.cshtml")]
    public class Views_Empleado_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Consultorio.WebUI.Models.EmpleadoViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-header\">\r\n        <h2>Empleados</h2>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        <div id=\"index\">\r\n            <p>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "30a427b6889f58eea3e285c39883bf21899aed7b4614", async() => {
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
#line 18 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.empe_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 21 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.empe_Nombres));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 24 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.empe_Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 27 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.empe_Identidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 30 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.empe_Sexo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 33 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.carg_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>Acciones</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 39 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 43 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.empe_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 46 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.empe_Nombres));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 49 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.empe_Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 52 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.empe_Identidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 55 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.empe_Sexo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 58 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.carg_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");
            WriteLiteral("                                ");
#nullable restore
#line 62 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                           Write(Html.ActionLink("Editar", "Edit", new { id = item.empe_Id }, new { @class = "btn btn-outline-warning" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                ");
#nullable restore
#line 63 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                           Write(Html.ActionLink("Detalles", "Details", new { id = item.empe_Id }, new { @class = "btn btn-outline-dark" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                <button class=\"btn btn-outline-danger Borrar\" data-id=\"");
#nullable restore
#line 64 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                                                                                  Write(item.empe_Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                    Eliminar\r\n                                </button>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 69 "C:\Users\PC\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Empleado\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n");
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "30a427b6889f58eea3e285c39883bf21899aed7b13727", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Consultorio.WebUI.Models.EmpleadoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
