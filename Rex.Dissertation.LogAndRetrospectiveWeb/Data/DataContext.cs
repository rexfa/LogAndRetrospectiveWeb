using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rex.Dissertation.LogAndRetrospectiveWeb.Models;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.ActionLogs;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Customers;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Flows;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Locations;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Media;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Subjects;
namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ActionLog> ActionLogs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FlowCustomerMapping> FlowCustomerMappings { get; set; }
        public DbSet<FlowSubjectMapping> FlowSubjectMappings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionLog>().HasKey(al => al.Id);
            modelBuilder.Entity<ActionLog>().Property(al => al.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<FlowCustomerMapping>().HasKey(fc => fc.Id);
            modelBuilder.Entity<FlowSubjectMapping>().HasKey(fs => fs.Id);
            modelBuilder.Entity<Location>().HasKey(l => l.Id);
            modelBuilder.Entity<Picture>().HasKey(p => p.Id);
            modelBuilder.Entity<Subject>().HasKey(s => s.Id);
        }

        //public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        //{
        //    return base.Set<TEntity>();
        //}
    }
}
