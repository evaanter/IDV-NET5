using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TodoAPI_CRUD.Migrations
{
    public partial class TodoAPI_CRUDModelsApplicationContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FichierCentral",
                columns: table => new
                {
                    DateDebut = table.Column<DateTime>(nullable: true),
                    DateFin = table.Column<DateTime>(nullable: true),
                    ID = table.Column<long>(nullable: true),
                    PKAbonnement = table.Column<long>(nullable: true),
                    PkAbonne = table.Column<long>(nullable: true),
                    Prix_Abonnement = table.Column<long>(nullable: true),
                    PK = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abonnement = table.Column<string>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    PkAbonnemnt = table.Column<int>(nullable: false),
                    PkCategorieAbonnement = table.Column<int>(nullable: false),
                    PkProfil = table.Column<int>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichierCentral", x => x.PK);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FichierCentral");
        }
    }
}
