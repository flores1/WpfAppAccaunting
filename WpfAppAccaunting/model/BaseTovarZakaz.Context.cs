﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppAccaunting.model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BaseTovarZakaz : DbContext
    {
        public BaseTovarZakaz()
            : base("name=BaseTovarZakaz")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    
        public virtual DbSet<sklads> sklads { get; set; }
        public virtual DbSet<zakazies> zakazies { get; set; }
    }
}