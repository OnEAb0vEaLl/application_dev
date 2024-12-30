using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _22023EMVC.Migrations
{
    /// <inheritdoc />
    public partial class seedingrolestodatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
             INSERT INTO [dbo].[AspNetRoles]
            ([Id],[Name],[NormalizedName])
             VALUES
           ('43064954-d35d-49ef-9cf2-abe84345e891','User','USER'),
		   ('c87fa796-d513-4c1b-aef5-2bfd73e7a439','Admin','ADMIN')   
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
