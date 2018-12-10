﻿using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
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
using GestionPlaneacionDidacticaAPP.Services.Enseñanza;
using GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Enseñanza
{
    public class FicVmEnseñanzaList : INotifyPropertyChanged
    {
        //Data of the grid
        public ObservableCollection<EnseñanzaLista> _SFDataGrid_ItemSource_Enseñanza;
        public EnseñanzaLista _SFDataGrid_SelectedItem_Enseñanza;
        public bool _Plantilla;
        public int _UsIndex = FicGlobalValues.USUARIO_INDEX;
        public Int16 _AsIndex;
        public bool Filtrado = false;

        //Buttons
        private ICommand _MetAddEnseñanzaICommand, _MetUpdatePlaneacionICommand, _MetViewPlaneacionICommand, _MetRemovePlaneacionICommand, _FiltrarPlantillaCommand, _GuardarComoCommand;
        //Navigation to lists
        private ICommand _FicMetNavigateToTemasICommand;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvEnseñanzaList IFicSrvEnseñanzaList;

        public FicVmEnseñanzaList(IFicSrvNavigationInventario ficSrvNavigationInventario,
            IFicSrvEnseñanzaList IFicSrvEnseñanzaList)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            this.IFicSrvEnseñanzaList = IFicSrvEnseñanzaList;

            _SFDataGrid_ItemSource_Enseñanza = new ObservableCollection<EnseñanzaLista>();
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

        public ObservableCollection<EnseñanzaLista> SFDataGrid_ItemSource_Enseñanza
        {
            get
            {
                return _SFDataGrid_ItemSource_Enseñanza;
            }
        }
        public EnseñanzaLista SFDataGrid_SelectedItem_Enseñanza
        {
            get
            {
                return _SFDataGrid_SelectedItem_Enseñanza;
            }
            set
            {
                if (value != null)
                {
                    _SFDataGrid_SelectedItem_Enseñanza = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand MetAddEnseñanzaICommand
        {
            get { return _MetAddEnseñanzaICommand = _MetAddEnseñanzaICommand ?? new FicVmDelegateCommand(FicMetAddEnseñanza); }
        }
        public void FicMetAddEnseñanza()
        {
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmEnseñanzaInsert>();
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
            if (SFDataGrid_SelectedItem_Enseñanza != null)
            {
                //IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacionView>(SFDataGrid_SelectedItem_Planeacion);
            }
        }

        public ICommand MetUpdatePlaneacionICommand
        {
            get { return _MetUpdatePlaneacionICommand = _MetUpdatePlaneacionICommand ?? new FicVmDelegateCommand(FicMetUpdatePlaneacion); }
        }

        public void FicMetUpdatePlaneacion()
        {
            if (SFDataGrid_SelectedItem_Enseñanza != null)
            {
                //IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacionUpdate>(SFDataGrid_SelectedItem_Planeacion);
            }
        }

        public ICommand MetRemovePlaneacionICommand
        {
            get { return _MetRemovePlaneacionICommand = _MetRemovePlaneacionICommand ?? new FicVmDelegateCommand(FicMetRemovePlaneacion); }
        }

        public async void FicMetRemovePlaneacion()
        {
            if (SFDataGrid_SelectedItem_Enseñanza != null)
            {

                var ask = await new Page().DisplayAlert("ALERTA!", "Seguro?", "Si", "No");
                if (ask)
                {
                    /*var res = await FicISrvPlaneacion.FicMetRemovePlaneacion(SFDataGrid_SelectedItem_Enseñanza);
                    if (res == "OK")
                    {
                        IFicSrvNavigationInventario.FicMetNavigateTo<FicVmEnseñanzaList>();
                    }
                    else
                    {
                        await new Page().DisplayAlert("DELETE", res.ToString(), "OK");
                    }*/
                }
            }
        }

        public ICommand FicMetNavigateToTemasICommand
        {
            get { return _FicMetNavigateToTemasICommand = _FicMetNavigateToTemasICommand ?? new FicVmDelegateCommand(FicMetNavigateToTemas); }
        }

        public void FicMetNavigateToTemas()
        {
            if (SFDataGrid_SelectedItem_Enseñanza != null)
            {
                //IFicSrvNavigationInventario.FicMetNavigateTo<FicVmTemasList>(SFDataGrid_SelectedItem_Planeacion);
            }

        }


        public async void OnAppearing()
        {
            try
            {
                //Si se oprime el boton de filtrar por plantilla entonces no se debe de rellenar el grid sin filtros
                var source_local_inv = await this.IFicSrvEnseñanzaList.FicMetGetListEnseñanza();
                if (source_local_inv != null)
                {
                    _SFDataGrid_ItemSource_Enseñanza.Clear();
                    foreach (eva_planeacion_enseñanza enseñanza in source_local_inv)
                    {
                        string Asignatura = this.IFicSrvEnseñanzaList.FicMetGetAsignatura(enseñanza.IdAsignatura).Result.NombreCorto;
                        string Planeacion = this.IFicSrvEnseñanzaList.FicMetGetPlaneacion(enseñanza.IdPlaneacion).Result.ReferenciaNorma;
                        string Tema = this.IFicSrvEnseñanzaList.FicMetGetTema(enseñanza.IdTema).Result.DesTema;
                        string Competencia = this.IFicSrvEnseñanzaList.FicMetGetCompetencia(enseñanza.IdCompetencia).Result.DesCompetencia;
                        EnseñanzaLista aux = new EnseñanzaLista(Asignatura,Planeacion,Tema,Competencia,enseñanza);
                        _SFDataGrid_ItemSource_Enseñanza.Add(aux);
                    }
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
    public class EnseñanzaLista
    {
        public string Asignatura { get; set; }
        public string Planeacion { get; set; }
        public string Tema { get; set; }
        public string Competencia { get; set; }
        public eva_planeacion_enseñanza eva_planeacion_enseñanza { get; set; }
        public EnseñanzaLista(string Asignatura,string Planeacion,string Tema,string Competencia,eva_planeacion_enseñanza eva_planeacion_enseñanza)
        {
            this.Asignatura = Asignatura;
            this.Planeacion = Planeacion;
            this.Tema = Tema;
            this.Competencia = Competencia;
            this.eva_planeacion_enseñanza = eva_planeacion_enseñanza;
        }

    }

}
