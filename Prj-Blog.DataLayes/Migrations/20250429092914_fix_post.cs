﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prj_Blog.DataLayes.Migrations
{
    /// <inheritdoc />
    public partial class fix_post : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SubCategoryId",
                table: "Posts",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_SubCategoryId",
                table: "Posts",
                column: "SubCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_SubCategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SubCategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Posts");
        }
    }
}
