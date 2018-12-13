using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Enseñanza
{
    public class FicVmEnseñanzaInsert : INotifyPropertyChanged
    {
        #region VARIABLES

        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvEnseñanzaInsert IFicSrvEnseñanzaInsert;

        public string _Asignaturas, _Planeacion, _Competencias, _Temas,_Actividad;
        public List<string> _Actividades;
        public string _AsignaturaSelected, _PlaneacionSelected, _CompetenciaSelected, _TemaSelected;
        public DateTime _FechaIni, _FechaFin;

        private ICommand _SaveCommand, _FicMetRegresarPlaneacionICommand;

        public object[] FicNavigationContextC { get; set; }

        #endregion

        public FicVmEnseñanzaInsert(IFicSrvNavigationInventario IFicSrvNavigationInventario,
            IFicSrvEnseñanzaInsert IFicSrvEnseñanzaInsert)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
            this.IFicSrvEnseñanzaInsert = IFicSrvEnseñanzaInsert;
        }

        #region METODOS

        public async Task<List<string>> GetAsignaturas()
        {
            try
            {
                var asignatura = await IFicSrvEnseñanzaInsert.FicMetGetAsignatura();
                if (asignatura != null)
                {
                    List<string> aux = new List<string>();
                    foreach (eva_cat_asignaturas asi in asignatura)
                    {
                        aux.Add(asi.IdAsignatura + "-" + asi.NombreCorto);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }
        }

        public async Task<List<string>> GetPlaneacion()
        {
            try
            {
                var planeacion = await IFicSrvEnseñanzaInsert.FicMetGetPlaneacion();
                if (planeacion != null)
                {
                    List<string> aux = new List<string>();
                    foreach (eva_planeacion pla in planeacion)
                    {
                        aux.Add(pla.IdPlaneacion + "-" + pla.ReferenciaNorma);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }
        }

        public async Task<List<string>> GetCompetencia()
        {
            try
            {
                var competencia = await IFicSrvEnseñanzaInsert.FicMetGetCompetencia();
                if (competencia != null)
                {
                    List<string> aux = new List<string>();
                    foreach (eva_cat_competencias com in competencia)
                    {
                        aux.Add(com.IdCompetencia + "-" + com.DesCompetencia);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }
        }

        public async Task<List<string>> GetTema()
        {
            try
            {
                var tema = await IFicSrvEnseñanzaInsert.FicMetGetTema();
                if (tema != null)
                {
                    List<string> aux = new List<string>();
                    foreach (eva_planeacion_temas tem in tema)
                    {
                        aux.Add(tem.IdTema + "-" + tem.DesTema);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }
        }

        #endregion

        #region ENLAZAR VARIABLES

        public string Asignaturas
        {
            get { return _Asignaturas; }
            set
            {
                _Asignaturas = value;
                RaisePropertyChanged("Asignaturas");
            }
        }
        public string Planeacion
        {
            get { return _Planeacion; }
            set
            {
                _Planeacion = value;
                RaisePropertyChanged("Planeacion");
            }
        }
        public string Competencias
        {
            get { return _Competencias; }
            set
            {
                _Competencias = value;
                RaisePropertyChanged("Competencias");
            }
        }
        public string Temas
        {
            get { return _Temas; }
            set
            {
                _Temas = value;
                RaisePropertyChanged("Temas");
            }
        }
        public string Actividad
        {
            get { return _Actividad; }
            set
            {
                _Actividad = value;
                RaisePropertyChanged("Actividad");
            }
        }
        public List<string> Actividades
        {
            get { return _Actividades; }
            set
            {
                _Actividades = value;
                RaisePropertyChanged("Actividades");
            }
        }

        public DateTime FechaIni
        {
            get { return _FechaIni;}
            set
            {
                _FechaIni = value;
                RaisePropertyChanged("FechaIni");
            }
        }

        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set
            {
                _FechaFin = value;
                RaisePropertyChanged("FechaFin");
            }
        }

        public string AsignaturaSelected
        {
            get
            {
                return _AsignaturaSelected;
            }
            set
            {
                if (value != null)
                {
                    _AsignaturaSelected = value;
                    RaisePropertyChanged("AsignaturaSelected");
                }
            }
        }
        public string PlaneacionSelected
        {
            get
            {
                return _PlaneacionSelected;
            }
            set
            {
                if (value != null)
                {
                    _PlaneacionSelected = value;
                    RaisePropertyChanged("PlaneacionSelected");
                }
            }
        }
        public string CompetenciaSelected
        {
            get
            {
                return _CompetenciaSelected;
            }
            set
            {
                if (value != null)
                {
                    _CompetenciaSelected = value;
                    RaisePropertyChanged("CompetenciaSelected");
                }
            }
        }

        public string TemaSelected
        {
            get
            {
                return _TemaSelected;
            }
            set
            {
                if (value != null)
                {
                    _TemaSelected = value;
                    RaisePropertyChanged("TemaSelected");
                }
            }
        }

        #endregion

        #region ICOMMAND

        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }
        public async void SaveCommandExecute()
        {
            try
            {
                var auxPlaneacion = FicNavigationContextC[1] as eva_planeacion;
                var auxTema = FicNavigationContextC[0] as eva_planeacion_temas;
                var auxCompetencia = FicNavigationContextC[2] as eva_planeacion_temas_competencias;

                Int16 _IdAsignatura = auxPlaneacion.IdAsignatura;
                int _IdPlaneacion = auxPlaneacion.IdPlaneacion;
                int _IdCompetencia = auxCompetencia.IdCompetencia;
                Int16 _IdTema = auxTema.IdTema;
                int _IdActividad = int.Parse(_Actividad.Split('-')[0]);
                var RespuestaInsert = await IFicSrvEnseñanzaInsert.FicMetAddEnseñanza(new eva_planeacion_enseñanza()
                {
                    IdAsignatura = _IdAsignatura,
                    IdPlaneacion = _IdPlaneacion,
                    IdCompetencia = _IdCompetencia,
                    IdTema = _IdTema,
                    IdActividadEnseñanza = _IdActividad,
                    FechaProgramada = _FechaIni,
                    FechaRealizada = _FechaFin,
                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = FicGlobalValues.USUARIO,
                    UsuarioMod = FicGlobalValues.USUARIO,
                    Activo = "S",
                    Borrado = "N"
                    /*eva_cat_asignaturas = new eva_cat_asignaturas(),
                    eva_planeacion = new eva_planeacion(),
                    eva_planeacion_temas = new eva_planeacion_temas(),
                    eva_cat_actividades_enseñanza = new eva_cat_actividades_enseñanza(),
                    eva_cat_competencias = new eva_cat_competencias()*/
                });
                if (RespuestaInsert == "OK")
                {
                    await new Page().DisplayAlert("ADD", "Insertado con éxito", "OK");
                    FicGlobalValues.NEXTIDPLANEACION++;
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmEnseñanzaList>(FicNavigationContextC);
                }
                else
                {
                    await new Page().DisplayAlert("ADD", RespuestaInsert.ToString(), "OK");
                }//SE INSERTO EL CONTEO?
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }//MANEJO GLOBAL DE ERRORES
        }

        public ICommand FicMetRegresarPlaneacionICommand
        {
            get
            {
                return _FicMetRegresarPlaneacionICommand = _FicMetRegresarPlaneacionICommand ?? new FicVmDelegateCommand(FicMetRegresarPlaneacion);
            }
        }

        private async void FicMetRegresarPlaneacion()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmEnseñanzaList>(FicNavigationContextC);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        #endregion

        public async void OnAppearing()
        {
            _Asignaturas = FicGlobalValues.ASIGNATURA;
            var auxPlaneacion = FicNavigationContextC[1] as eva_planeacion;
            _Planeacion = auxPlaneacion.ReferenciaNorma;
            var auxTema = FicNavigationContextC[0] as eva_planeacion_temas;
            _Temas = auxTema.DesTema;
            var auxCompetencia = FicNavigationContextC[2] as eva_planeacion_temas_competencias;
            _Competencias = auxCompetencia.Observaciones;
            _Actividades = new List<string>();
            IEnumerable<eva_cat_actividades_enseñanza> auxLista = IFicSrvEnseñanzaInsert.FicMetGetActividades().Result;
            foreach(eva_cat_actividades_enseñanza actividad in auxLista)
            {
                _Actividades.Add(actividad.IdActividadEnseñanza + "-" + actividad.DesActividadEnseñanza);
            }


            RaisePropertyChanged("Asignaturas");
            RaisePropertyChanged("Planeacion");
            RaisePropertyChanged("Temas");
            RaisePropertyChanged("Competencias");
            RaisePropertyChanged("Actividades");
        }

        #region  INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
