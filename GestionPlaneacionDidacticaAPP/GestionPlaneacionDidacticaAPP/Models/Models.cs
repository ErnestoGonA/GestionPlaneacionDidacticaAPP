using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPlaneacionDidacticaAPP.Models
{
    //sqlite3 "C:\Users\Ernesto Gonzalez\AppData\Local\Packages\f0644c92-e285-444d-8482-d0d98319d46b_kdnzcphg1beew\LocalState\DBPlaneacion.db3"
    [Table("eva_cat_asignaturas")]
    public class eva_cat_asignaturas
    {
        
        public Int16 IdAsignatura { get; set; }

        [StringLength(50)]
        public string ClaveAsignatura { get; set; }
        [StringLength(150)]
        public string DesAsignatura { get; set; }
        [StringLength(10)]
        public string Matricula { get; set; }
        [StringLength(1)]
        public string Actual { get; set; }
        public DateTime FechaPlanEstudios { get; set; }
        [StringLength(100)]
        public string NombreCorto { get; set; }
        [StringLength(18)]
        public string Creditos { get; set; }

        public Int16 IdTipoGenAsignatura { get; set; }
        public Int16 IdGenAsignatura { get; set; }
        public Int16 IdTipoGenNivelEscolar { get; set; }
        public Int16 IdGenNivelEscolar { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }

    [Table("eva_planeacion")]
    public class eva_planeacion
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlaneacion { get; set; }
        public Int16 IdAsignatura { get; set; }


        [StringLength(20)]
        public string ReferenciaNorma { get; set; }
        [StringLength(20)]
        public string Revision { get; set; }
        [StringLength(1)]
        public string Actual { get; set; }
        [StringLength(1)]
        public string PlantillaOriginal { get; set; }
        [StringLength(20)]
        public string CompetenciaAsignatura { get; set; }
        [StringLength(20)]
        public string AportacionPerfilEgreso { get; set; }
        public Int16 IdPeriodo { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //Foreign keys
        public eva_cat_asignaturas eva_cat_asignaturas { get; set; }
        public cat_periodos cat_periodos { get; set; }
    }

    [Table("eva_planeacion_temas")]
    public class eva_planeacion_temas
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdTema { get; set; }
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }

        [StringLength(200)]
        public string DesTema { get; set; }
        [StringLength(1000)]
        public string Observaciones { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //Foreign keys
        public eva_cat_asignaturas eva_cat_asignaturas { get; set; }
        public eva_planeacion eva_planeacion { get; set; }

    }

    [Table("eva_planeacion_subtemas")]
    public class eva_planeacion_subtemas
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdSubtema { get; set; }
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }


        [StringLength(255)]
        public string DesSubtema { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //Foreign keys
        public eva_cat_asignaturas eva_cat_asignaturas { get; set; }
        public eva_planeacion eva_planeacion { get; set; }
        public eva_planeacion_temas eva_planeacion_temas { get; set; }

    }

    [Table("eva_planeacion_fuentes")]
    public class eva_planeacion_fuentes
    {
        ////Necesario para que se genere la tabla con el Entity Framework
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Int16 IdPlaneacionFuentes { get; set; }

        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdFuente { get; set; }

        public Int16 Prioridad { get; set; }
        [StringLength(1000)]
        public string Observaciones { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //Foreign keys
        public eva_cat_asignaturas eva_cat_asignaturas { get; set; }
        public eva_planeacion eva_planeacion { get; set; }
        public eva_cat_fuentes_bibliograficas eva_cat_fuentes_bibliograficas { get; set; }
    }

    [Table("eva_planeacion_apoyos")]
    public class eva_planeacion_apoyos
    {
        ////Necesario para que se genere la tabla con el Entity Framework
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Int16 IdPlaneacionApoyos { get; set; }

        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdApoyoDidactico { get; set; }

        [StringLength(1000)]
        public string Observaciones { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //Foreign keys
        public eva_cat_asignaturas eva_cat_asignaturas { get; set; }
        public eva_planeacion eva_planeacion { get; set; }
        public eva_cat_apoyos_didacticos eva_cat_apoyos_didacticos { get; set; }

    }

    [Table("eva_cat_competencias")]
    public class eva_cat_competencias
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCompetencia { get; set; }
        //No estoy seguro con que tabla relacionarla
        public Int16 IdTipoCompetencia { get; set; }

        [StringLength(255)]
        public string DesCompetencia { get; set; }
        [StringLength(3000)]
        public string Detalle { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //Foreign keys

    }

    [Table("eva_planeacion_temas_competencias")]
    public class eva_planeacion_temas_competencias
    {
        ////Necesario para que se genere la tabla con el Entity Framework
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Int16 IdPlaneacionTemasCompetencias { get; set; }


        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }
        public int IdCompetencia { get; set; }

        [StringLength(1000)]
        public string Observaciones { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //Foreign keys
        public eva_cat_asignaturas eva_cat_asignaturas { get; set; }
        public eva_planeacion eva_planeacion { get; set; }
        public eva_planeacion_temas eva_planeacion_temas { get; set; }
        public eva_cat_competencias eva_cat_competencias { get; set; }

    }

    [Table("eva_planeacion_aprendizaje")]
    public class eva_planeacion_aprendizaje
    {
        ////Necesario para que se genere la tabla con el Entity Framework
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Int16 IdPlaneacionAprendizaje { get; set; }

        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }
        public int IdCompetencia { get; set; }
        public int IdActividadAprendizaje { get; set; }

        [StringLength(1000)]
        public string Observaciones { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //Foreign keys
        public eva_planeacion_temas_competencias eva_planeacion_temas_competencias {get;set;}

        public eva_cat_asignaturas eva_cat_asignaturas { get; set; }
        public eva_planeacion eva_planeacion { get; set; }
        public eva_planeacion_temas eva_planeacion_temas { get; set; }
        public eva_cat_competencias eva_cat_competencias { get; set; }
        public eva_cat_actividades_aprendizaje eva_cat_actividades_aprendizaje { get; set; }

    }

    [Table("eva_planeacion_enseñanza")]
    public class eva_planeacion_enseñanza
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }
        public int IdCompetencia { get; set; }
        public int IdActividadEnseñanza { get; set; }
        
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //Foreign keys

        public eva_planeacion_temas_competencias eva_planeacion_temas_competencias { get; set; }
        public eva_cat_asignaturas eva_cat_asignaturas { get; set; }
        public eva_planeacion eva_planeacion { get; set; }
        public eva_planeacion_temas eva_planeacion_temas { get; set; }
        public eva_cat_competencias eva_cat_competencias { get; set; }
        public eva_cat_actividades_enseñanza eva_cat_actividades_enseñanza { get; set; }

    }

    [Table("eva_planeacion_criterios_evalua")]
    public class eva_planeacion_criterios_evalua
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCriterio { get; set; }
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }
        public int IdCompetencia { get; set; }

        [StringLength(100)]
        public string DesCriterio { get; set; }
        public float Porcentaje { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //Foreign keys
        public eva_planeacion_temas_competencias eva_planeacion_temas_competencias { get; set; }
        public eva_cat_asignaturas eva_cat_asignaturas { get; set; }
        public eva_planeacion eva_planeacion { get; set; }
        public eva_planeacion_temas eva_planeacion_temas { get; set; }
        public eva_cat_competencias eva_cat_competencias { get; set; }

    }

    [Table("eva_planeacion_mejora_desempeño")]
    public class eva_planeacion_mejora_desempeño
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMejora { get; set; }
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }

        [StringLength(1000)]
        public string DesMejora { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //Foreign keys
        public eva_cat_asignaturas eva_cat_asignaturas { get; set; }
        public eva_planeacion eva_planeacion { get; set; }
        public eva_planeacion_temas eva_planeacion_temas { get; set; }

    }

    [Table("eva_cat_fuentes_bibliograficas")]
    public class eva_cat_fuentes_bibliograficas
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdFuente { get; set; }

        [StringLength(255)]
        public string DesFuenteCompleta { get; set; }
        [StringLength(20)]
        public string NombreFuente { get; set; }
        [StringLength(20)]
        public string Autor { get; set; }
        [StringLength(20)]
        public string Editorial { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
        
    }

    [Table("eva_cat_apoyos_didacticos")]
    public class eva_cat_apoyos_didacticos
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdApoyoDidactico { get; set; }

        [StringLength(255)]
        public string DesApoyoDidactico { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }

    [Table("eva_cat_actividades_aprendizaje")]
    public class eva_cat_actividades_aprendizaje
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdActividadAprendizaje { get; set; }

        [StringLength(1000)]
        public string DesActividadAprendizaje { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }

    [Table("eva_cat_actividades_enseñanza")]
    public class eva_cat_actividades_enseñanza
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdActividadEnseñanza { get; set; }

        [StringLength(1000)]
        public string DesActividadEnseñanza { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }

    [Table("cat_tipos_estatus")]
    public class cat_tipos_estatus
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdTipoEstatus { get; set; }

        [StringLength(30)]
        public string DesTipoEstatus { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }

    [Table("cat_estatus")]
    public class cat_estatus
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdEstatus { get; set; }
        public Int16 IdTipoEstatus { get; set; }

        [StringLength(50)]
        public string Clave { get; set; }
        [StringLength(30)]
        public string DesEstatus { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }

    [Table("cat_tipos_generales")]
    public class cat_tipos_generales
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdTipoGeneral { get; set; }

        [StringLength(100)]
        public string DesTipo { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }

    [Table("cat_generales")]
    public class cat_generales
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdGeneral { get; set; }
        public Int16 IdTipoGeneral { get; set; }

        [StringLength(20)]
        public string Clave { get; set; }
        [StringLength(100)]
        public string DesGeneral { get; set; }
        [StringLength(50)]
        public string IdLlaveClasifica { get; set; }
        [StringLength(50)]
        public string Referencia { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }

    [Table("cat_periodos")]
    public class cat_periodos
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdPeriodo { get; set; }

        [StringLength(100)]
        public string DesPeriodo { get; set; }
        [StringLength(30)]
        public string NombreCorto { get; set; }
        public DateTime PeriodoIni { get; set; }
        public DateTime PeriodoFin { get; set; }
        public Int16 Año { get; set; }
        [StringLength(1)]
        public string NumPeriodo { get; set; }
        public Int16 IdTipoGenPeriodo { get; set; }
        public Int16 IdGenPeriodo { get; set; }
        [StringLength(5)]
        public string ClavePeriodo { get; set; }
        public Int16 NumDias { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }

    [Table("cat_institutos")]
    public class cat_institutos
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdInstituto { get; set; }
        [StringLength(50)]
        public string DesInstituto { get; set; }
        [StringLength(50)]
        public string Alias { get; set; }
        [StringLength(1)]
        public string Matriz { get; set; }
        public Int16 IdInstitutoPadre { get; set; }
        public Int16 IdTipoGenGiro { get; set; }
        public Int16 IdGenGiro { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }

    [Table("rh_cat_personas")]
    public class rh_cat_personas
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }
        public Int16 IdInstituto { get; set; }

        [StringLength(20)]
        public string NumControl { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(60)]
        public string ApPaterno { get; set; }
        [StringLength(60)]
        public string ApMaterno { get; set; }
        [StringLength(15)]
        public string RFC { get; set; }
        [StringLength(25)]
        public string CURP { get; set; }
        public DateTime FechaNac { get; set; }
        [StringLength(1)]
        public string TipoPersona { get; set; }
        [StringLength(1)]
        public string Sexo { get; set; }
        [StringLength(255)]
        public string RutaFoto { get; set; }
        [StringLength(20)]
        public string Alias { get; set; }
        public Int16 IdTipoGenOcupacion { get; set; }
        public Int16 IdGenOcupacion { get; set; }
        public Int16 IdTipoGenEstadoCivil { get; set; }
        public Int16 IdGenEstadoCivil { get; set; }

        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

        //Foreign keys
        public cat_institutos cat_institutos { get; set; }

    }

}
