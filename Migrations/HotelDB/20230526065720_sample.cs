using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations.HotelDB
{
    /// <inheritdoc />
    public partial class sample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    CustId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.CustId);
                });

            migrationBuilder.CreateTable(
                name: "HotelDetails",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomsAvailable = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDetails", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "RoomDetails",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChargePerDay = table.Column<int>(type: "int", nullable: false),
                    HotelDetailsHotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDetails", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_RoomDetails_HotelDetails_HotelDetailsHotelId",
                        column: x => x.HotelDetailsHotelId,
                        principalTable: "HotelDetails",
                        principalColumn: "HotelId");
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CustomerDetailsCustId = table.Column<int>(type: "int", nullable: true),
                    RoomDetailsRoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingDetails_CustomerDetails_CustomerDetailsCustId",
                        column: x => x.CustomerDetailsCustId,
                        principalTable: "CustomerDetails",
                        principalColumn: "CustId");
                    table.ForeignKey(
                        name: "FK_BookingDetails_RoomDetails_RoomDetailsRoomId",
                        column: x => x.RoomDetailsRoomId,
                        principalTable: "RoomDetails",
                        principalColumn: "RoomId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_CustomerDetailsCustId",
                table: "BookingDetails",
                column: "CustomerDetailsCustId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_RoomDetailsRoomId",
                table: "BookingDetails",
                column: "RoomDetailsRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetails_HotelDetailsHotelId",
                table: "RoomDetails",
                column: "HotelDetailsHotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "CustomerDetails");

            migrationBuilder.DropTable(
                name: "RoomDetails");

            migrationBuilder.DropTable(
                name: "HotelDetails");
        }
    }
}
