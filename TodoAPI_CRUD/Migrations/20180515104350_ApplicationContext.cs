using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TodoAPI_CRUD.Migrations
{
    public partial class ApplicationContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profils",
                columns: table => new
                {
                    ProfilsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodeProfil = table.Column<int>(nullable: false),
                    ProfilName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profils", x => x.ProfilsID);
                });

            migrationBuilder.CreateTable(
                name: "FichierCentral",
                columns: table => new
                {
                    FichierCentralID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbonnementsID = table.Column<long>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    ProfilsID = table.Column<long>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichierCentral", x => x.FichierCentralID);
                    table.ForeignKey(
                        name: "FK_FichierCentral_Profils_ProfilsID",
                        column: x => x.ProfilsID,
                        principalTable: "Profils",
                        principalColumn: "ProfilsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticlesID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateDelete = table.Column<DateTime>(nullable: false),
                    DateModification = table.Column<DateTime>(nullable: false),
                    FichierCentralID = table.Column<long>(nullable: false),
                    LoginCreation = table.Column<string>(nullable: true),
                    LoginDelete = table.Column<string>(nullable: true),
                    LoginModification = table.Column<string>(nullable: true),
                    PhraseAcroche = table.Column<string>(nullable: true),
                    TextArticle = table.Column<string>(nullable: true),
                    TitreArticle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticlesID);
                    table.ForeignKey(
                        name: "FK_Articles_FichierCentral_FichierCentralID",
                        column: x => x.FichierCentralID,
                        principalTable: "FichierCentral",
                        principalColumn: "FichierCentralID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abonnements",
                columns: table => new
                {
                    AbonnementsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abonnement = table.Column<string>(nullable: true),
                    ArticlesID = table.Column<long>(nullable: true),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    DateFin = table.Column<DateTime>(nullable: false),
                    Prix_Abonnement = table.Column<long>(nullable: false),
                    pkAbonne = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnements", x => x.AbonnementsID);
                    table.ForeignKey(
                        name: "FK_Abonnements_Articles_ArticlesID",
                        column: x => x.ArticlesID,
                        principalTable: "Articles",
                        principalColumn: "ArticlesID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesMedia",
                columns: table => new
                {
                    CategoriesMediaID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticlesID = table.Column<long>(nullable: true),
                    TypeCategorieMedia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesMedia", x => x.CategoriesMediaID);
                    table.ForeignKey(
                        name: "FK_CategoriesMedia_Articles_ArticlesID",
                        column: x => x.ArticlesID,
                        principalTable: "Articles",
                        principalColumn: "ArticlesID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotesEtCommentaires",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleID = table.Column<long>(nullable: false),
                    ArticlesID = table.Column<long>(nullable: true),
                    Commentaire = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    FichierCentralID = table.Column<long>(nullable: true),
                    Note = table.Column<int>(nullable: false),
                    NotesEtCommentairesID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotesEtCommentaires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotesEtCommentaires_Articles_ArticlesID",
                        column: x => x.ArticlesID,
                        principalTable: "Articles",
                        principalColumn: "ArticlesID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotesEtCommentaires_FichierCentral_FichierCentralID",
                        column: x => x.FichierCentralID,
                        principalTable: "FichierCentral",
                        principalColumn: "FichierCentralID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImagesID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleID = table.Column<long>(nullable: false),
                    ArticlesID = table.Column<long>(nullable: true),
                    CategorieID = table.Column<long>(nullable: false),
                    CategoriesMediaID = table.Column<long>(nullable: true),
                    NomImage = table.Column<string>(nullable: true),
                    URLImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImagesID);
                    table.ForeignKey(
                        name: "FK_Images_Articles_ArticlesID",
                        column: x => x.ArticlesID,
                        principalTable: "Articles",
                        principalColumn: "ArticlesID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_CategoriesMedia_CategoriesMediaID",
                        column: x => x.CategoriesMediaID,
                        principalTable: "CategoriesMedia",
                        principalColumn: "CategoriesMediaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideosID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticlesID = table.Column<long>(nullable: false),
                    CategoriesMediaID = table.Column<long>(nullable: false),
                    URLVideo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideosID);
                    table.ForeignKey(
                        name: "FK_Videos_Articles_ArticlesID",
                        column: x => x.ArticlesID,
                        principalTable: "Articles",
                        principalColumn: "ArticlesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Videos_CategoriesMedia_CategoriesMediaID",
                        column: x => x.CategoriesMediaID,
                        principalTable: "CategoriesMedia",
                        principalColumn: "CategoriesMediaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonnements_ArticlesID",
                table: "Abonnements",
                column: "ArticlesID");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_FichierCentralID",
                table: "Articles",
                column: "FichierCentralID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesMedia_ArticlesID",
                table: "CategoriesMedia",
                column: "ArticlesID");

            migrationBuilder.CreateIndex(
                name: "IX_FichierCentral_AbonnementsID",
                table: "FichierCentral",
                column: "AbonnementsID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FichierCentral_ProfilsID",
                table: "FichierCentral",
                column: "ProfilsID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ArticlesID",
                table: "Images",
                column: "ArticlesID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CategoriesMediaID",
                table: "Images",
                column: "CategoriesMediaID");

            migrationBuilder.CreateIndex(
                name: "IX_NotesEtCommentaires_ArticlesID",
                table: "NotesEtCommentaires",
                column: "ArticlesID");

            migrationBuilder.CreateIndex(
                name: "IX_NotesEtCommentaires_FichierCentralID",
                table: "NotesEtCommentaires",
                column: "FichierCentralID");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ArticlesID",
                table: "Videos",
                column: "ArticlesID");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CategoriesMediaID",
                table: "Videos",
                column: "CategoriesMediaID");

            migrationBuilder.AddForeignKey(
                name: "FK_FichierCentral_Abonnements_AbonnementsID",
                table: "FichierCentral",
                column: "AbonnementsID",
                principalTable: "Abonnements",
                principalColumn: "AbonnementsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abonnements_Articles_ArticlesID",
                table: "Abonnements");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "NotesEtCommentaires");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "CategoriesMedia");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "FichierCentral");

            migrationBuilder.DropTable(
                name: "Abonnements");

            migrationBuilder.DropTable(
                name: "Profils");
        }
    }
}
