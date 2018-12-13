using GestionPlaneacionDidacticaAPP.Data;
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
    public class FicVmActividadEnseñanzaInsert : INotifyPropertyChanged
    {
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvActividadEnseñanza IFicSrvActividadEnseñanza;

        public string _DesActividadEnseñanza;
        private ICommand _SaveCommand, _FicMetRegresarPlaneacionICommand;

        public object FicNavigationContextC { get; set; }

        public FicVmActividadEnseñanzaInsert(IFicSrvNavigationInventario IFicSrvNavigationInventario,
            IFicSrvActividadEnseñanza IFicSrvActividadEnseñanza)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
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
                if(value != null)
                {
                    _DesActividadEnseñanza = value;
                    RaisePropertyChanged("DesActividadEnseñanza");
                }
            }
        }


        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }
        public async void SaveCommandExecute()
        {
            try
            {
                var RespuestaInsert = await IFicSrvActividadEnseñanza.FicMetUpdateEnseñanza(new eva_cat_actividades_enseñanza()
                {
                    DesActividadEnseñanza = _DesActividadEnseñanza,
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
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmActividadEnseñanza>(FicNavigationContextC);
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
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmActividadEnseñanza>(FicNavigationContextC);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        public async void OnAppearing()
        {

        }

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
