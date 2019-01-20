using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodpressureApp.Migrations
{
    public partial class ChangeToPersonId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bloodpressures_Persons_Personnummer",
                table: "Bloodpressures");

            migrationBuilder.DropForeignKey(
                name: "FK_Weight_Persons_Personnummer",
                table: "Weight");

            migrationBuilder.DropIndex(
                name: "IX_Weight_Personnummer",
                table: "Weight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Bloodpressures_Personnummer",
                table: "Bloodpressures");

            migrationBuilder.DropColumn(
                name: "Personnummer",
                table: "Weight");

            migrationBuilder.DropColumn(
                name: "Personnummer",
                table: "Bloodpressures");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Weight",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Personnummer",
                table: "Persons",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Persons",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Bloodpressures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_PersonId",
                table: "Weight",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloodpressures_PersonId",
                table: "Bloodpressures",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bloodpressures_Persons_PersonId",
                table: "Bloodpressures",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weight_Persons_PersonId",
                table: "Weight",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bloodpressures_Persons_PersonId",
                table: "Bloodpressures");

            migrationBuilder.DropForeignKey(
                name: "FK_Weight_Persons_PersonId",
                table: "Weight");

            migrationBuilder.DropIndex(
                name: "IX_Weight_PersonId",
                table: "Weight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Bloodpressures_PersonId",
                table: "Bloodpressures");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Weight");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Bloodpressures");

            migrationBuilder.AddColumn<string>(
                name: "Personnummer",
                table: "Weight",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Personnummer",
                table: "Persons",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Personnummer",
                table: "Bloodpressures",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Personnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_Personnummer",
                table: "Weight",
                column: "Personnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Bloodpressures_Personnummer",
                table: "Bloodpressures",
                column: "Personnummer");

            migrationBuilder.AddForeignKey(
                name: "FK_Bloodpressures_Persons_Personnummer",
                table: "Bloodpressures",
                column: "Personnummer",
                principalTable: "Persons",
                principalColumn: "Personnummer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weight_Persons_Personnummer",
                table: "Weight",
                column: "Personnummer",
                principalTable: "Persons",
                principalColumn: "Personnummer",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
