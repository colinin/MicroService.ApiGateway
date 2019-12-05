using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.ApiGateway.Migrations
{
    public partial class modifyratelimitrule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayDynamicReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayRateLimitRule_ReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.AlterColumn<long>(
                name: "ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayRateLimitRule_DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "DynamicReRouteId",
                unique: true,
                filter: "[DynamicReRouteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayRateLimitRule_ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "ReRouteId",
                unique: true,
                filter: "[ReRouteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayDynamicReRoute_DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "DynamicReRouteId",
                principalTable: "AbpApiGatewayDynamicReRoute",
                principalColumn: "DynamicReRouteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "ReRouteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayDynamicReRoute_DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayRateLimitRule_DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayRateLimitRule_ReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropColumn(
                name: "DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.AlterColumn<long>(
                name: "ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayRateLimitRule_ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayDynamicReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayDynamicReRoute",
                principalColumn: "DynamicReRouteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "ReRouteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
