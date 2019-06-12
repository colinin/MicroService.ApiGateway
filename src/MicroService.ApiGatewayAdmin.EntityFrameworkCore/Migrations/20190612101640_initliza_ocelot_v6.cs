using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.ApiGateway.Migrations
{
    public partial class initliza_ocelot_v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpApiGatewayServerAuth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "AbpApiGatewayServerInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "AbpApiGatewayServerInfo");

            migrationBuilder.DropTable(
                name: "AbpApiGatewayServerAuth");
        }
    }
}
