using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.ApiGateway.Migrations
{
    public partial class modifyglobalconfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayBalancerOptions_AbpApiGatewayReRoute_ItemId",
                table: "AbpApiGatewayBalancerOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayGlobalConfiguration_AbpApiGatewayHttpOptions_HttpHandlerOptionsId",
                table: "AbpApiGatewayGlobalConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayGlobalConfiguration_AbpApiGatewayBalancerOptions_LoadBalancerOptionsId",
                table: "AbpApiGatewayGlobalConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayGlobalConfiguration_AbpApiGatewayQoSOptions_QoSOptionsId",
                table: "AbpApiGatewayGlobalConfiguration");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayHttpOptions_AbpApiGatewayReRoute_ItemId",
                table: "AbpApiGatewayHttpOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpApiGatewayQoSOptions_AbpApiGatewayReRoute_ItemId",
                table: "AbpApiGatewayQoSOptions");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayQoSOptions_ItemId",
                table: "AbpApiGatewayQoSOptions");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayHttpOptions_ItemId",
                table: "AbpApiGatewayHttpOptions");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayGlobalConfiguration_HttpHandlerOptionsId",
                table: "AbpApiGatewayGlobalConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayGlobalConfiguration_LoadBalancerOptionsId",
                table: "AbpApiGatewayGlobalConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayGlobalConfiguration_QoSOptionsId",
                table: "AbpApiGatewayGlobalConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayBalancerOptions_ItemId",
                table: "AbpApiGatewayBalancerOptions");

            migrationBuilder.DropColumn(
                name: "HttpHandlerOptionsId",
                table: "AbpApiGatewayGlobalConfiguration");

            migrationBuilder.DropColumn(
                name: "LoadBalancerOptionsId",
                table: "AbpApiGatewayGlobalConfiguration");

            migrationBuilder.DropColumn(
                name: "QoSOptionsId",
                table: "AbpApiGatewayGlobalConfiguration");

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "AbpApiGatewayQoSOptions",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "ReRouteId",
                table: "AbpApiGatewayQoSOptions",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "AbpApiGatewayHttpOptions",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "ReRouteId",
                table: "AbpApiGatewayHttpOptions",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "AbpApiGatewayBalancerOptions",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "ReRouteId",
                table: "AbpApiGatewayBalancerOptions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayQoSOptions_ItemId",
                table: "AbpApiGatewayQoSOptions",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayQoSOptions_ReRouteId",
                table: "AbpApiGatewayQoSOptions",
                column: "ReRouteId",
                unique: true,
                filter: "[ReRouteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayHttpOptions_ItemId",
                table: "AbpApiGatewayHttpOptions",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayHttpOptions_ReRouteId",
                table: "AbpApiGatewayHttpOptions",
                column: "ReRouteId",
                unique: true,
                filter: "[ReRouteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayBalancerOptions_ItemId",
                table: "AbpApiGatewayBalancerOptions",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayBalancerOptions_ReRouteId",
                table: "AbpApiGatewayBalancerOptions",
                column: "ReRouteId",
                unique: true,
                filter: "[ReRouteId] IS NOT NULL");

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

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayQoSOptions_ItemId",
                table: "AbpApiGatewayQoSOptions");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayQoSOptions_ReRouteId",
                table: "AbpApiGatewayQoSOptions");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayHttpOptions_ItemId",
                table: "AbpApiGatewayHttpOptions");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayHttpOptions_ReRouteId",
                table: "AbpApiGatewayHttpOptions");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayBalancerOptions_ItemId",
                table: "AbpApiGatewayBalancerOptions");

            migrationBuilder.DropIndex(
                name: "IX_AbpApiGatewayBalancerOptions_ReRouteId",
                table: "AbpApiGatewayBalancerOptions");

            migrationBuilder.DropColumn(
                name: "ReRouteId",
                table: "AbpApiGatewayQoSOptions");

            migrationBuilder.DropColumn(
                name: "ReRouteId",
                table: "AbpApiGatewayHttpOptions");

            migrationBuilder.DropColumn(
                name: "ReRouteId",
                table: "AbpApiGatewayBalancerOptions");

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "AbpApiGatewayQoSOptions",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "AbpApiGatewayHttpOptions",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HttpHandlerOptionsId",
                table: "AbpApiGatewayGlobalConfiguration",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoadBalancerOptionsId",
                table: "AbpApiGatewayGlobalConfiguration",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QoSOptionsId",
                table: "AbpApiGatewayGlobalConfiguration",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "AbpApiGatewayBalancerOptions",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayQoSOptions_ItemId",
                table: "AbpApiGatewayQoSOptions",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpApiGatewayHttpOptions_ItemId",
                table: "AbpApiGatewayHttpOptions",
                column: "ItemId",
                unique: true);

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
                name: "IX_AbpApiGatewayBalancerOptions_ItemId",
                table: "AbpApiGatewayBalancerOptions",
                column: "ItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayBalancerOptions_AbpApiGatewayReRoute_ItemId",
                table: "AbpApiGatewayBalancerOptions",
                column: "ItemId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "ReRouteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayGlobalConfiguration_AbpApiGatewayHttpOptions_HttpHandlerOptionsId",
                table: "AbpApiGatewayGlobalConfiguration",
                column: "HttpHandlerOptionsId",
                principalTable: "AbpApiGatewayHttpOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayGlobalConfiguration_AbpApiGatewayBalancerOptions_LoadBalancerOptionsId",
                table: "AbpApiGatewayGlobalConfiguration",
                column: "LoadBalancerOptionsId",
                principalTable: "AbpApiGatewayBalancerOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayGlobalConfiguration_AbpApiGatewayQoSOptions_QoSOptionsId",
                table: "AbpApiGatewayGlobalConfiguration",
                column: "QoSOptionsId",
                principalTable: "AbpApiGatewayQoSOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayHttpOptions_AbpApiGatewayReRoute_ItemId",
                table: "AbpApiGatewayHttpOptions",
                column: "ItemId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "ReRouteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpApiGatewayQoSOptions_AbpApiGatewayReRoute_ItemId",
                table: "AbpApiGatewayQoSOptions",
                column: "ItemId",
                principalTable: "AbpApiGatewayReRoute",
                principalColumn: "ReRouteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
