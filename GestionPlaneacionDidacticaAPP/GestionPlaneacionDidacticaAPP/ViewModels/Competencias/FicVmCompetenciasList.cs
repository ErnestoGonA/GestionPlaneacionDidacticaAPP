using System;
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
        private FicISrvCompetencias FicISrvCompetencias;

        public async void OnAppearing()
        {
            try
            {
                var source_local_inv = await FicISrvCompetencias.MetGetListCompetencias();
                if (source_local_inv != null)
                {
                    foreach (eva_planeacion_temas_competencias competencias in source_local_inv)
                    {
                        _SFDataGrid_ItemSource_Competencias.Add(competencias); 
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
