using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.API.Migrations
{
    public partial class seedroleandUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1701f22a-ec9f-4d0a-8db6-19fc3a73bc3f", "b123242b-5960-4b65-ab28-5d47912c3710", "Administrator", "ADMINISTRATOR" },
                    { "9df4a2bd-e083-4299-957c-dbf0a296ae6b", "f7554eb0-14e5-435a-ab57-6ffd61534ba4", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ee82860c-b2b5-49b0-8c02-defe6f8e434c", 0, "4bca6abd-ebf0-4068-b164-51ac1b4731ce", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEOBq1MQfjLiYNjbDdNtjEJshEw8z5NskOW3aJpsEaijlW5Y2WkPOUGJIHr/kTHQqHw==", null, false, "84a253c8-6ab1-415b-9723-ea5b6ea7b841", false, "admin@bookstaor.com" },
                    { "f4d77821-6610-402e-8e98-11b0d83a0426", 0, "548d3147-8905-494a-8e06-c814a85437a9", "user@bookstore.com", false, "System", "uSER", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAENy65KaIg3j/6ENyDDP+S9wIyZmI0RiXfGtpLIUCynBHf6tq4LaudsXW4CH8eeG/cg==", null, false, "21f72126-081a-4115-8b56-6bd4202add99", false, "user@bookstaor.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1701f22a-ec9f-4d0a-8db6-19fc3a73bc3f", "ee82860c-b2b5-49b0-8c02-defe6f8e434c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9df4a2bd-e083-4299-957c-dbf0a296ae6b", "f4d77821-6610-402e-8e98-11b0d83a0426" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1701f22a-ec9f-4d0a-8db6-19fc3a73bc3f", "ee82860c-b2b5-49b0-8c02-defe6f8e434c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9df4a2bd-e083-4299-957c-dbf0a296ae6b", "f4d77821-6610-402e-8e98-11b0d83a0426" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1701f22a-ec9f-4d0a-8db6-19fc3a73bc3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9df4a2bd-e083-4299-957c-dbf0a296ae6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee82860c-b2b5-49b0-8c02-defe6f8e434c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f4d77821-6610-402e-8e98-11b0d83a0426");
        }
    }
}
