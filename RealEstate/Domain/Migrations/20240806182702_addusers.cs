using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateAPI.Domain.Migrations
{
    /// <inheritdoc />
    public partial class addusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numOfAllowedProperty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfAddedPropertys = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Subscription_id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastEditDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEditBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Subscriptions_Subscription_id",
                        column: x => x.Subscription_id,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfRooms = table.Column<int>(type: "int", nullable: false),
                    NumOfBathrooms = table.Column<int>(type: "int", nullable: false),
                    NumOfFloors = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolService = table.Column<bool>(type: "bit", nullable: true),
                    WaterService = table.Column<bool>(type: "bit", nullable: true),
                    SupermarketService = table.Column<bool>(type: "bit", nullable: true),
                    GasStationService = table.Column<bool>(type: "bit", nullable: true),
                    ParkingService = table.Column<bool>(type: "bit", nullable: true),
                    PetsService = table.Column<bool>(type: "bit", nullable: true),
                    HospitalService = table.Column<bool>(type: "bit", nullable: true),
                    ElectricityService = table.Column<bool>(type: "bit", nullable: true),
                    User_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastEditDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEditBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_User_id",
                table: "Properties",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subscription_id",
                table: "Users",
                column: "Subscription_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
