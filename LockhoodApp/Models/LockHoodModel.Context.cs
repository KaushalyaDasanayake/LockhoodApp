﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LockhoodApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LockHoodDBEntities : DbContext
    {
        public LockHoodDBEntities()
            : base("name=LockHoodDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cutomer> Cutomers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Factory> Factories { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<RoleType> RoleTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductItem> ProductItems { get; set; }
        public virtual DbSet<OrderSale> OrderSales { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<WorkTask> WorkTasks { get; set; }
        public virtual DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
