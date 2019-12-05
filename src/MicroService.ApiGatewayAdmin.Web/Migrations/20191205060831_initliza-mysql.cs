using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.ApiGatewayAdmin.Web.Migrations
{
    public partial class initlizamysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpApiGatewayAggregate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ReRouteId = table.Column<long>(nullable: false),
                    ReRouteKeys = table.Column<string>(maxLength: 1000, nullable: true),
                    UpstreamPathTemplate = table.Column<string>(maxLength: 1000, nullable: true),
                    UpstreamHost = table.Column<string>(maxLength: 1000, nullable: true),
                    ReRouteIsCaseSensitive = table.Column<bool>(nullable: false, defaultValue: false),
                    Aggregator = table.Column<string>(maxLength: 256, nullable: true),
                    Priority = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayAggregate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayDynamicReRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DynamicReRouteId = table.Column<long>(nullable: false),
                    ServiceName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayDynamicReRoute", x => x.Id);
                    table.UniqueConstraint("AK_AbpApiGatewayDynamicReRoute_DynamicReRouteId", x => x.DynamicReRouteId);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayGlobalConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ItemId = table.Column<long>(nullable: false),
                    RequestIdKey = table.Column<string>(maxLength: 100, nullable: true),
                    BaseUrl = table.Column<string>(maxLength: 256, nullable: false),
                    DownstreamScheme = table.Column<string>(maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayGlobalConfiguration", x => x.Id);
                    table.UniqueConstraint("AK_AbpApiGatewayGlobalConfiguration_ItemId", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<long>(nullable: false),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<long>(nullable: false),
                    Host = table.Column<string>(maxLength: 50, nullable: false),
                    Port = table.Column<int>(nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayHostAndPort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayReRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ReRouteId = table.Column<long>(nullable: false),
                    ReRouteName = table.Column<string>(maxLength: 50, nullable: false),
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
                    ReRouteIsCaseSensitive = table.Column<bool>(nullable: false),
                    ServiceName = table.Column<string>(maxLength: 100, nullable: true),
                    DownstreamScheme = table.Column<string>(maxLength: 100, nullable: true),
                    DownstreamHostAndPorts = table.Column<string>(maxLength: 1000, nullable: true),
                    DelegatingHandlers = table.Column<string>(maxLength: 1000, nullable: true),
                    UpstreamHost = table.Column<string>(maxLength: 100, nullable: true),
                    Key = table.Column<string>(maxLength: 100, nullable: true),
                    Priority = table.Column<int>(nullable: true),
                    Timeout = table.Column<int>(nullable: true),
                    DangerousAcceptAnyServerCertificateValidator = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayReRoute", x => x.Id);
                    table.UniqueConstraint("AK_AbpApiGatewayReRoute_ReRouteId", x => x.ReRouteId);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayServerAuth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServerId = table.Column<long>(nullable: false),
                    ApiAddress = table.Column<string>(maxLength: 100, nullable: false),
                    ClientId = table.Column<string>(maxLength: 50, nullable: false),
                    ClientSecret = table.Column<string>(maxLength: 256, nullable: false),
                    Scope = table.Column<string>(maxLength: 50, nullable: false),
                    GrantType = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayServerAuth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayAggregateConfig",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<long>(nullable: false),
                    ReRouteKey = table.Column<string>(maxLength: 256, nullable: true),
                    Parameter = table.Column<string>(maxLength: 1000, nullable: true),
                    JsonPath = table.Column<string>(maxLength: 256, nullable: true),
                    AggregateReRouteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayAggregateConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayAggregateConfig_AbpApiGatewayAggregate_Aggregat~",
                        column: x => x.AggregateReRouteId,
                        principalTable: "AbpApiGatewayAggregate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayDiscovery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<long>(nullable: false),
                    Host = table.Column<string>(maxLength: 50, nullable: true),
                    Port = table.Column<int>(nullable: true),
                    Type = table.Column<string>(maxLength: 128, nullable: true),
                    Token = table.Column<string>(maxLength: 256, nullable: true),
                    ConfigurationKey = table.Column<string>(maxLength: 256, nullable: true),
                    PollingInterval = table.Column<int>(nullable: true),
                    Namespace = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayDiscovery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayDiscovery_AbpApiGatewayGlobalConfiguration_Item~",
                        column: x => x.ItemId,
                        principalTable: "AbpApiGatewayGlobalConfiguration",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayRateLimitOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<long>(nullable: false),
                    ClientIdHeader = table.Column<string>(maxLength: 50, nullable: true, defaultValue: "ClientId"),
                    QuotaExceededMessage = table.Column<string>(maxLength: 256, nullable: true),
                    RateLimitCounterPrefix = table.Column<string>(maxLength: 50, nullable: true, defaultValue: "ocelot"),
                    DisableRateLimitHeaders = table.Column<bool>(nullable: false),
                    HttpStatusCode = table.Column<int>(nullable: true, defaultValue: 429)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayRateLimitOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayRateLimitOptions_AbpApiGatewayGlobalConfigurati~",
                        column: x => x.ItemId,
                        principalTable: "AbpApiGatewayGlobalConfiguration",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayAuthOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<long>(nullable: false),
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
                        principalColumn: "ReRouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayBalancerOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<long>(nullable: true),
                    ReRouteId = table.Column<long>(nullable: true),
                    Type = table.Column<string>(maxLength: 100, nullable: true),
                    Key = table.Column<string>(maxLength: 100, nullable: true),
                    Expiry = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayBalancerOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayBalancerOptions_AbpApiGatewayGlobalConfiguratio~",
                        column: x => x.ItemId,
                        principalTable: "AbpApiGatewayGlobalConfiguration",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayBalancerOptions_AbpApiGatewayReRoute_ReRouteId",
                        column: x => x.ReRouteId,
                        principalTable: "AbpApiGatewayReRoute",
                        principalColumn: "ReRouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayCacheOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<long>(nullable: false),
                    TtlSeconds = table.Column<int>(nullable: true),
                    Region = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayCacheOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayCacheOptions_AbpApiGatewayReRoute_ReRouteId",
                        column: x => x.ReRouteId,
                        principalTable: "AbpApiGatewayReRoute",
                        principalColumn: "ReRouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayHttpOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<long>(nullable: true),
                    ReRouteId = table.Column<long>(nullable: true),
                    AllowAutoRedirect = table.Column<bool>(nullable: false),
                    UseCookieContainer = table.Column<bool>(nullable: false),
                    UseTracing = table.Column<bool>(nullable: false),
                    UseProxy = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayHttpOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayHttpOptions_AbpApiGatewayGlobalConfiguration_It~",
                        column: x => x.ItemId,
                        principalTable: "AbpApiGatewayGlobalConfiguration",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayHttpOptions_AbpApiGatewayReRoute_ReRouteId",
                        column: x => x.ReRouteId,
                        principalTable: "AbpApiGatewayReRoute",
                        principalColumn: "ReRouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayQoSOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<long>(nullable: true),
                    ReRouteId = table.Column<long>(nullable: true),
                    ExceptionsAllowedBeforeBreaking = table.Column<int>(nullable: true),
                    DurationOfBreak = table.Column<int>(nullable: true),
                    TimeoutValue = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayQoSOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayQoSOptions_AbpApiGatewayGlobalConfiguration_Ite~",
                        column: x => x.ItemId,
                        principalTable: "AbpApiGatewayGlobalConfiguration",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayQoSOptions_AbpApiGatewayReRoute_ReRouteId",
                        column: x => x.ReRouteId,
                        principalTable: "AbpApiGatewayReRoute",
                        principalColumn: "ReRouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayRateLimitRule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<long>(nullable: true),
                    DynamicReRouteId = table.Column<long>(nullable: true),
                    ClientWhitelist = table.Column<string>(maxLength: 1000, nullable: true),
                    EnableRateLimiting = table.Column<bool>(nullable: false),
                    Period = table.Column<string>(maxLength: 50, nullable: true),
                    PeriodTimespan = table.Column<double>(nullable: true),
                    Limit = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayRateLimitRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayDynamicReRoute_Dynam~",
                        column: x => x.DynamicReRouteId,
                        principalTable: "AbpApiGatewayDynamicReRoute",
                        principalColumn: "DynamicReRouteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayRateLimitRule_AbpApiGatewayReRoute_ReRouteId",
                        column: x => x.ReRouteId,
                        principalTable: "AbpApiGatewayReRoute",
                        principalColumn: "ReRouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewaySecurityOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReRouteId = table.Column<long>(nullable: false),
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
                        principalColumn: "ReRouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpApiGatewayServerInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    ServerId = table.Column<long>(nullable: false),
                    ServerName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Host = table.Column<string>(maxLength: 50, nullable: false),
                    Port = table.Column<int>(nullable: false, defaultValue: 80),
                    EventName = table.Column<string>(maxLength: 50, nullable: false),
                    ConfigType = table.Column<int>(nullable: false, defaultValue: 1),
                    ServerAuthId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpApiGatewayServerInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpApiGatewayServerInfo_AbpApiGatewayServerAuth_ServerAuthId",
                        column: x => x.ServerAuthId,
                        principalTable: "AbpApiGatewayServerAuth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayAggregateConfig_AggregateReRouteId",
                table: "AbpApiGatewayAggregateConfig",
                column: "AggregateReRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayAuthOptions_ReRouteId",
                table: "AbpApiGatewayAuthOptions",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayBalancerOptions_ItemId",
                table: "AbpApiGatewayBalancerOptions",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayBalancerOptions_ReRouteId",
                table: "AbpApiGatewayBalancerOptions",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayCacheOptions_ReRouteId",
                table: "AbpApiGatewayCacheOptions",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayDiscovery_ItemId",
                table: "AbpApiGatewayDiscovery",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayHttpOptions_ItemId",
                table: "AbpApiGatewayHttpOptions",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayHttpOptions_ReRouteId",
                table: "AbpApiGatewayHttpOptions",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayQoSOptions_ItemId",
                table: "AbpApiGatewayQoSOptions",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayQoSOptions_ReRouteId",
                table: "AbpApiGatewayQoSOptions",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayRateLimitOptions_ItemId",
                table: "AbpApiGatewayRateLimitOptions",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayRateLimitRule_DynamicReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "DynamicReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayRateLimitRule_ReRouteId",
                table: "AbpApiGatewayRateLimitRule",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayReRoute_DownstreamPathTemplate_UpstreamPathTemp~",
                table: "AbpApiGatewayReRoute",
                columns: new[] { "DownstreamPathTemplate", "UpstreamPathTemplate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewaySecurityOptions_ReRouteId",
                table: "AbpApiGatewaySecurityOptions",
                column: "ReRouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayServerAuth_ServerId",
                table: "AbpApiGatewayServerAuth",
                column: "ServerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayServerInfo_ServerAuthId",
                table: "AbpApiGatewayServerInfo",
                column: "ServerAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayServerInfo_ServerId",
                table: "AbpApiGatewayServerInfo",
                column: "ServerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpApiGatewayAggregateConfig");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayAuthOptions");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayBalancerOptions");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayCacheOptions");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayDiscovery");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayHeaders");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayHostAndPort");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayHttpOptions");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayQoSOptions");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayRateLimitOptions");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayRateLimitRule");

            migrationBuilder.DropTable(
                name: "AbpApiGatewaySecurityOptions");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayServerInfo");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayAggregate");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayGlobalConfiguration");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayDynamicReRoute");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayReRoute");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayServerAuth");
        }
    }
}
