using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodpressureApp.Migrations
{
    public partial class newBloodpressureDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Personnummer = table.Column<string>(maxLength: 10, nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(maxLength: 200, nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Personnummer);
                });

            migrationBuilder.CreateTable(
                name: "Bloodpressures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Personnummer = table.Column<string>(maxLength: 10, nullable: true),
                    Systolic = table.Column<int>(nullable: false),
                    Diastolic = table.Column<int>(nullable: false),
                    Heartrate = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloodpressures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloodpressures_Persons_Personnummer",
                        column: x => x.Personnummer,
                        principalTable: "Persons",
                        principalColumn: "Personnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weight",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Weigth = table.Column<double>(nullable: false),
                    Personnummer = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weight_Persons_Personnummer",
                        column: x => x.Personnummer,
                        principalTable: "Persons",
                        principalColumn: "Personnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bloodpressures_Personnummer",
                table: "Bloodpressures",
                column: "Personnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_Personnummer",
                table: "Weight",
                column: "Personnummer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bloodpressures");

            migrationBuilder.DropTable(
                name: "Weight");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
