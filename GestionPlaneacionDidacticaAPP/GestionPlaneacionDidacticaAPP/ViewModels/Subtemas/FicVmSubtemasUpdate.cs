using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Subtemas;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Subtemas
{
    public class FicVmSubtemasUpdate : INotifyPropertyChanged
    {
        //Interfaces
        private IFicSrvSubtemas FicSrvSubtemas;
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelAsignatura;
        private int _LabelIdTema; 

        private short _LabelIdSubtema;
        private string _LabelDesSubtema;

        private ICommand _MetRegresarSubtemasListICommand, _SaveCommand;

        public object[] FicNavigationContextC { get; set; }


        public FicVmSubtemasUpdate(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvSubtemas FicSrvSubtemas)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            this.FicSrvSubtemas = FicSrvSubtemas;
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



        public async void OnAppearing()
        {
            var source_eva_planeacion_temas = FicNavigationContextC[0] as eva_planeacion_subtemas;
            eva_planeacion_temas source_eva_planeacion = FicNavigationContextC[1] as eva_planeacion_temas;

            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;
            _LabelIdTema = source_eva_planeacion_temas.IdTema;

            _LabelIdSubtema = source_eva_planeacion_temas.IdSubtema;
            _LabelDesSubtema = source_eva_planeacion_temas.DesSubtema;

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdTema");
            RaisePropertyChanged("LabelIdSubtema");
            RaisePropertyChanged("LabelDesSubtema");

        }


        public ICommand FicMetRegesarCatEdificiosListICommand
        {
            get
            {
                return _MetRegresarSubtemasListICommand = _MetRegresarSubtemasListICommand ??
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

        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }



        private async void SaveCommandExecute()
        {
            var source_eva_planecion_temas = FicNavigationContextC[0] as eva_planeacion_subtemas;
            var source_eva_planecion = FicNavigationContextC[1] as eva_planeacion_temas;
            try
            {
                var RespuestaInsert = await FicSrvSubtemas.UpdateSubtema(new eva_planeacion_subtemas()
                {
                    IdAsignatura = source_eva_planecion.IdAsignatura,
                    IdPlaneacion = source_eva_planecion.IdPlaneacion,
                    IdTema = source_eva_planecion.IdTema,

                    IdSubtema = source_eva_planecion_temas.IdSubtema,
                    DesSubtema = LabelDesSubtema,
                    

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
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmSubtemaList>(source_eva_planecion);
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
