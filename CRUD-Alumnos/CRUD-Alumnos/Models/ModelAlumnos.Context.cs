﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_Alumnos.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AlumnosContext : DbContext
    {
        public AlumnosContext()
            : base("name=AlumnosContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumno> Alumnoes { get; set; }
        public virtual DbSet<Ciudade> Ciudades { get; set; }
        public virtual DbSet<Docente> Docentes { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<Nota> Notas { get; set; }
    }
}
