using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GestionPlaneacionDidacticaAPP.Data;
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

        private string _ReferenciaNorma, _Revision, _CompetenciaAsignatura, _AportacionPerfilEgreso;
        private string _Usuario = FicGlobalValues.USUARIO;
        private string _Asignatura = FicGlobalValues.ASIGNATURA;
        private string _Periodo = FicGlobalValues.PERIODO;
        private bool _Actual, _PlantillaOriginal;



        private ICommand _SaveCommand, _FicMetRegresarPlaneacionICommand;

        public object[] FicNavigationContextC { get; set; }

        public FicVmPlaneacionInsert(IFicSrvNavigationInventario IFicSrvNavigationInventario, IFicSrvPlaneacionInsert IFicSrvPlaneacionInsert)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
            this.IFicSrvPlaneacionInsert = IFicSrvPlaneacionInsert;
        }

        public string Usuario
        {
            get
            {
                return _Usuario;
            }
            set
            {
                if (value != null)
                {
                    _Usuario = FicGlobalValues.USUARIO = value;
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
                if (value != null)
                {
                    _Asignatura = FicGlobalValues.ASIGNATURA = value;
                }
            }
        }

        public string Periodo
        {
            get
            {
                return _Periodo;
            }
            set
            {
                if (value != null)
                {
                    _Periodo = FicGlobalValues.PERIODO = value;
                }
            }
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

        public bool Actual
        {
            get { return _Actual; }
            set
            {
                _Actual = value;
                RaisePropertyChanged("Actual");
            }
        }

        public bool PlantillaOriginal
        {
            get { return _PlantillaOriginal; }
            set
            {
                _PlantillaOriginal = value;
                RaisePropertyChanged("PlantillaOriginal");
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
                    IdAsignatura = (Int16)(FicGlobalValues.ASIGNATURA_INDEX + 1),
                    IdPlaneacion = FicGlobalValues.NEXTIDPLANEACION,
                    ReferenciaNorma = this.ReferenciaNorma,
                    Revision = this.Revision,
                    Actual = this.Actual ? "S" : "N",
                    PlantillaOriginal = this.PlantillaOriginal ? "S" : "N",
                    CompetenciaAsignatura = this.CompetenciaAsignatura,
                    AportacionPerfilEgreso = this.AportacionPerfilEgreso,
                    IdPeriodo = FicGlobalValues.PERIODO_INDEX,
                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = FicGlobalValues.USUARIO,
                    UsuarioMod = FicGlobalValues.USUARIO,
                    Activo = "S",
                    Borrado = "N"
                });
                if (RespuestaInsert == "OK")
                {
                    await new Page().DisplayAlert("ADD", "Insertado con éxito", "OK");
                    FicGlobalValues.NEXTIDPLANEACION++;
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

        public ICommand FicMetRegresarPlaneacionICommand
        {
            get
            {
                return _FicMetRegresarPlaneacionICommand = _FicMetRegresarPlaneacionICommand ?? new FicVmDelegateCommand(FicMetRegresarPlaneacion);
            }
        }

        private async void FicMetRegresarPlaneacion()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacion>(FicNavigationContextC);
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
