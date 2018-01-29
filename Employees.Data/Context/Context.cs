﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using Employees.Entities.Documents;
using Employees.Entities.Employees;

namespace Employees.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base("ApplicationDbContext")
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {

        }
    }
}
