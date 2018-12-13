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
using GestionPlaneacionDidacticaAPP.Interfaces.Asignatura;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Interfaces.Aprendizajes;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Aprendizajes
{
    public class FicVmAprendizajesInsert : INotifyPropertyChanged
    {

        ///Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvAprendizajes IFicSrvAprendizajes;
        private FicISrvPlaneacion IFicSrvPlaneacion;
        private IFicSrvAsignatura IFicSrvAsignatura;
        private IFicSrvTemas IFicSrvTemas;

        //Labels
        private string _LabelUsuario;
        private string _LabelIdAsignatura;
        private string _LabelPeriodo;
        private int _LabelIdPlaneacion;
        private string _LabelTema;
        private string _LabelCompetencia;

        public int _IdAprendizaje;
        private List<string> _Aprendizajes;

        private string _LabelObservaciones;

        private ICommand _MetRegresarAprendizajesListICommand, _SaveCommand;

        //Valor mandado de view padre a hija
        public object[] FicNavigationContextC { get; set; }

        public FicVmAprendizajesInsert(IFicSrvNavigationInventario ficSrvNavigationInventario,
           IFicSrvAprendizajes ficSrvAprendizajes,
           IFicSrvAsignatura ficSrvAsignatura,
           FicISrvPlaneacion iFicSrvPlaneacion,
           IFicSrvTemas ficSrvTemas)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvAprendizajes = ficSrvAprendizajes;
            IFicSrvAsignatura = ficSrvAsignatura;
            IFicSrvPlaneacion = iFicSrvPlaneacion;
            IFicSrvTemas = ficSrvTemas;
            _Aprendizajes = ficSrvAprendizajes.MetGetActividadesAprendizaje().Result;
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

        public string LabelCompetencia
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

        public int IdAprendizaje
        {
            get
            {
                return _IdAprendizaje;
            }
            set
            {
                _IdAprendizaje = value;
            }
        }

        public List<string> Aprendizajes
        {
            get { return _Aprendizajes; }
            set
            {
                _Aprendizajes = value;
                RaisePropertyChanged("Aprendizajes");
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

        public ICommand MetRegresarAprendizajesListICommand
        {
            get
            {
                return _MetRegresarAprendizajesListICommand = _MetRegresarAprendizajesListICommand ?? new FicVmDelegateCommand(MetRegresarAprendizajesList);
            }
        }

        private async void MetRegresarAprendizajesList()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajesList>(FicNavigationContextC);
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
                var eptc = FicNavigationContextC[2] as eva_planeacion_temas_competencias;

                var res = await IFicSrvAprendizajes.InsertAprendizaje(new eva_planeacion_aprendizaje()
                {
                    IdAsignatura = eptc.IdAsignatura,
                    IdPlaneacion = eptc.IdPlaneacion,
                    IdTema = eptc.IdTema,
                    IdCompetencia = eptc.IdCompetencia,

                    IdActividadAprendizaje =(this._IdAprendizaje + 1),
                    Observaciones = _LabelObservaciones,

                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = FicGlobalValues.USUARIO,
                    UsuarioMod = FicGlobalValues.USUARIO,
                    Activo = "S",
                    Borrado = "N"
                });

                if (res == "OK")
                {
                    await new Page().DisplayAlert("Insert", "¡INSERTADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajesList>(FicNavigationContextC);
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
            try
            {
                eva_planeacion_temas tema = FicNavigationContextC[0] as eva_planeacion_temas;
                eva_planeacion source_eva_planeacion = FicNavigationContextC[1] as eva_planeacion;
                eva_planeacion_temas_competencias eptc = FicNavigationContextC[2] as eva_planeacion_temas_competencias;
                cat_periodos periodo = await IFicSrvPlaneacion.GetListPeriodos(source_eva_planeacion.IdPeriodo);

                _LabelUsuario = FicGlobalValues.USUARIO;
                _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
                _LabelPeriodo = periodo.DesPeriodo;
                _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;
                _LabelTema = tema.DesTema;
                _LabelCompetencia = eptc.Observaciones;

                RaisePropertyChanged("LabelPeriodo");
                RaisePropertyChanged("LabelUsuario");
                RaisePropertyChanged("LabelIdAsignatura");
                RaisePropertyChanged("LabelIdPlaneacion");
                RaisePropertyChanged("LabelTema");
                RaisePropertyChanged("LabelCompetencia");

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
