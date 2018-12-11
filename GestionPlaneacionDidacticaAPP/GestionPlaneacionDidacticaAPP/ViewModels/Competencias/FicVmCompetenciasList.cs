﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Competencias;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Asignatura;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Competencias
{
    public class FicVmCompetenciasList : INotifyPropertyChanged
    {
        //Data of the grid
        public ObservableCollection<eva_planeacion_temas_competencias> _SFDataGrid_ItemSource_Competencias;
        public eva_planeacion_temas_competencias _SFDataGrid_SelectedItem_Competencias;

        //Buttons
        private ICommand _MetAddCompetenciaICommand, _MetUpdateCompetenciaICommand, _MetViewCompetenciaICommand, _MetRemoveCompetenciaICommand;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvCompetencias IFicSrvCompetencias;
        private IFicSrvAsignatura IFicSrvAsignatura;

        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelIdAsignatura;
        private int _LabelIdTema;

        public object FicNavigationContextC { get; set; }

        public FicVmCompetenciasList(IFicSrvNavigationInventario ificSrvNavigationInventario, IFicSrvCompetencias ificSrvCompetencias, IFicSrvAsignatura ificSrvAsignatura)
        {
            this.IFicSrvNavigationInventario = ificSrvNavigationInventario;
            this.IFicSrvCompetencias = ificSrvCompetencias;
            this.IFicSrvAsignatura = ificSrvAsignatura;

            _SFDataGrid_ItemSource_Competencias = new ObservableCollection<eva_planeacion_temas_competencias>();
        }

        public ObservableCollection<eva_planeacion_temas_competencias> SFDataGrid_ItemSource_Competencias
        {
            get
            {
                return _SFDataGrid_ItemSource_Competencias;
            }
        }

        public eva_planeacion_temas_competencias SFDataGrid_SelectedItem_Competencias
        {
            get
            {
                return _SFDataGrid_SelectedItem_Competencias;
            }
            set
            {
                if (value != null)
                {
                    _SFDataGrid_SelectedItem_Competencias = value;
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

        public ICommand FicMetAddCompetenciaICommand
        {
            get
            {
                return _MetAddCompetenciaICommand = _MetAddCompetenciaICommand ?? new FicVmDelegateCommand(FicMetAddCompetencia);
            }
        }

        private void FicMetAddCompetencia()
        {
            var source_eva_planeacion_tema = FicNavigationContextC as eva_planeacion_temas;
            IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasInsert>(source_eva_planeacion_tema);
        }

        public ICommand FicMetViewCompetenciaICommand
        {
            get
            {
                return _MetViewCompetenciaICommand = _MetViewCompetenciaICommand ?? new FicVmDelegateCommand(FicMetViewCompetencia);
            }
        }

        private void FicMetViewCompetencia()
        {
            if (SFDataGrid_SelectedItem_Competencias != null)
            {
                eva_planeacion_temas source_eva_planeacion_temas = FicNavigationContextC as eva_planeacion_temas;
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasView>(new object[] { SFDataGrid_SelectedItem_Competencias, source_eva_planeacion_temas });
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

                    var source_local_inv1 = await IFicSrvCompetencias.MetGetListCompetenciasTemasPlaneacion(source_eva_planeacion_temas.IdTema);
                    if (source_local_inv1 != null)
                    {
                        _SFDataGrid_ItemSource_Competencias.Clear();
                        foreach (eva_planeacion_temas_competencias competencias in source_local_inv1)
                        {
                            _SFDataGrid_ItemSource_Competencias.Add(competencias);
                        }
                    }
                }
                else
                {
                    var source_local_inv2 = await IFicSrvCompetencias.MetGetListCompetencias();
                    if (source_local_inv2 != null)
                    {
                        foreach (eva_planeacion_temas_competencias competencias in source_local_inv2)
                        {
                            _SFDataGrid_ItemSource_Competencias.Add(competencias);
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
