using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Enseñanza
{
    public class FicVmEnseñanzaDetalle : INotifyPropertyChanged
    {
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvEnseñanzaDetalle IFicSrvEnseñanzaDetalle;

        private string _FechaIni, _FechaFin,_PlaneacionNorma,_CompetenciaNombre,_TemaNombre;
        private string _FechaReg, _UsuarioReg, _FechaUltMod, _UsuarioMod, _Activo, _Borrado, _ClaveAsignatura, _DesAsignatura, _NombreCorto;
        private ICommand _FicMetRegresarPlaneacionICommand;
        public object FicNavigationContextC { get; set; }

        public FicVmEnseñanzaDetalle(IFicSrvNavigationInventario IFicSrvNavigationInventario,
            IFicSrvEnseñanzaDetalle IFicSrvEnseñanzaDetalle)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
            this.IFicSrvEnseñanzaDetalle = IFicSrvEnseñanzaDetalle;
        }

        #region ENLAZAR VARIABLES
        public string TemaNombre
        {
            get
            {
                return _TemaNombre;
            }
            set
            {
                if (value != null)
                {
                    _TemaNombre = value;
                    RaisePropertyChanged("TemaNombre");
                }
            }
        }
        public string CompetenciaNombre
        {
            get
            {
                return _CompetenciaNombre;
            }
            set
            {
                if (value != null)
                {
                    _CompetenciaNombre = value;
                    RaisePropertyChanged("CompetenciaNombre");
                }
            }
        }
        public string PlaneacionNorma
        {
            get
            {
                return _PlaneacionNorma;
            }
            set
            {
                if (value != null)
                {
                    _PlaneacionNorma = value;
                    RaisePropertyChanged("PlaneacionNorma");
                }
            }
        }
        public string FechaFin
        {
            get
            {
                return _FechaFin;
            }
            set
            {
                if (value != null)
                {
                    _FechaFin = value;
                    RaisePropertyChanged("FechaFin");
                }
            }
        }
        public string FechaIni
        {
            get
            {
                return _FechaIni;
            }
            set
            {
                if (value != null)
                {
                    _FechaIni = value;
                    RaisePropertyChanged("FechaIni");
                }
            }
        }
        public string FechaReg
        {
            get
            {
                return _FechaReg;
            }
            set
            {
                if (value != null)
                {
                    _FechaReg = value;
                    RaisePropertyChanged("FechaReg");
                }
            }
        }
        public string UsuarioReg
        {
            get
            {
                return _UsuarioReg;
            }
            set
            {
                if (value != null)
                {
                    _UsuarioReg = value;
                    RaisePropertyChanged("UsuarioReg");
                }
            }
        }
        public string FechaUltMod
        {
            get
            {
                return _FechaUltMod;
            }
            set
            {
                if (value != null)
                {
                    _FechaUltMod = value;
                    RaisePropertyChanged("FechUltMod");
                }
            }
        }
        public string UsuarioMod
        {
            get
            {
                return _UsuarioMod;
            }
            set
            {
                if (value != null)
                {
                    _UsuarioMod = value;
                    RaisePropertyChanged("UsuarioMod");
                }
            }
        }
        public string Activo
        {
            get
            {
                return _Activo;
            }
            set
            {
                if (value != null)
                {
                    _Activo = value;
                    RaisePropertyChanged("Activo");
                }
            }
        }
        public string Borrado
        {
            get
            {
                return _Borrado;
            }
            set
            {
                if (value != null)
                {
                    _Borrado = value;
                    RaisePropertyChanged("Borrado");
                }
            }
        }
        public string ClaveAsignatura
        {
            get
            {
                return _ClaveAsignatura;
            }
            set
            {
                if (value != null)
                {
                    _ClaveAsignatura = value;
                    RaisePropertyChanged("ClaveAsignatura");
                }
            }
        }
        public string DesAsignatura
        {
            get
            {
                return _DesAsignatura;
            }
            set
            {
                if (value != null)
                {
                    _DesAsignatura = value;
                    RaisePropertyChanged("DesAignatura");
                }
            }
        }
        public string NombreCorto
        {
            get
            {
                return _NombreCorto;
            }
            set
            {
                if (value != null)
                {
                    _NombreCorto = value;
                    RaisePropertyChanged("NombreCorto");
                }
            }
        }
        #endregion

        public async void OnAppearing()
        {
            var enseñanzaItem = FicNavigationContextC as EnseñanzaLista;
            eva_planeacion_enseñanza source_eva_enseñanza = enseñanzaItem.eva_planeacion_enseñanza;

            eva_cat_asignaturas asignatura = this.IFicSrvEnseñanzaDetalle.FicMetGetAsignatura(source_eva_enseñanza.IdAsignatura).Result;
            eva_planeacion planeacion = this.IFicSrvEnseñanzaDetalle.FicMetGetPlaneacion(source_eva_enseñanza.IdPlaneacion).Result;
            eva_cat_competencias competencia = this.IFicSrvEnseñanzaDetalle.FicMetGetCompetencia(source_eva_enseñanza.IdCompetencia).Result;
            eva_planeacion_temas tema = this.IFicSrvEnseñanzaDetalle.FicMetGetTema(source_eva_enseñanza.IdTema).Result;

            _DesAsignatura = asignatura.DesAsignatura;
            _PlaneacionNorma = planeacion.ReferenciaNorma;
            _CompetenciaNombre = competencia.DesCompetencia;
            _TemaNombre = tema.DesTema;
            _FechaIni = source_eva_enseñanza.FechaProgramada.ToString();
            _FechaFin = source_eva_enseñanza.FechaRealizada.ToString();
            _FechaReg = source_eva_enseñanza.FechaReg.ToString();
            _UsuarioReg = source_eva_enseñanza.UsuarioReg;
            _FechaUltMod = source_eva_enseñanza.FechaUltMod.ToString();
            _UsuarioMod = source_eva_enseñanza.UsuarioMod;
            _Activo = source_eva_enseñanza.Activo;
            _Borrado = source_eva_enseñanza.Borrado;

            RaisePropertyChanged("DesAsignatura");
            RaisePropertyChanged("PlaneacionNorma");
            RaisePropertyChanged("CompetenciaNombre");
            RaisePropertyChanged("TemaNombre");
            RaisePropertyChanged("FechaIni");
            RaisePropertyChanged("FechaFin");
            RaisePropertyChanged("FechaReg");
            RaisePropertyChanged("UsuarioReg");
            RaisePropertyChanged("FechaUltMod");
            RaisePropertyChanged("UsuarioMod");
            RaisePropertyChanged("Activo");
            RaisePropertyChanged("Borrado");

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
