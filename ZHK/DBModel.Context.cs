﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZHK
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ЖК_311Entities : DbContext
    {
        private static ЖК_311Entities _context;
        public ЖК_311Entities() : base("name=ЖК_311Entities")
        {
        }
    
        //если будут лаги - вернуть if
        public static ЖК_311Entities GetContext()
        {
            _context = new ЖК_311Entities();
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Apartament> Apartaments { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<ResidentialComplex> ResidentialComplexes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
