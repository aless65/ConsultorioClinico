#pragma checksum "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e427c63da366c290e5c8495790fe1e9dbc93cd0d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e427c63da366c290e5c8495790fe1e9dbc93cd0d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ec2083f7fab0cf3bedd515bf733f4f08ae80541", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\LAB01\Documents\GitHub\ConsultorioClinico\ConsultorioClinico\FrontEnd\ConsultorioFrontEnd\Consultorio.WebUI\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-2"">
        </div>
        <div class=""col-6"">
            <div class=""card"">
                <div class=""card-header"">
                    <h2>Empleados por sexo</h2>
                </div>
                <div class=""card-body"">
                    <div style=""max-width: 500px"" class=""ml-2 mr-2"" >
                        <canvas id=""graficapai""></canvas>
                    </div>
                </div>
            </div>
        </div>

");
            WriteLiteral(@"    </div>
</div>

<script>
    $(document).ready(function () {

        const $grafica = document.querySelector(""#graficapai"");
        const etiquetas = [""Mujer"", ""Hombre""]
        const Cantidad = [];


        $.ajax({
            url: '/Empleado/GraficaSexo',
            data: """",
            dataType: 'json',
            success: function (Grafica) {

                //Declaracion de los arrys
                var i = 0;
                // Agrega las opciones de municipios
                $.each(Grafica, function (index, GraficaS) {
                    i++;
                    Cantidad.push(GraficaS.femenino);
                    Cantidad.push(GraficaS.masculino);

                    console.log(GraficaS.femenino);
                });

                //Grafica

                const datosIngresos = {
                    data: Cantidad, // La data es un arreglo que debe tener la misma cantidad de valores que la cantidad de etiquetas
                    // Ahora debería ha");
            WriteLiteral(@"ber tantos background colors como datos, es decir, para este ejemplo, 4
                    backgroundColor: [
                        'rgba(163,221,203,0.2)',
                        'rgba(232,233,161,0.2)',
                        'rgba(230,181,102,0.2)',
                        'rgba(229,112,126,0.2)',
                    ],// Color de fondo
                    borderColor: [
                        'rgba(163,221,203,1)',
                        'rgba(232,233,161,1)',
                        'rgba(230,181,102,1)',
                        'rgba(229,112,126,1)',
                    ],// Color del borde
                    borderWidth: 1,// Ancho del borde
                };
                new Chart($grafica, {
                    type: 'pie',// Tipo de gráfica. Puede ser dougnhut o pie
                    data: {
                        labels: etiquetas,
                        datasets: [
                            datosIngresos,
                            // Aquí más datos...
    ");
            WriteLiteral(@"                    ]
                    },
                });


            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Error al cargar : ' + textStatus + ', ' + errorThrown);
            }
        });

    });

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
