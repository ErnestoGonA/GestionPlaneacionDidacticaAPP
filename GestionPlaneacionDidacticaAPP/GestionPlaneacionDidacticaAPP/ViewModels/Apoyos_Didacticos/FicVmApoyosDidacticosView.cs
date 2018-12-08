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
using GestionPlaneacionDidacticaAPP.Data;


namespace GestionPlaneacionDidacticaAPP.ViewModels.Apoyos_Didacticos
{
    public class FicVmApoyosDidacticosView : INotifyPropertyChanged
    {
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private ISrvApoyosDidacticos ISrvApoyosDidacticos;

        private string _LabelDesApoyoDidactico, _LabelFechaReg, _LabelFechaMod, _LabelUsuarioReg, _LabelUsuarioMod, _LabelActivo, _LabelBorrado;
        private short _LabelIdApoyoDidactico;

        private ICommand _FicMetRegesarApoyosDidacticosListICommand, _SaveCommand;

        //Valor mandado de view padre a hija
        public object FicNavigationContextC { get; set; }

        public FicVmApoyosDidacticosView(IFicSrvNavigationInventario IFicSrvNavigationInventario, ISrvApoyosDidacticos ISrvApoyosDidacticos)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
            this.ISrvApoyosDidacticos = ISrvApoyosDidacticos;
        }

        public short LabelIdApoyoDidactico
        {
            get { return _LabelIdApoyoDidactico; }
            set
            {
                if (value != null)
                {
                    _LabelIdApoyoDidactico = value;
                    RaisePropertyChanged("LabelIdTema");
                }
            }
        }

        public string LabelDesApoyoDidactico
        {
            get { return _LabelDesApoyoDidactico; }
            set
            {
                if (value != null)
                {
                    _LabelDesApoyoDidactico = value;
                    RaisePropertyChanged("LabelDesTema");
                }
            }
        }

        public string LabelFechaReg
        {
            get { return _LabelFechaReg; }
            set
            {
                if (value != null)
                {
                    _LabelFechaReg = value;
                    RaisePropertyChanged("LabelFechaReg");
                }
            }
        }

        public string LabelFechaMod
        {
            get { return _LabelFechaMod; }
            set
            {
                if (value != null)
                {
                    _LabelFechaMod = value;
                    RaisePropertyChanged("LabelFechaMod");
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

        public string LabelUsuarioMod
        {
            get { return _LabelUsuarioMod; }
            set
            {
                if (value != null)
                {
                    _LabelUsuarioMod = value;
                    RaisePropertyChanged("LabelUsuarioMod");
                }
            }
        }

        public string LabelActivo
        {
            get { return _LabelActivo; }
            set
            {
                if (value != null)
                {
                    _LabelActivo = value;
                    RaisePropertyChanged("LabelActivo");
                }
            }
        }

        public string LabelBorrado
        {
            get { return _LabelBorrado; }
            set
            {
                if (value != null)
                {
                    _LabelBorrado = value;
                    RaisePropertyChanged("LabelBorrado");
                }
            }
        }

        public async void OnAppearing()
        {
            var source_eva_cat_apoyos_didacticos = FicNavigationContextC as eva_cat_apoyos_didacticos;


            _LabelIdApoyoDidactico = source_eva_cat_apoyos_didacticos.IdApoyoDidactico;
            _LabelDesApoyoDidactico = source_eva_cat_apoyos_didacticos.DesApoyoDidactico;

            _LabelFechaReg = source_eva_cat_apoyos_didacticos.FechaReg.ToString();
            _LabelFechaMod = source_eva_cat_apoyos_didacticos.FechaUltMod.ToString();
            _LabelUsuarioReg = source_eva_cat_apoyos_didacticos.UsuarioReg;
            _LabelUsuarioMod = source_eva_cat_apoyos_didacticos.UsuarioMod;
            _LabelActivo = source_eva_cat_apoyos_didacticos.Activo;
            _LabelBorrado = source_eva_cat_apoyos_didacticos.Borrado;

            RaisePropertyChanged("LabelIdApoyoDidactico");
            RaisePropertyChanged("LabelDesApoyoDidactico");

            RaisePropertyChanged("LabelFechaReg");
            RaisePropertyChanged("LabelFechaMod");
            RaisePropertyChanged("LabelUsuarioReg");
            RaisePropertyChanged("LabelUsuarioMod");
            RaisePropertyChanged("LabelActivo");
            RaisePropertyChanged("LabelBorrado");

        }

        public ICommand FicMetRegesarApoyosDidacticosListICommand
        {
            get
            {
                return _FicMetRegesarApoyosDidacticosListICommand = _FicMetRegesarApoyosDidacticosListICommand ??
                    new FicVmDelegateCommand(FicMetRegresarApoyosDidacticos);
            }
        }

        private async void FicMetRegresarApoyosDidacticos()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<VmApoyosDidacticosList>(FicNavigationContextC);
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
