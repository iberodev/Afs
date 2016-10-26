using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Afs.Diego.Web.Migrations
{
    public partial class InitialAfsDiegoSingleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    ApiRequestType = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    Error = table.Column<string>(maxLength: 2000, nullable: true),
                    HttpMethod = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RequestBeginTime = table.Column<DateTime>(nullable: false),
                    RequestEndTime = table.Column<DateTime>(nullable: true),
                    RequestUrl = table.Column<string>(maxLength: 2000, nullable: false),
                    ResponseCode = table.Column<int>(maxLength: 3, nullable: true),
                    ResponseText = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiRequests");
        }
    }
}
