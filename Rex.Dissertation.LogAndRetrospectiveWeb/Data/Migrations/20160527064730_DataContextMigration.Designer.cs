using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data;

namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20160527064730_DataContextMigration")]
    partial class DataContextMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.ActionLogs.ActionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Message");

                    b.Property<int>("SubjectId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SubjectId");

                    b.ToTable("ActionLogs");
                });

            modelBuilder.Entity("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordSalt");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Flows.FlowCustomerMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("ObserverCustomerId");

                    b.Property<int>("ProducerCustomerId");

                    b.Property<int>("Tag");

                    b.HasKey("Id");

                    b.HasIndex("ObserverCustomerId");

                    b.HasIndex("ProducerCustomerId");

                    b.ToTable("FlowCustomerMappings");
                });

            modelBuilder.Entity("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Flows.FlowSubjectMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("ObserverCustomerId");

                    b.Property<int>("ProducerSubjectId");

                    b.Property<int>("Tag");

                    b.HasKey("Id");

                    b.HasIndex("ObserverCustomerId");

                    b.HasIndex("ProducerSubjectId");

                    b.ToTable("FlowSubjectMappings");
                });

            modelBuilder.Entity("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Locations.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("Deleted");

                    b.Property<string>("LocationData");

                    b.Property<int>("LocationTypeId");

                    b.Property<int>("SubjectId");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Media.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionLogId");

                    b.Property<int>("CustomerId");

                    b.Property<byte[]>("PictureBinary");

                    b.Property<int>("SubjectId");

                    b.HasKey("Id");

                    b.HasIndex("ActionLogId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Subjects.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SubjectName");

                    b.Property<int>("SubjectTypeId");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.ActionLogs.ActionLog", b =>
                {
                    b.HasOne("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Customers.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Subjects.Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Flows.FlowCustomerMapping", b =>
                {
                    b.HasOne("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Customers.Customer")
                        .WithMany()
                        .HasForeignKey("ObserverCustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Customers.Customer")
                        .WithMany()
                        .HasForeignKey("ProducerCustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Flows.FlowSubjectMapping", b =>
                {
                    b.HasOne("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Customers.Customer")
                        .WithMany()
                        .HasForeignKey("ObserverCustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Subjects.Subject")
                        .WithMany()
                        .HasForeignKey("ProducerSubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Locations.Location", b =>
                {
                    b.HasOne("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Subjects.Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Media.Picture", b =>
                {
                    b.HasOne("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.ActionLogs.ActionLog")
                        .WithMany()
                        .HasForeignKey("ActionLogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Customers.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Subjects.Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
