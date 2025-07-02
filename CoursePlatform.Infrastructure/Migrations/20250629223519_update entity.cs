using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursePlatform.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AppUserInfo_UserId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_AppUserInfo_User_Id",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_AspNetUsers_ApplicationUserId",
                table: "Favourites");

            migrationBuilder.DropTable(
                name: "AppUserInfo");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_ApplicationUserId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Favourites");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_UserId",
                table: "Courses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_AspNetUsers_User_Id",
                table: "Favourites",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_UserId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_AspNetUsers_User_Id",
                table: "Favourites");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Favourites",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppUserInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_ApplicationUserId",
                table: "Favourites",
                column: "ApplicationUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_AspNetUsers_ApplicationUserId",
                table: "Favourites",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
