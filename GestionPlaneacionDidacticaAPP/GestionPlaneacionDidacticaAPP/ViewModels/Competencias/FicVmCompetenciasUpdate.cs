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
    public class FicVmCompetenciasUpdate : INotifyPropertyChanged
    {
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvCompetencias IFicSrvCompetencias;

        private string _LabelObservaciones;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelAsignatura;
        private int _LabelIdCompetencia;
        private int _LabelIdTema;
        private short _LabelIdTemaCompetencia;

        private ICommand _FicMetRegesarCompetenciasListICommand, _SaveCommand;

        public object[] FicNavigationContextC { get; set; }

        public FicVmCompetenciasUpdate(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvCompetencias ficSrvCompetencias)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvCompetencias = ficSrvCompetencias;
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

        public int LabelIdTema
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

        public short LabelIdTemaCompetencia
        {
            get { return _LabelIdTemaCompetencia; }
            set
            {
                if (value != null)
                {
                    _LabelIdTemaCompetencia = value;
                    RaisePropertyChanged("LabelIdTemaCompetencia");
                }
            }
        }

        public int LabelIdCompetencia
        {
            get { return _LabelIdCompetencia; }
            set
            {
                if (value != null)
                {
                    _LabelIdCompetencia = value;
                    RaisePropertyChanged("LabelIdCompetencia");
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
            var source_eva_planeacion_temas_competencias = FicNavigationContextC[0] as eva_planeacion_temas_competencias;
            eva_planeacion_temas source_eva_planeacion_temas = FicNavigationContextC[1] as eva_planeacion_temas;

            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion_temas_competencias.IdPlaneacion;

            _LabelIdTema = source_eva_planeacion_temas_competencias.IdTema;
            _LabelIdCompetencia = source_eva_planeacion_temas_competencias.IdCompetencia;

            _LabelIdTemaCompetencia = source_eva_planeacion_temas_competencias.IdPlaneacionTemasCompetencias;
            _LabelObservaciones = source_eva_planeacion_temas_competencias.Observaciones;

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdTema");
            RaisePropertyChanged("LabelIdCompetencia");
            RaisePropertyChanged("LabelObservaciones");
            RaisePropertyChanged("LabelIdTemaCompetencia");

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
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasList>(FicNavigationContextC[1]);
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
            var source_eva_planecion_temas_competencias = FicNavigationContextC[0] as eva_planeacion_temas_competencias;
            var source_eva_planecion_temas = FicNavigationContextC[1] as eva_planeacion_temas;
            try
            {
                var RespuestaInsert = await IFicSrvCompetencias.UpdateCompetencia(new eva_planeacion_temas_competencias()
                {
                    IdAsignatura = source_eva_planecion_temas_competencias.IdAsignatura,
                    IdPlaneacion = source_eva_planecion_temas_competencias.IdPlaneacion,
                    IdTema = source_eva_planecion_temas_competencias.IdTema,
                    IdCompetencia = source_eva_planecion_temas_competencias.IdCompetencia,

                    IdPlaneacionTemasCompetencias = LabelIdTemaCompetencia,
                    Observaciones = LabelObservaciones,

                    FechaReg = source_eva_planecion_temas_competencias.FechaReg,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = source_eva_planecion_temas_competencias.UsuarioReg,
                    UsuarioMod = LabelUsuario,
                    Activo = "S",
                    Borrado = "N"
                });

                if (RespuestaInsert == "OK")
                {
                    await new Page().DisplayAlert("UPDATE", "¡EDITADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasList>(FicNavigationContextC[1]);
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
