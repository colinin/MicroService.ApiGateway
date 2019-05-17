using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.ApiGateway.Migrations
{
    public partial class initliza_ocelot_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpApiGatewayBalancerOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: true),
                    Key = table.Column<string>(maxLength: 100, nullable: true),
                    Expiry = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayBalancerOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayDiscovery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    Host = table.Column<string>(maxLength: 50, nullable: true),
                    Port = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 128, nullable: true),
                    Token = table.Column<string>(maxLength: 256, nullable: true),
                    ConfigurationKey = table.Column<string>(maxLength: 256, nullable: true),
                    PollingInterval = table.Column<int>(nullable: false),
                    Namespace = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayDiscovery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<int>(nullable: false),
                    Key = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayHostAndPort",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<int>(nullable: false),
                    Host = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayHostAndPort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayHttpOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    AllowAutoRedirect = table.Column<bool>(nullable: false),
                    UseCookieContainer = table.Column<bool>(nullable: false),
                    UseTracing = table.Column<bool>(nullable: false),
                    UseProxy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayHttpOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayQoSOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    ExceptionsAllowedBeforeBreaking = table.Column<int>(nullable: false),
                    DurationOfBreak = table.Column<int>(nullable: false),
                    TimeoutValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayQoSOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayRateLimitOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    ClientIdHeader = table.Column<string>(maxLength: 50, nullable: true),
                    QuotaExceededMessage = table.Column<string>(maxLength: 256, nullable: true),
                    RateLimitCounterPrefix = table.Column<string>(maxLength: 50, nullable: true),
                    DisableRateLimitHeaders = table.Column<bool>(nullable: false),
                    HttpStatusCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayRateLimitOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2048, nullable: false),
                    ProviderName = table.Column<string>(maxLength: 64, nullable: true),
                    ProviderKey = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayReRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ReRouteId = table.Column<int>(nullable: false),
                    ReRouteName = table.Column<string>(nullable: true),
                    DownstreamPathTemplate = table.Column<string>(maxLength: 100, nullable: false),
                    UpstreamPathTemplate = table.Column<string>(maxLength: 100, nullable: false),
                    UpstreamHttpMethod = table.Column<string>(maxLength: 50, nullable: false),
                    AddHeadersToRequest = table.Column<string>(maxLength: 1000, nullable: true),
                    UpstreamHeaderTransform = table.Column<string>(maxLength: 1000, nullable: true),
                    DownstreamHeaderTransform = table.Column<string>(maxLength: 1000, nullable: true),
                    AddClaimsToRequest = table.Column<string>(maxLength: 1000, nullable: true),
                    RouteClaimsRequirement = table.Column<string>(maxLength: 1000, nullable: true),
                    AddQueriesToRequest = table.Column<string>(maxLength: 1000, nullable: true),
                    RequestIdKey = table.Column<string>(maxLength: 100, nullable: true),
                    ReRouteIsCaseSensitive = table.Column<bool>(nullable: true),
                    ServiceName = table.Column<string>(maxLength: 100, nullable: true),
                    DownstreamScheme = table.Column<string>(maxLength: 100, nullable: true),
                    QoSOptionsId = table.Column<int>(nullable: true),
                    LoadBalancerOptionsId = table.Column<int>(nullable: true),
                    HttpHandlerOptionsId = table.Column<int>(nullable: true),
                    DownstreamHostAndPorts = table.Column<string>(maxLength: 1000, nullable: true),
                    DelegatingHandlers = table.Column<string>(nullable: true),
                    UpstreamHost = table.Column<string>(maxLength: 100, nullable: true),
                    Key = table.Column<string>(maxLength: 100, nullable: true),
                    Priority = table.Column<int>(nullable: true),
                    Timeout = table.Column<int>(nullable: true),
                    DangerousAcceptAnyServerCertificateValidator = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayReRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayReRoute_AbpApiGatewayHttpOptions_HttpHandlerOptionsId",
                        column: x => x.HttpHandlerOptionsId,
                        principalTable: "AbpApiGatewayHttpOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayReRoute_AbpApiGatewayBalancerOptions_LoadBalancerOptionsId",
                        column: x => x.LoadBalancerOptionsId,
                        principalTable: "AbpApiGatewayBalancerOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayReRoute_AbpApiGatewayQoSOptions_QoSOptionsId",
                        column: x => x.QoSOptionsId,
                        principalTable: "AbpApiGatewayQoSOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayGlobalConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false),
                    RequestIdKey = table.Column<string>(maxLength: 100, nullable: true),
                    ServiceDiscoveryProviderId = table.Column<int>(nullable: true),
                    RateLimitOptionsId = table.Column<int>(nullable: true),
                    QoSOptionsId = table.Column<int>(nullable: true),
                    BaseUrl = table.Column<string>(maxLength: 256, nullable: false),
                    LoadBalancerOptionsId = table.Column<int>(nullable: true),
                    DownstreamScheme = table.Column<string>(maxLength: 100, nullable: false),
                    HttpHandlerOptionsId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayGlobalConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayGlobalConfiguration_AbpApiGatewayHttpOptions_HttpHandlerOptionsId",
                        column: x => x.HttpHandlerOptionsId,
                        principalTable: "AbpApiGatewayHttpOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayGlobalConfiguration_AbpApiGatewayBalancerOptions_LoadBalancerOptionsId",
                        column: x => x.LoadBalancerOptionsId,
                        principalTable: "AbpApiGatewayBalancerOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayGlobalConfiguration_AbpApiGatewayQoSOptions_QoSOptionsId",
                        column: x => x.QoSOptionsId,
                        principalTable: "AbpApiGatewayQoSOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayGlobalConfiguration_AbpApiGatewayRateLimitOptions_RateLimitOptionsId",
                        column: x => x.RateLimitOptionsId,
                        principalTable: "AbpApiGatewayRateLimitOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayGlobalConfiguration_AbpApiGatewayDiscovery_ServiceDiscoveryProviderId",
                        column: x => x.ServiceDiscoveryProviderId,
                        principalTable: "AbpApiGatewayDiscovery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayAuthOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<int>(nullable: false),
                    AuthenticationProviderKey = table.Column<string>(maxLength: 100, nullable: true),
                    AllowedScopes = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayAuthOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayAuthOptions_AbpApiGatewayReRoute_ReRouteId",
                        column: x => x.ReRouteId,
                        principalTable: "AbpApiGatewayReRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayCacheOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<int>(nullable: false),
                    TtlSeconds = table.Column<int>(nullable: false),
                    Region = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayCacheOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayCacheOptions_AbpApiGatewayReRoute_ReRouteId",
                        column: x => x.ReRouteId,
                        principalTable: "AbpApiGatewayReRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayRateLimitRule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<int>(nullable: false),
                    ClientWhitelist = table.Column<string>(maxLength: 1000, nullable: true),
                    EnableRateLimiting = table.Column<bool>(nullable: false),
                    Period = table.Column<string>(maxLength: 50, nullable: true),
                    PeriodTimespan = table.Column<double>(nullable: false),
                    Limit = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayRateLimitRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                        column: x => x.ReRouteId,
                        principalTable: "AbpApiGatewayReRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewaySecurityOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<int>(nullable: false),
                    IPAllowedList = table.Column<string>(maxLength: 1000, nullable: true),
                    IPBlockedList = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewaySecurityOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewaySecurityOptions_AbpApiGatewayReRoute_ReRouteId",
                        column: x => x.ReRouteId,
                        principalTable: "AbpApiGatewayReRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayDynamicReRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DunamicReRouteId = table.Column<int>(nullable: false),
                    ServiceName = table.Column<string>(maxLength: 100, nullable: false),
                    RateLimitRuleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayDynamicReRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayDynamicReRoute_AbpApiGatewayRateLimitRule_RateLimitRuleId",
                        column: x => x.RateLimitRuleId,
                        principalTable: "AbpApiGatewayRateLimitRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayAuthOptions_ReRouteId",
                table: "AbpApiGatewayAuthOptions",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayCacheOptions_ReRouteId",
                table: "AbpApiGatewayCacheOptions",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayDynamicReRoute_RateLimitRuleId",
                table: "AbpApiGatewayDynamicReRoute",
                column: "RateLimitRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayGlobalConfiguration_HttpHandlerOptionsId",
                table: "AbpApiGatewayGlobalConfiguration",
                column: "HttpHandlerOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayGlobalConfiguration_LoadBalancerOptionsId",
                table: "AbpApiGatewayGlobalConfiguration",
                column: "LoadBalancerOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayGlobalConfiguration_QoSOptionsId",
                table: "AbpApiGatewayGlobalConfiguration",
                column: "QoSOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayGlobalConfiguration_RateLimitOptionsId",
                table: "AbpApiGatewayGlobalConfiguration",
                column: "RateLimitOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayGlobalConfiguration_ServiceDiscoveryProviderId",
                table: "AbpApiGatewayGlobalConfiguration",
                column: "ServiceDiscoveryProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayRateLimitRule_ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayReRoute_HttpHandlerOptionsId",
                table: "AbpApiGatewayReRoute",
                column: "HttpHandlerOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayReRoute_LoadBalancerOptionsId",
                table: "AbpApiGatewayReRoute",
                column: "LoadBalancerOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayReRoute_QoSOptionsId",
                table: "AbpApiGatewayReRoute",
                column: "QoSOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewaySecurityOptions_ReRouteId",
                table: "AbpApiGatewaySecurityOptions",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_Name_ProviderName_ProviderKey",
                table: "AbpSettings",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpApiGatewayAuthOptions");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayCacheOptions");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayDynamicReRoute");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayGlobalConfiguration");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayHeaders");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayHostAndPort");

            migrationBuilder.DropTable(
                name: "AbpApiGatewaySecurityOptions");

            migrationBuilder.DropTable(
                name: "AbpSettings");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayRateLimitOptions");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayDiscovery");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayReRoute");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayHttpOptions");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayBalancerOptions");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayQoSOptions");
        }
    }
}
