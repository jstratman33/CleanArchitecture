using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.EntityFrameworkCore.Migrations
{
    public partial class removebaseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_ShoppingListId",
                table: "BaseEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_ShoppingListId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ShoppingListId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ShoppingList_Guid",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ShoppingList_Name",
                table: "BaseEntity");

            migrationBuilder.RenameTable(
                name: "BaseEntity",
                newName: "ShoppingLists");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "ShoppingLists",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingLists",
                table: "ShoppingLists",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ShoppingItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModifiedTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ShoppingListId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingItems_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItems_ShoppingListId",
                table: "ShoppingItems",
                column: "ShoppingListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingLists",
                table: "ShoppingLists");

            migrationBuilder.RenameTable(
                name: "ShoppingLists",
                newName: "BaseEntity");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "BaseEntity",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntity",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ShoppingListId",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingList_Guid",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShoppingList_Name",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_ShoppingListId",
                table: "BaseEntity",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_ShoppingListId",
                table: "BaseEntity",
                column: "ShoppingListId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
