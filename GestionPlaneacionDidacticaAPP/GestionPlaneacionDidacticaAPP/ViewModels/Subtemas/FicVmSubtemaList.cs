using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Subtemas;
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

namespace GestionPlaneacionDidacticaAPP.ViewModels.Subtemas
{
    public class FicVmSubtemaList : INotifyPropertyChanged
    {
        //Data of the grid
        public ObservableCollection<eva_planeacion_subtemas> _SFDataGrid_ItemSource_Subtema;
        public eva_planeacion_subtemas _SFDataGrid_SelectedItem_Subtema;
        
        //Interfaces
        private IFicSrvSubtemas FicSrvSubtemas;
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;

        //Botones
        private ICommand _MetRegesarSubtemasListICommand;

        //Valor mandado de view padre a hija
        public object[] NavigationContextC { get; set; }

        


        public FicVmSubtemaList(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvSubtemas FicSrvSubtemas)
        {
            this.IFicSrvNavigationInventario = ficSrvNavigationInventario;
            this.FicSrvSubtemas = FicSrvSubtemas;

            _SFDataGrid_ItemSource_Subtema = new ObservableCollection<eva_planeacion_subtemas>();
        }


        public async void OnAppearing()
        {
            try
            {
                var source_local_inv = await FicSrvSubtemas.FicMetGetListSubtemas();
                if (source_local_inv != null)
                {
                    foreach (eva_planeacion_subtemas subtemas in source_local_inv)
                    {
                        _SFDataGrid_ItemSource_Subtema.Add(subtemas);
                    }
                }//Llenar el grid
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }


        public ObservableCollection<eva_planeacion_subtemas> SFDataGrid_ItemSource_Subtema
        {
            get
            {
                return _SFDataGrid_ItemSource_Subtema;
            }
        }
        public eva_planeacion_subtemas SFDataGrid_SelectedItem_Subtema 
        {
            get
            {
                return _SFDataGrid_SelectedItem_Subtema;
            }
            set
            {
                if (value != null)
                {
                    _SFDataGrid_SelectedItem_Subtema = value;
                    RaisePropertyChanged();
                }
            }
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
