using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class ReNameCapXa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CapXaId",
                table: "LangNghe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "LangNghe",
                type: "ntext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "CuaHang",
                type: "ntext",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CapTinh",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    MaTinh = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapTinh", x => x.Id);
                    table.UniqueConstraint("AK_CapTinh_Ten", x => x.Ten);
                });

            migrationBuilder.CreateTable(
                name: "CapHuyen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    MaHuyen = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    CapTinhId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapHuyen", x => x.Id);
                    table.UniqueConstraint("AK_CapHuyen_Ten", x => x.Ten);
                    table.ForeignKey(
                        name: "FK_CapHuyen_CapTinh_CapTinhId",
                        column: x => x.CapTinhId,
                        principalTable: "CapTinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapXa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(nullable: false, defaultValue: false),
                    TrangThai = table.Column<int>(nullable: false, defaultValue: 0),
                    MaXa = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    CapHuyenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapXa", x => x.Id);
                    table.UniqueConstraint("AK_CapXa_Ten", x => x.Ten);
                    table.ForeignKey(
                        name: "FK_CapXa_CapHuyen_CapHuyenId",
                        column: x => x.CapHuyenId,
                        principalTable: "CapHuyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LangNghe_CapXaId",
                table: "LangNghe",
                column: "CapXaId");

            migrationBuilder.CreateIndex(
                name: "IX_CapHuyen_CapTinhId",
                table: "CapHuyen",
                column: "CapTinhId");

            migrationBuilder.CreateIndex(
                name: "IX_CapXa_CapHuyenId",
                table: "CapXa",
                column: "CapHuyenId");

            migrationBuilder.AddForeignKey(
                name: "FK_LangNghe_CapXa_CapXaId",
                table: "LangNghe",
                column: "CapXaId",
                principalTable: "CapXa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LangNghe_CapXa_CapXaId",
                table: "LangNghe");

            migrationBuilder.DropTable(
                name: "CapXa");

            migrationBuilder.DropTable(
                name: "CapHuyen");

            migrationBuilder.DropTable(
                name: "CapTinh");

            migrationBuilder.DropIndex(
                name: "IX_LangNghe_CapXaId",
                table: "LangNghe");

            migrationBuilder.DropColumn(
                name: "CapXaId",
                table: "LangNghe");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "LangNghe");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "CuaHang");
        }
    }
}
