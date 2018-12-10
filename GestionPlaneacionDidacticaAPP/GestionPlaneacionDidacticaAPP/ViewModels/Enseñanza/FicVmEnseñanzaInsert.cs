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

        public List<string> _Asignaturas, _Planeacion, _Competencias, _Temas;
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
            _Asignaturas = GetAsignaturas().Result;
            _Planeacion = GetPlaneacion().Result;
            _Competencias = GetCompetencia().Result;
            _Temas = GetTema().Result;
            RaisePropertyChanged("Asignaturas");
            RaisePropertyChanged("Planeacion");
            RaisePropertyChanged("Competencias");
            RaisePropertyChanged("Temas");
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

        public List<string> Asignaturas
        {
            get { return _Asignaturas; }
            set
            {
                _Asignaturas = value;
                RaisePropertyChanged("Asignaturas");
            }
        }
        public List<string> Planeacion
        {
            get { return _Planeacion; }
            set
            {
                _Planeacion = value;
                RaisePropertyChanged("Planeacion");
            }
        }
        public List<string> Competencias
        {
            get { return _Competencias; }
            set
            {
                _Competencias = value;
                RaisePropertyChanged("Competencias");
            }
        }
        public List<string> Temas
        {
            get { return _Temas; }
            set
            {
                _Temas = value;
                RaisePropertyChanged("Temas");
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
                Int16 _IdAsignatura = Int16.Parse(_AsignaturaSelected.Split('-')[0]);
                int _IdPlaneacion = int.Parse(_PlaneacionSelected.Split('-')[0]);
                int _IdCompetencia = int.Parse(_CompetenciaSelected.Split('-')[0]);
                Int16 _IdTema = Int16.Parse(_TemaSelected.Split('-')[0]);
                var RespuestaInsert = await IFicSrvEnseñanzaInsert.FicMetAddEnseñanza(new eva_planeacion_enseñanza()
                {
                    //IdActividadEnseñanza = 1,
                    IdAsignatura = _IdAsignatura,
                    IdPlaneacion = _IdPlaneacion,
                    IdCompetencia = _IdCompetencia,
                    IdTema = _IdTema,
                    FechaProgramada = _FechaIni,
                    FechaRealizada = _FechaFin,
                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = FicGlobalValues.USUARIO,
                    UsuarioMod = FicGlobalValues.USUARIO,
                    Activo = "S",
                    Borrado = "N"
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
