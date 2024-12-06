using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMS.DataManager.Migrations
{
    /// <inheritdoc />
    public partial class dingtalkOrganizationId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DingTalkOrganizationUnitId",
                table: "AbpOrganizationUnits",
                type: "bigint",
                maxLength: 64,
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DingTalkOrganizationUnitId",
                table: "AbpOrganizationUnits");
        }
    }
}
