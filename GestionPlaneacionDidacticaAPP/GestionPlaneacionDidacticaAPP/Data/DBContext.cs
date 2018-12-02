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

        //crud
        public DbSet<eva_planeacion> eva_planeacion { get; set; }
        public DbSet<eva_planeacion_temas> eva_planeacion_temas { get; set; }
        public DbSet<eva_planeacion_subtemas> eva_planeacion_subtemas { get; set; }
        public DbSet<eva_planeacion_fuentes> eva_planeacion_fuentes { get; set; }
        public DbSet<eva_planeacion_apoyos> eva_planeacion_apoyos { get; set; }
        public DbSet<eva_planeacion_temas_competencias> eva_planeacion_temas_competencias { get; set; }
        public DbSet<eva_cat_competencias> eva_cat_competencias { get; set; }
        public DbSet<eva_planeacion_aprendizaje> eva_planeacion_aprendizaje { get; set; }
        public DbSet<eva_planeacion_enseñanza> eva_planeacion_enseñanza { get; set; }
        public DbSet<eva_planeacion_criterios_evalua> eva_planeacion_criterios_evalua { get; set; }
        public DbSet<eva_planeacion_mejora_desempeño> eva_planeacion_mejor_desempeño { get; set; }
        public DbSet<eva_cat_fuentes_bibliograficas> eva_cat_fuentes_bibliograficas { get; set; }
        public DbSet<eva_cat_apoyos_didacticos> eva_cat_apoyos_didacticos { get; set; }
        public DbSet<eva_cat_actividades_aprendizaje> eva_cat_actividades_aprendizaje { get; set; }
        public DbSet<eva_cat_actividades_enseñanza> eva_cat_actividades_enseñanza { get; set; }
        //relacionados
        public DbSet<cat_tipos_estatus> cat_tipos_estatus { get; set; }
        public DbSet<cat_estatus> cat_estatus { get; set; }
        public DbSet<cat_tipos_generales> cat_tipos_generales { get; set; }
        public DbSet<cat_generales> cat_generales { get; set; }
        public DbSet<cat_periodos> cat_periodos { get; set; }
        public DbSet<rh_cat_personas> rh_cat_personas { get; set; }
        public DbSet<eva_cat_asignaturas> eva_cat_asignaturas { get; set; }
        public DbSet<cat_institutos> cat_institutos { get; set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {

                ////Primary keys
                modelBuilder.Entity<eva_cat_asignaturas>().HasKey(eca => new { eca.IdAsignatura });
                modelBuilder.Entity<eva_planeacion>().HasKey(plan => new { plan.IdPlaneacion });
                modelBuilder.Entity<eva_planeacion_temas>().HasKey(tem => new { tem.IdTema });
                modelBuilder.Entity<eva_planeacion_subtemas>().HasKey(subt => new { subt.IdSubtema });
                modelBuilder.Entity<eva_planeacion_criterios_evalua>().HasKey(crit => new { crit.IdCriterio });
                modelBuilder.Entity<eva_cat_fuentes_bibliograficas>().HasKey(fuen => new { fuen.IdFuente });
                modelBuilder.Entity<eva_cat_apoyos_didacticos>().HasKey(apdida => new { apdida.IdApoyoDidactico });
                modelBuilder.Entity<eva_cat_actividades_aprendizaje>().HasKey(acapre => new { acapre.IdActividadAprendizaje });
                modelBuilder.Entity<eva_cat_actividades_enseñanza>().HasKey(acense => new { acense.IdActividadEnseñanza });
                modelBuilder.Entity<cat_tipos_estatus>().HasKey(cte => new { cte.IdTipoEstatus });
                modelBuilder.Entity<cat_estatus>().HasKey(ce => new { ce.IdEstatus });
                modelBuilder.Entity<cat_tipos_generales>().HasKey(ctg => new { ctg.IdTipoGeneral });
                modelBuilder.Entity<cat_generales>().HasKey(cg => new { cg.IdGeneral });
                modelBuilder.Entity<cat_periodos>().HasKey(cp => new { cp.IdPeriodo });
                modelBuilder.Entity<cat_institutos>().HasKey(ci => new { ci.IdInstituto });
                modelBuilder.Entity<rh_cat_personas>().HasKey(rcp => new { rcp.IdPersona });

                ////Foreign keys
                ///
                //eva_planeacion
                modelBuilder.Entity<eva_planeacion>().HasOne(s => s.eva_cat_asignaturas).WithMany().HasForeignKey(s => s.IdAsignatura);
                modelBuilder.Entity<eva_planeacion>().HasOne(s => s.cat_periodos).WithMany().HasForeignKey(s => s.IdPeriodo);

                //eva_planeacion_temas
                modelBuilder.Entity<eva_planeacion_temas>().HasOne(s => s.eva_planeacion).WithMany().HasForeignKey(s => s.IdPlaneacion);
                modelBuilder.Entity<eva_planeacion_temas>().HasOne(s => s.eva_cat_asignaturas).WithMany().HasForeignKey(s => s.IdAsignatura);

                //eva_planeacion_subtemas
                modelBuilder.Entity<eva_planeacion_subtemas>().HasOne(s => s.eva_planeacion).WithMany().HasForeignKey(s => s.IdPlaneacion);
                modelBuilder.Entity<eva_planeacion_subtemas>().HasOne(s => s.eva_cat_asignaturas).WithMany().HasForeignKey(s => s.IdAsignatura);
                modelBuilder.Entity<eva_planeacion_subtemas>().HasOne(s => s.eva_planeacion_temas).WithMany().HasForeignKey(s => s.IdTema);

                //eva_planeacion_fuentes
                modelBuilder.Entity<eva_planeacion_fuentes>().HasOne(s => s.eva_cat_asignaturas).WithMany().HasForeignKey(s => s.IdAsignatura);
                modelBuilder.Entity<eva_planeacion_fuentes>().HasOne(s => s.eva_planeacion).WithMany().HasForeignKey(s => s.IdPlaneacion);
                modelBuilder.Entity<eva_planeacion_fuentes>().HasOne(s => s.eva_cat_fuentes_bibliograficas).WithMany().HasForeignKey(s => s.IdFuente);

                //eva_planeacion_apoyos
                modelBuilder.Entity<eva_planeacion_apoyos>().HasOne(s => s.eva_cat_asignaturas).WithMany().HasForeignKey(s => s.IdAsignatura);
                modelBuilder.Entity<eva_planeacion_apoyos>().HasOne(s => s.eva_planeacion).WithMany().HasForeignKey(s => s.IdPlaneacion);
                modelBuilder.Entity<eva_planeacion_apoyos>().HasOne(s => s.eva_cat_apoyos_didacticos).WithMany().HasForeignKey(s => s.IdApoyoDidactico);

                //eva_planeacion_temas_competencias
                modelBuilder.Entity<eva_planeacion_temas_competencias>().HasOne(s => s.eva_planeacion).WithMany().HasForeignKey(s => s.IdPlaneacion);
                modelBuilder.Entity<eva_planeacion_temas_competencias>().HasOne(s => s.eva_cat_asignaturas).WithMany().HasForeignKey(s => s.IdAsignatura);
                modelBuilder.Entity<eva_planeacion_temas_competencias>().HasOne(s => s.eva_planeacion_temas).WithMany().HasForeignKey(s => s.IdTema);
                modelBuilder.Entity<eva_planeacion_temas_competencias>().HasOne(s => s.eva_cat_competencias).WithMany().HasForeignKey(s => s.IdCompetencia);

                //eva_planeacion_aprendizaje
                modelBuilder.Entity<eva_planeacion_aprendizaje>().HasOne(s => s.eva_planeacion).WithMany().HasForeignKey(s => s.IdPlaneacion);
                modelBuilder.Entity<eva_planeacion_aprendizaje>().HasOne(s => s.eva_cat_asignaturas).WithMany().HasForeignKey(s => s.IdAsignatura);
                modelBuilder.Entity<eva_planeacion_aprendizaje>().HasOne(s => s.eva_planeacion_temas).WithMany().HasForeignKey(s => s.IdTema);
                modelBuilder.Entity<eva_planeacion_aprendizaje>().HasOne(s => s.eva_cat_competencias).WithMany().HasForeignKey(s => s.IdCompetencia);
                modelBuilder.Entity<eva_planeacion_aprendizaje>().HasOne(s => s.eva_cat_actividades_aprendizaje).WithMany().HasForeignKey(s => s.IdActividadAprendizaje);

                //eva_planeacion_enseñanza
                modelBuilder.Entity<eva_planeacion_enseñanza>().HasOne(s => s.eva_planeacion).WithMany().HasForeignKey(s => s.IdPlaneacion);
                modelBuilder.Entity<eva_planeacion_enseñanza>().HasOne(s => s.eva_cat_asignaturas).WithMany().HasForeignKey(s => s.IdAsignatura);
                modelBuilder.Entity<eva_planeacion_enseñanza>().HasOne(s => s.eva_planeacion_temas).WithMany().HasForeignKey(s => s.IdTema);
                modelBuilder.Entity<eva_planeacion_enseñanza>().HasOne(s => s.eva_cat_competencias).WithMany().HasForeignKey(s => s.IdCompetencia);
                modelBuilder.Entity<eva_planeacion_enseñanza>().HasOne(s => s.eva_cat_actividades_enseñanza).WithMany().HasForeignKey(s => s.IdActividadEnseñanza);

                //eva_planeacion_criterios_evalua
                modelBuilder.Entity<eva_planeacion_criterios_evalua>().HasOne(s => s.eva_planeacion).WithMany().HasForeignKey(s => s.IdPlaneacion);
                modelBuilder.Entity<eva_planeacion_criterios_evalua>().HasOne(s => s.eva_cat_asignaturas).WithMany().HasForeignKey(s => s.IdAsignatura);
                modelBuilder.Entity<eva_planeacion_criterios_evalua>().HasOne(s => s.eva_planeacion_temas).WithMany().HasForeignKey(s => s.IdTema);
                modelBuilder.Entity<eva_planeacion_criterios_evalua>().HasOne(s => s.eva_cat_competencias).WithMany().HasForeignKey(s => s.IdCompetencia);

                //eva_planeacion_mejora_desempeño
                modelBuilder.Entity<eva_planeacion_mejora_desempeño>().HasOne(s => s.eva_planeacion).WithMany().HasForeignKey(s => s.IdPlaneacion);
                modelBuilder.Entity<eva_planeacion_mejora_desempeño>().HasOne(s => s.eva_cat_asignaturas).WithMany().HasForeignKey(s => s.IdAsignatura);
                modelBuilder.Entity<eva_planeacion_mejora_desempeño>().HasOne(s => s.eva_planeacion_temas).WithMany().HasForeignKey(s => s.IdTema);

                //rh_cat_personas
                modelBuilder.Entity<rh_cat_personas>().HasOne(s => s.cat_institutos).WithMany().HasForeignKey(s => s.IdInstituto);

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

        }//AL CREAR EL MODELO

    }
}
