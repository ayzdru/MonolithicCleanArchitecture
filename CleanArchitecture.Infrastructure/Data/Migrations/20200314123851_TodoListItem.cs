using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Data.Migrations
{
    public partial class TodoListItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoListItem_AspNetUsers_CreatedByUserId",
                table: "TodoListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoListItem_AspNetUsers_LastModifiedByUserId",
                table: "TodoListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoListItem_TodoLists_TodoListId",
                table: "TodoListItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoListItem",
                table: "TodoListItem");

            migrationBuilder.RenameTable(
                name: "TodoListItem",
                newName: "TodoListItems");

            migrationBuilder.RenameIndex(
                name: "IX_TodoListItem_TodoListId",
                table: "TodoListItems",
                newName: "IX_TodoListItems_TodoListId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoListItem_LastModifiedByUserId",
                table: "TodoListItems",
                newName: "IX_TodoListItems_LastModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoListItem_CreatedByUserId",
                table: "TodoListItems",
                newName: "IX_TodoListItems_CreatedByUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoListItems",
                table: "TodoListItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoListItems_AspNetUsers_CreatedByUserId",
                table: "TodoListItems",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoListItems_AspNetUsers_LastModifiedByUserId",
                table: "TodoListItems",
                column: "LastModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoListItems_TodoLists_TodoListId",
                table: "TodoListItems",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoListItems_AspNetUsers_CreatedByUserId",
                table: "TodoListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoListItems_AspNetUsers_LastModifiedByUserId",
                table: "TodoListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoListItems_TodoLists_TodoListId",
                table: "TodoListItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoListItems",
                table: "TodoListItems");

            migrationBuilder.RenameTable(
                name: "TodoListItems",
                newName: "TodoListItem");

            migrationBuilder.RenameIndex(
                name: "IX_TodoListItems_TodoListId",
                table: "TodoListItem",
                newName: "IX_TodoListItem_TodoListId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoListItems_LastModifiedByUserId",
                table: "TodoListItem",
                newName: "IX_TodoListItem_LastModifiedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoListItems_CreatedByUserId",
                table: "TodoListItem",
                newName: "IX_TodoListItem_CreatedByUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoListItem",
                table: "TodoListItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoListItem_AspNetUsers_CreatedByUserId",
                table: "TodoListItem",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoListItem_AspNetUsers_LastModifiedByUserId",
                table: "TodoListItem",
                column: "LastModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoListItem_TodoLists_TodoListId",
                table: "TodoListItem",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
