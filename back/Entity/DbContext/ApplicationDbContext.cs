using Entity.DataInit;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Entity.Context
{
    /// <summary>
    /// Representa el contexto de la base de datos de la aplicación,
    /// proporcionando configuraciones y métodos para la gestión de entidades.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Configuración de la aplicación.
        /// </summary>
        protected readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor del contexto de la base de datos.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto de base de datos.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //
        // DBSets - Representación de las tablas en la base de datos
        //
        public DbSet<User> Users { get; set; }
        public DbSet<Pizzas> Pizzas { get; set; }
        public DbSet<rol> Roles { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<RolUser> RolUsers { get; set; }
        public DbSet<RolFormPermissions> RolFormPermissions { get; set; }

        /// <summary>
        /// Configura las relaciones y datos semilla aplicando clases de configuración.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo de base de datos.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica relaciones específicas
            // modelBuilder.ApplyConfiguration(new RelacionesLog()); // Descomenta si es necesario

            // Aplica todas las configuraciones IEntityTypeConfiguration del ensamblado actual
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.SeedModels(); // Llama al método de inicialización

            base.OnModelCreating(modelBuilder);
        }

    }
}
