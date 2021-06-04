using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Data.Migrations
{
    public partial class XoaLangNgheDanhMuc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LangNgheDanhMuc");

            migrationBuilder.AddColumn<int>(
                name: "DanhMucId",
                table: "LangNghe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LangNghe_DanhMucId",
                table: "LangNghe",
                column: "DanhMucId");

            migrationBuilder.AddForeignKey(
                name: "FK_LangNghe_DanhMuc_DanhMucId",
                table: "LangNghe",
                column: "DanhMucId",
                principalTable: "DanhMuc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LangNghe_DanhMuc_DanhMucId",
                table: "LangNghe");

            migrationBuilder.DropIndex(
                name: "IX_LangNghe_DanhMucId",
                table: "LangNghe");

            migrationBuilder.DropColumn(
                name: "DanhMucId",
                table: "LangNghe");

            migrationBuilder.CreateTable(
                name: "LangNgheDanhMuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DanhMucId = table.Column<int>(type: "int", nullable: false),
                    LangNgheId = table.Column<int>(type: "int", nullable: false),
                    MaSo = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangNgheDanhMuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LangNgheDanhMuc_DanhMuc_DanhMucId",
                        column: x => x.DanhMucId,
                        principalTable: "DanhMuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LangNgheDanhMuc_LangNghe_LangNgheId",
                        column: x => x.LangNgheId,
                        principalTable: "LangNghe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LangNgheDanhMuc_DanhMucId",
                table: "LangNgheDanhMuc",
                column: "DanhMucId");

            migrationBuilder.CreateIndex(
                name: "IX_LangNgheDanhMuc_LangNgheId",
                table: "LangNgheDanhMuc",
                column: "LangNgheId");
        }
    }
}
