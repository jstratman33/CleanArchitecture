using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.EntityFrameworkCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModifiedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Discriminator = table.Column<string>(nullable: false),
                    Guid = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<double>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    ShoppingListId = table.Column<long>(nullable: true),
                    ShoppingList_Guid = table.Column<Guid>(nullable: true),
                    ShoppingList_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_ShoppingListId",
                table: "BaseEntity",
                column: "ShoppingListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseEntity");
        }
    }
}
