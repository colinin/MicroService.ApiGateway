using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.ApiGateway.Migrations
{
    public partial class initliza_ocelot_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpApiGatewayAggregate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "AbpApiGatewayAggregateConfig",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        name: "FK_AbpApiGatewayAggregateConfig_AbpApiGatewayAggregate_AggregateReRouteId",
                        column: x => x.AggregateReRouteId,
                        principalTable: "AbpApiGatewayAggregate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayAggregateConfig_AggregateReRouteId",
                table: "AbpApiGatewayAggregateConfig",
                column: "AggregateReRouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpApiGatewayAggregateConfig");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayAggregate");
        }
    }
}
