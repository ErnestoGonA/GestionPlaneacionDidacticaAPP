using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Planeacion
{
    public class FicVmPlaneacionInsert : INotifyPropertyChanged
    {
        //Variables
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvPlaneacionInsert IFicSrvPlaneacionInsert;

        private string _ReferenciaNorma, _Revision, _Actual, _PlantillaOriginal, _CompetenciaAsignatura, _AportacionPerfilEgreso;
        private Int16 _IdPeriodo;

        private ICommand _SaveCommand;

        public object[] FicNavigationContextC { get; set; }

        public FicVmPlaneacionInsert(IFicSrvNavigationInventario IFicSrvNavigationInventario, IFicSrvPlaneacionInsert IFicSrvPlaneacionInsert)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
            this.IFicSrvPlaneacionInsert = IFicSrvPlaneacionInsert;
        }

        public string ReferenciaNorma
        {
            get { return _ReferenciaNorma; }
            set
            {
                if (value != null)
                {
                    _ReferenciaNorma = value;
                    RaisePropertyChanged("ReferenciaNorma");
                }
            }
        }
        public string Revision
        {
            get { return _Revision; }
            set
            {
                if (value != null)
                {
                    _Revision = value;
                    RaisePropertyChanged("Revision");
                }
            }
        }

        public string Actual
        {
            get { return _Actual; }
            set
            {
                if (value != null)
                {
                    _Actual = value;
                    RaisePropertyChanged("Actual");
                }
            }
        }

        public string PlantillaOriginal
        {
            get { return _PlantillaOriginal; }
            set
            {
                if (value != null)
                {
                    _PlantillaOriginal = value;
                    RaisePropertyChanged("PlantillaOriginal");
                }
            }
        }

        public string CompetenciaAsignatura
        {
            get { return _CompetenciaAsignatura; }
            set
            {
                if (value != null)
                {
                    _CompetenciaAsignatura = value;
                    RaisePropertyChanged("CompetenciaAsignatura");
                }
            }
        }

        public string AportacionPerfilEgreso
        {
            get { return _AportacionPerfilEgreso; }
            set
            {
                if (value != null)
                {
                    _AportacionPerfilEgreso = value;
                    RaisePropertyChanged("AportacionPerfilEgreso");
                }
            }
        }

        public Int16 IdPeriodo
        {
            get { return _IdPeriodo; }
            set
            {
                _IdPeriodo = value;
                RaisePropertyChanged("IdPeriodo");
            }
        }

        public async void OnAppearing()
        {

        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }
        public async void SaveCommandExecute()
        {
            try
            {
                var RespuestaInsert = await IFicSrvPlaneacionInsert.Insert_eva_planeacion(new eva_planeacion() {
                    ReferenciaNorma = this.ReferenciaNorma,
                    Revision = this.Revision,
                    Actual = this.Actual,
                    PlantillaOriginal = this.PlantillaOriginal,
                    CompetenciaAsignatura = this.CompetenciaAsignatura,
                    AportacionPerfilEgreso = this.AportacionPerfilEgreso,
                    IdPeriodo = this.IdPeriodo,
                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = "PEDRO",
                    UsuarioMod = "PEDRO",
                    Activo = "S",
                    Borrado = "N"
                });
                if (RespuestaInsert == "OK")
                {
                    await new Page().DisplayAlert("ADD", "Insertado con éxito", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacion>(FicNavigationContextC);
                }
                else
                {
                    await new Page().DisplayAlert("ADD", RespuestaInsert.ToString(), "OK");
                }//SE INSERTO EL CONTEO?
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }//MANEJO GLOBAL DE ERRORES
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
