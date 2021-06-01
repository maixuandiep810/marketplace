using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class TaiCauTrucJwt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuyenEntityTaiKhoan");

            migrationBuilder.DropTable(
                name: "QuyenEntityVaiTro");

            migrationBuilder.DropTable(
                name: "QuyenEntity");

            migrationBuilder.AddColumn<int>(
                name: "BitFields",
                table: "QuyenRoute",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JwtToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    Token = table.Column<string>(nullable: true),
                    TaiKhoanId = table.Column<Guid>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JwtToken");

            migrationBuilder.DropColumn(
                name: "BitFields",
                table: "QuyenRoute");

            migrationBuilder.CreateTable(
                name: "QuyenEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BitFields = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HanhDong = table.Column<string>(type: "varchar(256)", nullable: false),
                    MoTa = table.Column<string>(type: "ntext", nullable: false),
                    Ten = table.Column<string>(type: "varchar(256)", nullable: false),
                    TenEntity = table.Column<string>(type: "varchar(256)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuyenEntityTaiKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EntityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuyenEntityId = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    QuyenEntityId = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    VaiTroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
        }
    }
}
