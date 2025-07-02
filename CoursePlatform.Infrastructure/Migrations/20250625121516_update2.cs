using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursePlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_appUserInfo_UserId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_appUserInfo_User_Id",
                table: "Favourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appUserInfo",
                table: "appUserInfo");

            migrationBuilder.RenameTable(
                name: "appUserInfo",
                newName: "AppUserInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserInfo",
                table: "AppUserInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AppUserInfo_UserId",
                table: "Courses",
                column: "UserId",
                principalTable: "AppUserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_AppUserInfo_User_Id",
                table: "Favourites",
                column: "User_Id",
                principalTable: "AppUserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AppUserInfo_UserId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_AppUserInfo_User_Id",
                table: "Favourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserInfo",
                table: "AppUserInfo");

            migrationBuilder.RenameTable(
                name: "AppUserInfo",
                newName: "appUserInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appUserInfo",
                table: "appUserInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_appUserInfo_UserId",
                table: "Courses",
                column: "UserId",
                principalTable: "appUserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_appUserInfo_User_Id",
                table: "Favourites",
                column: "User_Id",
                principalTable: "appUserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
