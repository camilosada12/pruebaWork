using Microsoft.EntityFrameworkCore;
using Entity.Model;

namespace Entity.DataInit
{
    public static class ModelDataInit
    {
        public static void SeedModels(this ModelBuilder modelBuilder)
        {
            // Usuarios
            modelBuilder.Entity<User>().HasData(
                new User { id = 1, username = "admin", password = "admin123",  },
                new User { id = 2, username = "asistente", password = "asistente123" },
                new User { id = 3, username = "pizzero", password = "pizzero123" }
            );

            // Roles
            modelBuilder.Entity<rol>().HasData(
                new rol { id = 1, name = "Administrador", description = "Administrador general", active = true },
                new rol { id = 2, name = "Asistente", description = "Asistente de pedidos", active = true },
                new rol { id = 3, name = "Pizzero", description = "Encargado de preparar pizzas", active = true }
            );

            // RolUser
            modelBuilder.Entity<RolUser>().HasData(
                new RolUser { id = 1, rolid = 1, userid = 1 },
                new RolUser { id = 2, rolid = 2, userid = 2 },
                new RolUser { id = 3, rolid = 3, userid = 3 }
            );

            // Pizzas
            modelBuilder.Entity<Pizzas>().HasData(
                new Pizzas { id = 1, name = "Margherita", description = "Pizza clásica con salsa de tomate, mozzarella y albahaca", active = true },
                new Pizzas { id = 2, name = "Pepperoni", description = "Pizza con pepperoni picante y extra queso mozzarella", active = true },
                new Pizzas { id = 3, name = "Hawaiana", description = "Pizza con jamón, piña y queso", active = true },
                new Pizzas { id = 4, name = "Cuatro Quesos", description = "Mezcla de mozzarella, cheddar, azul y parmesano", active = true },
                new Pizzas { id = 5, name = "Vegetariana", description = "Pizza con champiñones, pimientos, cebolla y aceitunas", active = true },
                new Pizzas { id = 6, name = "Mexicana", description = "Pizza con carne, jalapeños y salsa picante", active = true }
            );


            // Pedidos
            modelBuilder.Entity<Pedidos>().HasData(
                new Pedidos { id = 1, name = "pedido 1 ", description = "Primer pedido registrado", active = true },
                new Pedidos { id = 2, name = "pedido 2", description = "Segundo pedido registrado", active = true },
                new Pedidos { id = 3, name = "pedido 3", description = "Tercer pedido registrado", active = true },
                new Pedidos { id = 4, name = "pedido 4", description = "cuarto pedido registrado", active = true }
            );

            // RolFormPermissions
            modelBuilder.Entity<RolFormPermissions>().HasData(
                // Admin
                new RolFormPermissions { id = 1, rolid = 1, formid = 1, permissionid = 1 }, // Registrar Pizza - Crear
                new RolFormPermissions { id = 2, rolid = 1, formid = 2, permissionid = 2 }, // Listar Pizzas - Leer
                new RolFormPermissions { id = 3, rolid = 1, formid = 3, permissionid = 2 }, // Listar Pedidos - Leer

                // Asistente
                new RolFormPermissions { id = 4, rolid = 2, formid = 4, permissionid = 1 }, // Registrar Pedido - Crear
                new RolFormPermissions { id = 5, rolid = 2, formid = 5, permissionid = 2 }, // Listar Pedidos con Estado - Leer
                new RolFormPermissions { id = 6, rolid = 2, formid = 5, permissionid = 3 }, // Actualizar estado - Actualizar

                // Pizzero
                new RolFormPermissions { id = 7, rolid = 3, formid = 6, permissionid = 2 } // Listar Pedidos Pendientes - Leer
            );
        }
    }
}
