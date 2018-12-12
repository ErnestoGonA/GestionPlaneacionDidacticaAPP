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
        public string _Usuario, _Asignatura,_PeriodoItem;
        public bool _Plantilla;
        public int _UsIndex = FicGlobalValues.USUARIO_INDEX;
        public Int16 _AsIndex;
        public bool Filtrado = false;
        public Int16 _PeriodoId = FicGlobalValues.PERIODO_INDEX;
        private List<string> _Periodos;

        //Buttons
        private ICommand _MetAddPlaneacionICommand, _MetUpdatePlaneacionICommand, _MetViewPlaneacionICommand, _MetRemovePlaneacionICommand, _FiltrarPlantillaCommand, _GuardarComoCommand;
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
            _Periodos = GetListPeriodos().Result;
        }

        public async Task<List<string>> GetListPeriodos()
        {
            try
            {
                var periodos = await FicISrvPlaneacion.GetListPeriodos();
                if (periodos != null)
                {
                    List<string> aux = new List<string>();
                    foreach (cat_periodos per in periodos)
                    {
                        aux.Add(per.ClavePeriodo);
                    }
                    return aux;
                }//Llenar el grid
                return null;
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
                return null;
            }

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

        public Int16 PeriodoId
        {
            get
            {
                return _PeriodoId;
            }
            set
            {
                _PeriodoId = value;
            }
        }

        public List<string> Periodos
        {
            get { return _Periodos; }
            set
            {
                _Periodos = value;
                RaisePropertyChanged("Periodos");
            }
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

        public string PeriodoItem
        {
            get
            {
                return _PeriodoItem;
            }
            set
            {
                if (value != null)
                {
                    _PeriodoItem = value;
                    FicGlobalValues.PERIODO = value;
                    RaisePropertyChanged("PeriodoItem");
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
        public bool Plantilla
        {
            get
            {
                return _Plantilla;
            }
            set
            {
                _Plantilla = value;
                RaisePropertyChanged("Plantilla");
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

        public ICommand MetRemovePlaneacionICommand
        {
            get { return _MetRemovePlaneacionICommand = _MetRemovePlaneacionICommand ?? new FicVmDelegateCommand(FicMetRemovePlaneacion); }
        }
        
        public async void FicMetRemovePlaneacion()
        {
            if (SFDataGrid_SelectedItem_Planeacion != null)
            {

                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro?", "Si", "No");
                if (ask)
                {
                    var res = await FicISrvPlaneacion.FicMetRemovePlaneacion(SFDataGrid_SelectedItem_Planeacion);
                    if (res == "OK")
                    {
                        IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacion>();
                    }
                    else
                    {
                        await new Page().DisplayAlert("DELETE", res.ToString(), "OK");
                    }
                }
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

        public ICommand FiltrarPlantillaCommand
        {
            get { return _FiltrarPlantillaCommand = _FiltrarPlantillaCommand ?? new FicVmDelegateCommand(FicMetFiltrarPlantilla); }
        }
        public async void FicMetFiltrarPlantilla()
        {
            var source_local_inv = await FicISrvPlaneacion.FicMetGetListPlaneacionPlantilla(FicGlobalValues.ASIGNATURA_INDEX+1,_Plantilla,(Int16)(FicGlobalValues.PERIODO_INDEX+1));
            if (source_local_inv != null)
            {
                _SFDataGrid_ItemSource_Planeacion.Clear();
                int planeacionCount = 0;
                foreach (eva_planeacion apoyosdidacticos in source_local_inv)
                {
                    planeacionCount++;
                    _SFDataGrid_ItemSource_Planeacion.Add(apoyosdidacticos);
                }
                int i = 0;
                foreach (eva_planeacion apoyosdidacticos in source_local_inv)
                {
                    i++;
                    if (planeacionCount == i)
                    {
                        FicGlobalValues.NEXTIDPLANEACION = apoyosdidacticos.IdPlaneacion + 1;
                    }
                }
            }//Llenar el grid
        }

        public ICommand GuardarComoCommand
        {
            get { return _GuardarComoCommand = _GuardarComoCommand ?? new FicVmDelegateCommand(FicMetGuardarComoPlaneacion); }
        }
        public void FicMetGuardarComoPlaneacion()
        {
            if (SFDataGrid_SelectedItem_Planeacion != null)
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacionGuardarComo>(SFDataGrid_SelectedItem_Planeacion);
            }
        }


        public async void OnAppearing()
        {
            try
            {
                //Si se oprime el boton de filtrar por plantilla entonces no se debe de rellenar el grid sin filtros
                if (!Filtrado)
                {
                    var source_local_inv = await FicISrvPlaneacion.FicMetGetListPlaneacion();
                    if (source_local_inv != null)
                    {
                        _SFDataGrid_ItemSource_Planeacion.Clear();
                        int planeacionCount = 0;
                        foreach (eva_planeacion apoyosdidacticos in source_local_inv)
                        {
                            planeacionCount++;
                            _SFDataGrid_ItemSource_Planeacion.Add(apoyosdidacticos);
                        }
                        int i = 0;
                        foreach (eva_planeacion apoyosdidacticos in source_local_inv)
                        {
                            i++;
                            if (planeacionCount == i)
                            {
                                FicGlobalValues.NEXTIDPLANEACION = apoyosdidacticos.IdPlaneacion + 1;
                            }
                        }
                        if(planeacionCount == 0)
                        {
                            FicGlobalValues.NEXTIDPLANEACION = 1;
                        }
                    }//Llenar el grid
                }
                _AsIndex = FicGlobalValues.ASIGNATURA_INDEX;
                _PeriodoId = FicGlobalValues.PERIODO_INDEX;
                RaisePropertyChanged("AsIndex");
                RaisePropertyChanged("PeriodoId");
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
