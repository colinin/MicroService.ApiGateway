using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.ApiGateway.Migrations
{
    public partial class modifyOnDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayBalancerOptions_AbpApiGatewayGlobalConfiguration_ItemId",
                table: "AbpApiGatewayBalancerOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayBalancerOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayBalancerOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayHttpOptions_AbpApiGatewayGlobalConfiguration_ItemId",
                table: "AbpApiGatewayHttpOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayHttpOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayHttpOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayQoSOptions_AbpApiGatewayGlobalConfiguration_ItemId",
                table: "AbpApiGatewayQoSOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayQoSOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayQoSOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayDynamicReRoute_DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayBalancerOptions_AbpApiGatewayGlobalConfiguration_ItemId",
                table: "AbpApiGatewayBalancerOptions",
                column: "ItemId",
                principalTable: "AbpApiGatewayGlobalConfiguration",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayBalancerOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayBalancerOptions",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "ReRouteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayHttpOptions_AbpApiGatewayGlobalConfiguration_ItemId",
                table: "AbpApiGatewayHttpOptions",
                column: "ItemId",
                principalTable: "AbpApiGatewayGlobalConfiguration",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayHttpOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayHttpOptions",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "ReRouteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayQoSOptions_AbpApiGatewayGlobalConfiguration_ItemId",
                table: "AbpApiGatewayQoSOptions",
                column: "ItemId",
                principalTable: "AbpApiGatewayGlobalConfiguration",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayQoSOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayQoSOptions",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "ReRouteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayDynamicReRoute_DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "DynamicReRouteId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayBalancerOptions_AbpApiGatewayGlobalConfiguration_ItemId",
                table: "AbpApiGatewayBalancerOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayBalancerOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayBalancerOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayHttpOptions_AbpApiGatewayGlobalConfiguration_ItemId",
                table: "AbpApiGatewayHttpOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayHttpOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayHttpOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayQoSOptions_AbpApiGatewayGlobalConfiguration_ItemId",
                table: "AbpApiGatewayQoSOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayQoSOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayQoSOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayDynamicReRoute_DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayBalancerOptions_AbpApiGatewayGlobalConfiguration_ItemId",
                table: "AbpApiGatewayBalancerOptions",
                column: "ItemId",
                principalTable: "AbpApiGatewayGlobalConfiguration",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayBalancerOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayBalancerOptions",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "ReRouteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayHttpOptions_AbpApiGatewayGlobalConfiguration_ItemId",
                table: "AbpApiGatewayHttpOptions",
                column: "ItemId",
                principalTable: "AbpApiGatewayGlobalConfiguration",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayHttpOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayHttpOptions",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "ReRouteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayQoSOptions_AbpApiGatewayGlobalConfiguration_ItemId",
                table: "AbpApiGatewayQoSOptions",
                column: "ItemId",
                principalTable: "AbpApiGatewayGlobalConfiguration",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayQoSOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayQoSOptions",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "ReRouteId",
                onDelete: ReferentialAction.Restrict);

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
    }
}
