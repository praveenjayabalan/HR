using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HR.Models.HR
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
            : base("EmployeeDBContext")
        {
            
        }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer<EmployeeDBContext>(null);
            base.OnModelCreating(modelBuilder);

        }

        
    }
}