﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace ConsultorioClinico.Entities.Entities
{
    public partial class VW_tbCargos
    {
        public int carg_Id { get; set; }
        public string carg_Nombre { get; set; }
        public int carg_UsuCreacion { get; set; }
        public string carg_UsuCreacionNombre { get; set; }
        public DateTime carg_FechaCreacion { get; set; }
        public int? carg_UsuModificacion { get; set; }
        public string carg_UsuModificacionNombre { get; set; }
        public DateTime? carg_FechaModificacion { get; set; }
        public bool carg_Estado { get; set; }
    }
}