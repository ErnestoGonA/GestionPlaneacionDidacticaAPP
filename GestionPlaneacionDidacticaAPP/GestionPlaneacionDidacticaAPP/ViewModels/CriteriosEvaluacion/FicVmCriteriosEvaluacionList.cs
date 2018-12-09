using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Asignatura;
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Interfaces.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;

namespace GestionPlaneacionDidacticaAPP.ViewModels.CriteriosEvaluacion
{
    public class FicVmCriteriosEvaluacionList: INotifyPropertyChanged
    {

        //Data of the grid
        public ObservableCollection<eva_planeacion_criterios_evalua> _SFDataGrid_ItemSource_CriteriosEvaluacion;
        public eva_planeacion_criterios_evalua _SFDataGrid_SelectedItem_CriteriosEvaluacion;

        //Buttons
        private ICommand _FicMetAddCriterioEvaluacionICommand, _FicMetUpdateCriteriosEvaluacionICommand, _FicMetViewCriteriosEvaluacionICommand, _FicMetRemoveCriteriosEvaluacionICommand;

        //Labels
        private string _LabelUsuario;
        private string _LabelIdAsignatura;
        private int _LabelIdPlaneacion;
        private string _LabelTema;
        private string _LabelCompetencia;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvCriteriosEvaluacion IFicSrvCriteriosEvaluacion;

        private IFicSrvAsignatura IFicSrvAsignatura;
        private IFicSrvTemas IFicSrvTemas;
        //private IFicSrvCompetencia IFicSrvCompetencia;

        public object[] FicNavigationContextC { get; set; }

        public FicVmCriteriosEvaluacionList(IFicSrvNavigationInventario ficSrvNavigationInventario,
            IFicSrvTemas srvTemas,
            IFicSrvAsignatura srvAsignatura,
            IFicSrvCriteriosEvaluacion ficSrvCriteriosEvaluacion)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvTemas = srvTemas;
            IFicSrvAsignatura = srvAsignatura;
            IFicSrvCriteriosEvaluacion = ficSrvCriteriosEvaluacion;

            _SFDataGrid_ItemSource_CriteriosEvaluacion = new ObservableCollection<eva_planeacion_criterios_evalua>();
        }

        public ObservableCollection<eva_planeacion_criterios_evalua> SFDataGrid_ItemSource_CriteriosEvaluacion
        {
            get
            {
                return _SFDataGrid_ItemSource_CriteriosEvaluacion;
            }
        }

        public eva_planeacion_criterios_evalua SFDataGrid_SelectedItem_CriteriosEvaluacion
        {
            get
            {
                return _SFDataGrid_SelectedItem_CriteriosEvaluacion;
            }
            set
            {
                if (value != null)
                {
                    _SFDataGrid_SelectedItem_CriteriosEvaluacion = value;
                    RaisePropertyChanged();
                }
            }
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

        public ICommand FicMetAddCriterioEvaluacionICommand
        {
            get
            {
                return _FicMetAddCriterioEvaluacionICommand = _FicMetAddCriterioEvaluacionICommand ?? new FicVmDelegateCommand(FicMetAddCriterioEvaluacion);
            }
        }

        private void FicMetAddCriterioEvaluacion()
        {
            //var source_eva_planeacion = FicNavigationContextC as eva_planeacion;
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCriteriosEvaluacionInsert>();
        }

        public ICommand FicMetViewCriteriosEvaluacionICommand
        {
            get
            {
                return _FicMetViewCriteriosEvaluacionICommand = _FicMetViewCriteriosEvaluacionICommand ?? new FicVmDelegateCommand(FicMetViewCriteriosEvaluacion);
            }
        }

        private void FicMetViewCriteriosEvaluacion()
        {
            if (SFDataGrid_SelectedItem_CriteriosEvaluacion != null)
            {
                //eva_planeacion source_eva_planeacion = FicNavigationContextC[] as eva_planeacion;
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCriteriosEvaluacionView>(new object[] { SFDataGrid_SelectedItem_CriteriosEvaluacion });
            }
        }

        public ICommand FicMetUpdateCriteriosEvaluacionICommand
        {
            get
            {
                return _FicMetUpdateCriteriosEvaluacionICommand = _FicMetUpdateCriteriosEvaluacionICommand ?? new FicVmDelegateCommand(FicMetUpdateCriteriosEvaluacion);
            }
        }

        private void FicMetUpdateCriteriosEvaluacion()
        {
            if (SFDataGrid_SelectedItem_CriteriosEvaluacion != null)
            {
                //eva_planeacion source_eva_planeacion = FicNavigationContextC as eva_planeacion;
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCriteriosEvaluacionUpdate>(new object[] { SFDataGrid_SelectedItem_CriteriosEvaluacion });
            }
        }

        public ICommand FicMetRemoveCriteriosEvaluacionICommand
        {
            get
            {
                return _FicMetRemoveCriteriosEvaluacionICommand = _FicMetRemoveCriteriosEvaluacionICommand ?? new FicVmDelegateCommand(FicMetRemoveCriteriosEvaluacion);
            }
        }

        private async void FicMetRemoveCriteriosEvaluacion()
        {
            if (SFDataGrid_SelectedItem_CriteriosEvaluacion != null)
            {

                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro?", "Si", "No");
                if (ask)
                {
                    var res = await IFicSrvCriteriosEvaluacion.DeleteCriterioEvaluacion(SFDataGrid_SelectedItem_CriteriosEvaluacion);
                    if (res == "OK")
                    {
                        //eva_planeacion source_eva_planeacion = FicNavigationContextC as eva_planeacion;
                        IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCriteriosEvaluacionList>();
                    }
                    else
                    {
                        await new Page().DisplayAlert("DELETE", res.ToString(), "OK");
                    }
                }
            }
        }

        public async void OnAppearing()
        {
            try
            {
                var criterios = await IFicSrvCriteriosEvaluacion.MetGetListCriteriosEvaluacion();
                if (criterios != null)
                {
                    _SFDataGrid_ItemSource_CriteriosEvaluacion.Clear();
                    foreach(eva_planeacion_criterios_evalua criterio in criterios)
                    {
                        _SFDataGrid_ItemSource_CriteriosEvaluacion.Add(criterio);
                    }
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyname = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        #endregion
    }
}
