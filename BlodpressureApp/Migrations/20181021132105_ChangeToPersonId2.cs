using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodpressureApp.Migrations
{
    public partial class ChangeToPersonId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bloodpressures_Persons_PersonId",
                table: "Bloodpressures");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Bloodpressures",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Bloodpressures_Persons_PersonId",
                table: "Bloodpressures",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bloodpressures_Persons_PersonId",
                table: "Bloodpressures");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Bloodpressures",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bloodpressures_Persons_PersonId",
                table: "Bloodpressures",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
