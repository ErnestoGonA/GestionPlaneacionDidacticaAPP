using System;
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
        public eva_cat_apoyos_didacticos _SFDataGrid_SelectedItem_ApoyosDidacticos;

        //Buttons
        private ICommand _MetAddApoyoDidacticoICommand, _MetUpdateApoyoDidacticoICommand, MetViewApoyoDidacticoICommand, _MetRemoveApoyoDidacticoICommand;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private ISrvApoyosDidacticos ISrvApoyosDidacticos;

        public VmApoyosDidacticosList(IFicSrvNavigationInventario ficSrvNavigationInventario, ISrvApoyosDidacticos srvApoyosDidacticos)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            ISrvApoyosDidacticos = srvApoyosDidacticos;

            _SFDataGrid_ItemSource_ApoyosDidacticos = new ObservableCollection<eva_cat_apoyos_didacticos>();
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
