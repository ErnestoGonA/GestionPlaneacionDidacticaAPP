using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Competencias;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.ViewModels.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.ViewModels.Aprendizajes;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Asignatura;
using GestionPlaneacionDidacticaAPP.ViewModels.ActividadEnseñanza;
using GestionPlaneacionDidacticaAPP.ViewModels.Enseñanza;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Competencias
{
    public class FicVmCompetenciasList : INotifyPropertyChanged
    {
        //Data of the grid
        public ObservableCollection<eva_planeacion_temas_competencias> _SFDataGrid_ItemSource_Competencias;
        public List<eva_planeacion_temas_competencias> _SFDataGrid_ItemSource_Competencias_AUX;
        public eva_planeacion_temas_competencias _SFDataGrid_SelectedItem_Competencias;

        //Buttons
        private ICommand _MetAddCompetenciaICommand, _MetUpdateCompetenciaICommand, _MetViewCompetenciaICommand, _MetRemoveCompetenciaICommand;
        private ICommand _FicMetAprendizajesICommand, _FicMetEnseñanzasICommand, _FicMetCriteriosICommand;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvCompetencias IFicSrvCompetencias;
        private IFicSrvAsignatura IFicSrvAsignatura;

        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelIdAsignatura;
        private string _LabelIdTema;

        public object[] FicNavigationContextC { get; set; }

        public FicVmCompetenciasList(IFicSrvNavigationInventario ificSrvNavigationInventario, IFicSrvCompetencias ificSrvCompetencias, IFicSrvAsignatura ificSrvAsignatura)
        {
            this.IFicSrvNavigationInventario = ificSrvNavigationInventario;
            this.IFicSrvCompetencias = ificSrvCompetencias;
            this.IFicSrvAsignatura = ificSrvAsignatura;

            _SFDataGrid_ItemSource_Competencias = new ObservableCollection<eva_planeacion_temas_competencias>();
            _SFDataGrid_ItemSource_Competencias_AUX = new List<eva_planeacion_temas_competencias>();
        }

        public ObservableCollection<eva_planeacion_temas_competencias> SFDataGrid_ItemSource_Competencias
        {
            get
            {
                return _SFDataGrid_ItemSource_Competencias;
            }
        }

        public eva_planeacion_temas_competencias SFDataGrid_SelectedItem_Competencias
        {
            get
            {
                return _SFDataGrid_SelectedItem_Competencias;
            }
            set
            {
                if (value != null)
                {
                    _SFDataGrid_SelectedItem_Competencias = value;
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

        public string LabelIdTema
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

        public ICommand FicMetAddCompetenciaICommand
        {
            get
            {
                return _MetAddCompetenciaICommand = _MetAddCompetenciaICommand ?? new FicVmDelegateCommand(FicMetAddCompetencia);
            }
        }

        private void FicMetAddCompetencia()
        {
            //var source_eva_planeacion_tema = FicNavigationContextC[0] as eva_planeacion_temas;
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasInsert>(FicNavigationContextC);
        }

        public ICommand FicMetViewCompetenciaICommand
        {
            get
            {
                return _MetViewCompetenciaICommand = _MetViewCompetenciaICommand ?? new FicVmDelegateCommand(FicMetViewCompetencia);
            }
        }

        private void FicMetViewCompetencia()
        {
            if (SFDataGrid_SelectedItem_Competencias != null)
            {
                //eva_planeacion_temas source_eva_planeacion_temas = FicNavigationContextC[0] as eva_planeacion_temas;
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasView>(new object[] { SFDataGrid_SelectedItem_Competencias, FicNavigationContextC[0] });
                //IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasView>(new object[] { SFDataGrid_SelectedItem_Competencias, FicNavigationContextC });
            }
        }

        public ICommand FicMetRemoveCompetenciaICommand
        {
            get
            {
                return _MetRemoveCompetenciaICommand = _MetRemoveCompetenciaICommand ?? new FicVmDelegateCommand(FicMetRemoveCompetencia);
            }
        }

        private async void FicMetRemoveCompetencia()
        {
            if (SFDataGrid_SelectedItem_Competencias != null)
            {

                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro?", "Si", "No");
                if (ask)
                {
                    var res = await IFicSrvCompetencias.DeleteCompetencia(SFDataGrid_SelectedItem_Competencias);
                    if (res == "OK")
                    {
                        //eva_planeacion_temas source_eva_planeacion_temas = FicNavigationContextC[0] as eva_planeacion_temas;
                        IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasList>(FicNavigationContextC);
                    }
                    else
                    {
                        await new Page().DisplayAlert("DELETE", res.ToString(), "OK");
                    }
                }
            }
        }

        public ICommand FicMetUpdateCompetenciaICommand
        {
            get
            {
                return _MetUpdateCompetenciaICommand = _MetUpdateCompetenciaICommand ?? new FicVmDelegateCommand(FicMetUpdateTema);
            }
        }

        private void FicMetUpdateTema()
        {
            if (SFDataGrid_SelectedItem_Competencias != null)
            {
                //eva_planeacion_temas source_eva_planeacion_temas = FicNavigationContextC[0] as eva_planeacion_temas;
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasUpdate>(new object[] { SFDataGrid_SelectedItem_Competencias, FicNavigationContextC[0] });
            }
        }

        public ICommand FicMetAprendizajesICommand
        {
            get
            {
                return _FicMetAprendizajesICommand = _FicMetAprendizajesICommand ?? new FicVmDelegateCommand(FicMetAprendizajes);
            }
        }

        private void FicMetAprendizajes()
        {
            if (SFDataGrid_SelectedItem_Competencias != null)
            {
                IFicSrvNavigationInventario
                    .FicMetNavigateTo<FicVmAprendizajesList>(new object[] {
                        FicNavigationContextC[0],
                        FicNavigationContextC[1],
                        SFDataGrid_SelectedItem_Competencias });
            }
        }

        public ICommand FicMetCriteriosICommand
        {
            get
            {
                return _FicMetCriteriosICommand = _FicMetCriteriosICommand ?? new FicVmDelegateCommand(FicMetCriterios);
            }
        }

        private void FicMetCriterios()
        {
            if (SFDataGrid_SelectedItem_Competencias != null)
            {
                IFicSrvNavigationInventario
                    .FicMetNavigateTo<FicVmCriteriosEvaluacionList>(new object[] {
                        FicNavigationContextC[0],
                        FicNavigationContextC[1],
                        SFDataGrid_SelectedItem_Competencias });
            }
        }
        public ICommand FicMetEnseñanzasICommand
        {
            get
            {
                return _FicMetEnseñanzasICommand = _FicMetEnseñanzasICommand ?? new FicVmDelegateCommand(FicMetEnseñanza);
            }
        }
        public void FicMetEnseñanza()
        {
            if (SFDataGrid_SelectedItem_Competencias != null)
            {
                IFicSrvNavigationInventario
                    .FicMetNavigateTo<FicVmEnseñanzaList>(new object[] {
                        FicNavigationContextC[0],
                        FicNavigationContextC[1],
                        SFDataGrid_SelectedItem_Competencias });
            }
        }


        public async void OnAppearing()
        {
            try
            {
                var source_eva_planeacion_temas = FicNavigationContextC[0] as eva_planeacion_temas;
                if (source_eva_planeacion_temas != null)
                {
                    _LabelUsuario = FicGlobalValues.USUARIO;
                    _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
                    _LabelIdPlaneacion = source_eva_planeacion_temas.IdPlaneacion;
                    _LabelIdTema = source_eva_planeacion_temas.DesTema;

                    RaisePropertyChanged("LabelUsuario");
                    RaisePropertyChanged("LabelIdAsignatura");
                    RaisePropertyChanged("LabelIdPlaneacion");
                    RaisePropertyChanged("LabelIdTema");

                    var source_local_inv1 = await IFicSrvCompetencias.MetGetListCompetenciasTemasPlaneacion(source_eva_planeacion_temas);
                    if (source_local_inv1 != null)
                    {
                        _SFDataGrid_ItemSource_Competencias.Clear();
                        foreach (eva_planeacion_temas_competencias competencias in source_local_inv1)
                        {
                            _SFDataGrid_ItemSource_Competencias.Add(competencias);
                            _SFDataGrid_ItemSource_Competencias_AUX.Add(competencias);
                        }
                    }
                }
                else
                {
                    var source_local_inv2 = await IFicSrvCompetencias.MetGetListCompetencias();
                    if (source_local_inv2 != null)
                    {
                        foreach (eva_planeacion_temas_competencias competencias in source_local_inv2)
                        {
                            _SFDataGrid_ItemSource_Competencias.Add(competencias);
                            _SFDataGrid_ItemSource_Competencias_AUX.Add(competencias);
                        }
                    }//Llenar el grid
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Sobrecarga el metodo OnAppearing() de la view

        internal void FilterTextChange(string newTextValue)
        {
            _SFDataGrid_ItemSource_Competencias.Clear();
            foreach (eva_planeacion_temas_competencias competencia in _SFDataGrid_ItemSource_Competencias_AUX)
            {
                if (competencia.Observaciones.Contains(newTextValue))
                {
                    _SFDataGrid_ItemSource_Competencias.Add(competencia);
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
