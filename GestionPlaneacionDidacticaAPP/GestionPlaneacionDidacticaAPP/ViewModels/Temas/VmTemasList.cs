using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Temas
{
    public class VmTemasList: INotifyPropertyChanged
    {

        //Data of the grid
        public ObservableCollection<eva_planeacion_temas> _SFDataGrid_ItemSource_Temas;       
        public eva_planeacion_temas _SFDataGrid_SelectedItem_Temas;

        //Buttons
        private ICommand _MetAddTemaICommand, _MetUpdateTemaICommand, MetViewTemaICommand, _MetRemoveTemaICommand;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private ISrvTemas ISrvTemas;

        public VmTemasList(IFicSrvNavigationInventario ficSrvNavigationInventario, ISrvTemas srvTemas)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            ISrvTemas = srvTemas;

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

        //public ICommand MetAddTemaICommand
        //{
        //    get
        //    {
        //        return _MetAddTemaICommand = _MetAddTemaICommand ?? new FicVmDelegateCommand(MetAddTema);
        //    }
        //}

        //private void MetAddTema()
        //{
        //    IFicSrvNavigationInventario.FicMetNavigateTo<VmTemasInsert>();
        //}

        public async void OnAppearing()
        {
            try
            {
                var source_local_inv = await ISrvTemas.MetGetListTemas();
                if (source_local_inv != null)
                {
                    foreach (eva_planeacion_temas tema in source_local_inv)
                    {
                        _SFDataGrid_ItemSource_Temas.Add(tema);
                    }
                }//Llenar el grid
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//Sobrecarga el metodo OnAppearing() de la view

        public async void OnAppearing(int IdPlaneacion)
        {
            try
            {
                var source_local_inv = await ISrvTemas.MetGetListTemas(IdPlaneacion);
                if (source_local_inv != null)
                {
                    foreach (eva_planeacion_temas tema in source_local_inv)
                    {
                        _SFDataGrid_ItemSource_Temas.Add(tema);
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
