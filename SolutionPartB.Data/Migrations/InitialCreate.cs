using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace SolutionPartB.Data.Migraion
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "GlossaryTerm",
            columns: table => new
            {
                GlossaryTermId = table.Column<int>(nullable: false),
                Term = table.Column<Guid>(nullable: false),
                Defination = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GlossaryTermId", x => x.GlossaryTermId);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlossaryTerm");
        }
    }
}