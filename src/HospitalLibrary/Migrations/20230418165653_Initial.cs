using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HospitalLibrary.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Country = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Pin_Value = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    SelectedDoctorId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Specialization = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    WorkHour_Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WorkHour_End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllergenPatient",
                columns: table => new
                {
                    AllergensId = table.Column<int>(type: "integer", nullable: false),
                    PatientsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergenPatient", x => new { x.AllergensId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_AllergenPatient_Allergens_AllergensId",
                        column: x => x.AllergensId,
                        principalTable: "Allergens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergenPatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsAnonymous = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    Rating_Rating = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    DateRange_Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateRange_End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examinations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examinations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examinations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Number", "Street" },
                values: new object[,]
                {
                    { 1, "Novi Sad", "Srbija", "12", "Dunavska 29" },
                    { 2, "Beograd", "Srbija", "10", "Beogradska" },
                    { 3, "Sremska Mitrovica", "Srbija", "15", "Skolska" },
                    { 4, "Gradska", "Srbija", "25", "Njegoseva" }
                });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Penicilin" },
                    { 2, "Sulfonamidi " },
                    { 3, "Salicilna kiselina" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Soba 12" },
                    { 2, "Soba 13 " },
                    { 3, "Soba 14" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "FirstName", "LastName", "RoomId", "Specialization", "WorkHour_End", "WorkHour_Start" },
                values: new object[,]
                {
                    { 1, "Slobodan", "Radulovic", 1, 0, new DateTime(2022, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Aleksa", "Zindovic", 2, 0, new DateTime(2022, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Mica", "Micic", 3, 0, new DateTime(2022, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "AddressId", "BloodType", "Email", "FirstName", "Gender", "LastName", "SelectedDoctorId", "UserId", "Pin_Value" },
                values: new object[,]
                {
                    { 1, 1, 0, "peraperic@gmail.com", "Pera", 0, "Peric", 1, 5, "2201000120492" },
                    { 2, 2, 7, "markomarkovic@gmail.com", "Marko", 0, "Markovic", 2, 6, "1412995012451" },
                    { 3, 3, 5, "dusanbaljinac@gmail.com", "Dusan", 0, "Baljinac", 1, 7, "2008004124293" },
                    { 4, 4, 3, "slobodanradulovic@gmail.com", "Slobodan", 0, "Radulovic", 2, 8, "1111952020204" }
                });

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "DoctorId", "PatientId", "RoomId", "Status", "DateRange_End", "DateRange_Start" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1, new DateTime(2022, 12, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 1, 2, 1, new DateTime(2022, 12, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 1, 2, 0, new DateTime(2022, 12, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, 1, 3, 0, new DateTime(2023, 1, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 22, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 1, 1, 0, new DateTime(2023, 2, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, 1, 1, 0, new DateTime(2022, 12, 27, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 27, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, 3, 3, 1, new DateTime(2022, 12, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, 3, 3, 0, new DateTime(2023, 1, 23, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, 1, 3, 0, new DateTime(2023, 1, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, 2, 3, 0, new DateTime(2023, 1, 23, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, 3, 3, 0, new DateTime(2023, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, 4, 3, 0, new DateTime(2023, 1, 23, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, 1, 3, 0, new DateTime(2023, 1, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, 2, 3, 0, new DateTime(2023, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 1, 3, 3, 0, new DateTime(2023, 1, 23, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, 4, 3, 0, new DateTime(2023, 1, 23, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, 1, 3, 0, new DateTime(2023, 1, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 1, 2, 3, 0, new DateTime(2023, 1, 23, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, 3, 3, 0, new DateTime(2023, 1, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 1, 4, 3, 0, new DateTime(2023, 1, 23, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, 1, 3, 0, new DateTime(2023, 1, 23, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 1, 2, 3, 0, new DateTime(2023, 1, 23, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 1, 3, 3, 0, new DateTime(2023, 1, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 1, 4, 3, 0, new DateTime(2023, 1, 23, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 1, 1, 3, 0, new DateTime(2023, 1, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 15, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 1, 2, 3, 0, new DateTime(2023, 1, 23, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 1, 3, 3, 0, new DateTime(2023, 1, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 16, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 1, 4, 3, 0, new DateTime(2023, 1, 23, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 1, 1, 3, 0, new DateTime(2023, 1, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 17, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 1, 2, 3, 0, new DateTime(2023, 1, 23, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 1, 3, 3, 0, new DateTime(2023, 1, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 1, 4, 3, 0, new DateTime(2023, 1, 23, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 1, 1, 3, 0, new DateTime(2023, 1, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 23, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 1, 3, 3, 0, new DateTime(2023, 1, 24, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 1, 1, 3, 0, new DateTime(2023, 1, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 7, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 1, 2, 3, 0, new DateTime(2023, 1, 24, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 1, 3, 3, 0, new DateTime(2023, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 1, 4, 3, 0, new DateTime(2023, 1, 24, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 1, 1, 3, 0, new DateTime(2023, 1, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 1, 2, 3, 0, new DateTime(2023, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 1, 3, 3, 0, new DateTime(2023, 1, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 1, 4, 3, 0, new DateTime(2023, 1, 24, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 1, 1, 3, 0, new DateTime(2023, 1, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 1, 2, 3, 0, new DateTime(2023, 1, 24, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 1, 3, 3, 0, new DateTime(2023, 1, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 1, 4, 3, 0, new DateTime(2023, 1, 24, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 1, 1, 3, 0, new DateTime(2023, 1, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 1, 2, 3, 0, new DateTime(2023, 1, 24, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 1, 3, 3, 0, new DateTime(2023, 1, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 1, 4, 3, 0, new DateTime(2023, 1, 24, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 1, 1, 3, 0, new DateTime(2023, 1, 24, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 15, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 1, 2, 3, 0, new DateTime(2023, 1, 24, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 1, 3, 3, 0, new DateTime(2023, 1, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 16, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 1, 4, 3, 0, new DateTime(2023, 1, 24, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 1, 1, 3, 0, new DateTime(2023, 1, 24, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 17, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 1, 2, 3, 0, new DateTime(2023, 1, 24, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 1, 3, 3, 0, new DateTime(2023, 1, 24, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 1, 4, 3, 0, new DateTime(2023, 1, 24, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 1, 1, 3, 0, new DateTime(2023, 1, 24, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 24, 19, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "CreationDate", "IsAnonymous", "IsPublic", "PatientId", "Status", "Text", "Rating_Rating" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 10, 24), true, true, 1, 0, "Bolnica je dobra", 3 },
                    { 2, new DateOnly(2022, 10, 24), false, true, 2, 0, "Bolnica je losa", 4 },
                    { 3, new DateOnly(2022, 10, 24), false, true, 3, 1, "Bolnica je odlicna", 5 },
                    { 4, new DateOnly(2022, 10, 24), true, true, 4, 0, "Bolnica je solidna", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergenPatient_PatientsId",
                table: "AllergenPatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoomId",
                table: "Doctors",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_DoctorId",
                table: "Examinations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_PatientId",
                table: "Examinations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_RoomId",
                table: "Examinations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PatientId",
                table: "Feedbacks",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergenPatient");

            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
