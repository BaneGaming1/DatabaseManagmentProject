using System;
using System.Collections.Generic;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Data.SqlClient;

namespace DatbaseProject.src
{
    /// <summary>
    /// Třída `CarRentalContext` reprezentuje kontext databáze pro správu entit a relací.
    /// Využívá Entity Framework Core k mapování entit na tabulky v databázi.
    /// </summary>
    public class CarRentalContext : DbContext
    {
        /// <summary>
        /// Konstruktor třídy `CarRentalContext`.
        /// </summary>
        public CarRentalContext()
        {
        }

        #region DbSety pro entity

        /// <summary>
        /// Reprezentuje tabulku `Customer` v databázi.
        /// </summary>
        public DbSet<Customer> Customer { get; set; }

        /// <summary>
        /// Reprezentuje tabulku `Car` v databázi.
        /// </summary>
        public DbSet<Car> Car { get; set; }

        /// <summary>
        /// Reprezentuje tabulku `Rental` v databázi.
        /// </summary>
        public DbSet<Rental> Rental { get; set; }

        /// <summary>
        /// Reprezentuje tabulku `ExtraService` v databázi.
        /// </summary>
        public DbSet<ExtraService> ExtraService { get; set; }

        /// <summary>
        /// Reprezentuje vazební tabulku `Rental_ExtraService` v databázi.
        /// </summary>
        public DbSet<Rental_ExtraService> RentalExtraService { get; set; }

        #endregion

        /// <summary>
        /// Konfigurace vztahů mezi entitami a dalších pravidel v databázi.
        /// </summary>
        /// <param name="modelBuilder">Poskytuje API pro konfiguraci modelu databáze.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definice kombinovaného primárního klíče pro vazební tabulku Rental_ExtraService
            modelBuilder.Entity<Rental_ExtraService>()
                .HasKey(x => new { x.RentalId, x.ExtraServiceId });

            // Zavolání základní implementace
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Konfigurace připojení k databázi.
        /// Získává přihlašovací údaje z `.env` souboru a sestavuje ConnectionString.
        /// </summary>
        /// <param name="optionsBuilder">Poskytuje API pro konfiguraci možností databázového připojení.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Načtení proměnných prostředí z `.env` souboru
                Env.Load();

                // Získání přihlašovacích údajů z prostředí
                var server = Environment.GetEnvironmentVariable("DB_SERVER");
                var dbName = Environment.GetEnvironmentVariable("DB_NAME");
                var user = Environment.GetEnvironmentVariable("DB_USER");
                var pass = Environment.GetEnvironmentVariable("DB_PASS");

                // Sestavení ConnectionStringu
                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = server,        // Např. server: ".\SQLEXPRESS"
                    InitialCatalog = dbName,    // Název databáze
                    IntegratedSecurity = false  // Použití SQL autentizace
                };

                // Nastavení uživatelského jména a hesla
                builder.UserID = user;
                builder.Password = pass;

                // Přidání možnosti ignorovat validaci certifikátu
                builder.TrustServerCertificate = true;

                // Předání ConnectionStringu do EF Core
                optionsBuilder.UseSqlServer(builder.ToString());
            }
        }
    }
}
