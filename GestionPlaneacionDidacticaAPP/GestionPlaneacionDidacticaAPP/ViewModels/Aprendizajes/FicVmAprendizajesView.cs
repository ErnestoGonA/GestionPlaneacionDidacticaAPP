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
    public class FicVmAprendizajesView: INotifyPropertyChanged
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

        public FicVmAprendizajesView(IFicSrvNavigationInventario ficSrvNavigationInventario,
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
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajesList>(new object[] { FicNavigationContextC[0], FicNavigationContextC[1], FicNavigationContextC[2] });
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "Ok");
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

                eva_planeacion_aprendizaje aprendizaje = FicNavigationContextC[3] as eva_planeacion_aprendizaje;

                _LabelUsuario = FicGlobalValues.USUARIO;
                _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
                _LabelPeriodo = periodo.DesPeriodo;
                _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;
                _LabelTema = tema.DesTema;
                _LabelCompetencia = eptc.Observaciones;

                _IdAprendizaje = aprendizaje.IdActividadAprendizaje - 1;
                _LabelObservaciones = aprendizaje.Observaciones;

                RaisePropertyChanged("LabelPeriodo");
                RaisePropertyChanged("LabelUsuario");
                RaisePropertyChanged("LabelIdAsignatura");
                RaisePropertyChanged("LabelIdPlaneacion");
                RaisePropertyChanged("LabelTema");
                RaisePropertyChanged("LabelCompetencia");

                RaisePropertyChanged("IdAprendizaje");
                RaisePropertyChanged("LabelObservaciones");


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
