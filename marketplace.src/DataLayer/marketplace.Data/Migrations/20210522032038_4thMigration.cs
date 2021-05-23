using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class _4thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_Orders_DonHangId",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDichThuat_DanhMuc_DanhMucId",
                table: "DanhMucDichThuat");

            migrationBuilder.DropForeignKey(
                name: "FK_DanhMucDichThuat_NgonNgu_NgonNguId",
                table: "DanhMucDichThuat");

            migrationBuilder.DropForeignKey(
                name: "FK_GiaoDich_Orders_DonHangId",
                table: "GiaoDich");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_KhachHang_KhachHangId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_QuanLyDonHang_Orders_DonHangId",
                table: "QuanLyDonHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DanhMucDichThuat",
                table: "DanhMucDichThuat");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_DanhMucDichThuat_DanhMucId_NgonNguId",
                table: "DanhMucDichThuat");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "DonHang");

            migrationBuilder.RenameTable(
                name: "DanhMucDichThuat",
                newName: "ChiTietDanhMuc");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_KhachHangId",
                table: "DonHang",
                newName: "IX_DonHang_KhachHangId");

            migrationBuilder.RenameIndex(
                name: "IX_DanhMucDichThuat_NgonNguId",
                table: "ChiTietDanhMuc",
                newName: "IX_ChiTietDanhMuc_NgonNguId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonHang",
                table: "DonHang",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietDanhMuc",
                table: "ChiTietDanhMuc",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ChiTietDanhMuc_DanhMucId_NgonNguId",
                table: "ChiTietDanhMuc",
                columns: new[] { "DanhMucId", "NgonNguId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDanhMuc_DanhMuc_DanhMucId",
                table: "ChiTietDanhMuc",
                column: "DanhMucId",
                principalTable: "DanhMuc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDanhMuc_NgonNgu_NgonNguId",
                table: "ChiTietDanhMuc",
                column: "NgonNguId",
                principalTable: "NgonNgu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_DonHang_DonHangId",
                table: "ChiTietDonHang",
                column: "DonHangId",
                principalTable: "DonHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHang_KhachHang_KhachHangId",
                table: "DonHang",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GiaoDich_DonHang_DonHangId",
                table: "GiaoDich",
                column: "DonHangId",
                principalTable: "DonHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuanLyDonHang_DonHang_DonHangId",
                table: "QuanLyDonHang",
                column: "DonHangId",
                principalTable: "DonHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDanhMuc_DanhMuc_DanhMucId",
                table: "ChiTietDanhMuc");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDanhMuc_NgonNgu_NgonNguId",
                table: "ChiTietDanhMuc");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDonHang_DonHang_DonHangId",
                table: "ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DonHang_KhachHang_KhachHangId",
                table: "DonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_GiaoDich_DonHang_DonHangId",
                table: "GiaoDich");

            migrationBuilder.DropForeignKey(
                name: "FK_QuanLyDonHang_DonHang_DonHangId",
                table: "QuanLyDonHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonHang",
                table: "DonHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietDanhMuc",
                table: "ChiTietDanhMuc");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ChiTietDanhMuc_DanhMucId_NgonNguId",
                table: "ChiTietDanhMuc");

            migrationBuilder.RenameTable(
                name: "DonHang",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "ChiTietDanhMuc",
                newName: "DanhMucDichThuat");

            migrationBuilder.RenameIndex(
                name: "IX_DonHang_KhachHangId",
                table: "Orders",
                newName: "IX_Orders_KhachHangId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietDanhMuc_NgonNguId",
                table: "DanhMucDichThuat",
                newName: "IX_DanhMucDichThuat_NgonNguId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DanhMucDichThuat",
                table: "DanhMucDichThuat",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_DanhMucDichThuat_DanhMucId_NgonNguId",
                table: "DanhMucDichThuat",
                columns: new[] { "DanhMucId", "NgonNguId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDonHang_Orders_DonHangId",
                table: "ChiTietDonHang",
                column: "DonHangId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDichThuat_DanhMuc_DanhMucId",
                table: "DanhMucDichThuat",
                column: "DanhMucId",
                principalTable: "DanhMuc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DanhMucDichThuat_NgonNgu_NgonNguId",
                table: "DanhMucDichThuat",
                column: "NgonNguId",
                principalTable: "NgonNgu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GiaoDich_Orders_DonHangId",
                table: "GiaoDich",
                column: "DonHangId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_KhachHang_KhachHangId",
                table: "Orders",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuanLyDonHang_Orders_DonHangId",
                table: "QuanLyDonHang",
                column: "DonHangId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
