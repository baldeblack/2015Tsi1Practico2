using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class EmployeeDBContext: DbContext
    {
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FullTimeEmployee>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("FULL_TIME_EMP");
         
            });

            modelBuilder.Entity<PartTimeEmployee>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PART_TIME_EMP");
            });
            modelBuilder.Entity<Employee>().Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            base.OnModelCreating(modelBuilder);
        }
    }
}
