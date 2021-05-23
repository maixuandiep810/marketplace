using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPham_Languages_NgonNguId",
                table: "ChiTietSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDichThuat_Languages_NgonNguId",
                table: "DanhMucDichThuat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "NgonNgu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NgonNgu",
                table: "NgonNgu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPham_NgonNgu_NgonNguId",
                table: "ChiTietSanPham",
                column: "NgonNguId",
                principalTable: "NgonNgu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDichThuat_NgonNgu_NgonNguId",
                table: "DanhMucDichThuat",
                column: "NgonNguId",
                principalTable: "NgonNgu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietSanPham_NgonNgu_NgonNguId",
                table: "ChiTietSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDichThuat_NgonNgu_NgonNguId",
                table: "DanhMucDichThuat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NgonNgu",
                table: "NgonNgu");

            migrationBuilder.RenameTable(
                name: "NgonNgu",
                newName: "Languages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietSanPham_Languages_NgonNguId",
                table: "ChiTietSanPham",
                column: "NgonNguId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDichThuat_Languages_NgonNguId",
                table: "DanhMucDichThuat",
                column: "NgonNguId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
