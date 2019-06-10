using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.ApiGateway.Migrations
{
    public partial class initliza_ocelot_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ReRouteIsCaseSensitive",
                table: "AbpApiGatewayReRoute",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "DangerousAcceptAnyServerCertificateValidator",
                table: "AbpApiGatewayReRoute",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EnableRateLimiting",
                table: "AbpApiGatewayRateLimitRule",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "DisableRateLimitHeaders",
                table: "AbpApiGatewayRateLimitOptions",
                nullable: false,
                oldClrType: typeof(bool),
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

            migrationBuilder.AlterColumn<string>(
                name: "DownstreamScheme",
                table: "AbpApiGatewayGlobalConfiguration",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Host",
                table: "AbpApiGatewayDiscovery",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ReRouteIsCaseSensitive",
                table: "AbpApiGatewayReRoute",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "DangerousAcceptAnyServerCertificateValidator",
                table: "AbpApiGatewayReRoute",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "EnableRateLimiting",
                table: "AbpApiGatewayRateLimitRule",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "DisableRateLimitHeaders",
                table: "AbpApiGatewayRateLimitOptions",
                nullable: true,
                oldClrType: typeof(bool));

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

            migrationBuilder.AlterColumn<string>(
                name: "DownstreamScheme",
                table: "AbpApiGatewayGlobalConfiguration",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Host",
                table: "AbpApiGatewayDiscovery",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
