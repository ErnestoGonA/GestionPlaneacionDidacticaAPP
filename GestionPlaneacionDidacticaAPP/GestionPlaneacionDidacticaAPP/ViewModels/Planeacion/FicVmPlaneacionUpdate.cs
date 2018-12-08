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
    public class FicVmPlaneacionUpdate : INotifyPropertyChanged
    {

        #region VARIABLES
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvPlaneacionUpdate IFicSrvPlaneacionUpdate;
        private string _ReferenciaNorma, _Revision, _CompetenciaAsignatura, _AportacionPerfilEgreso;
        private string _Usuario = FicGlobalValues.USUARIO;
        private string _Asignatura = FicGlobalValues.ASIGNATURA;
        private bool _Actual, _PlantillaOriginal;
        public Int16 _PeriodoId;
        private List<string> _Periodos;
        public object FicNavigationContextC { get; set; }
        private ICommand _FicMetRegresarPlaneacionICommand, _SaveCommand;
        #endregion

        public FicVmPlaneacionUpdate(IFicSrvNavigationInventario IFicSrvNavigationInventario,
            IFicSrvPlaneacionUpdate IFicSrvPlaneacionUpdate)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
            this.IFicSrvPlaneacionUpdate = IFicSrvPlaneacionUpdate;
            _Periodos = GetListPeriodos().Result;
        }

        #region VARIABLE CON VISTA
        public async Task<List<string>> GetListPeriodos()
        {
            try
            {
                var periodos = await IFicSrvPlaneacionUpdate.GetListPeriodos();
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

        public Int16 PeriodoId
        {
            get
            {
                return _PeriodoId;
            }
            set
            {
                _PeriodoId = value;
                RaisePropertyChanged("PeriodoId");
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

        public List<string> Periodos
        {
            get { return _Periodos; }
            set
            {
                _Periodos = value;
                RaisePropertyChanged("Periodos");
            }
        }
        #endregion

        public async void OnAppearing()
        {
            var source_eva_planeacion = FicNavigationContextC as eva_planeacion;
            _ReferenciaNorma = source_eva_planeacion.ReferenciaNorma;
            _Revision = source_eva_planeacion.Revision;
            _Actual = source_eva_planeacion.Actual == "1" ? true : false ;
            _PlantillaOriginal = source_eva_planeacion.PlantillaOriginal == "1" ? true : false;
            _CompetenciaAsignatura = source_eva_planeacion.CompetenciaAsignatura;
            _AportacionPerfilEgreso = source_eva_planeacion.AportacionPerfilEgreso;
            _PeriodoId = 0;
            

            RaisePropertyChanged("ReferenciaNorma");
            RaisePropertyChanged("Revision");
            RaisePropertyChanged("Actual");
            RaisePropertyChanged("PlantillaOriginal");
            RaisePropertyChanged("CompetenciaAsignatura");
            RaisePropertyChanged("AportacionPerfilEgreso");
            RaisePropertyChanged("PeriodoId");
        }

        #region ICOMMAND

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

        public ICommand SavCommand
        {
            get
            {
                return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute);
            }
        }

        public async void SaveCommandExecute()
        {
            var source_eva_planeacion = FicNavigationContextC as eva_planeacion;
            try
            {
                var RespuestaUpdate = await IFicSrvPlaneacionUpdate.Update_eva_planeacion(new eva_planeacion()
                {
                    IdAsignatura = source_eva_planeacion.IdAsignatura,
                    IdPlaneacion = source_eva_planeacion.IdPlaneacion,
                    ReferenciaNorma = this.ReferenciaNorma,
                    Revision = this.Revision,
                    Actual = this.Actual ? "1" : "0",
                    PlantillaOriginal = this.PlantillaOriginal ? "1" : "0",
                    CompetenciaAsignatura = this.CompetenciaAsignatura,
                    AportacionPerfilEgreso = this.AportacionPerfilEgreso,
                    IdPeriodo = PeriodoId,
                    FechaReg = source_eva_planeacion.FechaReg,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = source_eva_planeacion.UsuarioReg,
                    UsuarioMod = FicGlobalValues.USUARIO,
                    Activo = "S",
                    Borrado = "N"
                });

                if (RespuestaUpdate == "OK")
                {
                    await new Page().DisplayAlert("UPDATE", "¡EDITADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacion>(FicNavigationContextC);
                }
                else
                {
                    await new Page().DisplayAlert("UDPATE", RespuestaUpdate.ToString(), "OK");
                }

            }catch(Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        #endregion

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
