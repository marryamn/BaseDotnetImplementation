using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class add_roleId_to_admin_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                table: "Admins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_RoleId",
                table: "Admins",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Roles_RoleId",
                table: "Admins",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Roles_RoleId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_RoleId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Admins");
        }
    }
}
