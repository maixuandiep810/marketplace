using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class nvarcharLoai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JwtToken");

            migrationBuilder.AlterColumn<string>(
                name: "Loai",
                table: "HinhAnh",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Loai",
                table: "HinhAnh",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "JwtToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JwtToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JwtToken_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JwtToken_TaiKhoanId",
                table: "JwtToken",
                column: "TaiKhoanId");
        }
    }
}
