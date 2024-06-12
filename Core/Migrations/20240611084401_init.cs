using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_ChatSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatSession_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_MasterAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAdmin_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ActivationStatus = table.Column<bool>(type: "bit", nullable: true),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_StaticDataType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticDataType_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_MasterAdminRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterAdminId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAdminRole_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterAdmin_MasterAdminRole",
                        column: x => x.MasterAdminId,
                        principalTable: "tb_MasterAdmin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Role_MasterAdminRole",
                        column: x => x.RoleId,
                        principalTable: "tb_Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_StaticData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaticDataTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticData_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticDataType_StaticData",
                        column: x => x.StaticDataTypeId,
                        principalTable: "tb_StaticDataType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_Clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    SpecialityId = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    ImageKey = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ActivationStatus = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Clinic__OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "tb_Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaticData_Clinic",
                        column: x => x.SpecialityId,
                        principalTable: "tb_StaticData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    SpecialityId = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageKey = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ActivationStatus = table.Column<bool>(type: "bit", nullable: false),
                    EnableCrossEdit = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_User_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "tb_Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaticData_User_Speciality",
                        column: x => x.SpecialityId,
                        principalTable: "tb_StaticData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaticData_User_UserType",
                        column: x => x.UserTypeId,
                        principalTable: "tb_StaticData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_ClinicService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Fees = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicService_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinic_ClinicService",
                        column: x => x.ClinicId,
                        principalTable: "tb_Clinic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaticData_ClinicService",
                        column: x => x.ServiceId,
                        principalTable: "tb_StaticData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_ClinicWaiting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicWaiting_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinic_ClinicWaiting",
                        column: x => x.ClinicId,
                        principalTable: "tb_Clinic",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_ReservationGuide",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    SatStart = table.Column<TimeOnly>(type: "time", nullable: true),
                    SatEnd = table.Column<TimeOnly>(type: "time", nullable: true),
                    SatTimeShift = table.Column<int>(type: "int", nullable: true),
                    SunStart = table.Column<TimeOnly>(type: "time", nullable: true),
                    SunEnd = table.Column<TimeOnly>(type: "time", nullable: true),
                    SunTimeShift = table.Column<int>(type: "int", nullable: true),
                    MonStart = table.Column<TimeOnly>(type: "time", nullable: true),
                    MonEnd = table.Column<TimeOnly>(type: "time", nullable: true),
                    MonTimeShift = table.Column<int>(type: "int", nullable: true),
                    TueStart = table.Column<TimeOnly>(type: "time", nullable: true),
                    TueEnd = table.Column<TimeOnly>(type: "time", nullable: true),
                    TueTimeShift = table.Column<int>(type: "int", nullable: true),
                    WedStart = table.Column<TimeOnly>(type: "time", nullable: true),
                    WedEnd = table.Column<TimeOnly>(type: "time", nullable: true),
                    WedTimeShift = table.Column<int>(type: "int", nullable: true),
                    ThuStart = table.Column<TimeOnly>(type: "time", nullable: true),
                    ThuEnd = table.Column<TimeOnly>(type: "time", nullable: true),
                    ThuTimeShift = table.Column<int>(type: "int", nullable: true),
                    FriStart = table.Column<TimeOnly>(type: "time", nullable: true),
                    FriEnd = table.Column<TimeOnly>(type: "time", nullable: true),
                    FriTimeShift = table.Column<int>(type: "int", nullable: true),
                    ReservationDuration = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationGuide_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinic_ReservationGuide",
                        column: x => x.ClinicId,
                        principalTable: "tb_Clinic",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_ChatSessionUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    User1Id = table.Column<int>(type: "int", nullable: false),
                    User2Id = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatSessionUser_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatSession_ChatSessionUser",
                        column: x => x.SessionId,
                        principalTable: "tb_ChatSession",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_ChatSessionUser1",
                        column: x => x.User1Id,
                        principalTable: "tb_User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_ChatSessionUser2",
                        column: x => x.User2Id,
                        principalTable: "tb_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_ClinicStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicStaff_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinic_ClinicStaff",
                        column: x => x.ClinicId,
                        principalTable: "tb_Clinic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_ClinicStaff",
                        column: x => x.UserId,
                        principalTable: "tb_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DocumentKey = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Annotation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Document",
                        column: x => x.PatientId,
                        principalTable: "tb_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_MedicalRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordTypeId = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnoses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextVisitDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreviousPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DayPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_MedicalRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinic_MedicalRecord",
                        column: x => x.ClinicId,
                        principalTable: "tb_Clinic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaticData_MedicalRecord",
                        column: x => x.RecordTypeId,
                        principalTable: "tb_StaticData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_MedicalRecord",
                        column: x => x.PatientId,
                        principalTable: "tb_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicReservation_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinic_Reservation",
                        column: x => x.ClinicId,
                        principalTable: "tb_Clinic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Reservation",
                        column: x => x.UserId,
                        principalTable: "tb_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinic_Review",
                        column: x => x.ClinicId,
                        principalTable: "tb_Clinic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Review",
                        column: x => x.UserId,
                        principalTable: "tb_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_StaffRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicStaffId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRole_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicStaff_StaffRole",
                        column: x => x.ClinicStaffId,
                        principalTable: "tb_ClinicStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Role_StaffRole",
                        column: x => x.RoleId,
                        principalTable: "tb_Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_ChatMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatSessionUser_ChatMessage",
                        column: x => x.UserId,
                        principalTable: "tb_ChatSessionUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChatSession_ChatMessage",
                        column: x => x.SessionId,
                        principalTable: "tb_ChatSession",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Document_ChatMessage",
                        column: x => x.DocumentId,
                        principalTable: "tb_Document",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_MedicalRecordDoctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_MedicalRecordDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_MedicalRecordDoctors",
                        column: x => x.MedicalRecordId,
                        principalTable: "tb_MedicalRecord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_MedicalRecordDoctors",
                        column: x => x.DoctorId,
                        principalTable: "tb_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_MedicalRecordDocument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: false),
                    DocumentIdId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecordDocument_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_MedicalRecordDocument",
                        column: x => x.DocumentIdId,
                        principalTable: "tb_Document",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalRecord_MedicalRecordDocument",
                        column: x => x.MedicalRecordId,
                        principalTable: "tb_MedicalRecord",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_DateCreated",
                table: "tb_ChatMessage",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_SessionId",
                table: "tb_ChatMessage",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_UserId",
                table: "tb_ChatMessage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessageDocumentId",
                table: "tb_ChatMessage",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "UK_ChatMessage_SessionIdAndUserIdAndDateCreated",
                table: "tb_ChatMessage",
                columns: new[] { "SessionId", "UserId", "DateCreated" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatSession_DateCreated",
                table: "tb_ChatSession",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_ChatSession_Topic",
                table: "tb_ChatSession",
                column: "Topic");

            migrationBuilder.CreateIndex(
                name: "UK_ChatSession_TopicAndDateCreated",
                table: "tb_ChatSession",
                columns: new[] { "Topic", "DateCreated" },
                unique: true,
                filter: "[Topic] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChatSessionUser_DateCreated",
                table: "tb_ChatSessionUser",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_ChatSessionUser_SessionId",
                table: "tb_ChatSessionUser",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatSessionUser_User1Id",
                table: "tb_ChatSessionUser",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChatSessionUser_User2Id",
                table: "tb_ChatSessionUser",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "UK_ChatSessionUser_SessionIdAndUser1IdAndUser2Id",
                table: "tb_ChatSessionUser",
                columns: new[] { "SessionId", "User1Id", "User2Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_SpecialityId",
                table: "tb_Clinic",
                column: "SpecialityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_Clinic_OrganizationId",
                table: "tb_Clinic",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "UK_Clinic_BrandName",
                table: "tb_Clinic",
                column: "BrandName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Clinic_Email",
                table: "tb_Clinic",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Clinic_Phone",
                table: "tb_Clinic",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicService_ClinicId",
                table: "tb_ClinicService",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicService_ServiceId",
                table: "tb_ClinicService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "UK_ClinicService_ClinicIdAndServiceId",
                table: "tb_ClinicService",
                columns: new[] { "ClinicId", "ServiceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicStaff_ClinicId",
                table: "tb_ClinicStaff",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicStaff_UserId",
                table: "tb_ClinicStaff",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UK_ClinicStaff_ClinicIdAndUserId",
                table: "tb_ClinicStaff",
                columns: new[] { "ClinicId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicWaiting_ClinicId",
                table: "tb_ClinicWaiting",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicWaiting_ClinicIdAndUserId",
                table: "tb_ClinicWaiting",
                columns: new[] { "ClinicId", "PatientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicWaiting_DateCreated",
                table: "tb_ClinicWaiting",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicWaiting_UserId",
                table: "tb_ClinicWaiting",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentKey",
                table: "tb_Document",
                column: "DocumentKey");

            migrationBuilder.CreateIndex(
                name: "IX_Document_UserId",
                table: "tb_Document",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterAdmin_Password",
                table: "tb_MasterAdmin",
                column: "Password");

            migrationBuilder.CreateIndex(
                name: "UK_MasterAdmin_Email",
                table: "tb_MasterAdmin",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_MasterAdmin_FullName",
                table: "tb_MasterAdmin",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_MasterAdmin_Phone",
                table: "tb_MasterAdmin",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MasterAdminRole_MasterAdminId",
                table: "tb_MasterAdminRole",
                column: "MasterAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterAdminRole_RoleId",
                table: "tb_MasterAdminRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UK_MasterAdminRole_MasterAdminIdAndRoleId",
                table: "tb_MasterAdminRole",
                columns: new[] { "MasterAdminId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_ClinicId",
                table: "tb_MedicalRecord",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_UserId",
                table: "tb_MedicalRecord",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_VisitDate",
                table: "tb_MedicalRecord",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_tb_MedicalRecord",
                table: "tb_MedicalRecord",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_MedicalRecord_RecordTypeId",
                table: "tb_MedicalRecord",
                column: "RecordTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_MedicalRecordDoctors_DoctorId",
                table: "tb_MedicalRecordDoctors",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_MedicalRecordDoctors_MedicalRecordId",
                table: "tb_MedicalRecordDoctors",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_MedicalRecordDocument_DocumentIdId",
                table: "tb_MedicalRecordDocument",
                column: "DocumentIdId");

            migrationBuilder.CreateIndex(
                name: "UK_MedicalRecordDocument_RecordIdAndDocumentId",
                table: "tb_MedicalRecordDocument",
                columns: new[] { "MedicalRecordId", "DocumentIdId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClinicId",
                table: "tb_Reservation",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ReservationDate",
                table: "tb_Reservation",
                column: "ReservationDate");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "tb_Reservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UK_Reservation_ClinicIdAndUserIdAndResDate",
                table: "tb_Reservation",
                columns: new[] { "ClinicId", "UserId", "ReservationDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationGuide_ClinicId",
                table: "tb_ReservationGuide",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "UK_ReservationGuide_ClinicId",
                table: "tb_ReservationGuide",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ClinicId",
                table: "tb_Review",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_DateCreated",
                table: "tb_Review",
                column: "DateCreated");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "tb_Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UK_Review_ClinicIdAndUserId",
                table: "tb_Review",
                columns: new[] { "ClinicId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_RoleName",
                table: "tb_Role",
                column: "RoleName");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRole_ClinicStaffId",
                table: "tb_StaffRole",
                column: "ClinicStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRole_RoleId",
                table: "tb_StaffRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UK_StaffRole_ClinicStaffIdAndRoleId",
                table: "tb_StaffRole",
                columns: new[] { "ClinicStaffId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaticData_StaticDataTypeId",
                table: "tb_StaticData",
                column: "StaticDataTypeId");

            migrationBuilder.CreateIndex(
                name: "UK_StaticData_TypeIdAndName",
                table: "tb_StaticData",
                columns: new[] { "StaticDataTypeId", "Name" },
                unique: true,
                filter: "[StaticDataTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UK_StaticDataType_Name",
                table: "tb_StaticDataType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_User_OrganizationId",
                table: "tb_User",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SpecialityId",
                table: "tb_User",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeId",
                table: "tb_User",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "UK_User_Email",
                table: "tb_User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "UK_User_FullName",
                table: "tb_User",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_User_Phone",
                table: "tb_User",
                column: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ChatMessage");

            migrationBuilder.DropTable(
                name: "tb_ClinicService");

            migrationBuilder.DropTable(
                name: "tb_ClinicWaiting");

            migrationBuilder.DropTable(
                name: "tb_MasterAdminRole");

            migrationBuilder.DropTable(
                name: "tb_MedicalRecordDoctors");

            migrationBuilder.DropTable(
                name: "tb_MedicalRecordDocument");

            migrationBuilder.DropTable(
                name: "tb_Reservation");

            migrationBuilder.DropTable(
                name: "tb_ReservationGuide");

            migrationBuilder.DropTable(
                name: "tb_Review");

            migrationBuilder.DropTable(
                name: "tb_StaffRole");

            migrationBuilder.DropTable(
                name: "tb_ChatSessionUser");

            migrationBuilder.DropTable(
                name: "tb_MasterAdmin");

            migrationBuilder.DropTable(
                name: "tb_Document");

            migrationBuilder.DropTable(
                name: "tb_MedicalRecord");

            migrationBuilder.DropTable(
                name: "tb_ClinicStaff");

            migrationBuilder.DropTable(
                name: "tb_Role");

            migrationBuilder.DropTable(
                name: "tb_ChatSession");

            migrationBuilder.DropTable(
                name: "tb_Clinic");

            migrationBuilder.DropTable(
                name: "tb_User");

            migrationBuilder.DropTable(
                name: "tb_Organization");

            migrationBuilder.DropTable(
                name: "tb_StaticData");

            migrationBuilder.DropTable(
                name: "tb_StaticDataType");
        }
    }
}
