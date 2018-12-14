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
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Interfaces.Aprendizajes;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Aprendizajes
{
    public class FicVmAprendizajesList: INotifyPropertyChanged
    {

        //Data of the grid
        public ObservableCollection<eva_planeacion_aprendizaje> _SFDataGrid_ItemSource_Aprendizajes;
        public List<eva_planeacion_aprendizaje> _SFDataGrid_ItemSource_Aprendizajes_AUX;
        public eva_planeacion_aprendizaje _SFDataGrid_SelectedItem_Aprendizajes;

        
        //Buttons
        private ICommand _FicMetAddAprendizajeICommand, _FicMetUpdateAprendizajeICommand, _FicMetViewAprendizajeICommand, _FicMetRemoveAprendizajeICommand;

        //Labels
        private string _LabelUsuario;
        private string _LabelIdAsignatura;
        private string _LabelPeriodo;
        private int _LabelIdPlaneacion;
        private string _LabelTema;
        private string _LabelCompetencia;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvAprendizajes IFicSrvAprendizajes;
        private FicISrvPlaneacion IFicSrvPlaneacion;

        private IFicSrvAsignatura IFicSrvAsignatura;
        private IFicSrvTemas IFicSrvTemas;
        

        public object[] FicNavigationContextC { get; set; }

        public FicVmAprendizajesList(IFicSrvNavigationInventario ficSrvNavigationInventario,
            IFicSrvTemas srvTemas,
            IFicSrvAsignatura srvAsignatura,
            FicISrvPlaneacion iFicSrvPlaneacion,
            IFicSrvAprendizajes ficSrvAprendizajes)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvTemas = srvTemas;
            IFicSrvAsignatura = srvAsignatura;
            IFicSrvPlaneacion = iFicSrvPlaneacion;
            IFicSrvAprendizajes = ficSrvAprendizajes;

            _SFDataGrid_ItemSource_Aprendizajes = new ObservableCollection<eva_planeacion_aprendizaje>();
            _SFDataGrid_ItemSource_Aprendizajes_AUX = new List<eva_planeacion_aprendizaje>();

        }

        public ObservableCollection<eva_planeacion_aprendizaje> SFDataGrid_ItemSource_Aprendizajes
        {
            get
            {
                return _SFDataGrid_ItemSource_Aprendizajes;
            }
        }

        public eva_planeacion_aprendizaje SFDataGrid_SelectedItem_Aprendizajes
        {
            get
            {
                return _SFDataGrid_SelectedItem_Aprendizajes;
            }
            set
            {
                if (value != null)
                {
                    _SFDataGrid_SelectedItem_Aprendizajes = value;
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

        public ICommand FicMetAddAprendizajesICommand
        {
            get
            {
                return _FicMetAddAprendizajeICommand = _FicMetAddAprendizajeICommand ?? new FicVmDelegateCommand(FicMetAddAprendizaje);
            }
        }

        private void FicMetAddAprendizaje()
        {
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajesInsert>(FicNavigationContextC);
        }

        public ICommand FicMetViewCriteriosEvaluacionICommand
        {
            get
            {
                return _FicMetViewAprendizajeICommand = _FicMetViewAprendizajeICommand ?? new FicVmDelegateCommand(FicMetViewAprendizaje);
            }
        }

        private void FicMetViewAprendizaje()
        {
            if (_SFDataGrid_SelectedItem_Aprendizajes != null)
            {
                //TODO change to view
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajesList>(new object[] {
                    FicNavigationContextC[0],
                    FicNavigationContextC[1],
                    FicNavigationContextC[2],
                    SFDataGrid_SelectedItem_Aprendizajes });
            }
        }

        public ICommand FicMetUpdateAprendizajesICommand
        {
            get
            {
                return _FicMetUpdateAprendizajeICommand = _FicMetUpdateAprendizajeICommand ?? new FicVmDelegateCommand(FicMetUpdateAprendizaje);
            }
        }

        private void FicMetUpdateAprendizaje()
        {
            if (SFDataGrid_SelectedItem_Aprendizajes != null)
            {
                //TODO change to update
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajesUpdate>(new object[] {
                    FicNavigationContextC[0],
                    FicNavigationContextC[1],
                    FicNavigationContextC[2],
                    SFDataGrid_SelectedItem_Aprendizajes });
            }
        }

        public ICommand FicMetRemoveAprendizajesICommand
        {
            get
            {
                return _FicMetRemoveAprendizajeICommand = _FicMetRemoveAprendizajeICommand ?? new FicVmDelegateCommand(FicMetRemoveAprendizaje);
            }
        }

        private async void FicMetRemoveAprendizaje()
        {
            if (SFDataGrid_SelectedItem_Aprendizajes != null)
            {

                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro?", "Si", "No");
                if (ask)
                {
                    var res = await IFicSrvAprendizajes.DeleteAprendizaje(SFDataGrid_SelectedItem_Aprendizajes);
                    if (res == "OK")
                    {
                        IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajesList>(FicNavigationContextC);
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

                var aprendizajes = await IFicSrvAprendizajes.MetGetListAprendizajes(eptc);
                if (aprendizajes != null)
                {
                    _SFDataGrid_ItemSource_Aprendizajes.Clear();
                    foreach (eva_planeacion_aprendizaje aprendizaje in aprendizajes)
                    {
                        _SFDataGrid_ItemSource_Aprendizajes.Add(aprendizaje);
                        _SFDataGrid_ItemSource_Aprendizajes_AUX.Add(aprendizaje);
                    }
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        internal void FilterTextChange(string newTextValue)
        {
            _SFDataGrid_ItemSource_Aprendizajes.Clear();
            foreach (eva_planeacion_aprendizaje criterio in _SFDataGrid_ItemSource_Aprendizajes_AUX)
            {
                if (true)
                {
                    _SFDataGrid_ItemSource_Aprendizajes.Add(criterio);
                }
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
