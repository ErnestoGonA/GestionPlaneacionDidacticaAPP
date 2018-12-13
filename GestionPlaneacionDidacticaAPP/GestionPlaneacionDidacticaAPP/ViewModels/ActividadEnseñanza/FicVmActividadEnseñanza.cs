using GestionPlaneacionDidacticaAPP.Interfaces.ActividadEnseñanza;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.ActividadEnseñanza
{
    public class FicVmActividadEnseñanza : INotifyPropertyChanged
    {
        public ObservableCollection<eva_cat_actividades_enseñanza> _SFDataGrid_ItemSource_Enseñanza;
        public eva_cat_actividades_enseñanza _SFDataGrid_SelectedItem_Enseñanza;
        public string _DesActividadEnseñanza;

        private ICommand _MetAddEnseñanzaICommand, _MetUpdateEnseñanzaICommand, _MetViewEnseñanzaICommand, _MetRemoveEnseñanzaICommand, _FiltrarPlantillaCommand, _GuardarComoCommand;

        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvActividadEnseñanza IFicSrvActividadEnseñanza;

        public FicVmActividadEnseñanza(IFicSrvNavigationInventario ficSrvNavigationInventario,
            IFicSrvActividadEnseñanza IFicSrvActividadEnseñanza)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            this.IFicSrvActividadEnseñanza = IFicSrvActividadEnseñanza;

            _SFDataGrid_ItemSource_Enseñanza = new ObservableCollection<eva_cat_actividades_enseñanza>();
        }


        public string DesActividadEnseñanza
        {
            get
            {
                return _DesActividadEnseñanza;
            }
            set
            {
                if(value != null)
                {
                    _DesActividadEnseñanza = value;
                    RaisePropertyChanged("DesActividadEnseñanza");
                }
            }
        }

        public ObservableCollection<eva_cat_actividades_enseñanza> SFDataGrid_ItemSource_Enseñanza
        {
            get
            {
                return _SFDataGrid_ItemSource_Enseñanza;
            }
        }
        public eva_cat_actividades_enseñanza SFDataGrid_SelectedItem_Enseñanza
        {
            get
            {
                return _SFDataGrid_SelectedItem_Enseñanza;
            }
            set
            {
                if (value != null)
                {
                    _SFDataGrid_SelectedItem_Enseñanza = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand MetAddEnseñanzaICommand
        {
            get { return _MetAddEnseñanzaICommand = _MetAddEnseñanzaICommand ?? new FicVmDelegateCommand(FicMetAddEnseñanza); }
        }
        public void FicMetAddEnseñanza()
        {
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmActividadEnseñanzaInsert>();
        }

        public ICommand MetViewEnseñanzaICommand
        {
            get
            {
                return _MetViewEnseñanzaICommand = _MetViewEnseñanzaICommand ?? new FicVmDelegateCommand(FicMetViewEnseñanza);
            }
        }
        public void FicMetViewEnseñanza()
        {
            if (SFDataGrid_SelectedItem_Enseñanza != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmActividadEnseñanzaDetalle>(SFDataGrid_SelectedItem_Enseñanza);
            }
        }

        public ICommand MetUpdateEnseñanzaICommand
        {
            get { return _MetUpdateEnseñanzaICommand = _MetUpdateEnseñanzaICommand ?? new FicVmDelegateCommand(FicMetUpdateEnseñanza); }
        }

        public void FicMetUpdateEnseñanza()
        {
            if (SFDataGrid_SelectedItem_Enseñanza != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmActividadEnseñanzaUpdate>(SFDataGrid_SelectedItem_Enseñanza);
            }
        }

        public ICommand MetRemoveEnseñanzaICommand
        {
            get { return _MetRemoveEnseñanzaICommand = _MetRemoveEnseñanzaICommand ?? new FicVmDelegateCommand(FicMetRemovePlaneacion); }
        }

        public async void FicMetRemovePlaneacion()
        {
            if (SFDataGrid_SelectedItem_Enseñanza != null)
            {

                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro?", "Si", "No");
                if (ask)
                {
                    var res = await IFicSrvActividadEnseñanza.FicMetRemoveEnseñanza(SFDataGrid_SelectedItem_Enseñanza);
                    if (res == "OK")
                    {
                        IFicSrvNavigationInventario.FicMetNavigateTo<FicVmActividadEnseñanza>();
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
                //Si se oprime el boton de filtrar por plantilla entonces no se debe de rellenar el grid sin filtros
                var source_local_inv = await this.IFicSrvActividadEnseñanza.FicMetGetListActividadEnseñanza();
                if (source_local_inv != null)
                {
                    _SFDataGrid_ItemSource_Enseñanza.Clear();
                    foreach (eva_cat_actividades_enseñanza enseñanza in source_local_inv)
                    {
                        _SFDataGrid_ItemSource_Enseñanza.Add(enseñanza);
                    }
                }//Llenar el grid
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
