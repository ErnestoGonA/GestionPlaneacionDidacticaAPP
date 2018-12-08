using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using System.Threading.Tasks;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Planeacion
{
    public class FicVmPlaneacion : INotifyPropertyChanged
    {
        //Data of the grid
        public ObservableCollection<eva_planeacion> _SFDataGrid_ItemSource_Planeacion;
        public eva_planeacion _SFDataGrid_SelectedItem_Planeacion;
        public List<string> _ListAsignatura;
        public string _Usuario, _Asignatura;
        public int _UsIndex = FicGlobalValues.USUARIO_INDEX;
        public Int16 _AsIndex;

        //Buttons
        private ICommand _MetAddPlaneacionICommand, _MetUpdatePlaneacionICommand, _MetViewPlaneacionICommand, _MetRemovePlaneacionICommand;
        //Navigation to lists
        private ICommand _FicMetNavigateToTemasICommand;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private FicISrvPlaneacion FicISrvPlaneacion;
        private IFicSrvPlaneacionInsert IFicSrvPlaneacionInsert;
        private IFicSrvPlaneacionUpdate IFicSrvPlaneacionUpdate;

        public FicVmPlaneacion(IFicSrvNavigationInventario ficSrvNavigationInventario, FicISrvPlaneacion FicISrvPlaneacion,
            IFicSrvPlaneacionInsert IFicSrvPlaneacionInsert,
            IFicSrvPlaneacionUpdate IFicSrvPlaneacionUpdate)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            this.FicISrvPlaneacion = FicISrvPlaneacion;
            this.IFicSrvPlaneacionInsert = IFicSrvPlaneacionInsert;
            this.IFicSrvPlaneacionUpdate = IFicSrvPlaneacionUpdate;

            _SFDataGrid_ItemSource_Planeacion = new ObservableCollection<eva_planeacion>();
            _ListAsignatura = GetListAsignatura().Result;
        }

        public async Task<List<string>> GetListAsignatura()
        {
            var listaAsignaturas = await FicISrvPlaneacion.FicMetGetListAsignatura();
            List<string> aux = new List<string>();
            if (listaAsignaturas != null)
            {
                foreach (eva_cat_asignaturas asignaturas in listaAsignaturas)
                {
                    aux.Add(asignaturas.ClaveAsignatura);
                }
                return aux;
            }
            return null;
        }

        public List<string> ListAsignatura
        {
            get
            {
                return _ListAsignatura;
            }
            set
            {
                if(value != null)
                {
                    _ListAsignatura = value;
                    RaisePropertyChanged("ListAsignatura");
                }
            }
        }

        public string Usuario
        {
            get
            {
                return _Usuario;
            }
            set
            {
                if(value != null)
                {
                    _Usuario = value;
                    FicGlobalValues.USUARIO = value;
                    RaisePropertyChanged("Usuario");
                }
            } 
        }
        public string Asignatura
        {
            get
            {
                return _Asignatura;
            }
            set
            {
                if(value != null)
                {
                    _Asignatura = value;
                    FicGlobalValues.ASIGNATURA = value;
                    RaisePropertyChanged("Asignatura");
                }
            }
        }

        public int UsIndex
        {
            get
            {
                return _UsIndex;
            }
            set
            {
                _UsIndex = FicGlobalValues.USUARIO_INDEX = value;
            }
        }

        public Int16 AsIndex
        {
            get
            {
                return _AsIndex;
            }
            set
            {
                _AsIndex = FicGlobalValues.ASIGNATURA_INDEX = value;
                RaisePropertyChanged("AsIndex");
            }
        }

        public ObservableCollection<eva_planeacion> SFDataGrid_ItemSource_Planeacion
        {
            get
            {
                return _SFDataGrid_ItemSource_Planeacion;
            }
        }
        public eva_planeacion SFDataGrid_SelectedItem_Planeacion
        {
            get
            {
                return _SFDataGrid_SelectedItem_Planeacion;
            }
            set
            {
                if (value != null)
                {
                    _SFDataGrid_SelectedItem_Planeacion = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand MetAddPlaneacionICommand
        {
            get { return _MetAddPlaneacionICommand = _MetAddPlaneacionICommand ?? new FicVmDelegateCommand(FicMetAddPlaneacion); }
        }
        public void FicMetAddPlaneacion()
        {
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacionInsert>();
        }
        
        public ICommand MetViewPlaneacionICommand
        {
            get
            {
                return _MetViewPlaneacionICommand = _MetViewPlaneacionICommand ?? new FicVmDelegateCommand(FicMetViewPlaneacion);
            }
        }
        public void FicMetViewPlaneacion()
        {
            if(SFDataGrid_SelectedItem_Planeacion != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacionView>(SFDataGrid_SelectedItem_Planeacion);
            }
        }

        public ICommand MetUpdatePlaneacionICommand
        {
            get { return _MetUpdatePlaneacionICommand = _MetUpdatePlaneacionICommand ?? new FicVmDelegateCommand(FicMetUpdatePlaneacion); }
        }

        public void FicMetUpdatePlaneacion()
        {
            if(SFDataGrid_SelectedItem_Planeacion != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacionUpdate>(SFDataGrid_SelectedItem_Planeacion);
            }
        }

        public ICommand FicMetNavigateToTemasICommand
        {
            get { return _FicMetNavigateToTemasICommand = _FicMetNavigateToTemasICommand ?? new FicVmDelegateCommand(FicMetNavigateToTemas); }
        }

        public void FicMetNavigateToTemas()
        {
            if (SFDataGrid_SelectedItem_Planeacion != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmTemasList>(SFDataGrid_SelectedItem_Planeacion);
            }
                            
        }

        public async void OnAppearing()
        {
            try
            {
                var source_local_inv = await FicISrvPlaneacion.FicMetGetListPlaneacion();
                if (source_local_inv != null)
                {
                    _SFDataGrid_ItemSource_Planeacion.Clear();
                    foreach (eva_planeacion apoyosdidacticos in source_local_inv)
                    {
                        _SFDataGrid_ItemSource_Planeacion.Add(apoyosdidacticos);
                    }
                    FicGlobalValues.NEXTIDPLANEACION = _SFDataGrid_ItemSource_Planeacion.Count + 1;
                }//Llenar el grid
                _AsIndex = FicGlobalValues.ASIGNATURA_INDEX;
                RaisePropertyChanged("AsIndex");
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
