using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_053502_Raniuk.Migrations
{
    public partial class test11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "AvatarImage",
                table: "User",
                newName: "Avatar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Avatar",
                table: "User",
                newName: "AvatarImage");

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "User",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
