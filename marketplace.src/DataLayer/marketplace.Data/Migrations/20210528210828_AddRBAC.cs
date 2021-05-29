using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class AddRBAC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "VaiTro",
                type: "ntext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)");

            migrationBuilder.AlterColumn<string>(
                name: "MaSP",
                table: "SanPham",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "MaNB",
                table: "NguoiBan",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "MaNN",
                table: "NgonNgu",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "NgonNgu",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)");

            migrationBuilder.AlterColumn<string>(
                name: "TenDayDu",
                table: "LangNghe",
                type: "ntext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)");

            migrationBuilder.AlterColumn<string>(
                name: "MaLN",
                table: "LangNghe",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "HinhAnh",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaHA",
                table: "HinhAnh",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Loai",
                table: "HinhAnh",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoiTuongId",
                table: "HinhAnh",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NhaCungCap",
                table: "GiaoDich",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaGD",
                table: "GiaoDich",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaDH",
                table: "DonHang",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "MaSo",
                table: "DanhMuc",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenDayDu",
                table: "CuaHang",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaCH",
                table: "CuaHang",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenDayDu",
                table: "ChiTietSanPham",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NgonNguId",
                table: "ChiTietSanPham",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)");

            migrationBuilder.AlterColumn<string>(
                name: "NgonNguId",
                table: "ChiTietDanhMuc",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)");

            migrationBuilder.CreateTable(
                name: "QuyenEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(nullable: false),
                    Ten = table.Column<string>(type: "varchar(256)", nullable: false),
                    MoTa = table.Column<string>(type: "ntext", nullable: false),
                    TenEntity = table.Column<string>(type: "varchar(256)", nullable: false),
                    HanhDong = table.Column<string>(type: "varchar(256)", nullable: false),
                    BitFields = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuyenRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(nullable: false),
                    Ten = table.Column<string>(type: "varchar(256)", nullable: false),
                    MoTa = table.Column<string>(type: "ntext", nullable: false),
                    HanhDong = table.Column<string>(type: "varchar(256)", nullable: false),
                    PathRegex = table.Column<string>(type: "ntext", nullable: false),
                    LaRouteCanXacThuc = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenRoute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuyenEntityTaiKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(nullable: false),
                    TaiKhoanId = table.Column<Guid>(nullable: false),
                    QuyenEntityId = table.Column<int>(nullable: false),
                    EntityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenEntityTaiKhoan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyenEntityTaiKhoan_QuyenEntity_QuyenEntityId",
                        column: x => x.QuyenEntityId,
                        principalTable: "QuyenEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyenEntityTaiKhoan_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuyenEntityVaiTro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(nullable: false),
                    QuyenEntityId = table.Column<int>(nullable: false),
                    VaiTroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenEntityVaiTro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyenEntityVaiTro_QuyenEntity_QuyenEntityId",
                        column: x => x.QuyenEntityId,
                        principalTable: "QuyenEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyenEntityVaiTro_VaiTro_VaiTroId",
                        column: x => x.VaiTroId,
                        principalTable: "VaiTro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuyenRouteVaiTro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(nullable: false),
                    QuyenRouteId = table.Column<int>(nullable: false),
                    VaiTroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenRouteVaiTro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyenRouteVaiTro_QuyenRoute_QuyenRouteId",
                        column: x => x.QuyenRouteId,
                        principalTable: "QuyenRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyenRouteVaiTro_VaiTro_VaiTroId",
                        column: x => x.VaiTroId,
                        principalTable: "VaiTro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuyenEntityTaiKhoan_QuyenEntityId",
                table: "QuyenEntityTaiKhoan",
                column: "QuyenEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenEntityTaiKhoan_TaiKhoanId",
                table: "QuyenEntityTaiKhoan",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenEntityVaiTro_QuyenEntityId",
                table: "QuyenEntityVaiTro",
                column: "QuyenEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenEntityVaiTro_VaiTroId",
                table: "QuyenEntityVaiTro",
                column: "VaiTroId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenRouteVaiTro_QuyenRouteId",
                table: "QuyenRouteVaiTro",
                column: "QuyenRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenRouteVaiTro_VaiTroId",
                table: "QuyenRouteVaiTro",
                column: "VaiTroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuyenEntityTaiKhoan");

            migrationBuilder.DropTable(
                name: "QuyenEntityVaiTro");

            migrationBuilder.DropTable(
                name: "QuyenRouteVaiTro");

            migrationBuilder.DropTable(
                name: "QuyenEntity");

            migrationBuilder.DropTable(
                name: "QuyenRoute");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "VaiTro",
                type: "nvarchar(1024)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.AlterColumn<string>(
                name: "MaSP",
                table: "SanPham",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "MaNB",
                table: "NguoiBan",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "MaNN",
                table: "NgonNgu",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "NgonNgu",
                type: "varchar(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "TenDayDu",
                table: "LangNghe",
                type: "nvarchar(1024)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.AlterColumn<string>(
                name: "MaLN",
                table: "LangNghe",
                type: "nvarchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "HinhAnh",
                type: "nvarchar(1024)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaHA",
                table: "HinhAnh",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Loai",
                table: "HinhAnh",
                type: "nvarchar(1024)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoiTuongId",
                table: "HinhAnh",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NhaCungCap",
                table: "GiaoDich",
                type: "nvarchar(1024)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaGD",
                table: "GiaoDich",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaDH",
                table: "DonHang",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "MaSo",
                table: "DanhMuc",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenDayDu",
                table: "CuaHang",
                type: "nvarchar(1024)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaCH",
                table: "CuaHang",
                type: "nvarchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenDayDu",
                table: "ChiTietSanPham",
                type: "nvarchar(1024)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NgonNguId",
                table: "ChiTietSanPham",
                type: "varchar(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "NgonNguId",
                table: "ChiTietDanhMuc",
                type: "varchar(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");
        }
    }
}
