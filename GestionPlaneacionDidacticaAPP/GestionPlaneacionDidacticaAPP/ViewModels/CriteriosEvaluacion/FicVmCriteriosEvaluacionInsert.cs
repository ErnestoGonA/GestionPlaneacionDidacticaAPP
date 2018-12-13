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
using GestionPlaneacionDidacticaAPP.Interfaces.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;

namespace GestionPlaneacionDidacticaAPP.ViewModels.CriteriosEvaluacion
{
    public class FicVmCriteriosEvaluacionInsert : INotifyPropertyChanged
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

        public FicVmCriteriosEvaluacionInsert(IFicSrvNavigationInventario ficSrvNavigationInventario,
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
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCriteriosEvaluacionList>(FicNavigationContextC);
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
             
                var res = await IFicSrvCriteriosEvaluacion.InsertCriterioEvaluacion(new eva_planeacion_criterios_evalua()
                {
                    IdAsignatura = eptc.IdAsignatura,
                    IdPlaneacion = eptc.IdPlaneacion,
                    IdTema = eptc.IdTema,
                    IdCompetencia= eptc.IdCompetencia,

                    DesCriterio = LabelDesCriterio,
                    Porcentaje = (float)LabelPorcentaje,

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
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCriteriosEvaluacionList>(FicNavigationContextC);
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
            var source_eva_planeacion_temas = FicNavigationContextC[0] as eva_planeacion_temas;
            var source_eva_planeacion = FicNavigationContextC[1] as eva_planeacion;
            var eptc = FicNavigationContextC[2] as eva_planeacion_temas_competencias;
            cat_periodos periodo = await IFicSrvPlaneacion.GetListPeriodos(source_eva_planeacion.IdPeriodo);

            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelPeriodo = periodo.DesPeriodo;
            _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;
            _LabelTema = source_eva_planeacion_temas.DesTema;
            _LabelCompetencia = eptc.Observaciones;

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelIdAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelTema");
            RaisePropertyChanged("LabelCompetencia");
            RaisePropertyChanged("LabelPeriodo");

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
