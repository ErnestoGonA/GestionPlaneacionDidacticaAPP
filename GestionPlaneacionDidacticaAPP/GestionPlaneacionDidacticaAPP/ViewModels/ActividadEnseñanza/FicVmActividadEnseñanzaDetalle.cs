using GestionPlaneacionDidacticaAPP.Interfaces.ActividadEnseñanza;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.ActividadEnseñanza
{
    public class FicVmActividadEnseñanzaDetalle : INotifyPropertyChanged
    {
        public string _DesActividadEnseñanza,_FechaReg,_UsuarioReg,_FechaUltMod,_UsuarioMod,_Activo,_Borrado;

        private ICommand _FicMetRegresarPlaneacionICommand;

        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvActividadEnseñanza IFicSrvActividadEnseñanza;

        public object FicNavigationContextC { get; set; }

        public FicVmActividadEnseñanzaDetalle(IFicSrvNavigationInventario ficSrvNavigationInventario,
            IFicSrvActividadEnseñanza IFicSrvActividadEnseñanza)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            this.IFicSrvActividadEnseñanza = IFicSrvActividadEnseñanza;

        }


        public string DesActividadEnseñanza
        {
            get
            {
                return _DesActividadEnseñanza;
            }
            set
            {
                if (value != null)
                {
                    _DesActividadEnseñanza = value;
                    RaisePropertyChanged("DesActividadEnseñanza");
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
                if(value != null)
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
                if(value != null)
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
                if(value != null)
                {
                    _FechaUltMod = value;
                    RaisePropertyChanged("FechaUltMod");
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
                if(value != null)
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
                if(value != null)
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
                if(value != null)
                {
                    _Borrado = value;
                    RaisePropertyChanged("Borrado");
                }
            }
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
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmActividadEnseñanza>(FicNavigationContextC);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }



        public async void OnAppearing()
        {
            var source_eva_cat_actividades_enseñanza = FicNavigationContextC as eva_cat_actividades_enseñanza;
            _DesActividadEnseñanza = source_eva_cat_actividades_enseñanza.DesActividadEnseñanza;
            _FechaReg = source_eva_cat_actividades_enseñanza.FechaReg.ToString(); ;
            _UsuarioReg = source_eva_cat_actividades_enseñanza.UsuarioReg;
            _FechaUltMod = source_eva_cat_actividades_enseñanza.FechaUltMod.ToString();
            _UsuarioMod = source_eva_cat_actividades_enseñanza.UsuarioMod;
            _Activo = source_eva_cat_actividades_enseñanza.Activo;
            _Borrado = source_eva_cat_actividades_enseñanza.Borrado;
            
            RaisePropertyChanged("DesActividadesEnseñanza");
            RaisePropertyChanged("FechaReg");
            RaisePropertyChanged("UsuarioReg");
            RaisePropertyChanged("FechaUltMod");
            RaisePropertyChanged("UsuarioMod");
            RaisePropertyChanged("Activo");
            RaisePropertyChanged("Borrado");
        }//Sobrecarga el metodo OnAppearing() de la view


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyname = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        #endregion
    }
}
