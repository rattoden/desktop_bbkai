﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace desktop_bbkai
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bbkaiEntities : DbContext
    {
        public bbkaiEntities()
            : base("name=bbkaiEntities")
        {
        }

        private static bbkaiEntities _context = new bbkaiEntities();

        public static bbkaiEntities GetContext()
        {
            if (_context == null)
                _context = new bbkaiEntities();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Chet> Chet { get; set; }
        public virtual DbSet<Discs> Discs { get; set; }
        public virtual DbSet<Doki> Doki { get; set; }
        public virtual DbSet<G_D> G_D { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Nedeli> Nedeli { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Otcheti> Otcheti { get; set; }
        public virtual DbSet<Raspis> Raspis { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Times> Times { get; set; }
        public virtual DbSet<U_D> U_D { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vidi> Vidi { get; set; }
    }
}