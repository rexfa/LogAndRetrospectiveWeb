using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        public virtual DbSet<ActionLog> ActionLogs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<FlowCustomerMapping> FlowCustomerMappings { get; set; }
        public virtual DbSet<FlowSubjectMapping> FlowSubjectMappings { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectType> SubjectTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionLog>(entity=> 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasMany(e => e.Pictures).WithOne().HasForeignKey(e => e.ActionLogId);
                //entity.Ignore(e => e.Pictures);
                entity.Ignore(e => e.Customer);
                entity.Ignore(e => e.Sunject);
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasMany(e => e.Observers).WithOne().HasForeignKey(e=>e.ProducerCustomerId);
                entity.HasMany(e => e.Producers).WithOne().HasForeignKey(e=>e.ObserverCustomerId);
                entity.HasMany(e => e.FlowSubjects).WithOne().HasForeignKey(e => e.ObserverCustomerId);
                entity.HasMany(e => e.Pictures).WithOne().HasForeignKey(e => e.CustomerId);
                entity.HasMany(e => e.ActionLogs).WithOne().HasForeignKey(e => e.CustomerId);
                //entity.Ignore(e => e.Pictures);
                //entity.Ignore(e => e.Observers);
                //entity.Ignore(e => e.Producers);
                //entity.Ignore(e => e.FlowSubjects);
            });
            modelBuilder.Entity<FlowCustomerMapping>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Ignore(e => e.ObserverCustomer);
                entity.Ignore(e => e.ProducerCustomer);
            });
            modelBuilder.Entity<FlowSubjectMapping>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Ignore(e => e.ObserverCustomer);
                entity.Ignore(e => e.ProducerSubject);
            });
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Ignore(e => e.Subject);
            });
            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Ignore(e => e.Customer);
                entity.Ignore(e => e.ActionLog);
                entity.Ignore(e => e.Subject);
            });
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasMany(e => e.Observers).WithOne().HasForeignKey(e => e.ProducerSubjectId);
                entity.HasMany(e => e.Pictures).WithOne().HasForeignKey(e => e.SubjectId);
                entity.HasMany(e => e.Locations).WithOne().HasForeignKey(e => e.SubjectId);
                entity.HasMany(e => e.ActionLogs).WithOne().HasForeignKey(e => e.SubjectId);
                entity.HasOne(e => e.SubjectType).WithMany().HasForeignKey(e => e.SubjectTypeId);
                //entity.Ignore(e => e.Pictures);
                //entity.Ignore(e => e.Observers);
                //entity.Ignore(e => e.Locations);
            });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=192.168.19.12\sqlexpress,3433;Initial Catalog=LAR;Persist Security Info=True;User ID=lar;Password=123qwe");
        }
        //public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        //{
        //    return base.Set<TEntity>();
        //}
    }
}
