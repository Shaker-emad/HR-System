﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace project12.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "Email", "FirstName", "LastName", "Phone", "Position" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "Doe", "123-456-7890", "HR Manager" },
                    { 2, "jane.smith@example.com", "Jane", "Smith", "987-654-3210", "IT Manager" },
                    { 3, "bob.brown@example.com", "Bob", "Brown", "555-555-5555", "Marketing Manager" },
                    { 4, "alice.white@example.com", "Alice", "White", "444-444-4444", "Sales Manager" },
                    { 5, "tom.green@example.com", "Tom", "Green", "333-333-3333", "Finance Manager" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName", "Location", "ManagerId" },
                values: new object[,]
                {
                    { 1, "Human Resources", "Building A", 1 },
                    { 2, "IT", "Building B", 2 },
                    { 3, "Marketing", "Building C", 3 },
                    { 4, "Sales", "Building D", 4 },
                    { 5, "Finance", "Building E", 5 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "HireDate", "Image", "LastName", "Phone", "Position", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "michael.jordan@example.com", "Michael", "Male", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.jpg", "Jordan", "111-111-1111", "HR Specialist", 50000m },
                    { 2, new DateTime(1990, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "serena.williams@example.com", "Serena", "Female", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.jp", "Williams", "222-222-2222", "IT Specialist", 60000m },
                    { 3, new DateTime(1988, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "lebron.james@example.com", "LeBron", "Male", new DateTime(2019, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.jp", "James", "333-333-3333", "Marketing Analyst", 55000m },
                    { 4, new DateTime(1996, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "simone.biles@example.com", "Simone", "Female", new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.jp", "Biles", "444-444-4444", "Sales Representative", 48000m },
                    { 5, new DateTime(1987, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "lionel.messi@example.com", "Lionel", "Male", new DateTime(2020, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.jp", "Messi", "555-555-5555", "Finance Analyst", 70000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                table: "Departments",
                column: "ManagerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
