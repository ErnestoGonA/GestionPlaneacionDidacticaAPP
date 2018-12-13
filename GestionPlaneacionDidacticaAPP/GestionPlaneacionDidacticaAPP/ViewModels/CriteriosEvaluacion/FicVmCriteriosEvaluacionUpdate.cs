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
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using GestionPlaneacionDidacticaAPP.Interfaces.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;

namespace GestionPlaneacionDidacticaAPP.ViewModels.CriteriosEvaluacion
{
    public class FicVmCriteriosEvaluacionUpdate : INotifyPropertyChanged
    {

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvCriteriosEvaluacion IFicSrvCriteriosEvaluacion;
        private IFicSrvAsignatura IFicSrvAsignatura;
        private FicISrvPlaneacion IFicSrvPlaneacion;
        private IFicSrvTemas IFicSrvTemas;
        //private IFicSrvCompetencia IFicSrvCompetencia;

        //Labels
        private string _LabelUsuario;
        private string _LabelIdAsignatura;
        private int _LabelIdPlaneacion;
        private string _LabelPeriodo;
        private string _LabelTema;
        private string _LabelCompetencia;

        private string _LabelDesCriterio;
        private float _LabelPorcentaje;

        private ICommand _MetRegresarCriteriosEvaluacionListICommand, _SaveCommand;

        //Valor mandado de view padre a hija
        public object[] FicNavigationContextC { get; set; }

        public FicVmCriteriosEvaluacionUpdate(IFicSrvNavigationInventario ficSrvNavigationInventario, 
            IFicSrvCriteriosEvaluacion ficSrvCriteriosEvaluacion, 
            IFicSrvAsignatura ficSrvAsignatura,
            FicISrvPlaneacion iFicSrvPlaneacion,
            IFicSrvTemas ficSrvTemas)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvCriteriosEvaluacion = ficSrvCriteriosEvaluacion;
            IFicSrvAsignatura = ficSrvAsignatura;
            IFicSrvPlaneacion = iFicSrvPlaneacion;
            IFicSrvTemas = ficSrvTemas;
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

        public string LabelDesCriterio
        {
            get { return _LabelDesCriterio; }
            set
            {
                if (value != null)
                {
                    _LabelDesCriterio = value;
                    RaisePropertyChanged("LabelDesCriterio");
                }
            }
        }

        public float LabelPorcentaje
        {
            get { return _LabelPorcentaje; }
            set
            {
                if (value != null)
                {
                    _LabelPorcentaje = value;
                    RaisePropertyChanged("LabelPorcentaje");
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

        public ICommand MetRegresarCriteriosEvaluacionListICommand
        {
            get
            {
                return _MetRegresarCriteriosEvaluacionListICommand = _MetRegresarCriteriosEvaluacionListICommand ?? new FicVmDelegateCommand(MetRegresarCriteriosEvaluacionList);
            }
        }

        private async void MetRegresarCriteriosEvaluacionList()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCriteriosEvaluacionList>();
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

        private void SaveCommandExecute()
        {
            // TODO: insert criterio
        }

        public async void OnAppearing()
        {
            //var source_eva_planeacion = FicNavigationContextC as eva_planeacion;
            _LabelUsuario = FicGlobalValues.USUARIO;
            //_LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
            //_LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;

            RaisePropertyChanged("LabelUsuario");
            //RaisePropertyChanged("LabelIdAsignatura");
            //RaisePropertyChanged("LabelIdPlaneacion");
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
