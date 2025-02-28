using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionnaireSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameQuestionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "question_id",
                table: "interviews",
                newName: "current_question_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "current_question_id",
                table: "interviews",
                newName: "question_id");
        }
    }
}
