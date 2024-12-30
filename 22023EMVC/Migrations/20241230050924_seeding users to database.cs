using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _22023EMVC.Migrations
{
    /// <inheritdoc />
    public partial class seedinguserstodatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
table: "AspNetUsers",
columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount" },
values: new object[]
{
            "3b91e7df-28bf-46a1-8c3f-8dd272e4ea0e", // Id
            "admin@ismt.com", // UserName
            "ADMIN@ISMT.COM", // NormalizedUserName
            "admin@ismt.com", // Email
            "ADMIN@ISMT.COM", // NormalizedEmail
            true, // EmailConfirmed
            "AQAAAAIAAYagAAAAEMXxWSMupdGvChgiyo6du2K7yeHLGsyDB4MvpOjhDEhxbUc7calgtyZOTvOPcNLZxQ==", // PasswordHash
            "MC7SB7PFC6WKS3WLNVF2AJRHUYO5HXJX", // SecurityStamp
            "a608ed71-754a-47ca-be2c-bb02ce6ba565", // ConcurrencyStamp
            null, // PhoneNumber
            false, // PhoneNumberConfirmed
            false, // TwoFactorEnabled
            null, // LockoutEnd
            true, // LockoutEnabled
            0 // AccessFailedCount
});

            migrationBuilder.InsertData(
       table: "AspNetUsers",
       columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount" },
       values: new object[]
       {
            "a440fff1-3c7f-4977-a5d9-38d26ff54c4d", // Id
            "user@ismt.com", // UserName
            "USER@ISMT.COM", // NormalizedUserName
            "user@ismt.com", // Email
            "USER@ISMT.COM", // NormalizedEmail
            true, // EmailConfirmed
            "AQAAAAIAAYagAAAAEMXxWSMupdGvChgiyo6du2K7yeHLGsyDB4MvpOjhDEhxbUc7calgtyZOTvOPcNLZxQ==", // PasswordHash
            "MC7SB7PFC6WKS3WLNVF2AJRHUYO5HXJX", // SecurityStamp
            "a608ed71-754a-47ca-be2c-bb02ce6ba565", // ConcurrencyStamp
            null, // PhoneNumber
            false, // PhoneNumberConfirmed
            false, // TwoFactorEnabled
            null, // LockoutEnd
            true, // LockoutEnabled
            0 // AccessFailedCount
       });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
