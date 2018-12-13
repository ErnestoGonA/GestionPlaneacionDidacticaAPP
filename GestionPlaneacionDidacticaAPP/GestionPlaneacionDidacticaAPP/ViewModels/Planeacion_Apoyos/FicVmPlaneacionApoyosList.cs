using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Asignatura;
using GestionPlaneacionDidacticaAPP.ViewModels.Apoyos_Didacticos;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Planeacion_Apoyos
{
    public class FicVmPlaneacionApoyosList : INotifyPropertyChanged
    {
        //Data of the grid
        public ObservableCollection<eva_planeacion_apoyos> _SFDataGrid_ItemSource_Planeacion_Apoyos;
        public eva_planeacion_apoyos _SFDataGrid_SelectedItem_Planeacion_Apoyos;

        //Buttons
        private ICommand _MetAddPlaneacionApoyosICommand, _MetUpdatePlaneacionApoyosICommand, _MetViewPlaneacionApoyosICommand, _MetRemovePlaneacionApoyosICommand, _MetPlaneacionApoyosICommand;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvPlaneacionApoyos IFicSrvPlaneacionApoyos;
        private IFicSrvAsignatura IFicSrvAsignatura;

        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelIdAsignatura;

        public object FicNavigationContextC { get; set; }

        public FicVmPlaneacionApoyosList(IFicSrvNavigationInventario ificSrvNavigationInventario, IFicSrvPlaneacionApoyos ificSrvPlaneacionApoyos, IFicSrvAsignatura ificSrvAsignatura)
        {
            this.IFicSrvNavigationInventario = ificSrvNavigationInventario;
            this.IFicSrvPlaneacionApoyos = ificSrvPlaneacionApoyos;
            this.IFicSrvAsignatura = ificSrvAsignatura;

            _SFDataGrid_ItemSource_Planeacion_Apoyos = new ObservableCollection<eva_planeacion_apoyos>();
        }

        public ObservableCollection<eva_planeacion_apoyos> SFDataGrid_ItemSource_Planeacion_Apoyos
        {
            get
            {
                return _SFDataGrid_ItemSource_Planeacion_Apoyos;
            }
        }

        public eva_planeacion_apoyos SFDataGrid_SelectedItem_Planeacion_Apoyos
        {
            get
            {
                return _SFDataGrid_SelectedItem_Planeacion_Apoyos;
            }
            set
            {
                if (value != null)
                {
                    _SFDataGrid_SelectedItem_Planeacion_Apoyos = value;
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

        public ICommand FicMetAddPlaneacionApoyoICommand
        {
            get
            {
                return _MetAddPlaneacionApoyosICommand = _MetAddPlaneacionApoyosICommand ?? new FicVmDelegateCommand(FicMetAddPlaneacionApoyo);
            }
        }

        private void FicMetAddPlaneacionApoyo()
        {
            var source_eva_planeacion = FicNavigationContextC as eva_planeacion;
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacionApoyosInsert>(source_eva_planeacion);
        }

        public ICommand MetPlaneacionApoyosICommand
        {
            get
            {
                return _MetPlaneacionApoyosICommand = _MetPlaneacionApoyosICommand ?? new FicVmDelegateCommand(FicMetPlaneacionApoyos);
            }
        }

        private void FicMetPlaneacionApoyos()
        {
            
                IFicSrvNavigationInventario.FicMetNavigateTo<VmApoyosDidacticosList>();
            
        }

        public async void OnAppearing()
        {
            try
            {
                var source_eva_planeacion_apoyos = FicNavigationContextC as eva_planeacion;
                if (source_eva_planeacion_apoyos != null)
                {
                    _LabelUsuario = FicGlobalValues.USUARIO;
                    _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
                    _LabelIdPlaneacion = source_eva_planeacion_apoyos.IdPlaneacion;

                    RaisePropertyChanged("LabelUsuario");
                    RaisePropertyChanged("LabelIdAsignatura");
                    RaisePropertyChanged("LabelIdPlaneacion");
                    RaisePropertyChanged("LabelIdTema");

                    var source_local_inv1 = await IFicSrvPlaneacionApoyos.MetGetListApoyosPlaneacion(source_eva_planeacion_apoyos);
                    if (source_local_inv1 != null)
                    {
                        _SFDataGrid_ItemSource_Planeacion_Apoyos.Clear();
                        foreach (eva_planeacion_apoyos apoyos in source_local_inv1)
                        {
                            _SFDataGrid_ItemSource_Planeacion_Apoyos.Add(apoyos);
                        }
                    }
                }
                else
                {
                    var source_local_inv2 = await IFicSrvPlaneacionApoyos.MetGetListPlaneacionAPoyos();
                    if (source_local_inv2 != null)
                    {
                        foreach (eva_planeacion_apoyos apoyos in source_local_inv2)
                        {
                            _SFDataGrid_ItemSource_Planeacion_Apoyos.Add(apoyos);
                        }
                    }//Llenar el grid
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
