using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.Interfaces.Apredizaje;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Aprendizaje
{
    public class FicVmAprendizajeList : INotifyPropertyChanged
    {
        public ObservableCollection<eva_planeacion_aprendizaje> _FicSfDataGrid_ItemSource_Aprendizaje;
        public eva_planeacion_aprendizaje _FicSfDataGrid_SelectItem_Aprendizaje;
        private ICommand _FicMetAddAprendizajeICommand;
        private ICommand _FicMetUpdateAprendizajeICommand;
        private ICommand _FicMetRemoveAprendizajeICommand;
        private ICommand _FicMetViewAprendizajeICommand;

        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvAprendizaje IFicSrvAprendizaje;

        public FicVmAprendizajeList(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvAprendizaje iFicSrvAprendizaje)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvAprendizaje = iFicSrvAprendizaje;
            _FicSfDataGrid_ItemSource_Aprendizaje = new ObservableCollection<eva_planeacion_aprendizaje>();
        }

        public ObservableCollection<eva_planeacion_aprendizaje> FicSfDataGrid_ItemSource_Aprendizaje
        {
            get { return _FicSfDataGrid_ItemSource_Aprendizaje; }
        }

        public eva_planeacion_aprendizaje FicSfDataGrid_SelectItem_Aprendizaje
        {
            get { return _FicSfDataGrid_SelectItem_Aprendizaje; }
            set
            {
                if(value != null)
                {
                    _FicSfDataGrid_SelectItem_Aprendizaje = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand FicMetAddAprendizajeICommand
        {
            get
            {
                return _FicMetAddAprendizajeICommand = _FicMetAddAprendizajeICommand ?? new FicVmDelegateCommand(FicMetAprendizajeAdd);
            }
        }
        private void FicMetAprendizajeAdd()
        {
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajeInsert>();
        }

        public ICommand FicMetUpdateAprendizajeICommand
        {
            get
            {
                return _FicMetUpdateAprendizajeICommand = _FicMetUpdateAprendizajeICommand ?? new FicVmDelegateCommand(FicMetUpdateAprendizaje);
            }
        }
        private void FicMetUpdateAprendizaje()
        {
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajeUpdate>();
        }

        public ICommand FicMetViewAprendizajeICommand
        {
            get
            {
                return _FicMetViewAprendizajeICommand = _FicMetViewAprendizajeICommand ?? new FicVmDelegateCommand(FicMetViewAprendizaje);
            }
        }
        private void FicMetViewAprendizaje()
        {
            if (FicSfDataGrid_SelectItem_Aprendizaje != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajeDetail>(FicSfDataGrid_SelectItem_Aprendizaje);
            }
        }

        public ICommand FicMetRemoveAprendizajeICommand
        {
            get
            {
                return _FicMetRemoveAprendizajeICommand = _FicMetRemoveAprendizajeICommand ?? new FicVmDelegateCommand(FicMetRemoveAprendizaje);
            }
        }
        private async void FicMetRemoveAprendizaje()
        {
            if (FicSfDataGrid_SelectItem_Aprendizaje != null)
            {

                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro que esea eliminar?", "Si", "No");
                if (ask)
                {
                    var res = await IFicSrvAprendizaje.RemoveAprendizaje(FicSfDataGrid_SelectItem_Aprendizaje);                        
                    if (res == "OK")
                    {
                        IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajeList>();
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
                var source_local_ap = await IFicSrvAprendizaje.MetGetListAprendizaje();                    
                if (source_local_ap != null)
                {
                    foreach (eva_planeacion_aprendizaje ap in source_local_ap)
                    {
                        _FicSfDataGrid_ItemSource_Aprendizaje.Add(ap);
                    }//llenar grid
                }

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        #region
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
