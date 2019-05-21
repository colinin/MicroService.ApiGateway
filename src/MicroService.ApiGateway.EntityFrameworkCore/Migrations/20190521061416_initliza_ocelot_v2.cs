using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.ApiGateway.Migrations
{
    public partial class initliza_ocelot_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PeriodTimespan",
                table: "AbpApiGatewayRateLimitRule",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<long>(
                name: "Limit",
                table: "AbpApiGatewayRateLimitRule",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<bool>(
                name: "EnableRateLimiting",
                table: "AbpApiGatewayRateLimitRule",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "HttpStatusCode",
                table: "AbpApiGatewayRateLimitOptions",
                nullable: true,
                defaultValue: 429,
                oldClrType: typeof(int),
                oldDefaultValue: 429);

            migrationBuilder.AlterColumn<bool>(
                name: "DisableRateLimitHeaders",
                table: "AbpApiGatewayRateLimitOptions",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "TimeoutValue",
                table: "AbpApiGatewayQoSOptions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ExceptionsAllowedBeforeBreaking",
                table: "AbpApiGatewayQoSOptions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DurationOfBreak",
                table: "AbpApiGatewayQoSOptions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "UseTracing",
                table: "AbpApiGatewayHttpOptions",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "UseProxy",
                table: "AbpApiGatewayHttpOptions",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "UseCookieContainer",
                table: "AbpApiGatewayHttpOptions",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "AllowAutoRedirect",
                table: "AbpApiGatewayHttpOptions",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "Port",
                table: "AbpApiGatewayDiscovery",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PollingInterval",
                table: "AbpApiGatewayDiscovery",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TtlSeconds",
                table: "AbpApiGatewayCacheOptions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Expiry",
                table: "AbpApiGatewayBalancerOptions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayReRoute_DownstreamPathTemplate_UpstreamPathTemplate",
                table: "AbpApiGatewayReRoute",
                columns: new[] { "DownstreamPathTemplate", "UpstreamPathTemplate" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayReRoute_DownstreamPathTemplate_UpstreamPathTemplate",
                table: "AbpApiGatewayReRoute");

            migrationBuilder.AlterColumn<double>(
                name: "PeriodTimespan",
                table: "AbpApiGatewayRateLimitRule",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Limit",
                table: "AbpApiGatewayRateLimitRule",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EnableRateLimiting",
                table: "AbpApiGatewayRateLimitRule",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HttpStatusCode",
                table: "AbpApiGatewayRateLimitOptions",
                nullable: false,
                defaultValue: 429,
                oldClrType: typeof(int),
                oldNullable: true,
                oldDefaultValue: 429);

            migrationBuilder.AlterColumn<bool>(
                name: "DisableRateLimitHeaders",
                table: "AbpApiGatewayRateLimitOptions",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TimeoutValue",
                table: "AbpApiGatewayQoSOptions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExceptionsAllowedBeforeBreaking",
                table: "AbpApiGatewayQoSOptions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DurationOfBreak",
                table: "AbpApiGatewayQoSOptions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "UseTracing",
                table: "AbpApiGatewayHttpOptions",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "UseProxy",
                table: "AbpApiGatewayHttpOptions",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "UseCookieContainer",
                table: "AbpApiGatewayHttpOptions",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AllowAutoRedirect",
                table: "AbpApiGatewayHttpOptions",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Port",
                table: "AbpApiGatewayDiscovery",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PollingInterval",
                table: "AbpApiGatewayDiscovery",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TtlSeconds",
                table: "AbpApiGatewayCacheOptions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Expiry",
                table: "AbpApiGatewayBalancerOptions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
