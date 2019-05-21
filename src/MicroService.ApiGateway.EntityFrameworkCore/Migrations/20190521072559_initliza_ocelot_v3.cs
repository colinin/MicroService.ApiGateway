using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.ApiGateway.Migrations
{
    public partial class initliza_ocelot_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayAuthOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayAuthOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayCacheOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayCacheOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewaySecurityOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewaySecurityOptions");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewaySecurityOptions_ReRouteId",
                table: "AbpApiGatewaySecurityOptions");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayRateLimitRule_ReRouteId",
                table: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayCacheOptions_ReRouteId",
                table: "AbpApiGatewayCacheOptions");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayAuthOptions_ReRouteId",
                table: "AbpApiGatewayAuthOptions");

            migrationBuilder.AlterColumn<long>(
                name: "ReRouteId",
                table: "AbpApiGatewaySecurityOptions",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ReRouteId",
                table: "AbpApiGatewayReRoute",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AuthenticationOptionsId",
                table: "AbpApiGatewayReRoute",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CacheOptionsId",
                table: "AbpApiGatewayReRoute",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RateLimitOptionsId",
                table: "AbpApiGatewayReRoute",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecurityOptionsId",
                table: "AbpApiGatewayReRoute",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "AbpApiGatewayRateLimitOptions",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "AbpApiGatewayQoSOptions",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "AbpApiGatewayHttpOptions",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ReRouteId",
                table: "AbpApiGatewayHostAndPort",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ReRouteId",
                table: "AbpApiGatewayHeaders",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "AbpApiGatewayGlobalConfiguration",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "DynamicReRouteId",
                table: "AbpApiGatewayDynamicReRoute",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "AbpApiGatewayDiscovery",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ReRouteId",
                table: "AbpApiGatewayCacheOptions",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "AbpApiGatewayBalancerOptions",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ReRouteId",
                table: "AbpApiGatewayAuthOptions",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayReRoute_AuthenticationOptionsId",
                table: "AbpApiGatewayReRoute",
                column: "AuthenticationOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayReRoute_CacheOptionsId",
                table: "AbpApiGatewayReRoute",
                column: "CacheOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayReRoute_RateLimitOptionsId",
                table: "AbpApiGatewayReRoute",
                column: "RateLimitOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayReRoute_SecurityOptionsId",
                table: "AbpApiGatewayReRoute",
                column: "SecurityOptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayReRoute_AbpApiGatewayAuthOptions_AuthenticationOptionsId",
                table: "AbpApiGatewayReRoute",
                column: "AuthenticationOptionsId",
                principalTable: "AbpApiGatewayAuthOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayReRoute_AbpApiGatewayCacheOptions_CacheOptionsId",
                table: "AbpApiGatewayReRoute",
                column: "CacheOptionsId",
                principalTable: "AbpApiGatewayCacheOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayReRoute_AbpApiGatewayRateLimitRule_RateLimitOptionsId",
                table: "AbpApiGatewayReRoute",
                column: "RateLimitOptionsId",
                principalTable: "AbpApiGatewayRateLimitRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayReRoute_AbpApiGatewaySecurityOptions_SecurityOptionsId",
                table: "AbpApiGatewayReRoute",
                column: "SecurityOptionsId",
                principalTable: "AbpApiGatewaySecurityOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayReRoute_AbpApiGatewayAuthOptions_AuthenticationOptionsId",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayReRoute_AbpApiGatewayCacheOptions_CacheOptionsId",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayReRoute_AbpApiGatewayRateLimitRule_RateLimitOptionsId",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayReRoute_AbpApiGatewaySecurityOptions_SecurityOptionsId",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayReRoute_AuthenticationOptionsId",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayReRoute_CacheOptionsId",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayReRoute_RateLimitOptionsId",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayReRoute_SecurityOptionsId",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.DropColumn(
                name: "AuthenticationOptionsId",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.DropColumn(
                name: "CacheOptionsId",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.DropColumn(
                name: "RateLimitOptionsId",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.DropColumn(
                name: "SecurityOptionsId",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.AlterColumn<int>(
                name: "ReRouteId",
                table: "AbpApiGatewaySecurityOptions",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ReRouteId",
                table: "AbpApiGatewayReRoute",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "AbpApiGatewayRateLimitOptions",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "AbpApiGatewayQoSOptions",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "AbpApiGatewayHttpOptions",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ReRouteId",
                table: "AbpApiGatewayHostAndPort",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ReRouteId",
                table: "AbpApiGatewayHeaders",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "AbpApiGatewayGlobalConfiguration",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "DynamicReRouteId",
                table: "AbpApiGatewayDynamicReRoute",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "AbpApiGatewayDiscovery",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ReRouteId",
                table: "AbpApiGatewayCacheOptions",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "AbpApiGatewayBalancerOptions",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ReRouteId",
                table: "AbpApiGatewayAuthOptions",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewaySecurityOptions_ReRouteId",
                table: "AbpApiGatewaySecurityOptions",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayRateLimitRule_ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayCacheOptions_ReRouteId",
                table: "AbpApiGatewayCacheOptions",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayAuthOptions_ReRouteId",
                table: "AbpApiGatewayAuthOptions",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayAuthOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayAuthOptions",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayCacheOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayCacheOptions",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewaySecurityOptions_AbpApiGatewayReRoute_ReRouteId",
                table: "AbpApiGatewaySecurityOptions",
                column: "ReRouteId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
