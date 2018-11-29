using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPlaneacionDidacticaAPP.Models
{
    [Table("eva_planeacion")]
    public class eva_planeacion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
    }
    [Table("eva_planeacion_temas")]
    public class eva_planeacion_temas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("eva_planeacion_subtemas")]
    public class eva_planeacion_subtemas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("eva_planeacion_fuentes")]
    public class eva_planeacion_fuentes
    {
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdFuente { get; set; }
        public Int16 Prioridad { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("eva_planeacion_apoyos")]
    public class eva_planeacion_apoyos
    {
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdApoyoDidactico { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("eva_planeacion_temas_competencias")]
    public class eva_planeacion_temas_competencias
    {
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
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("eva_planeacion_aprendizaje")]
    public class eva_planeacion_aprendizaje
    {
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }
        public int IdCompetencia { get; set; }
        public int idActividadAprendizaje { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("eva_planeacion_enseñanza")]
    public class eva_planeacion_enseñanza
    {
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }
        public int IdCompetencia { get; set; }
        public int IdActividadEnseñanza { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("eva_planeacion_criterios_evalua")]
    public class eva_planeacion_criterios_evalua
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("eva_planeacion_mejora_desempeño")]
    public class eva_planeacion_mejora_desempeño
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("eva_cat_fuentes_bibliograficas")]
    public class eva_cat_fuentes_bibliograficas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("eva_cat_apoyos_didacticos")]
    public class eva_cat_apoyos_didacticos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdApoyoDidactico { get; set; }
        [StringLength(255)]
        public string DesApoyoDidactico { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("eva_cat_actividades_aprendizaje")]
    public class eva_cat_actividades_aprendizaje
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdActividadAprendizaje { get; set; }
        [StringLength(1000)]
        public string DesActividadAprendizaje { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("eva_cat_actividades_enseñanza")]
    public class eva_cat_actividades_enseñanza
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdActividadEnseñanza { get; set; }
        [StringLength(1000)]
        public string DesActividadEnseñanza { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("cat_tipos_estatus")]
    public class cat_tipos_estatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdTipoEstatus { get; set; }
        [StringLength(30)]
        public string DesTipoEstatus { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("cat_estatus")]
    public class cat_estatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("cat_tipos_generales")]
    public class cat_tipos_generales
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdTipoGeneral { get; set; }
        [StringLength(100)]
        public string DesTipo { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("cat_generales")]
    public class cat_generales
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("cat_periodos")]
    public class cat_periodos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    [Table("rh_cat_personas")]
    public class rh_cat_personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public Int16 IdTipoGenOcupacio { get; set; }
        public Int16 IdGenOcupacion { get; set; }
        public Int16 IdTipoGenEstadoCivil { get; set; }
        public Int16 IdGenEstadoCivil { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioUltMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
}
