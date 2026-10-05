using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SameApi.Db.Migrations
{
    /// <inheritdoc />
    public partial class _100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LKP_SameApi_Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LKP_SameApi_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LKP_SameApi_Profession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LKP_SameApi_Profession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LKP_SameApi_School",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LKP_SameApi_School", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LKP_ProfessionDaoLKP_SchoolDao",
                columns: table => new
                {
                    ProfessionsId = table.Column<int>(type: "int", nullable: false),
                    SchoolsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LKP_ProfessionDaoLKP_SchoolDao", x => new { x.ProfessionsId, x.SchoolsId });
                    table.ForeignKey(
                        name: "FK_LKP_ProfessionDaoLKP_SchoolDao_LKP_SameApi_Profession_ProfessionsId",
                        column: x => x.ProfessionsId,
                        principalTable: "LKP_SameApi_Profession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LKP_ProfessionDaoLKP_SchoolDao_LKP_SameApi_School_SchoolsId",
                        column: x => x.SchoolsId,
                        principalTable: "LKP_SameApi_School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SameApi_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pseudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberFollowers = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderDaoId = table.Column<int>(type: "int", nullable: true),
                    SchoolDaoId = table.Column<int>(type: "int", nullable: true),
                    ProfessionDaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SameApi_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SameApi_User_LKP_SameApi_Gender_GenderDaoId",
                        column: x => x.GenderDaoId,
                        principalTable: "LKP_SameApi_Gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SameApi_User_LKP_SameApi_Profession_ProfessionDaoId",
                        column: x => x.ProfessionDaoId,
                        principalTable: "LKP_SameApi_Profession",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SameApi_User_LKP_SameApi_School_SchoolDaoId",
                        column: x => x.SchoolDaoId,
                        principalTable: "LKP_SameApi_School",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SameApi_Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserDaoId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes_count = table.Column<int>(type: "int", nullable: true),
                    Comments_count = table.Column<int>(type: "int", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SameApi_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SameApi_Post_SameApi_User_UserDaoId",
                        column: x => x.UserDaoId,
                        principalTable: "SameApi_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SameApi_Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserDaoId = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikesCount = table.Column<int>(type: "int", nullable: true),
                    CommentsCount = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SameApi_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SameApi_Comment_SameApi_Comment_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "SameApi_Comment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SameApi_Comment_SameApi_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "SameApi_Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SameApi_Comment_SameApi_User_UserDaoId",
                        column: x => x.UserDaoId,
                        principalTable: "SameApi_User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "LKP_SameApi_Gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Others" }
                });

            migrationBuilder.InsertData(
                table: "LKP_SameApi_Profession",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Informaticien/ne CFC" },
                    { 2, "Electronicien/ne CFC" },
                    { 3, "Automaticien/ne CFC" },
                    { 4, "Polymécanicien/ne CFC" },
                    { 5, "Employé/e de commerce CFC" },
                    { 6, "Gestionnaire du commerce de détail CFC" },
                    { 7, "Dessinateur/trice en bâtiment CFC" },
                    { 8, "Installateur/trice sanitaire CFC" },
                    { 9, "Maçon/ne CFC" },
                    { 10, "Graphiste CFC" },
                    { 11, "Bijoutier/ère CFC" },
                    { 12, "Assistant/e en soins et santé communautaire CFC" },
                    { 13, "Assistant/e socio-éducatif/ve CFC" }
                });

            migrationBuilder.InsertData(
                table: "LKP_SameApi_School",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CFPT - École d'informatique" },
                    { 2, "CFPC - École de Commerce Raymond-Uldry" },
                    { 3, "CFP Construction - Site André-De-Ternier" },
                    { 4, "CFP Construction - Site du Rhône" },
                    { 5, "CFP Arts - École d'arts appliqués" },
                    { 6, "CFPSa - Centre de Formation Professionnelle Santé" },
                    { 7, "CFPSo - Centre de Formation Professionnelle Social" },
                    { 8, "CFPT - École d'électronique et de mécanique" }
                });

            migrationBuilder.InsertData(
                table: "LKP_ProfessionDaoLKP_SchoolDao",
                columns: new[] { "ProfessionsId", "SchoolsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 8 },
                    { 3, 8 },
                    { 4, 8 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 3 },
                    { 8, 4 },
                    { 9, 3 },
                    { 10, 5 },
                    { 11, 5 },
                    { 12, 6 },
                    { 13, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LKP_ProfessionDaoLKP_SchoolDao_SchoolsId",
                table: "LKP_ProfessionDaoLKP_SchoolDao",
                column: "SchoolsId");

            migrationBuilder.CreateIndex(
                name: "IX_SameApi_Comment_ParentCommentId",
                table: "SameApi_Comment",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_SameApi_Comment_PostId",
                table: "SameApi_Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_SameApi_Comment_UserDaoId",
                table: "SameApi_Comment",
                column: "UserDaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SameApi_Post_UserDaoId",
                table: "SameApi_Post",
                column: "UserDaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SameApi_User_GenderDaoId",
                table: "SameApi_User",
                column: "GenderDaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SameApi_User_ProfessionDaoId",
                table: "SameApi_User",
                column: "ProfessionDaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SameApi_User_SchoolDaoId",
                table: "SameApi_User",
                column: "SchoolDaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LKP_ProfessionDaoLKP_SchoolDao");

            migrationBuilder.DropTable(
                name: "SameApi_Comment");

            migrationBuilder.DropTable(
                name: "SameApi_Post");

            migrationBuilder.DropTable(
                name: "SameApi_User");

            migrationBuilder.DropTable(
                name: "LKP_SameApi_Gender");

            migrationBuilder.DropTable(
                name: "LKP_SameApi_Profession");

            migrationBuilder.DropTable(
                name: "LKP_SameApi_School");
        }
    }
}
