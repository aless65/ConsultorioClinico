﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace ConsultorioClinico.Entities.Entities
{
    public partial class tbEstadosCiviles
    {
        public tbEstadosCiviles()
        {
            tbEmpleados = new HashSet<tbEmpleados>();
            tbPacientes = new HashSet<tbPacientes>();
        }

        public int estacivi_Id { get; set; }
        public string estacivi_Nombre { get; set; }
        public int estacivi_UsuCreacion { get; set; }
        public DateTime estacivi_FechaCreacion { get; set; }
        public int? estacivi_UsuModificacion { get; set; }
        public DateTime? estacivi_FechaModificacion { get; set; }
        public bool? estacivi_Estado { get; set; }

        public virtual tbUsuarios estacivi_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios estacivi_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbEmpleados> tbEmpleados { get; set; }
        public virtual ICollection<tbPacientes> tbPacientes { get; set; }
    }
}