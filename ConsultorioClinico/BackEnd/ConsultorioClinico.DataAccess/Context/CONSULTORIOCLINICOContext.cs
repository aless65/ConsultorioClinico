﻿using System;
using ConsultorioClinico.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Consultorio.DataAccess.Context
{
    public partial class CONSULTORIOCLINICOContext : DbContext
    {
        public CONSULTORIOCLINICOContext()
        {
        }

        public CONSULTORIOCLINICOContext(DbContextOptions<CONSULTORIOCLINICOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VW_tbCargos> VW_tbCargos { get; set; }
        public virtual DbSet<VW_tbConsultas> VW_tbConsultas { get; set; }
        public virtual DbSet<VW_tbDepartamentos> VW_tbDepartamentos { get; set; }
        public virtual DbSet<tbAreas> tbAreas { get; set; }
        public virtual DbSet<tbCargos> tbCargos { get; set; }
        public virtual DbSet<tbClinicas> tbClinicas { get; set; }
        public virtual DbSet<tbConsultas> tbConsultas { get; set; }
        public virtual DbSet<tbConsultorios> tbConsultorios { get; set; }
        public virtual DbSet<tbDepartamentos> tbDepartamentos { get; set; }
        public virtual DbSet<tbEmpleados> tbEmpleados { get; set; }
        public virtual DbSet<tbEstadosCiviles> tbEstadosCiviles { get; set; }
        public virtual DbSet<tbFacturas> tbFacturas { get; set; }
        public virtual DbSet<tbFacturasDetalles> tbFacturasDetalles { get; set; }
        public virtual DbSet<tbMedicamentos> tbMedicamentos { get; set; }
        public virtual DbSet<tbMetodosPago> tbMetodosPago { get; set; }
        public virtual DbSet<tbMunicipios> tbMunicipios { get; set; }
        public virtual DbSet<tbPacientes> tbPacientes { get; set; }
        public virtual DbSet<tbPantallas> tbPantallas { get; set; }
        public virtual DbSet<tbPantallasPorRoles> tbPantallasPorRoles { get; set; }
        public virtual DbSet<tbProveedores> tbProveedores { get; set; }
        public virtual DbSet<tbRoles> tbRoles { get; set; }
        public virtual DbSet<tbUsuarios> tbUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<VW_tbCargos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_tbCargos", "cons");

                entity.Property(e => e.carg_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.carg_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.carg_Nombre)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.carg_UsuCreacionNombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.carg_UsuModificacionNombre).HasMaxLength(100);
            });

            modelBuilder.Entity<VW_tbConsultas>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_tbConsultas", "cons");

                entity.Property(e => e.cons_Costo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.cons_Final).HasColumnType("datetime");

                entity.Property(e => e.cons_Inicio).HasColumnType("datetime");

                entity.Property(e => e.cons_Paciente)
                    .IsRequired()
                    .HasMaxLength(401);

                entity.Property(e => e.cons_UsuarioCreacionNombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.cons_UsuarioModificacionNombre).HasMaxLength(100);

                entity.Property(e => e.consltro_Nombre)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<VW_tbDepartamentos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_tbDepartamentos", "gral");

                entity.Property(e => e.depa_FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.depa_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.depa_Id)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.depa_Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.depa_UsuCreacionNombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.depa_UsuModificacionNombre).HasMaxLength(100);
            });

            modelBuilder.Entity<tbAreas>(entity =>
            {
                entity.HasKey(e => e.area_Id)
                    .HasName("PK_tbAreas_area_Id");

                entity.ToTable("tbAreas", "cons");

                entity.Property(e => e.area_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.area_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.area_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.area_Nombre)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.area_UsuCreacionNavigation)
                    .WithMany(p => p.tbAreasarea_UsuCreacionNavigation)
                    .HasForeignKey(d => d.area_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbAreas_tbUsuarios_area_UsuCreacion_user_Id");

                entity.HasOne(d => d.area_UsuModificacionNavigation)
                    .WithMany(p => p.tbAreasarea_UsuModificacionNavigation)
                    .HasForeignKey(d => d.area_UsuModificacion)
                    .HasConstraintName("FK_tbAreas_tbUsuarios_area_UsuModificacion_user_Id");
            });

            modelBuilder.Entity<tbCargos>(entity =>
            {
                entity.HasKey(e => e.carg_Id)
                    .HasName("PK_tbCargos_carg_Id");

                entity.ToTable("tbCargos", "cons");

                entity.Property(e => e.carg_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.carg_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.carg_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.carg_Nombre)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.carg_UsuCreacionNavigation)
                    .WithMany(p => p.tbCargoscarg_UsuCreacionNavigation)
                    .HasForeignKey(d => d.carg_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCargos_tbUsuarios_carg_UsuCreacion_user_Id");

                entity.HasOne(d => d.carg_UsuModificacionNavigation)
                    .WithMany(p => p.tbCargoscarg_UsuModificacionNavigation)
                    .HasForeignKey(d => d.carg_UsuModificacion)
                    .HasConstraintName("FK_tbCargos_tbUsuarios_carg_UsuModificacion_user_Id");
            });

            modelBuilder.Entity<tbClinicas>(entity =>
            {
                entity.HasKey(e => e.clin_Id)
                    .HasName("PK_tbClinicas_clin_Id");

                entity.ToTable("tbClinicas", "cons");

                entity.Property(e => e.clin_Direccion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.clin_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.clin_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.clin_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.clin_Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.muni_Id)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.clin_UsuCreacionNavigation)
                    .WithMany(p => p.tbClinicasclin_UsuCreacionNavigation)
                    .HasForeignKey(d => d.clin_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbClinicas_tbUsuarios_clin_UsuCreacion_user_Id");

                entity.HasOne(d => d.clin_UsuModificacionNavigation)
                    .WithMany(p => p.tbClinicasclin_UsuModificacionNavigation)
                    .HasForeignKey(d => d.clin_UsuModificacion)
                    .HasConstraintName("FK_tbClinicas_tbUsuarios_clin_UsuModificacion_user_Id");

                entity.HasOne(d => d.empe)
                    .WithMany(p => p.tbClinicas)
                    .HasForeignKey(d => d.empe_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbClientes_tbEmpleados_empe_Id");

                entity.HasOne(d => d.muni)
                    .WithMany(p => p.tbClinicas)
                    .HasForeignKey(d => d.muni_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbClinicas_tbClinicas_muni_Id");
            });

            modelBuilder.Entity<tbConsultas>(entity =>
            {
                entity.HasKey(e => e.cons_Id)
                    .HasName("PK_tbConsultas_cons_Id");

                entity.ToTable("tbConsultas", "cons");

                entity.Property(e => e.cons_Costo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.cons_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.cons_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.cons_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.cons_Final).HasColumnType("datetime");

                entity.Property(e => e.cons_Inicio).HasColumnType("datetime");

                entity.HasOne(d => d.cons_UsuCreacionNavigation)
                    .WithMany(p => p.tbConsultascons_UsuCreacionNavigation)
                    .HasForeignKey(d => d.cons_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbConsultas_tbUsuarios_cons_UsuCreacion_user_Id");

                entity.HasOne(d => d.cons_UsuModificacionNavigation)
                    .WithMany(p => p.tbConsultascons_UsuModificacionNavigation)
                    .HasForeignKey(d => d.cons_UsuModificacion)
                    .HasConstraintName("FK_tbConsultas_tbUsuarios_cons_UsuModificacion_user_Id");

                entity.HasOne(d => d.consltro)
                    .WithMany(p => p.tbConsultas)
                    .HasForeignKey(d => d.consltro_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.paci)
                    .WithMany(p => p.tbConsultas)
                    .HasForeignKey(d => d.paci_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<tbConsultorios>(entity =>
            {
                entity.HasKey(e => e.consltro_Id)
                    .HasName("PK_tbConsultorios_consltro_Id");

                entity.ToTable("tbConsultorios", "cons");

                entity.Property(e => e.consltro_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.consltro_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.consltro_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.consltro_Nombre)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.area)
                    .WithMany(p => p.tbConsultorios)
                    .HasForeignKey(d => d.area_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.consltro_UsuCreacionNavigation)
                    .WithMany(p => p.tbConsultoriosconsltro_UsuCreacionNavigation)
                    .HasForeignKey(d => d.consltro_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbConsultorios_tbUsuarios_consltro_UsuCreacion_user_Id");

                entity.HasOne(d => d.consltro_UsuModificacionNavigation)
                    .WithMany(p => p.tbConsultoriosconsltro_UsuModificacionNavigation)
                    .HasForeignKey(d => d.consltro_UsuModificacion)
                    .HasConstraintName("FK_tbConsultorios_tbUsuarios_consltro_UsuModificacion_user_Id");

                entity.HasOne(d => d.empe)
                    .WithMany(p => p.tbConsultorios)
                    .HasForeignKey(d => d.empe_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<tbDepartamentos>(entity =>
            {
                entity.HasKey(e => e.depa_Id)
                    .HasName("PK_gral_tbDepartamentos_depa_Id");

                entity.ToTable("tbDepartamentos", "gral");

                entity.Property(e => e.depa_Id)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.depa_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.depa_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.depa_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.depa_Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.depa_UsuCreacionNavigation)
                    .WithMany(p => p.tbDepartamentosdepa_UsuCreacionNavigation)
                    .HasForeignKey(d => d.depa_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_gral_tbDepartamentos_acce_tbUsuarios_depa_UsuCreacion_user_Id");

                entity.HasOne(d => d.depa_UsuModificacionNavigation)
                    .WithMany(p => p.tbDepartamentosdepa_UsuModificacionNavigation)
                    .HasForeignKey(d => d.depa_UsuModificacion)
                    .HasConstraintName("FK_gral_tbDepartamentos_acce_tbUsuarios_depa_UsuModificacion_user_Id");
            });

            modelBuilder.Entity<tbEmpleados>(entity =>
            {
                entity.HasKey(e => e.empe_Id)
                    .HasName("PK_tbEmpleados_empe_Id");

                entity.ToTable("tbEmpleados", "cons");

                entity.Property(e => e.empe_Apellido)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.empe_Correo)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.empe_Direccion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.empe_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.empe_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.empe_FechaFinal).HasColumnType("date");

                entity.Property(e => e.empe_FechaInicio).HasColumnType("date");

                entity.Property(e => e.empe_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.empe_FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.empe_Identidad)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.empe_Nombres)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.empe_Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.empe_Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.muni_Id)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.carg)
                    .WithMany(p => p.tbEmpleados)
                    .HasForeignKey(d => d.carg_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.clin)
                    .WithMany(p => p.tbEmpleados)
                    .HasForeignKey(d => d.clin_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.empe_UsuCreacionNavigation)
                    .WithMany(p => p.tbEmpleadosempe_UsuCreacionNavigation)
                    .HasForeignKey(d => d.empe_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEmpleados_tbUsuarios_empe_UsuCreacion_user_Id");

                entity.HasOne(d => d.empe_UsuModificacionNavigation)
                    .WithMany(p => p.tbEmpleadosempe_UsuModificacionNavigation)
                    .HasForeignKey(d => d.empe_UsuModificacion)
                    .HasConstraintName("FK_tbEmpleados_tbUsuarios_empe_UsuModificacion_user_Id");

                entity.HasOne(d => d.estacivi)
                    .WithMany(p => p.tbEmpleados)
                    .HasForeignKey(d => d.estacivi_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.muni)
                    .WithMany(p => p.tbEmpleados)
                    .HasForeignKey(d => d.muni_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<tbEstadosCiviles>(entity =>
            {
                entity.HasKey(e => e.estacivi_Id)
                    .HasName("PK_gral_tbEstadosCiviles_estacivi_Id");

                entity.ToTable("tbEstadosCiviles", "gral");

                entity.Property(e => e.estacivi_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.estacivi_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.estacivi_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.estacivi_Nombre).HasMaxLength(50);

                entity.HasOne(d => d.estacivi_UsuCreacionNavigation)
                    .WithMany(p => p.tbEstadosCivilesestacivi_UsuCreacionNavigation)
                    .HasForeignKey(d => d.estacivi_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_gral_tbEstadosCiviles_acce_tbUsuarios_estacivi_UsuCreacion_user_Id");

                entity.HasOne(d => d.estacivi_UsuModificacionNavigation)
                    .WithMany(p => p.tbEstadosCivilesestacivi_UsuModificacionNavigation)
                    .HasForeignKey(d => d.estacivi_UsuModificacion)
                    .HasConstraintName("FK_gral_tbEstadosCiviles_acce_tbUsuarios_estacivi_UsuModificacion_user_Id");
            });

            modelBuilder.Entity<tbFacturas>(entity =>
            {
                entity.HasKey(e => e.fact_Id)
                    .HasName("PK_tbFacturas_fact_Id");

                entity.ToTable("tbFacturas", "cons");

                entity.Property(e => e.fact_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.fact_Fecha).HasColumnType("datetime");

                entity.Property(e => e.fact_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fact_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.empe)
                    .WithMany(p => p.tbFacturas)
                    .HasForeignKey(d => d.empe_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFacturas_tbPacientes_empe_Id");

                entity.HasOne(d => d.fact_UsuCreacionNavigation)
                    .WithMany(p => p.tbFacturasfact_UsuCreacionNavigation)
                    .HasForeignKey(d => d.fact_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFacturas_tbUsuarios_fact_UsuCreacion_user_Id");

                entity.HasOne(d => d.fact_UsuModificacionNavigation)
                    .WithMany(p => p.tbFacturasfact_UsuModificacionNavigation)
                    .HasForeignKey(d => d.fact_UsuModificacion)
                    .HasConstraintName("FK_tbFacturas_tbUsuarios_fact_UsuModificacion_user_Id");

                entity.HasOne(d => d.meto)
                    .WithMany(p => p.tbFacturas)
                    .HasForeignKey(d => d.meto_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFacturas_tbMetodosPago_empe_Id");

                entity.HasOne(d => d.paci)
                    .WithMany(p => p.tbFacturas)
                    .HasForeignKey(d => d.paci_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<tbFacturasDetalles>(entity =>
            {
                entity.HasKey(e => e.factdeta_Id)
                    .HasName("PK_tbFacturasDetalles_factdeta_Id");

                entity.ToTable("tbFacturasDetalles", "cons");

                entity.Property(e => e.factdeta_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.factdeta_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.factdeta_FechaModificacion).HasColumnType("datetime");


                entity.HasOne(d => d.cons)
                    .WithMany(p => p.tbFacturasDetalles)
                    .HasForeignKey(d => d.cons_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.fact)
                    .WithMany(p => p.tbFacturasDetalles)
                    .HasForeignKey(d => d.fact_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.factdeta_UsuCreacionNavigation)
                    .WithMany(p => p.tbFacturasDetallesfactdeta_UsuCreacionNavigation)
                    .HasForeignKey(d => d.factdeta_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFacturasDetalles_tbUsuarios_factdeta_UsuCreacion_user_Id");

                entity.HasOne(d => d.factdeta_UsuModificacionNavigation)
                    .WithMany(p => p.tbFacturasDetallesfactdeta_UsuModificacionNavigation)
                    .HasForeignKey(d => d.factdeta_UsuModificacion)
                    .HasConstraintName("FK_tbFacturasDetalles_tbUsuarios_factdeta_UsuModificacion_user_Id");

            });

            modelBuilder.Entity<tbMedicamentos>(entity =>
            {
                entity.HasKey(e => e.medi_Id)
                    .HasName("PK_tbMedicamentos_medi_Id");

                entity.ToTable("tbMedicamentos", "cons");

                entity.Property(e => e.medi_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.medi_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.medi_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.medi_Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.medi_PrecioCompra).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.medi_PrecioVenta).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.medi_UsuCreacionNavigation)
                    .WithMany(p => p.tbMedicamentosmedi_UsuCreacionNavigation)
                    .HasForeignKey(d => d.medi_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMedicamentos_tbUsuarios_medi_UsuCreacion_user_Id");

                entity.HasOne(d => d.medi_UsuModificacionNavigation)
                    .WithMany(p => p.tbMedicamentosmedi_UsuModificacionNavigation)
                    .HasForeignKey(d => d.medi_UsuModificacion)
                    .HasConstraintName("FK_tbMedicamentos_tbUsuarios_medi_UsuModificacion_user_Id");

                entity.HasOne(d => d.prov)
                    .WithMany(p => p.tbMedicamentos)
                    .HasForeignKey(d => d.prov_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<tbMetodosPago>(entity =>
            {
                entity.HasKey(e => e.meto_Id)
                    .HasName("PK_tbMetodosPago_meto_Id");

                entity.ToTable("tbMetodosPago", "cons");

                entity.Property(e => e.meto_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.meto_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.meto_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.meto_Nombre)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.HasOne(d => d.meto_UsuCreacionNavigation)
                    .WithMany(p => p.tbMetodosPagometo_UsuCreacionNavigation)
                    .HasForeignKey(d => d.meto_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMetodosPago_tbUsuarios_meto_UsuCreacion_user_Id");

                entity.HasOne(d => d.meto_UsuModificacionNavigation)
                    .WithMany(p => p.tbMetodosPagometo_UsuModificacionNavigation)
                    .HasForeignKey(d => d.meto_UsuModificacion)
                    .HasConstraintName("FK_tbMetodosPago_tbUsuarios_meto_UsuModificacion_user_Id");
            });

            modelBuilder.Entity<tbMunicipios>(entity =>
            {
                entity.HasKey(e => e.muni_id)
                    .HasName("PK_gral_tbMunicipios_muni_Id");

                entity.ToTable("tbMunicipios", "gral");

                entity.Property(e => e.muni_id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.depa_Id)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.muni_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.muni_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.muni_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.muni_Nombre)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasOne(d => d.depa)
                    .WithMany(p => p.tbMunicipios)
                    .HasForeignKey(d => d.depa_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_gral_tbMunicipios_gral_tbDepartamentos_depa_Id");

                entity.HasOne(d => d.muni_UsuCreacionNavigation)
                    .WithMany(p => p.tbMunicipiosmuni_UsuCreacionNavigation)
                    .HasForeignKey(d => d.muni_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_gral_tbMunicipios_acce_tbUsuarios_muni_UsuCreacion_user_Id");

                entity.HasOne(d => d.muni_UsuModificacionNavigation)
                    .WithMany(p => p.tbMunicipiosmuni_UsuModificacionNavigation)
                    .HasForeignKey(d => d.muni_UsuModificacion)
                    .HasConstraintName("FK_gral_tbMunicipios_acce_tbUsuarios_muni_UsuModificacion_user_Id");
            });

            modelBuilder.Entity<tbPacientes>(entity =>
            {
                entity.HasKey(e => e.paci_Id)
                    .HasName("PK_tbPacientes_paci_Id");

                entity.ToTable("tbPacientes", "cons");

                entity.Property(e => e.paci_Apellidos)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.paci_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.paci_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.paci_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.paci_FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.paci_Identidad)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.paci_Nombres)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.paci_Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.paci_TipoSangre)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.estacivi)
                    .WithMany(p => p.tbPacientes)
                    .HasForeignKey(d => d.estacivi_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.paci_UsuCreacionNavigation)
                    .WithMany(p => p.tbPacientespaci_UsuCreacionNavigation)
                    .HasForeignKey(d => d.paci_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbPacientes_tbUsuarios_paci_UsuCreacion_user_Id");

                entity.HasOne(d => d.paci_UsuModificacionNavigation)
                    .WithMany(p => p.tbPacientespaci_UsuModificacionNavigation)
                    .HasForeignKey(d => d.paci_UsuModificacion)
                    .HasConstraintName("FK_tbPacientes_tbUsuarios_paci_UsuModificacion_user_Id");
            });

            modelBuilder.Entity<tbPantallas>(entity =>
            {
                entity.HasKey(e => e.pant_Id)
                    .HasName("PK_acce_tbPantallas_pant_Id");

                entity.ToTable("tbPantallas", "acce");

                entity.Property(e => e.pant_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.pant_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pant_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.pant_Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<tbPantallasPorRoles>(entity =>
            {
                entity.HasKey(e => e.pantrole_Id)
                    .HasName("PK_acce_tbPantallasPorRoles_pantrole_Id");

                entity.ToTable("tbPantallasPorRoles", "acce");

                entity.Property(e => e.pantrole_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.pantrole_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.pantrole_FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.pant)
                    .WithMany(p => p.tbPantallasPorRoles)
                    .HasForeignKey(d => d.pant_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_acce_tbPantallasPorRoles_acce_tbPantallas_pant_Id");

                entity.HasOne(d => d.pantrole_UsuCreacionNavigation)
                    .WithMany(p => p.tbPantallasPorRolespantrole_UsuCreacionNavigation)
                    .HasForeignKey(d => d.pantrole_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_acce_tbPantallasPorRoles_acce_tbUsuarios_pantrole_UsuCreacion_user_Id");

                entity.HasOne(d => d.pantrole_UsuModificacionNavigation)
                    .WithMany(p => p.tbPantallasPorRolespantrole_UsuModificacionNavigation)
                    .HasForeignKey(d => d.pantrole_UsuModificacion)
                    .HasConstraintName("FK_acce_tbPantallasPorRoles_acce_tbUsuarios_pantrole_UsuModificacion_user_Id");

                entity.HasOne(d => d.role)
                    .WithMany(p => p.tbPantallasPorRoles)
                    .HasForeignKey(d => d.role_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_acce_tbPantallasPorRoles_acce_tbRoles_role_Id");
            });

            modelBuilder.Entity<tbProveedores>(entity =>
            {
                entity.HasKey(e => e.prov_Id)
                    .HasName("PK_tbProveedores_prov_Id");

                entity.ToTable("tbProveedores", "cons");

                entity.Property(e => e.prov_Correo)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.prov_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.prov_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.prov_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.prov_Nombre)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.prov_Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.prov_UsuCreacionNavigation)
                    .WithMany(p => p.tbProveedoresprov_UsuCreacionNavigation)
                    .HasForeignKey(d => d.prov_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProveedores_tbUsuarios_prov_UsuCreacion_user_Id");

                entity.HasOne(d => d.prov_UsuModificacionNavigation)
                    .WithMany(p => p.tbProveedoresprov_UsuModificacionNavigation)
                    .HasForeignKey(d => d.prov_UsuModificacion)
                    .HasConstraintName("FK_tbProveedores_tbUsuarios_prov_UsuModificacion_user_Id");
            });

            modelBuilder.Entity<tbRoles>(entity =>
            {
                entity.HasKey(e => e.role_Id)
                    .HasName("PK_acce_tbRoles_role_Id");

                entity.ToTable("tbRoles", "acce");

                entity.Property(e => e.role_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.role_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.role_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.role_Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.role_UsuCreacionNavigation)
                    .WithMany(p => p.tbRolesrole_UsuCreacionNavigation)
                    .HasForeignKey(d => d.role_UsuCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_acce_tbRoles_acce_tbUsuarios_role_UsuCreacion_user_Id");

                entity.HasOne(d => d.role_UsuModificacionNavigation)
                    .WithMany(p => p.tbRolesrole_UsuModificacionNavigation)
                    .HasForeignKey(d => d.role_UsuModificacion)
                    .HasConstraintName("FK_acce_tbRoles_acce_tbUsuarios_role_UsuModificacion_user_Id");
            });

            modelBuilder.Entity<tbUsuarios>(entity =>
            {
                entity.HasKey(e => e.user_Id)
                    .HasName("PK_acce_tbUsuarios_user_Id");

                entity.ToTable("tbUsuarios", "acce");

                entity.Property(e => e.user_Contrasena).IsRequired();

                entity.Property(e => e.user_Estado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.user_FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.user_FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.user_NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.empe)
                    .WithMany(p => p.tbUsuarios)
                    .HasForeignKey(d => d.empe_Id);

                entity.HasOne(d => d.role)
                    .WithMany(p => p.tbUsuarios)
                    .HasForeignKey(d => d.role_Id)
                    .HasConstraintName("FK_acce_tbUsuarios_acce_tbRoles_role_Id");

                entity.HasOne(d => d.user_UsuCreacionNavigation)
                    .WithMany(p => p.Inverseuser_UsuCreacionNavigation)
                    .HasForeignKey(d => d.user_UsuCreacion)
                    .HasConstraintName("FK_acce_tbUsuarios_acce_tbUsuarios_user_UsuCreacion_user_Id");

                entity.HasOne(d => d.user_UsuModificacionNavigation)
                    .WithMany(p => p.Inverseuser_UsuModificacionNavigation)
                    .HasForeignKey(d => d.user_UsuModificacion)
                    .HasConstraintName("FK_acce_tbUsuarios_acce_tbUsuarios_user_UsuModificacion_user_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}