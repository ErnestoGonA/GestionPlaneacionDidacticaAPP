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
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.Services.Temas;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Temas
{
    public class FicVmTemasInsert: INotifyPropertyChanged
    {

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvTemas IFicSrvTemas;
        private FicISrvPlaneacion IFicSrvPlaneacion;


        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelIdAsignatura;
        private string _LabelPeriodo;


        private string _LabelDesTema, _LabelObservaciones;

        //Botones
        private ICommand _MetRegresarTemasListICommand, _SaveCommand;

        //Valor mandado de view padre a hija
        public object FicNavigationContextC { get; set; }

        public FicVmTemasInsert(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvTemas srvTemas, FicISrvPlaneacion iFicSrvPlaneacion)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvTemas = srvTemas;
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

        public string LabelPeriodo
        {
            get { return _LabelPeriodo; }
            set
            {
                if (value != null)
                {
                    _LabelPeriodo = value;
                    RaisePropertyChanged("LabelPeriodo");
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
                    RaisePropertyChanged("LabelObervaciones");
                }
            }
        }

        public ICommand MetRegresarTemasListICommand
        {
            get
            {
                return _MetRegresarTemasListICommand = _MetRegresarTemasListICommand ?? new FicVmDelegateCommand(MetRegresarTemasList);
            }
        }

        private async void MetRegresarTemasList()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmTemasList>(FicNavigationContextC);
            }
            catch(Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(),"Ok");
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

                var source_eva_planeacion = FicNavigationContextC as eva_planeacion;

                var res = await IFicSrvTemas.InsertTema(new eva_planeacion_temas()
                {
                    IdAsignatura = source_eva_planeacion.IdAsignatura,
                    IdPlaneacion = source_eva_planeacion.IdPlaneacion,

                    DesTema = LabelDesTema,
                    Observaciones = LabelObservaciones,

                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = FicGlobalValues.USUARIO,
                    UsuarioMod = FicGlobalValues.USUARIO,
                    Activo = "S",
                    Borrado = "N"
                });

                if(res == "Ok")
                {
                    await new Page().DisplayAlert("Insert", "¡INSERTADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmTemasList>(FicNavigationContextC);
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

            var source_eva_planeacion = FicNavigationContextC as eva_planeacion;
            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;

            cat_periodos periodo = await IFicSrvPlaneacion.GetListPeriodos(source_eva_planeacion.IdPeriodo);

            _LabelPeriodo = periodo.DesPeriodo;
            RaisePropertyChanged("LabelPeriodo");

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelIdAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
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
