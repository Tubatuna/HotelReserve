using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class level2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Room_RoomID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Booking_Booking_BookingID",
                table: "Guests_Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Booking_Guest_GuestID",
                table: "Guests_Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Booking_BookingID",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Hotel_HotelID",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RoomTypeID",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Hotel_HotelID",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomType",
                table: "RoomType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests_Booking",
                table: "Guests_Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guest",
                table: "Guest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "RoomType",
                newName: "RoomTypes");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "Hotel",
                newName: "Hotels");

            migrationBuilder.RenameTable(
                name: "Guests_Booking",
                newName: "Guests_Bookings");

            migrationBuilder.RenameTable(
                name: "Guest",
                newName: "Guests");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Room_RoomTypeID",
                table: "Rooms",
                newName: "IX_Rooms_RoomTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Room_HotelID",
                table: "Rooms",
                newName: "IX_Rooms_HotelID");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_BookingID",
                table: "Payments",
                newName: "IX_Payments_BookingID");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_Booking_BookingID",
                table: "Guests_Bookings",
                newName: "IX_Guests_Bookings_BookingID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_RoomID",
                table: "Bookings",
                newName: "IX_Bookings_RoomID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests_Bookings",
                table: "Guests_Bookings",
                columns: new[] { "GuestID", "BookingID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests",
                table: "Guests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomID",
                table: "Bookings",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Bookings_Bookings_BookingID",
                table: "Guests_Bookings",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Bookings_Guests_GuestID",
                table: "Guests_Bookings",
                column: "GuestID",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bookings_BookingID",
                table: "Payments",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelID",
                table: "Rooms",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeID",
                table: "Rooms",
                column: "RoomTypeID",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Hotels_HotelID",
                table: "Staff",
                column: "HotelID",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Bookings_Bookings_BookingID",
                table: "Guests_Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Bookings_Guests_GuestID",
                table: "Guests_Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bookings_BookingID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Hotels_HotelID",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomTypes",
                table: "RoomTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests_Bookings",
                table: "Guests_Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests",
                table: "Guests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "RoomTypes",
                newName: "RoomType");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameTable(
                name: "Hotels",
                newName: "Hotel");

            migrationBuilder.RenameTable(
                name: "Guests_Bookings",
                newName: "Guests_Booking");

            migrationBuilder.RenameTable(
                name: "Guests",
                newName: "Guest");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_RoomTypeID",
                table: "Room",
                newName: "IX_Room_RoomTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_HotelID",
                table: "Room",
                newName: "IX_Room_HotelID");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_BookingID",
                table: "Payment",
                newName: "IX_Payment_BookingID");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_Bookings_BookingID",
                table: "Guests_Booking",
                newName: "IX_Guests_Booking_BookingID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RoomID",
                table: "Booking",
                newName: "IX_Booking_RoomID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomType",
                table: "RoomType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests_Booking",
                table: "Guests_Booking",
                columns: new[] { "GuestID", "BookingID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guest",
                table: "Guest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Room_RoomID",
                table: "Booking",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Booking_Booking_BookingID",
                table: "Guests_Booking",
                column: "BookingID",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Booking_Guest_GuestID",
                table: "Guests_Booking",
                column: "GuestID",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Booking_BookingID",
                table: "Payment",
                column: "BookingID",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Hotel_HotelID",
                table: "Room",
                column: "HotelID",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RoomTypeID",
                table: "Room",
                column: "RoomTypeID",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Hotel_HotelID",
                table: "Staff",
                column: "HotelID",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
