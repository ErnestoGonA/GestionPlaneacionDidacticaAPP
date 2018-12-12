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
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.ViewModels.Competencias;
using GestionPlaneacionDidacticaAPP.ViewModels.Subtemas;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Temas
{
    public class FicVmTemasList : INotifyPropertyChanged
    {

        //Data of the grid
        public ObservableCollection<eva_planeacion_temas> _SFDataGrid_ItemSource_Temas;
        public eva_planeacion_temas _SFDataGrid_SelectedItem_Temas;

        //Buttons
        private ICommand _FicMetAddTemaICommand,
            _FicMetUpdateTemaICommand,
            _FicMetViewTemaICommand,
            _FicMetRemoveTemaICommand,
            _FicMetSubtemasICommand,
            _FicMetCompetenciasICommand;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelIdAsignatura;
        private string _LabelPeriodo;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvTemas IFicSrvTemas;
        private IFicSrvAsignatura IFicSrvAsignatura;
        private FicISrvPlaneacion IFicSrvPlaneacion;

        public object FicNavigationContextC { get; set; }

        public FicVmTemasList(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvTemas srvTemas,IFicSrvAsignatura srvAsignatura, FicISrvPlaneacion iFicSrvPlaneacion)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvTemas = srvTemas;
            IFicSrvAsignatura = srvAsignatura;
            IFicSrvPlaneacion = iFicSrvPlaneacion;

            _SFDataGrid_ItemSource_Temas = new ObservableCollection<eva_planeacion_temas>();
        }

        public ObservableCollection<eva_planeacion_temas> SFDataGrid_ItemSource_Temas
        {
            get
            {
                return _SFDataGrid_ItemSource_Temas;
            }
        }

        public eva_planeacion_temas SFDataGrid_SelectedItem_Temas
        {
            get
            {
                return _SFDataGrid_SelectedItem_Temas;
            }
            set
            {
                if (value!=null)
                {
                    _SFDataGrid_SelectedItem_Temas = value;
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


        public ICommand FicMetAddTemaICommand
        {
            get
            {
                return _FicMetAddTemaICommand = _FicMetAddTemaICommand ?? new FicVmDelegateCommand(FicMetAddTema);
            }
        }

        private void FicMetAddTema()
        {
            var source_eva_planeacion = FicNavigationContextC as eva_planeacion;
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmTemasInsert>(source_eva_planeacion);
        }

        public ICommand FicMetViewTemaICommand
        {
            get
            {
                return _FicMetViewTemaICommand = _FicMetViewTemaICommand ?? new FicVmDelegateCommand(FicMetViewTema);
            }
        }

        private void FicMetViewTema()
        {
            if (SFDataGrid_SelectedItem_Temas != null)
            {
                eva_planeacion source_eva_planeacion = FicNavigationContextC as eva_planeacion;
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmTemasView>(new object[] { SFDataGrid_SelectedItem_Temas , source_eva_planeacion });
            }
        }

        public ICommand FicMetUpdateTemaICommand
        {
            get
            {
                return _FicMetUpdateTemaICommand = _FicMetUpdateTemaICommand ?? new FicVmDelegateCommand(FicMetUpdateTema);
            }
        }

        private void FicMetUpdateTema()
        {
            if (SFDataGrid_SelectedItem_Temas != null)
            {
                eva_planeacion source_eva_planeacion = FicNavigationContextC as eva_planeacion;
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmTemasUpdate>(new object[] { SFDataGrid_SelectedItem_Temas, source_eva_planeacion });
            }
        }

        public ICommand FicMetRemoveTemaICommand
        {
            get
            {
                return _FicMetRemoveTemaICommand = _FicMetRemoveTemaICommand ?? new FicVmDelegateCommand(FicMetRemoveTema);
            }
        }

        private async void FicMetRemoveTema()
        {
            if (SFDataGrid_SelectedItem_Temas != null)
            {

                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro?", "Si", "No");
                if (ask)
                {
                    var res = await IFicSrvTemas.DeleteTema(SFDataGrid_SelectedItem_Temas);
                    if (res == "OK")
                    {
                        eva_planeacion source_eva_planeacion = FicNavigationContextC as eva_planeacion;
                        IFicSrvNavigationInventario.FicMetNavigateTo<FicVmTemasList>(source_eva_planeacion);
                    }
                    else
                    {
                        await new Page().DisplayAlert("DELETE", res.ToString(), "OK");
                    }
                }
            }
        }

        public ICommand FicMetSubtemasICommand
        {
            get
            {
                return _FicMetSubtemasICommand = _FicMetSubtemasICommand ?? new FicVmDelegateCommand(FicMetSubtemas);
            }
        }

        private void FicMetSubtemas()
        {
            if (SFDataGrid_SelectedItem_Temas != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmSubtemaList>(SFDataGrid_SelectedItem_Temas);
            }
        }

        public ICommand FicMetCompetenciasICommand
        {
            get
            {
                return _FicMetCompetenciasICommand = _FicMetCompetenciasICommand ?? new FicVmDelegateCommand(FicMetCompetencias);
            }
        }

        private void FicMetCompetencias()
        {
            if (SFDataGrid_SelectedItem_Temas != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasList>(new object[] { SFDataGrid_SelectedItem_Temas , FicNavigationContextC });
            }
        }

        public async void OnAppearing()
        {
            try
            {
                var source_eva_planeacion = FicNavigationContextC as eva_planeacion;
                if (source_eva_planeacion != null)
                {                    
                    _LabelUsuario = FicGlobalValues.USUARIO;
                    _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
                    _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;

                    cat_periodos periodo = await IFicSrvPlaneacion.GetListPeriodos(source_eva_planeacion.IdPeriodo);
                        
                    _LabelPeriodo = periodo.DesPeriodo;
                    RaisePropertyChanged("LabelPeriodo");
                    RaisePropertyChanged("LabelUsuario");
                    RaisePropertyChanged("LabelIdAsignatura");
                    RaisePropertyChanged("LabelIdPlaneacion");
                    

                    var source_local_inv1 = await IFicSrvTemas.MetGetListTemasPlaneacion(source_eva_planeacion);
                    if (source_local_inv1 != null)
                    {
                        _SFDataGrid_ItemSource_Temas.Clear();
                        foreach (eva_planeacion_temas tema in source_local_inv1)
                        {
                            _SFDataGrid_ItemSource_Temas.Add(tema);
                        }
                    }
                }
                else
                {
                    var source_local_inv2 = await IFicSrvTemas.MetGetListTemas();
                    if (source_local_inv2 != null)
                    {
                        foreach (eva_planeacion_temas tema in source_local_inv2)
                        {
                            _SFDataGrid_ItemSource_Temas.Add(tema);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Sobrecarga el metodo OnAppearing() de la view

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
