using GestionPlaneacionDidacticaAPP.Data;
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
        private ICommand _FicMetAddSubtemaICommand;
        private ICommand _FicMetUpdateSubtemaICommand;
        private ICommand _FicMetViewSubtemaICommand;
        private ICommand _FicMetRemoveSubtemaICommand;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelIdAsignatura;
        private int _LabelIdTema;

        //Valor mandado de view padre a hija
        public object FicNavigationContextC { get; set; }

        
        public FicVmSubtemaList(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvSubtemas FicSrvSubtemas)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            this.FicSrvSubtemas = FicSrvSubtemas;

            _SFDataGrid_ItemSource_Subtema = new ObservableCollection<eva_planeacion_subtemas>();
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

        public int LabelIdTema
        {
            get { return _LabelIdTema; }
            set
            {
                if (value != null)
                {
                    _LabelIdTema = value;
                    RaisePropertyChanged("LabelIdTema");
                }
            }
        }



        public ICommand FicMetAddSubtemaICommand
        {
            get
            {
                return _FicMetAddSubtemaICommand = _FicMetAddSubtemaICommand ?? new FicVmDelegateCommand(FicMetAddSubtema);
            }
        }

        private void FicMetAddSubtema()
        {
            var source_eva_planeacion = FicNavigationContextC as eva_planeacion_temas;
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmSubtemaInsert>(source_eva_planeacion);
        }

        public ICommand FicMetViewSubtemaICommand
        {
            get
            {
                return _FicMetViewSubtemaICommand = _FicMetViewSubtemaICommand ?? new FicVmDelegateCommand(FicMetViewSubtema);
            }
        }

        private void FicMetViewSubtema()
        {
            if (SFDataGrid_SelectedItem_Subtema != null)
            {
                eva_planeacion_temas source_eva_planeacion = FicNavigationContextC as eva_planeacion_temas;
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmSubtemaView>(new object[] { SFDataGrid_SelectedItem_Subtema, source_eva_planeacion });
            }
        }

        public ICommand FicMetUpdateSubtemaICommand
        {
            get
            {
                return _FicMetUpdateSubtemaICommand = _FicMetUpdateSubtemaICommand ?? new FicVmDelegateCommand(FicMetUpdateSubtema);
            }
        }

        private void FicMetUpdateSubtema()
        {
            if (SFDataGrid_SelectedItem_Subtema != null)
            {
                eva_planeacion_temas source_eva_planeacion = FicNavigationContextC as eva_planeacion_temas;
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmSubtemasUpdate>(new object[] { SFDataGrid_SelectedItem_Subtema, source_eva_planeacion });
            }
        }

        public ICommand FicMetRemoveSubtemaICommand 
        {
            get
            {
                return _FicMetRemoveSubtemaICommand = _FicMetRemoveSubtemaICommand ?? new FicVmDelegateCommand(FicMetRemoveSubtema);
            }
        }

        private async void FicMetRemoveSubtema()
        {
            if (SFDataGrid_SelectedItem_Subtema != null)
            {

                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro?", "Si", "No");
                if (ask)
                {
                    var res = await FicSrvSubtemas.DeleteSubtema(SFDataGrid_SelectedItem_Subtema);
                    if (res == "OK")
                    {
                        eva_planeacion_temas source_eva_planeacion = FicNavigationContextC as eva_planeacion_temas;
                        IFicSrvNavigationInventario.FicMetNavigateTo<FicVmSubtemaList>(source_eva_planeacion);
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
                var source_eva_planeacion_temas = FicNavigationContextC as eva_planeacion_temas;
                if (source_eva_planeacion_temas != null)
                {
                    _LabelUsuario = FicGlobalValues.USUARIO;
                    _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
                    _LabelIdPlaneacion = source_eva_planeacion_temas.IdPlaneacion;
                    _LabelIdTema = source_eva_planeacion_temas.IdTema;

                    RaisePropertyChanged("LabelUsuario");
                    RaisePropertyChanged("LabelIdAsignatura");
                    RaisePropertyChanged("LabelIdPlaneacion");
                    RaisePropertyChanged("LabelIdTema");

                    var source_local_inv1 = await FicSrvSubtemas.MetGetListSubtemasTema(source_eva_planeacion_temas.IdTema);
                    if (source_local_inv1 != null)
                    {
                        _SFDataGrid_ItemSource_Subtema.Clear();
                        foreach (eva_planeacion_subtemas subtema in source_local_inv1)
                        {
                            _SFDataGrid_ItemSource_Subtema.Add(subtema);
                        }
                    }
                }
                else
                {
                    var source_local_inv2 = await FicSrvSubtemas.FicMetGetListSubtemas();
                    if (source_local_inv2 != null)
                    {
                        foreach (eva_planeacion_subtemas subtema in source_local_inv2)
                        {
                            _SFDataGrid_ItemSource_Subtema.Add(subtema);
                        }
                    }
                }
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
