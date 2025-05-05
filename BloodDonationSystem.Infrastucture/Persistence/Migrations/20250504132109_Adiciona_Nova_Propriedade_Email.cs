using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationSystem.Infrastucture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Adiciona_Nova_Propriedade_Email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Donors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Donors");
        }
    }
}
