using Microsoft.EntityFrameworkCore.Migrations;

namespace Doctor.Scheduler.Api.Migrations
{
    public partial class AddAttendees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Events_AttendeesId",
                table: "Events",
                column: "AttendeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Attendees_AttendeesId",
                table: "Events",
                column: "AttendeesId",
                principalTable: "Attendees",
                principalColumn: "AttendeesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Attendees_AttendeesId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_AttendeesId",
                table: "Events");
        }
    }
}
