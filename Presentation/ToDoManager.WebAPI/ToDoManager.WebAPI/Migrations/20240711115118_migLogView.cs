using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoManager.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class migLogView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
            Create View LogView As
            SELECT
                ""Checkpoints"".""Id"" AS checkpoint_id,
                ""Checkpoints"".""Name"" AS checkpoint_name,
                ""Servers"".""Id"" AS server_id,
                ""Servers"".""Name"" AS server_name,
                ""Servers"".""Ip"" AS server_ip,
	            ""AspNetUsers"".""Id"" As user_id,
	            ""AspNetUsers"".""Name"" as user_name,
	            ""AspNetUsers"".""Surname"" as user_surname
            FROM
                ""Log""
            JOIN
                ""Checkpoints"" ON ""Log"".""CheckpointId"" = ""Checkpoints"".""Id""
            JOIN
                ""Servers"" ON ""Log"".""ServerId"" = ""Servers"".""Id""
            JOIN
                ""AspNetUsers"" ON ""Log"".""AppUserId"" = ""AspNetUsers"".""Id""");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP VIEW LogView");
        }
    }
}
