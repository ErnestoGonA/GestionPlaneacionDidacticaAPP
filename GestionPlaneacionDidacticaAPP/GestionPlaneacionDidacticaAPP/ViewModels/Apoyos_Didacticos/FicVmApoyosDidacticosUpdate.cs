using System;
using System.Collections.Generic;
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
    public class FicVmApoyosDidacticosUpdate: INotifyPropertyChanged
    {
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private ISrvApoyosDidacticos ISrvApoyosDidacticos;

        private string _LabelDesApoyoDidactico, _LabelUsuarioReg;
        private short _LabelId;

        private ICommand _FicMetRegesarApoyosDidacticosListICommand, _SaveCommand;

        //Valor mandado de view padre a hija
        public object NavigationContextC { get; set; }

        public FicVmApoyosDidacticosUpdate(IFicSrvNavigationInventario IFicSrvNavigationInventario, ISrvApoyosDidacticos ISrvApoyosDidacticos)
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

        public short LabelId
        {
            get { return _LabelId; }
            set
            {
                if (value != null)
                {
                    _LabelId = value;
                    RaisePropertyChanged("LabelId");
                }
            }
        }

        public string LabelUsuarioReg
        {
            get { return _LabelUsuarioReg; }
            set
            {
                if (value != null)
                {
                    _LabelUsuarioReg = value;
                    RaisePropertyChanged("LabelUsuarioReg");
                }
            }
        }

        public async void OnAppearing()
        {
            var source_eva_cat_apoyos_didacticos = NavigationContextC as eva_cat_apoyos_didacticos;

            _LabelId = source_eva_cat_apoyos_didacticos.IdApoyoDidactico;
            _LabelDesApoyoDidactico = source_eva_cat_apoyos_didacticos.DesApoyoDidactico;
            _LabelUsuarioReg = source_eva_cat_apoyos_didacticos.UsuarioReg;

            RaisePropertyChanged("LabelId");
            RaisePropertyChanged("LabelDesApoyoDidactico");
            RaisePropertyChanged("LabelUsuarioReg");
        }

        public ICommand FicMetRegesarApoyosDidacticosListICommand
        {
            get
            {
                return _FicMetRegesarApoyosDidacticosListICommand = _FicMetRegesarApoyosDidacticosListICommand ?? new FicVmDelegateCommand(MetRegesarApoyosDidacticosList);
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
            var source_eva_cat_apoyos_didacticos = NavigationContextC as eva_cat_apoyos_didacticos;
            try
            {
                var res = await ISrvApoyosDidacticos.UpdateApoyoDidactico(new eva_cat_apoyos_didacticos()
                {
                    //IdAsignatura = 1,
                    //IdPlaneacion = 1,

                    IdApoyoDidactico = source_eva_cat_apoyos_didacticos.IdApoyoDidactico,
                    DesApoyoDidactico = LabelDesApoyoDidactico,
                    FechaReg = source_eva_cat_apoyos_didacticos.FechaReg,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = source_eva_cat_apoyos_didacticos.UsuarioReg,
                    UsuarioMod = source_eva_cat_apoyos_didacticos.UsuarioMod,
                    Activo = "S",
                    Borrado = "N"
                });

                if (res == "Ok")
                {
                    await new Page().DisplayAlert("UPDATE", "¡ACTUALIZADO CORREACTAMENTE!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<VmApoyosDidacticosList>(NavigationContextC);
                }
                else
                {
                    await new Page().DisplayAlert("UPDATE", res.ToString(), "OK");
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
