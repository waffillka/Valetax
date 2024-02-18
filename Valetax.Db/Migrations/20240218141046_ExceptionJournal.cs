using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valetax.Db.Migrations
{
    /// <inheritdoc />
    public partial class ExceptionJournal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExceptionJournal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    StackTrace = table.Column<string>(type: "text", nullable: true),
                    TraceIdentifier = table.Column<string>(type: "text", nullable: true),
                    RequestParameters = table.Column<string>(type: "text", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionJournal", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExceptionJournal");
        }
    }
}
