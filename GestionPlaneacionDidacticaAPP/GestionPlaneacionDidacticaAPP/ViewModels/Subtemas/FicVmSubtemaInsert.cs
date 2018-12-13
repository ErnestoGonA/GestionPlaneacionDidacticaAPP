using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Subtemas;
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
    public class FicVmSubtemaInsert : INotifyPropertyChanged
    {
        //Interfaces
        private IFicSrvSubtemas FicSrvSubtemas;
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelIdAsignatura;
        private int _LabelIdTema;
        private string _LabelDesSubtema;
        //Botones
        private ICommand _MetRegresarSubtemasListICommand, _SaveCommand;
        

        //Valor mandado de view padre a hija
        public object FicNavigationContextC { get; set; }

        public FicVmSubtemaInsert(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvSubtemas FicSrvSubtemas)
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

        public string LabelIdAsignatura
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

        public ICommand MetRegresarSubtemasListICommand
        {
            get
            {
                return _MetRegresarSubtemasListICommand = _MetRegresarSubtemasListICommand ?? new FicVmDelegateCommand(MetRegresarSubtemaList);
            }
        }

        private async void MetRegresarSubtemaList()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmSubtemaList>(FicNavigationContextC);
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
                var source_eva_planeacion = FicNavigationContextC as eva_planeacion_temas;
                var res = await FicSrvSubtemas.InsertSubtema(new eva_planeacion_subtemas()
                {
                    IdAsignatura = source_eva_planeacion.IdAsignatura,
                    IdPlaneacion = source_eva_planeacion.IdPlaneacion,
                    IdTema = source_eva_planeacion.IdTema,
                    DesSubtema = _LabelDesSubtema,
                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = FicGlobalValues.USUARIO,
                    UsuarioMod = FicGlobalValues.USUARIO,
                    Activo = "S",
                    Borrado = "N"
                });

                if (res == "Ok")
                {
                    await new Page().DisplayAlert("Insert", "¡INSERTADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmSubtemaList>(source_eva_planeacion);
                }
                else
                {
                    await new Page().DisplayAlert("Insert", res.ToString(), "OK");
                }

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Alerta", e.Message.ToString(), "OK");
            }
        }

        public async void OnAppearing()
        {

            var source_eva_planeacion = FicNavigationContextC as eva_planeacion_temas;
            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;
            _LabelIdTema = source_eva_planeacion.IdTema;

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelIdAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdTema");
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
