﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data.Migrations
{
    public partial class DataContextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectName = table.Column<string>(nullable: true),
                    SubjectTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowCustomerMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ObserverCustomerId = table.Column<int>(nullable: false),
                    ProducerCustomerId = table.Column<int>(nullable: false),
                    Tag = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowCustomerMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowCustomerMappings_Customers_ObserverCustomerId",
                        column: x => x.ObserverCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowCustomerMappings_Customers_ProducerCustomerId",
                        column: x => x.ProducerCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionLogs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionLogs_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowSubjectMappings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ObserverCustomerId = table.Column<int>(nullable: false),
                    ProducerSubjectId = table.Column<int>(nullable: false),
                    Tag = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowSubjectMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowSubjectMappings_Customers_ObserverCustomerId",
                        column: x => x.ObserverCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowSubjectMappings_Subjects_ProducerSubjectId",
                        column: x => x.ProducerSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    LocationData = table.Column<string>(nullable: true),
                    LocationTypeId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActionLogId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    PictureBinary = table.Column<byte[]>(nullable: true),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_ActionLogs_ActionLogId",
                        column: x => x.ActionLogId,
                        principalTable: "ActionLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pictures_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pictures_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionLogs_CustomerId",
                table: "ActionLogs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionLogs_SubjectId",
                table: "ActionLogs",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowCustomerMappings_ObserverCustomerId",
                table: "FlowCustomerMappings",
                column: "ObserverCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowCustomerMappings_ProducerCustomerId",
                table: "FlowCustomerMappings",
                column: "ProducerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowSubjectMappings_ObserverCustomerId",
                table: "FlowSubjectMappings",
                column: "ObserverCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowSubjectMappings_ProducerSubjectId",
                table: "FlowSubjectMappings",
                column: "ProducerSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_SubjectId",
                table: "Locations",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ActionLogId",
                table: "Pictures",
                column: "ActionLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_CustomerId",
                table: "Pictures",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_SubjectId",
                table: "Pictures",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowCustomerMappings");

            migrationBuilder.DropTable(
                name: "FlowSubjectMappings");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "ActionLogs");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
