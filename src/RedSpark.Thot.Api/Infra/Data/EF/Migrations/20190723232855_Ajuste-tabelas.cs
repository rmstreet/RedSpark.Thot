using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedSpark.Thot.Api.Infra.Data.EF.Migrations
{
    public partial class Ajustetabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeadComent");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Coment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FatherComentId",
                table: "Coment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeadId",
                table: "Coment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Coment_CreatedById",
                table: "Coment",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Coment_FatherComentId",
                table: "Coment",
                column: "FatherComentId");

            migrationBuilder.CreateIndex(
                name: "IX_Coment_LeadId",
                table: "Coment",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coment_Person_CreatedById",
                table: "Coment",
                column: "CreatedById",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coment_Coment_FatherComentId",
                table: "Coment",
                column: "FatherComentId",
                principalTable: "Coment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coment_Lead_LeadId",
                table: "Coment",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coment_Person_CreatedById",
                table: "Coment");

            migrationBuilder.DropForeignKey(
                name: "FK_Coment_Coment_FatherComentId",
                table: "Coment");

            migrationBuilder.DropForeignKey(
                name: "FK_Coment_Lead_LeadId",
                table: "Coment");

            migrationBuilder.DropIndex(
                name: "IX_Coment_CreatedById",
                table: "Coment");

            migrationBuilder.DropIndex(
                name: "IX_Coment_FatherComentId",
                table: "Coment");

            migrationBuilder.DropIndex(
                name: "IX_Coment_LeadId",
                table: "Coment");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Coment");

            migrationBuilder.DropColumn(
                name: "FatherComentId",
                table: "Coment");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "Coment");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Skills",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Skills",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LeadComent",
                columns: table => new
                {
                    LeadId = table.Column<int>(nullable: false),
                    ComentId = table.Column<int>(nullable: false),
                    AnswerComentId = table.Column<int>(nullable: true),
                    AnswerLeadId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadComent", x => new { x.LeadId, x.ComentId });
                    table.ForeignKey(
                        name: "FK_LeadComent_Coment_ComentId",
                        column: x => x.ComentId,
                        principalTable: "Coment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadComent_Person_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadComent_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadComent_LeadComent_AnswerLeadId_AnswerComentId",
                        columns: x => new { x.AnswerLeadId, x.AnswerComentId },
                        principalTable: "LeadComent",
                        principalColumns: new[] { "LeadId", "ComentId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeadComent_ComentId",
                table: "LeadComent",
                column: "ComentId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadComent_CreatedById",
                table: "LeadComent",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LeadComent_AnswerLeadId_AnswerComentId",
                table: "LeadComent",
                columns: new[] { "AnswerLeadId", "AnswerComentId" });
        }
    }
}
