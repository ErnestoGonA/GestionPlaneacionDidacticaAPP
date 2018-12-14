using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;

using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.Services.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Planeacion_Apoyos
{
    public class FicVmPlaneacionApoyosView : INotifyPropertyChanged
    {
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private FicISrvPlaneacion IFicSrvPlaneacion;

        private string _LabelObservaciones, _LabelFechaReg, _LabelFechaMod, _LabelUsuarioReg, _LabelUsuarioMod, _LabelActivo, _LabelBorrado;
        private short _LabelIdApoyoDidactico;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelAsignatura;


        private ICommand _FicMetRegesarPlaneacionApoyosListICommand;

        public object[] FicNavigationContextC { get; set; }

        public FicVmPlaneacionApoyosView(IFicSrvNavigationInventario IFicSrvNavigationInventario, FicISrvPlaneacion iFicSrvPlaneacion)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
            IFicSrvPlaneacion = iFicSrvPlaneacion;

        }

        public string LabelUsuario
        {
            get { return _LabelUsuario; }
            set
            {
                if (value != null)
                {
                    _LabelUsuario = value;
                    RaisePropertyChanged("LabelUsuario");
                }
            }
        }

        public int LabelIdPlaneacion
        {
            get { return _LabelIdPlaneacion; }
            set
            {
                if (value != null)
                {
                    _LabelIdPlaneacion = value;
                    RaisePropertyChanged("LabelIdPlaneacion");
                }
            }
        }

        public string LabelAsignatura
        {
            get { return _LabelAsignatura; }
            set
            {
                if (value != null)
                {
                    _LabelAsignatura = value;
                    RaisePropertyChanged("LabelIdAsignatura");
                }
            }
        }

        public short LabelIdApoyoDidactico
        {
            get { return _LabelIdApoyoDidactico; }
            set
            {
                if (value != null)
                {
                    _LabelIdApoyoDidactico = value;
                    RaisePropertyChanged("LabelIdApoyoDidactico");
                }
            }
        }

        public string LabelObservaciones
        {
            get { return _LabelObservaciones; }
            set
            {
                if (value != null)
                {
                    _LabelObservaciones = value;
                    RaisePropertyChanged("LabelObservaciones");
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
            var source_eva_planeacion_apoyos = FicNavigationContextC[0] as eva_planeacion_apoyos;
            var source_eva_planeacion = FicNavigationContextC[1] as eva_planeacion;

            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;


            _LabelIdApoyoDidactico = source_eva_planeacion_apoyos.IdApoyoDidactico;
            _LabelObservaciones = source_eva_planeacion_apoyos.Observaciones;

            _LabelFechaReg = source_eva_planeacion_apoyos.FechaReg.ToString();
            _LabelFechaMod = source_eva_planeacion_apoyos.FechaUltMod.ToString();
            _LabelUsuarioReg = source_eva_planeacion_apoyos.UsuarioReg;
            _LabelUsuarioMod = source_eva_planeacion_apoyos.UsuarioMod;
            _LabelActivo = source_eva_planeacion_apoyos.Activo;
            _LabelBorrado = source_eva_planeacion_apoyos.Borrado;

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdApoyoDidactico");
            RaisePropertyChanged("LabelObservaciones");

            RaisePropertyChanged("LabelFechaReg");
            RaisePropertyChanged("LabelFechaMod");
            RaisePropertyChanged("LabelUsuarioReg");
            RaisePropertyChanged("LabelUsuarioMod");
            RaisePropertyChanged("LabelActivo");
            RaisePropertyChanged("LabelBorrado");

        }

        public ICommand FicMetRegesarPlaneacionApoyosListICommand
        {
            get
            {
                return _FicMetRegesarPlaneacionApoyosListICommand = _FicMetRegesarPlaneacionApoyosListICommand ??
                    new FicVmDelegateCommand(FicMetRegresarPlaneacionApoyos);
            }
        }

        private async void FicMetRegresarPlaneacionApoyos()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacionApoyosList>(FicNavigationContextC[1]);
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
