using Microsoft.EntityFrameworkCore.Migrations;

namespace SmWikipediaWebApi.Migrations
{
    public partial class AddedCommentsAcceptation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Comments",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Comments");
        }
    }
}
