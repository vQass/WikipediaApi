using Microsoft.EntityFrameworkCore.Migrations;

namespace SmWikipediaWebApi.Migrations
{
    public partial class DisplayOrderInArticleContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SectionName",
                table: "ArticleContents",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<short>(
                name: "DisplayOrder",
                table: "ArticleContents",
                type: "smallint",
                maxLength: 255,
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "ArticleContents");

            migrationBuilder.AlterColumn<string>(
                name: "SectionName",
                table: "ArticleContents",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
