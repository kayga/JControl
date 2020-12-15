using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JControl.Base.Models.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortCateories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortCateories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Device",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Origin = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Cateory = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Device", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RouterLink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    RouterType = table.Column<int>(nullable: false),
                    RouterKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RouterLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductPorts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    PortName = table.Column<string>(nullable: true),
                    PortKey = table.Column<string>(nullable: true),
                    ParentProductId = table.Column<int>(nullable: false),
                    PortCateoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPorts_tbl_Device_ParentProductId",
                        column: x => x.ParentProductId,
                        principalTable: "tbl_Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPorts_PortCateories_PortCateoryId",
                        column: x => x.PortCateoryId,
                        principalTable: "PortCateories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RoomDevice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    DisName = table.Column<string>(maxLength: 20, nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RoomDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_RoomDevice_tbl_Device_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tbl_Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPorts_ParentProductId",
                table: "ProductPorts",
                column: "ParentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPorts_PortCateoryId",
                table: "ProductPorts",
                column: "PortCateoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RoomDevice_ProductId",
                table: "tbl_RoomDevice",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPorts");

            migrationBuilder.DropTable(
                name: "tbl_RoomDevice");

            migrationBuilder.DropTable(
                name: "tbl_RouterLink");

            migrationBuilder.DropTable(
                name: "PortCateories");

            migrationBuilder.DropTable(
                name: "tbl_Device");
        }
    }
}
