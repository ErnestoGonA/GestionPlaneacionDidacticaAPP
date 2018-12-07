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
        private ICommand _MetAddPlaneacionICommand, _MetUpdatePlaneacionICommand, MetViewPlaneacionICommand, _MetRemovePlaneacionICommand;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private FicISrvPlaneacion FicISrvPlaneacion;
        private IFicSrvPlaneacionInsert IFicSrvPlaneacionInsert;

        public FicVmPlaneacion(IFicSrvNavigationInventario ficSrvNavigationInventario, FicISrvPlaneacion FicISrvPlaneacion,
            IFicSrvPlaneacionInsert IFicSrvPlaneacionInsert)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            this.FicISrvPlaneacion = FicISrvPlaneacion;
            this.IFicSrvPlaneacionInsert = IFicSrvPlaneacionInsert;

            _SFDataGrid_ItemSource_Planeacion = new ObservableCollection<eva_planeacion>();
            _ListAsignatura = GetListAsignatura().Result;
            _AsIndex = FicGlobalValues.ASIGNATURA_INDEX;
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
            }
        }

        public ObservableCollection<eva_planeacion> SFDataGrid_ItemSource_Planeacion
        {
            get
            {
                return _SFDataGrid_ItemSource_Planeacion;
            }
        }
        public eva_planeacion SFDataGrud_SelectedItem_Planeacion
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

        public async void OnAppearing()
        {
            try
            {
                var source_local_inv = await FicISrvPlaneacion.FicMetGetListPlaneacion();
                if (source_local_inv != null)
                {
                    foreach (eva_planeacion apoyosdidacticos in source_local_inv)
                    {
                        _SFDataGrid_ItemSource_Planeacion.Add(apoyosdidacticos);
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
