﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessEF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<arduBase> arduBase { get; set; }
        public virtual DbSet<tblCountry> tblCountry { get; set; }
        public virtual DbSet<tblElectronMeta> tblElectronMeta { get; set; }
        public virtual DbSet<tblLabel> tblLabel { get; set; }
        public virtual DbSet<tblMountainRegionn> tblMountainRegionn { get; set; }
        public virtual DbSet<tblPredicament> tblPredicament { get; set; }
        public virtual DbSet<tblWeather> tblWeather { get; set; }
    }
}