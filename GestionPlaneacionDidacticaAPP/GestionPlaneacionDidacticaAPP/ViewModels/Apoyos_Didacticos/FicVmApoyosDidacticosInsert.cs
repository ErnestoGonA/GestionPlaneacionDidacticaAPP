using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.Services.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Apoyos_Didacticos
{
    public class FicVmApoyosDidacticosInsert: INotifyPropertyChanged
    {
        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private ISrvApoyosDidacticos ISrvApoyosDidacticos;

        private string _LabelDesApoyoDidactico;

        //Botones
        private ICommand _MetRegesarApoyosDidacticosListICommand, _SaveCommand;

        //Valor mandado de view padre a hija
        public object[] NavigationContextC { get; set; }

        public FicVmApoyosDidacticosInsert(IFicSrvNavigationInventario IFicSrvNavigationInventario, ISrvApoyosDidacticos ISrvApoyosDidacticos)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
            this.ISrvApoyosDidacticos = ISrvApoyosDidacticos;
        }

        public string LabelDesApoyoDidactico
        {
            get { return _LabelDesApoyoDidactico; }
            set
            {
                if (value != null)
                {
                    _LabelDesApoyoDidactico = value;
                    RaisePropertyChanged("LabelDesApoyoDidactico");
                }
            }
        }

        public ICommand MetRegesarApoyosDidacticosListICommand
        {
            get
            {
                return _MetRegesarApoyosDidacticosListICommand = _MetRegesarApoyosDidacticosListICommand ?? new FicVmDelegateCommand(MetRegesarApoyosDidacticosList);
            }
        }

        private async void MetRegesarApoyosDidacticosList()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<VmApoyosDidacticosList>(NavigationContextC);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "Ok");
            }
        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        private async void SaveCommandExecute()
        {
            try
            {
                var res = await ISrvApoyosDidacticos.InsertApoyoDidactico(new eva_cat_apoyos_didacticos()
                {
                    //IdAsignatura = 1,
                    //IdPlaneacion = 1,

                    DesApoyoDidactico = LabelDesApoyoDidactico,
                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = "Reyes",
                    UsuarioMod = "Reyes",
                    Activo = "S",
                    Borrado = "N"
                });

                if (res == "Ok")
                {
                    await new Page().DisplayAlert("INSERT", "¡INSERTADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<VmApoyosDidacticosList>(NavigationContextC);
                }
                else
                {
                    await new Page().DisplayAlert("INSERT", res.ToString(), "OK");
                }

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
