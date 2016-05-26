using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data;

namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
        }
    }
}
