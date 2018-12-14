using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Asignatura;
using GestionPlaneacionDidacticaAPP.Interfaces.Fuentes;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Fuentes
{
    public class FicVmFuentesList : INotifyPropertyChanged
    {
        //Data of the grid
        public ObservableCollection<eva_planeacion_fuentes> _SFDataGrid_ItemSource_Fuentes;
        public List<eva_planeacion_fuentes> _SFDataGrid_ItemSource_Fuentes_AUX;
        public eva_planeacion_fuentes _SFDataGrid_SelectedItem_Fuentes;

        //Buttons
        private ICommand _FicMetAddFuentesICommand,
            _FicMetUpdateFuentesICommand,
            _FicMetViewFuentesICommand,
            _FicMetRemoveFuentesICommand;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelIdAsignatura;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvFuentes IFicSrvFuentes;

        public object FicNavigationContextC { get; set; }

        public FicVmFuentesList(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvFuentes srvFuentes)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvFuentes = srvFuentes;

            _SFDataGrid_ItemSource_Fuentes = new ObservableCollection<eva_planeacion_fuentes>();
            _SFDataGrid_ItemSource_Fuentes_AUX = new List<eva_planeacion_fuentes>();
        }

        public ObservableCollection<eva_planeacion_fuentes> SFDataGrid_ItemSource_Fuentes
        {
            get
            {
                return _SFDataGrid_ItemSource_Fuentes;
            }
        }

        public eva_planeacion_fuentes SFDataGrid_SelectedItem_Fuentes
        {
            get
            {
                return _SFDataGrid_SelectedItem_Fuentes;
            }
            set
            {
                if (value != null)
                {
                    _SFDataGrid_SelectedItem_Fuentes = value;
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


        public ICommand FicMetAddFuentesICommand
        {
            get
            {
                return _FicMetAddFuentesICommand = _FicMetAddFuentesICommand ?? new FicVmDelegateCommand(FicMetAddFuentes);
            }
        }

        private void FicMetAddFuentes()
        {
            var source_eva_planeacion = FicNavigationContextC as eva_planeacion;
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmFuentesInsert>(source_eva_planeacion);
        }

        public ICommand FicMetViewFuentesICommand
        {
            get
            {
                return _FicMetViewFuentesICommand = _FicMetViewFuentesICommand ?? new FicVmDelegateCommand(FicMetViewFuentes);
            }
        }

        private void FicMetViewFuentes()
        {
            if (SFDataGrid_SelectedItem_Fuentes != null)
            {
                eva_planeacion source_eva_planeacion = FicNavigationContextC as eva_planeacion;
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmFuentesView>(new object[] { SFDataGrid_SelectedItem_Fuentes, source_eva_planeacion });
            }
        }

        public ICommand FicMetUpdateFuentesICommand
        {
            get
            {
                return _FicMetUpdateFuentesICommand = _FicMetUpdateFuentesICommand ?? new FicVmDelegateCommand(FicMetUpdateFuentes);
            }
        }

        private void FicMetUpdateFuentes()
        {
            if (SFDataGrid_SelectedItem_Fuentes != null)
            {
                eva_planeacion source_eva_planeacion = FicNavigationContextC as eva_planeacion;
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmFuentesUpdate>(new object[] { SFDataGrid_SelectedItem_Fuentes, source_eva_planeacion });
            }
        }

        public ICommand FicMetRemoveFuentesICommand
        {
            get
            {
                return _FicMetRemoveFuentesICommand = _FicMetRemoveFuentesICommand ?? new FicVmDelegateCommand(FicMetRemoveFuentes);
            }
        }

        private async void FicMetRemoveFuentes()
        {
            if (SFDataGrid_SelectedItem_Fuentes != null)
            {

                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro?", "Si", "No");
                if (ask)
                {
                    var res = await IFicSrvFuentes.DeleteFuente(SFDataGrid_SelectedItem_Fuentes);
                    if (res == "OK")
                    {
                        eva_planeacion source_eva_planeacion = FicNavigationContextC as eva_planeacion;
                        IFicSrvNavigationInventario.FicMetNavigateTo<FicVmFuentesList>(source_eva_planeacion);
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
                var source_eva_planeacion = FicNavigationContextC as eva_planeacion;
                if (source_eva_planeacion != null)
                {
                    _LabelUsuario = FicGlobalValues.USUARIO;
                    _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
                    _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;
                    
                    RaisePropertyChanged("LabelUsuario");
                    RaisePropertyChanged("LabelIdAsignatura");
                    RaisePropertyChanged("LabelIdPlaneacion");


                    var source_local_inv1 = await IFicSrvFuentes.MetGetListFuentesPlaneacion(source_eva_planeacion);
                    if (source_local_inv1 != null)
                    {
                        _SFDataGrid_ItemSource_Fuentes.Clear();
                        foreach (eva_planeacion_fuentes fuentes in source_local_inv1)
                        {
                            _SFDataGrid_ItemSource_Fuentes.Add(fuentes);
                            _SFDataGrid_ItemSource_Fuentes_AUX.Add(fuentes);
                        }
                    }
                }
                else
                {
                    var source_local_inv2 = await IFicSrvFuentes.MetGetListFuentes();
                    if (source_local_inv2 != null)
                    {
                        foreach (eva_planeacion_fuentes fuentes in source_local_inv2)
                        {
                            _SFDataGrid_ItemSource_Fuentes.Add(fuentes);
                            _SFDataGrid_ItemSource_Fuentes_AUX.Add(fuentes);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Sobrecarga el metodo OnAppearing() de la view

        internal void FilterTextChange(string newTextValue)
        {
            _SFDataGrid_ItemSource_Fuentes.Clear();
            foreach (eva_planeacion_fuentes fuentes in _SFDataGrid_ItemSource_Fuentes_AUX)
            {
                if (fuentes.Observaciones.Contains(newTextValue) || fuentes.Prioridad+"" == newTextValue)
                {
                    _SFDataGrid_ItemSource_Fuentes.Add(fuentes);
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
