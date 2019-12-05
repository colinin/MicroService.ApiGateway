using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.ApiGateway.Migrations
{
    public partial class modifyRateLimitRulev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayDynamicReRoute_DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayDynamicReRoute_DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "DynamicReRouteId",
                principalTable: "AbpApiGatewayDynamicReRoute",
                principalColumn: "DynamicReRouteId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "ReRouteId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayDynamicReRoute_DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule");

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
    }
}
