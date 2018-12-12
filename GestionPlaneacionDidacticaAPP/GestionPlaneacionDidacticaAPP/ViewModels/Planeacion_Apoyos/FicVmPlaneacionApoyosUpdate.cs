using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.Services.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Planeacion_Apoyos
{
    public class FicVmPlaneacionApoyosUpdate : INotifyPropertyChanged
    {
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvPlaneacionApoyos IFicSrvPlaneacionApoyos;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelAsignatura;
        private Int16 _LabelIdApoyoDidactico;

        private ICommand _FicMetRegesarPlaneacionApoyosListICommand, _SaveCommand;

        public object[] FicNavigationContextC { get; set; }

        public FicVmPlaneacionApoyosUpdate(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvPlaneacionApoyos ficSrvCompetencias)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvPlaneacionApoyos = ficSrvCompetencias;
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

        public string LabelAsignatura
        {
            get { return _LabelAsignatura; }
            set
            {
                if (value != null)
                {
                    _LabelAsignatura = value;
                    RaisePropertyChanged("LabelAsignatura");
                }
            }
        }

        public async void OnAppearing()
        {
            var source_eva_planeacion_apoyos = FicNavigationContextC[0] as eva_planeacion_apoyos;
            eva_planeacion source_eva_planeacion = FicNavigationContextC[1] as eva_planeacion;

            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion_apoyos.IdPlaneacion;
            _LabelIdApoyoDidactico = source_eva_planeacion_apoyos.IdApoyoDidactico;

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdAoyoDidactico");

        }

        public ICommand FicMetRegesarPlaneacionApoyosListICommand
        {
            get
            {
                return _FicMetRegesarPlaneacionApoyosListICommand = _FicMetRegesarPlaneacionApoyosListICommand ??
                    new FicVmDelegateCommand(FicMetRegresarCompetencias);
            }
        }

        private async void FicMetRegresarCompetencias()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacionApoyosList>(FicNavigationContextC[1]);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
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
