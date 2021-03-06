﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Apoyos_Didacticos;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Apoyos_Didacticos
{
    public class VmApoyosDidacticosList : INotifyPropertyChanged
    {
        //Data of the grid
        public ObservableCollection<eva_cat_apoyos_didacticos> _SFDataGrid_ItemSource_ApoyosDidacticos;
        public List<eva_cat_apoyos_didacticos> _SFDataGrid_ItemSource_ApoyosDidacticos_AUX;
        public eva_cat_apoyos_didacticos _SFDataGrid_SelectedItem_ApoyosDidacticos;

        //Buttons
        private ICommand _MetAddApoyoDidacticoICommand, _MetUpdateApoyoDidacticoICommand, _MetViewApoyoDidacticoICommand, _MetRemoveApoyoDidacticoICommand;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private ISrvApoyosDidacticos ISrvApoyosDidacticos;

        public VmApoyosDidacticosList(IFicSrvNavigationInventario ficSrvNavigationInventario, ISrvApoyosDidacticos srvApoyosDidacticos)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            ISrvApoyosDidacticos = srvApoyosDidacticos;

            _SFDataGrid_ItemSource_ApoyosDidacticos = new ObservableCollection<eva_cat_apoyos_didacticos>();
            _SFDataGrid_ItemSource_ApoyosDidacticos_AUX = new List<eva_cat_apoyos_didacticos>();
        }

        public ObservableCollection<eva_cat_apoyos_didacticos> SFDataGrid_ItemSource_ApoyosDidacticos
        {
            get
            {
                return _SFDataGrid_ItemSource_ApoyosDidacticos;
            }
        }

        public eva_cat_apoyos_didacticos SFDataGrid_SelectedItem_ApoyosDidacticos
        {
            get
            {
                return _SFDataGrid_SelectedItem_ApoyosDidacticos;
            }
            set
            {
                if (value != null)
                {
                    _SFDataGrid_SelectedItem_ApoyosDidacticos = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand MetAddApoyoDidacticoICommand
        {
            get
            {
                return _MetAddApoyoDidacticoICommand = _MetAddApoyoDidacticoICommand ?? new FicVmDelegateCommand(MetAddApoyoDidactico);
            }
        }

        private void MetAddApoyoDidactico()
        {
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmApoyosDidacticosInsert>();
        }

        public ICommand MetUpdateApoyoDidacticoICommand
        {
            get
            {
                return _MetUpdateApoyoDidacticoICommand = _MetUpdateApoyoDidacticoICommand ?? new FicVmDelegateCommand(MetUpdateApoyoDidactico);
            }
        }

        private void MetUpdateApoyoDidactico()
        {
            
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmApoyosDidacticosUpdate>(SFDataGrid_SelectedItem_ApoyosDidacticos);

        }

        public ICommand FicMetViewApoyoDidacticoICommand
        {
            get
            {
                return _MetViewApoyoDidacticoICommand = _MetViewApoyoDidacticoICommand ?? new FicVmDelegateCommand(FicMetViewApoyoDidactico);
            }
        }

        private void FicMetViewApoyoDidactico()
        {
            if (SFDataGrid_SelectedItem_ApoyosDidacticos != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmApoyosDidacticosView>(SFDataGrid_SelectedItem_ApoyosDidacticos);
            }
        }

        public ICommand FicMetRemoveApoyoDidacticoICommand
        {
            get
            {
                return _MetRemoveApoyoDidacticoICommand = _MetRemoveApoyoDidacticoICommand ?? new FicVmDelegateCommand(FicMetRemoveApoyoDidactico);
            }
        }

        private async void FicMetRemoveApoyoDidactico()
        {
            if (SFDataGrid_SelectedItem_ApoyosDidacticos != null)
            {

                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro?", "Si", "No");
                if (ask)
                {
                    var res = await ISrvApoyosDidacticos.DeleteApoyoDidactico(SFDataGrid_SelectedItem_ApoyosDidacticos);
                    if (res == "OK")
                    {
                        await new Page().DisplayAlert("MENSAJE", "ELIMINADO CORRECTAMENTE", "OK");
                        IFicSrvNavigationInventario.FicMetNavigateTo<VmApoyosDidacticosList>();
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
                var source_local_inv = await ISrvApoyosDidacticos.MetGetListApoyosDidacticos();
                if (source_local_inv != null)
                {
                    foreach (eva_cat_apoyos_didacticos apoyosdidacticos in source_local_inv)
                    {
                        _SFDataGrid_ItemSource_ApoyosDidacticos.Add(apoyosdidacticos);
                        _SFDataGrid_ItemSource_ApoyosDidacticos_AUX.Add(apoyosdidacticos);
                    }
                }//Llenar el grid
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Sobrecarga el metodo OnAppearing() de la view

        internal void FilterTextChange(string newTextValue)
        {
            //_SFDataGrid_ItemSource_ApoyosDidacticos.Clear();
            //foreach (eva_planeacion_apoyos apoyo in _SFDataGrid_ItemSource_ApoyosDidacticos_AUX)
            //{
            //    if (apoyo.)
            //    {
            //        _SFDataGrid_ItemSource_Temas.Add(tema);
            //    }
            //}
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
