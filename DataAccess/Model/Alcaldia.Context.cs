﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ReclamosAlcaldiaEntities : DbContext
    {
        public ReclamosAlcaldiaEntities()
            : base("name=ReclamosAlcaldiaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Zona> Zona { get; set; }
        public virtual DbSet<Cuadrilla> Cuadrilla { get; set; }
        public virtual DbSet<LogReclamo> LogReclamo { get; set; }
        public virtual DbSet<Tipo_De_Reclamo> Tipo_De_Reclamo { get; set; }
        public virtual DbSet<Tipo_Usuario> Tipo_Usuario { get; set; }
        public virtual DbSet<Vertice> Vertice { get; set; }
        public virtual DbSet<Reclamo> Reclamo { get; set; }
        public virtual DbSet<V_ReclamosAbiertosPorCuadrilla> V_ReclamosAbiertosPorCuadrilla { get; set; }
        public virtual DbSet<V_ReclamosResueltosPorCuadrilla> V_ReclamosResueltosPorCuadrilla { get; set; }
        public virtual DbSet<V_ReclamosActivosPorZonas> V_ReclamosActivosPorZonas { get; set; }
    }
}
