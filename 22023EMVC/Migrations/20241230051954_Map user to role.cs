using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _22023EMVC.Migrations
{
    /// <inheritdoc />
    public partial class Mapusertorole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            Insert into AspNetUserRoles values
            ('3b91e7df-28bf-46a1-8c3f-8dd272e4ea0e','c87fa796-d513-4c1b-aef5-2bfd73e7a439'),
            ('a440fff1-3c7f-4977-a5d9-38d26ff54c4d','43064954-d35d-49ef-9cf2-abe84345e891')
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
