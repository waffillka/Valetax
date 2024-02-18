using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Valetax.Db.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tree_nodes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tree_nodes", x => x.id);
                    table.ForeignKey(
                        name: "FK_tree_nodes_tree_nodes_parent_id",
                        column: x => x.parent_id,
                        principalTable: "tree_nodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tree_nodes_name_parent_id",
                table: "tree_nodes",
                columns: new[] { "name", "parent_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tree_nodes_parent_id",
                table: "tree_nodes",
                column: "parent_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tree_nodes");
        }
    }
}
