using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPhamDichThuat");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "Ten",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "TenDayDu",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "HinhAnh");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "HinhAnh");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "HinhAnh");

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "VaiTro",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "TaiKhoan",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "SanPhamDanhMuc",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "SanPham",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "QuanLyDonHang",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "NguoiBan",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "Languages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "LangNgheDanhMuc",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "LangNghe",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "KhachHang",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "HinhAnh",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LaAnhMacDinh",
                table: "HinhAnh",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ThuTu",
                table: "HinhAnh",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "GioHang",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "GiaoDich",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "DanhMucDichThuat",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "DanhMuc",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "CuaHang",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DaXoa",
                table: "ChiTietDonHang",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ChiTietSanPham",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    TenDayDu = table.Column<string>(type: "nvarchar(1024)", nullable: true),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    SanPhamId = table.Column<int>(nullable: false),
                    NgonNguId = table.Column<string>(type: "varchar(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietSanPham", x => x.Id);
                    table.UniqueConstraint("AK_ChiTietSanPham_SanPhamId_NgonNguId", x => new { x.SanPhamId, x.NgonNguId });
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_Languages_NgonNguId",
                        column: x => x.NgonNguId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietSanPham_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietSanPham_NgonNguId",
                table: "ChiTietSanPham",
                column: "NgonNguId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietSanPham");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "VaiTro");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "TaiKhoan");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "SanPhamDanhMuc");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "QuanLyDonHang");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "NguoiBan");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "LangNgheDanhMuc");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "LangNghe");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "HinhAnh");

            migrationBuilder.DropColumn(
                name: "LaAnhMacDinh",
                table: "HinhAnh");

            migrationBuilder.DropColumn(
                name: "ThuTu",
                table: "HinhAnh");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "GioHang");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "GiaoDich");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "DanhMucDichThuat");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "DanhMuc");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "CuaHang");

            migrationBuilder.DropColumn(
                name: "DaXoa",
                table: "ChiTietDonHang");

            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ten",
                table: "SanPham",
                type: "nvarchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenDayDu",
                table: "SanPham",
                type: "nvarchar(1024)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "HinhAnh",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "HinhAnh",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "HinhAnh",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SanPhamDichThuat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoTa = table.Column<string>(type: "ntext", nullable: true),
                    NgonNguId = table.Column<string>(type: "varchar(16)", nullable: false),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    TenDayDu = table.Column<string>(type: "nvarchar(1024)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamDichThuat", x => x.Id);
                    table.UniqueConstraint("AK_SanPhamDichThuat_SanPhamId_NgonNguId", x => new { x.SanPhamId, x.NgonNguId });
                    table.ForeignKey(
                        name: "FK_SanPhamDichThuat_Languages_NgonNguId",
                        column: x => x.NgonNguId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamDichThuat_SanPham_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamDichThuat_NgonNguId",
                table: "SanPhamDichThuat",
                column: "NgonNguId");
        }
    }
}
