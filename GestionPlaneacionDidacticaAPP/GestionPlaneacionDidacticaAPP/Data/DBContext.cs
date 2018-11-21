using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Models;

namespace GestionPlaneacionDidacticaAPP.Data
{
    public class DBContext : DbContext
    {

        private readonly string LoDataBasePath;

        public DBContext(string DataBasePath)
        {
            LoDataBasePath = DataBasePath;
            MetCrearDB();
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        private async void MetCrearDB()
        {
            try
            {
                //FIC: Se crea la base de datos en base el esquema
                await Database.EnsureCreatedAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        protected async override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite($"Filename={LoDataBasePath}");
                optionsBuilder.EnableSensitiveDataLogging();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        //public DbSet<eva_cat_edificios> eva_cat_edificios { get; set; }
        //public DbSet<eva_cat_espacios> eva_cat_espacios { get; set; }
        //public DbSet<eva_cat_estatus> eva_cat_estatus { get; set; }
        //public DbSet<eva_cat_tipos_estatus> eva_cat_tipos_estatus { get; set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {

                ////Primary keys
                //modelBuilder.Entity<eva_cat_edificios>()
                //    .HasKey(c => new { c.IdEdificio });

                //modelBuilder.Entity<eva_cat_espacios>()
                //    .HasKey(c => new { c.IdEspacio });

                //modelBuilder.Entity<eva_cat_tipos_estatus>()
                //    .HasKey(c => new { c.IdTipoEstatus });

                //modelBuilder.Entity<eva_cat_estatus>()
                //    .HasKey(c => new { c.IdEstatus });

                //modelBuilder.Entity<eva_cat_conocimientos>()
                //    .HasKey(c => new { c.IdConocimiento });

                //modelBuilder.Entity<eva_cat_competencias>()
                //    .HasKey(c => new { c.IdCompetencia });

                ////Foreign keys
                //modelBuilder.Entity<eva_cat_espacios>()
                //    .HasOne(s => s.Eva_Cat_Edificios)
                //    .WithMany().HasForeignKey(s => new { s.IdEdificio });
                //modelBuilder.Entity<eva_cat_espacios>()
                //    .HasOne(s => s.Eva_Cat_Estatus)
                //    .WithMany().HasForeignKey(s => new { s.IdEstatus });
                //modelBuilder.Entity<eva_cat_espacios>()
                //    .HasOne(s => s.Eva_Cat_Tipos_Estatus)
                //    .WithMany().HasForeignKey(s => new { s.IdTipoEstatus });

                //modelBuilder.Entity<eva_cat_estatus>()
                //    .HasOne(s => s.Eva_Cat_Tipos_Estatus)
                //    .WithMany().HasForeignKey(s => new { s.IdTipoEstatus });

                //modelBuilder.Entity<eva_cat_competencias>()
                //    .HasOne(s => s.Eva_Cat_Tipo_Competencias)
                //    .WithMany().HasForeignKey(s => new { s.IdTipoCompetencia });

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

        }//AL CREAR EL MODELO

    }
}
