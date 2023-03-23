﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
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

        public virtual DbSet<tbDepartamentos> tbDepartamentos { get; set; }
        public virtual DbSet<tbEstadosCiviles> tbEstadosCiviles { get; set; }
        public virtual DbSet<tbMunicipios> tbMunicipios { get; set; }
        public virtual DbSet<tbPantallas> tbPantallas { get; set; }
        public virtual DbSet<tbPantallasPorRoles> tbPantallasPorRoles { get; set; }
        public virtual DbSet<tbRoles> tbRoles { get; set; }
        public virtual DbSet<tbUsuarios> tbUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

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

            modelBuilder.Entity<tbEstadosCiviles>(entity =>
            {
                entity.HasKey(e => e.estacivi_Id)
                    .HasName("PK_gral_tbEstadosCiviles");

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

                entity.Property(e => e.pantrole_Identificador)
                    .IsRequired()
                    .HasMaxLength(100);

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