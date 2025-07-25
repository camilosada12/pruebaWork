using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RolFormPermissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolid = table.Column<int>(type: "int", nullable: false),
                    formid = table.Column<int>(type: "int", nullable: false),
                    permissionid = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolFormPermissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_RolFormPermissions_Pedidos_permissionid",
                        column: x => x.permissionid,
                        principalTable: "Pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolFormPermissions_Pizzas_formid",
                        column: x => x.formid,
                        principalTable: "Pizzas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolFormPermissions_Roles_rolid",
                        column: x => x.rolid,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsers", x => x.id);
                    table.ForeignKey(
                        name: "FK_RolUsers_Roles_rolid",
                        column: x => x.rolid,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsers_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "id", "active", "description", "name" },
                values: new object[,]
                {
                    { 1, true, "Primer pedido registrado", "pedido 1 " },
                    { 2, true, "Segundo pedido registrado", "pedido 2" },
                    { 3, true, "Tercer pedido registrado", "pedido 3" },
                    { 4, true, "cuarto pedido registrado", "pedido 4" }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "id", "active", "description", "name" },
                values: new object[,]
                {
                    { 1, true, "Pizza clásica con salsa de tomate, mozzarella y albahaca", "Margherita" },
                    { 2, true, "Pizza con pepperoni picante y extra queso mozzarella", "Pepperoni" },
                    { 3, true, "Pizza con jamón, piña y queso", "Hawaiana" },
                    { 4, true, "Mezcla de mozzarella, cheddar, azul y parmesano", "Cuatro Quesos" },
                    { 5, true, "Pizza con champiñones, pimientos, cebolla y aceitunas", "Vegetariana" },
                    { 6, true, "Pizza con carne, jalapeños y salsa picante", "Mexicana" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "active", "description", "name" },
                values: new object[,]
                {
                    { 1, true, "Administrador general", "Administrador" },
                    { 2, true, "Asistente de pedidos", "Asistente" },
                    { 3, true, "Encargado de preparar pizzas", "Pizzero" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "active", "password", "username" },
                values: new object[,]
                {
                    { 1, false, "admin123", "admin" },
                    { 2, false, "asistente123", "asistente" },
                    { 3, false, "pizzero123", "pizzero" }
                });

            migrationBuilder.InsertData(
                table: "RolFormPermissions",
                columns: new[] { "id", "active", "formid", "permissionid", "rolid" },
                values: new object[,]
                {
                    { 1, false, 1, 1, 1 },
                    { 2, false, 2, 2, 1 },
                    { 3, false, 3, 2, 1 },
                    { 4, false, 4, 1, 2 },
                    { 5, false, 5, 2, 2 },
                    { 6, false, 5, 3, 2 },
                    { 7, false, 6, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "RolUsers",
                columns: new[] { "id", "active", "rolid", "userid" },
                values: new object[,]
                {
                    { 1, false, 1, 1 },
                    { 2, false, 2, 2 },
                    { 3, false, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolFormPermissions_formid",
                table: "RolFormPermissions",
                column: "formid");

            migrationBuilder.CreateIndex(
                name: "IX_RolFormPermissions_permissionid",
                table: "RolFormPermissions",
                column: "permissionid");

            migrationBuilder.CreateIndex(
                name: "IX_RolFormPermissions_rolid",
                table: "RolFormPermissions",
                column: "rolid");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsers_rolid",
                table: "RolUsers",
                column: "rolid");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsers_userid",
                table: "RolUsers",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolFormPermissions");

            migrationBuilder.DropTable(
                name: "RolUsers");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
