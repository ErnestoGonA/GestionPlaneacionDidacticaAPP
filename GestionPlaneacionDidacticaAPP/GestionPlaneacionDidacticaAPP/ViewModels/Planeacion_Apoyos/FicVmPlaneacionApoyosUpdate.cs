using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.Services.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Planeacion_Apoyos
{
    public class FicVmPlaneacionApoyosUpdate : INotifyPropertyChanged
    {
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private FicISrvPlaneacion IFicSrvPlaneacion;
        private IFicSrvPlaneacionApoyos IFicSrvPlaneacionApoyos;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelAsignatura;
        private Int16 _LabelIdApoyoDidactico;
        private string _LabelObservaciones;

        private ICommand _FicMetRegesarPlaneacionApoyosListICommand, _SaveCommand;

        public object[] FicNavigationContextC { get; set; }

        public FicVmPlaneacionApoyosUpdate(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvPlaneacionApoyos iFicSrvPlaneacionApoyos, FicISrvPlaneacion iFicSrvPlaneacion)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvPlaneacionApoyos = iFicSrvPlaneacionApoyos;
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
                    RaisePropertyChanged("LabelAsignatura");
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

        public async void OnAppearing()
        {
            var source_eva_planeacion_temas = FicNavigationContextC[0] as eva_planeacion_apoyos;
            eva_planeacion source_eva_planeacion = FicNavigationContextC[1] as eva_planeacion;

            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;

            _LabelIdApoyoDidactico = source_eva_planeacion_temas.IdApoyoDidactico;

            _LabelObservaciones = source_eva_planeacion_temas.Observaciones;

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdApoyoDidactico");
            RaisePropertyChanged("LabelObservaciones");

        }

        public ICommand FicMetRegesarPlaneacionApoyosListICommand
        {
            get
            {
                return _FicMetRegesarPlaneacionApoyosListICommand = _FicMetRegesarPlaneacionApoyosListICommand ??
                    new FicVmDelegateCommand(FicMetRegresarCompetencias);
            }
        }

        private async void FicMetRegresarCompetencias()
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

        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        private async void SaveCommandExecute()
        {
            var source_eva_planecion_temas = FicNavigationContextC[0] as eva_planeacion_apoyos;
            var source_eva_planecion = FicNavigationContextC[1] as eva_planeacion;
            try
            {
                var RespuestaInsert = await IFicSrvPlaneacionApoyos.UpdatePlaneacionApoyos(new eva_planeacion_apoyos()
                {
                    IdAsignatura = source_eva_planecion_temas.IdAsignatura,
                    IdPlaneacion = source_eva_planecion.IdPlaneacion,
                    IdApoyoDidactico = LabelIdApoyoDidactico,

                    Observaciones = LabelObservaciones,

                    FechaReg = source_eva_planecion_temas.FechaReg,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = source_eva_planecion_temas.UsuarioReg,
                    UsuarioMod = LabelUsuario,
                    Activo = "S",
                    Borrado = "N"
                });

                if (RespuestaInsert == "OK")
                {
                    await new Page().DisplayAlert("ADD", "¡EDITADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacionApoyosList>(FicNavigationContextC[1]);
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
