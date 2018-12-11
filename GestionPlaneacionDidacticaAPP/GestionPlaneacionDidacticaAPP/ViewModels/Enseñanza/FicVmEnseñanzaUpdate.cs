using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Enseñanza;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Enseñanza
{
    public class FicVmEnseñanzaUpdate : INotifyPropertyChanged
    {

        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvEnseñanzaUpdate IFicSrvEnseñanzaUpdate;

        public DateTime _FechaIni, _FechaFin;
        public object FicNavigationContextC { get; set; }

        private ICommand _FicMetRegresarPlaneacionICommand, _SaveCommand;

        public FicVmEnseñanzaUpdate(IFicSrvNavigationInventario IFicSrvNavigationInventario,
            IFicSrvEnseñanzaUpdate IFicSrvEnseñanzaUpdate)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
            this.IFicSrvEnseñanzaUpdate = IFicSrvEnseñanzaUpdate;
        }

        #region ENLAZAR VARIABLES
        public DateTime FechaIni
        {
            get
            {
                return _FechaIni;
            }
            set
            {
                _FechaIni = value;
                RaisePropertyChanged("FechaIni");
            }
        }
        public DateTime FechaFin
        {
            get
            {
                return _FechaFin;
            }
            set
            {
                _FechaFin = value;
                RaisePropertyChanged("FechaFin");
            }
        }
        #endregion

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
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmEnseñanzaList>(FicNavigationContextC);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }
        public async void SaveCommandExecute()
        {
            var source_eva_planeacion_enseñanza = FicNavigationContextC as EnseñanzaLista;
            try
            {
                var RespuestaUpdate = await IFicSrvEnseñanzaUpdate.FicMetUpdateEnseñanza(new eva_planeacion_enseñanza()
                {
                    Id = source_eva_planeacion_enseñanza.eva_planeacion_enseñanza.Id,
                    IdAsignatura = source_eva_planeacion_enseñanza.eva_planeacion_enseñanza.IdAsignatura,
                    IdPlaneacion = source_eva_planeacion_enseñanza.eva_planeacion_enseñanza.IdPlaneacion,
                    IdCompetencia = source_eva_planeacion_enseñanza.eva_planeacion_enseñanza.IdCompetencia,
                    IdTema = source_eva_planeacion_enseñanza.eva_planeacion_enseñanza.IdTema,
                    FechaProgramada = _FechaIni,
                    FechaRealizada = _FechaFin,
                    FechaReg = source_eva_planeacion_enseñanza.eva_planeacion_enseñanza.FechaReg,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = source_eva_planeacion_enseñanza.eva_planeacion_enseñanza.UsuarioReg,
                    UsuarioMod = FicGlobalValues.USUARIO,
                    Activo = "S",
                    Borrado = "N"
                });

                if (RespuestaUpdate == "OK")
                {
                    await new Page().DisplayAlert("UPDATE", "¡EDITADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmEnseñanzaList>(FicNavigationContextC);
                }
                else
                {
                    await new Page().DisplayAlert("UDPATE", RespuestaUpdate.ToString(), "OK");
                }

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }
        #endregion

        public async void OnAppearing()
        {
            var source_eva_planeacion_enseñanza = FicNavigationContextC as EnseñanzaLista;
            _FechaIni = source_eva_planeacion_enseñanza.eva_planeacion_enseñanza.FechaProgramada;
            _FechaFin = source_eva_planeacion_enseñanza.eva_planeacion_enseñanza.FechaRealizada;


            RaisePropertyChanged("FechaIni");
            RaisePropertyChanged("FechaFin");
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
