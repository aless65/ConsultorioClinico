﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace ConsultorioClinico.Entities.Entities
{
    public partial class VW_tbFacturas_tbFacturasDetalles
    {
        public int fact_Id { get; set; }
        public DateTime fact_Fecha { get; set; }
        public int paci_Id { get; set; }
        public int empe_Id { get; set; }
        public int meto_Id { get; set; }
        public int fact_UsuCreacion { get; set; }
        public DateTime fact_FechaCreacion { get; set; }
        public int? fact_UsuModificacion { get; set; }
        public DateTime? fact_FechaModificacion { get; set; }
        public bool fact_Estado { get; set; }
        public int? factdeta_Id { get; set; }
        public int? cons_Id { get; set; }
        public decimal? cons_Costo { get; set; }
        public string cons_Nombre { get; set; }
        public int? factdeta_UsuCreacion { get; set; }
        public DateTime? factdeta_FechaCreacion { get; set; }
    }
}