using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Subtemas
{
    public class FicVmSubtemaView : INotifyPropertyChanged
    {
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;

        private string _LabelDesSubtema, _LabelFechaReg, _LabelFechaMod, _LabelUsuarioReg, _LabelUsuarioMod, _LabelActivo, _LabelBorrado;
        private short _LabelIdSubtema;

        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelAsignatura;
        private short _LabelIdTema;

        private ICommand _FicMetRegesarCatEdificiosListICommand;

        public object[] FicNavigationContextC { get; set; }

        public FicVmSubtemaView(IFicSrvNavigationInventario IFicSrvNavigationInventario)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
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

        public short LabelIdTema
        {
            get { return _LabelIdTema; }
            set
            {
                if (value != null)
                {
                    _LabelIdTema = value;
                    RaisePropertyChanged("LabelIdTema");
                }
            }
        }

        public string LabelDesSubtema
        {
            get { return _LabelDesSubtema; }
            set
            {
                if (value != null)
                {
                    _LabelDesSubtema = value;
                    RaisePropertyChanged("LabelDesSubtema");
                }
            }
        }

        public short LabelIdSubtema
        {
            get { return _LabelIdSubtema; }
            set
            {
                if (value != null)
                {
                    _LabelIdSubtema = value;
                    RaisePropertyChanged("LabelIdSubtema");
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
            var source_eva_planeacion_temas = FicNavigationContextC[0] as eva_planeacion_subtemas;
            var source_eva_planeacion = FicNavigationContextC[1] as eva_planeacion_temas;

            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;
            _LabelIdTema = source_eva_planeacion_temas.IdTema;

            _LabelIdSubtema = source_eva_planeacion_temas.IdSubtema;
            _LabelDesSubtema = source_eva_planeacion_temas.DesSubtema;

            _LabelFechaReg = source_eva_planeacion_temas.FechaReg.ToString();
            _LabelFechaMod = source_eva_planeacion_temas.FechaUltMod.ToString();
            _LabelUsuarioReg = source_eva_planeacion_temas.UsuarioReg;
            _LabelUsuarioMod = source_eva_planeacion_temas.UsuarioMod;
            _LabelActivo = source_eva_planeacion_temas.Activo;
            _LabelBorrado = source_eva_planeacion_temas.Borrado;

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdTema");
            RaisePropertyChanged("LabelDesSubtema");
            RaisePropertyChanged("LabelIdSubtema");

            RaisePropertyChanged("LabelFechaReg");
            RaisePropertyChanged("LabelFechaMod");
            RaisePropertyChanged("LabelUsuarioReg");
            RaisePropertyChanged("LabelUsuarioMod");
            RaisePropertyChanged("LabelActivo");
            RaisePropertyChanged("LabelBorrado");

        }
        

        public ICommand FicMetRegesarCatEdificiosListICommand
        {
            get
            {
                return _FicMetRegesarCatEdificiosListICommand = _FicMetRegesarCatEdificiosListICommand ??
                    new FicVmDelegateCommand(FicMetRegresarCatEdificios);
            }
        }

        private async void FicMetRegresarCatEdificios()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmSubtemaList>(FicNavigationContextC[1]);
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
