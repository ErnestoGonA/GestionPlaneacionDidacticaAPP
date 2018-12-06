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
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.Services.Temas;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Temas
{
    public class FicVmTemasUpdate : INotifyPropertyChanged
    {

        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvTemas IFicSrvTemas;

        private string _LabelDesTema, _LabelObservaciones;
        private short _LabelIdAsignatura, _LabelIdTema;
        private int _LabelIdPlaneacion;

        private ICommand _FicMetRegesarCatEdificiosListICommand, _SaveCommand;

        public object FicNavigationContextC { get; set; }

        public FicVmTemasUpdate(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvTemas ficSrvTemas)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvTemas = ficSrvTemas;
        }

        public short LabelIdAsignatura
        {
            get { return _LabelIdAsignatura; }
            set
            {
                if (value != null)
                {
                    _LabelIdAsignatura = value;
                    RaisePropertyChanged("LabelIdAsignatura");
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

        public string LabelDesTema
        {
            get { return _LabelDesTema; }
            set
            {
                if (value != null)
                {
                    _LabelDesTema = value;
                    RaisePropertyChanged("LabelDesTema");
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
            var source_eva_planeacion_temas = FicNavigationContextC as eva_planeacion_temas;

            _LabelIdAsignatura = source_eva_planeacion_temas.IdAsignatura;
            _LabelIdPlaneacion = source_eva_planeacion_temas.IdPlaneacion;
            _LabelIdTema = source_eva_planeacion_temas.IdTema;
            _LabelDesTema = source_eva_planeacion_temas.DesTema;
            _LabelObservaciones = source_eva_planeacion_temas.Observaciones;

            RaisePropertyChanged("LabelIdAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdTema");
            RaisePropertyChanged("LabelDesTema");
            RaisePropertyChanged("LabelObservaciones");

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
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmTemasList>(FicNavigationContextC);
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
            var source_eva_planecion_temas = FicNavigationContextC as eva_planeacion_temas;
            try
            {
                var RespuestaInsert = await IFicSrvTemas.UpdateTema(new eva_planeacion_temas()
                {
                    IdAsignatura = LabelIdAsignatura,
                    IdPlaneacion = LabelIdPlaneacion,
                    IdTema = LabelIdTema,
                    DesTema = LabelDesTema,
                    Observaciones = LabelObservaciones,

                    FechaReg = source_eva_planecion_temas.FechaReg,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = source_eva_planecion_temas.UsuarioReg,
                    UsuarioMod = "ERNESTO",
                    Activo = "S",
                    Borrado = "N"
                });

                if (RespuestaInsert == "OK")
                {
                    await new Page().DisplayAlert("ADD", "¡EDITADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmTemasList>(FicNavigationContextC);
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
