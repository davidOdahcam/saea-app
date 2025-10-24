using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAEA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_OPERATING_BLOCKS",
                columns: table => new
                {
                    ST_OPERATING_BLOCK_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NB_RESOURCE_TYPE = table.Column<int>(type: "int", nullable: false),
                    ST_RESOURCE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DT_START_DATE_TIME = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DT_END_DATE_TIME = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ST_REASON = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_OPERATING_BLOCKS", x => x.ST_OPERATING_BLOCK_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_OPERATING_HOURS",
                columns: table => new
                {
                    ST_OPERATING_HOURS_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NB_RESOURCE_TYPE = table.Column<int>(type: "int", nullable: false),
                    ST_RESOURCE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NB_DAY_OF_WEEK = table.Column<int>(type: "int", nullable: false),
                    DT_START_TIME = table.Column<TimeSpan>(type: "time", nullable: false),
                    DT_END_TIME = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_OPERATING_HOURS", x => x.ST_OPERATING_HOURS_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PAVILIONS",
                columns: table => new
                {
                    ST_PAVILION_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ST_CODE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ST_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PAVILIONS", x => x.ST_PAVILION_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_ROOMS",
                columns: table => new
                {
                    ST_ROOM_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ST_CODE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ST_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NB_CAPACITY = table.Column<int>(type: "int", nullable: false),
                    ST_PAVILION_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ROOMS", x => x.ST_ROOM_ID);
                    table.ForeignKey(
                        name: "FK_TB_ROOMS_TB_PAVILIONS_ST_PAVILION_ID",
                        column: x => x.ST_PAVILION_ID,
                        principalTable: "TB_PAVILIONS",
                        principalColumn: "ST_PAVILION_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_DESKS",
                columns: table => new
                {
                    ST_DESK_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ST_CODE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ST_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NB_CAPACITY = table.Column<int>(type: "int", nullable: false),
                    ST_ROOM_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DESKS", x => x.ST_DESK_ID);
                    table.ForeignKey(
                        name: "FK_TB_DESKS_TB_ROOMS_ST_ROOM_ID",
                        column: x => x.ST_ROOM_ID,
                        principalTable: "TB_ROOMS",
                        principalColumn: "ST_ROOM_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_DESKS_ST_ROOM_ID",
                table: "TB_DESKS",
                column: "ST_ROOM_ID");

            migrationBuilder.CreateIndex(
                name: "UN_DESK_CODE",
                table: "TB_DESKS",
                column: "ST_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OPERATING_BLOCKS_END",
                table: "TB_OPERATING_BLOCKS",
                column: "DT_END_DATE_TIME");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATING_BLOCKS_RESOURCE",
                table: "TB_OPERATING_BLOCKS",
                columns: new[] { "NB_RESOURCE_TYPE", "ST_RESOURCE_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_OPERATING_BLOCKS_RESOURCE_PERIOD",
                table: "TB_OPERATING_BLOCKS",
                columns: new[] { "NB_RESOURCE_TYPE", "ST_RESOURCE_ID", "DT_START_DATE_TIME", "DT_END_DATE_TIME" });

            migrationBuilder.CreateIndex(
                name: "IX_OPERATING_BLOCKS_START",
                table: "TB_OPERATING_BLOCKS",
                column: "DT_START_DATE_TIME");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATING_HOURS_DAY",
                table: "TB_OPERATING_HOURS",
                column: "NB_DAY_OF_WEEK");

            migrationBuilder.CreateIndex(
                name: "IX_OPERATING_HOURS_RESOURCE",
                table: "TB_OPERATING_HOURS",
                columns: new[] { "NB_RESOURCE_TYPE", "ST_RESOURCE_ID" });

            migrationBuilder.CreateIndex(
                name: "UN_PAVILION_CODE",
                table: "TB_PAVILIONS",
                column: "ST_CODE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ROOMS_ST_PAVILION_ID",
                table: "TB_ROOMS",
                column: "ST_PAVILION_ID");

            migrationBuilder.CreateIndex(
                name: "UN_ROOM_CODE",
                table: "TB_ROOMS",
                column: "ST_CODE",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_DESKS");

            migrationBuilder.DropTable(
                name: "TB_OPERATING_BLOCKS");

            migrationBuilder.DropTable(
                name: "TB_OPERATING_HOURS");

            migrationBuilder.DropTable(
                name: "TB_ROOMS");

            migrationBuilder.DropTable(
                name: "TB_PAVILIONS");
        }
    }
}
