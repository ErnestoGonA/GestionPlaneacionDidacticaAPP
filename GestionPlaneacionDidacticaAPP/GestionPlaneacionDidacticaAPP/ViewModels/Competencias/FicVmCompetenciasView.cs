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
using GestionPlaneacionDidacticaAPP.Interfaces.Competencias;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.Services.Competencias;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Competencias
{
    public class FicVmCompetenciasView : INotifyPropertyChanged
    {
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;

        private string _LabelObservaciones, _LabelFechaReg, _LabelFechaMod, _LabelUsuarioReg, _LabelUsuarioMod, _LabelActivo, _LabelBorrado;
        private int _LabelCompetencia;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelAsignatura;
        private string _LabelTema;

        private ICommand _FicMetRegesarCompetenciasListICommand;

        public object[] FicNavigationContextC { get; set; }

        public FicVmCompetenciasView(IFicSrvNavigationInventario IFicSrvNavigationInventario)
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
                    RaisePropertyChanged("LabelAsignatura");
                }
            }
        }

        public int LabelCompetencia
        {
            get { return _LabelCompetencia; }
            set
            {
                if (value != null)
                {
                    _LabelCompetencia = value;
                    RaisePropertyChanged("LabelCompetencia");
                }
            }
        }

        public string LabelTema
        {
            get { return _LabelTema; }
            set
            {
                if (value != null)
                {
                    _LabelTema = value;
                    RaisePropertyChanged("LabelTema");
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
            var source_eva_planeacion_temas_competencias = FicNavigationContextC[0] as eva_planeacion_temas_competencias;
            var source_eva_planeacion_temas = FicNavigationContextC[1] as eva_planeacion_temas;

            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion_temas_competencias.IdPlaneacion;
            _LabelTema = source_eva_planeacion_temas.DesTema;
            _LabelCompetencia = source_eva_planeacion_temas_competencias.IdCompetencia;

            _LabelObservaciones = source_eva_planeacion_temas_competencias.Observaciones;

            _LabelFechaReg = source_eva_planeacion_temas_competencias.FechaReg.ToString();
            _LabelFechaMod = source_eva_planeacion_temas_competencias.FechaUltMod.ToString();
            _LabelUsuarioReg = source_eva_planeacion_temas_competencias.UsuarioReg;
            _LabelUsuarioMod = source_eva_planeacion_temas_competencias.UsuarioMod;
            _LabelActivo = source_eva_planeacion_temas_competencias.Activo;
            _LabelBorrado = source_eva_planeacion_temas_competencias.Borrado;

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelTema");
            RaisePropertyChanged("LabelCompetencia");
            RaisePropertyChanged("LabelObservaciones");

            RaisePropertyChanged("LabelFechaReg");
            RaisePropertyChanged("LabelFechaMod");
            RaisePropertyChanged("LabelUsuarioReg");
            RaisePropertyChanged("LabelUsuarioMod");
            RaisePropertyChanged("LabelActivo");
            RaisePropertyChanged("LabelBorrado");

        }


        public ICommand FicMetRegesarCompetenciasListICommand
        {
            get
            {
                return _FicMetRegesarCompetenciasListICommand = _FicMetRegesarCompetenciasListICommand ??
                    new FicVmDelegateCommand(FicMetRegresarCompetencias);
            }
        }

        private async void FicMetRegresarCompetencias()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasList>(new object[] { FicNavigationContextC[1], FicNavigationContextC[2] });
                
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
