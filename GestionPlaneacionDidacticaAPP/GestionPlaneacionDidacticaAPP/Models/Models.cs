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
    [Table("eva_planeacion_tema")]
    public class eva_planeacion_tema
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
}
