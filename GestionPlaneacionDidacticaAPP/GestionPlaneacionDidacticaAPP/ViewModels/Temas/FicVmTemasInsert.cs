using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.Services.Temas;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Temas
{
    public class FicVmTemasInsert: INotifyPropertyChanged
    {

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvTemas IFicSrvTemas;

        private string _LabelDesTema, _LabelObservaciones;

        //Botones
        private ICommand _MetRegesarTemasListICommand, _SaveCommand;

        //Valor mandado de view padre a hija
        public object[] NavigationContextC { get; set; }

        public FicVmTemasInsert(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvTemas srvTemas)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvTemas = srvTemas;
        }

        public string LabelDesTema
        {
            get { return _LabelDesTema; }
            set
            {
                if (value != null)
                {
                    _LabelDesTema = value;
                    RaisePropertyChanged("LabelDesTema");
                }
            }
        }

        public string LabelObservaciones
        {
            get { return _LabelObservaciones; }
            set
            {
                if (value != null)
                {
                    _LabelObservaciones = value;
                    RaisePropertyChanged("LabelObervaciones");
                }
            }
        }

        public ICommand MetRegresarTemasListICommand
        {
            get
            {
                return _MetRegesarTemasListICommand = _MetRegesarTemasListICommand ?? new FicVmDelegateCommand(MetRegresarTemasList);
            }
        }

        private async void MetRegresarTemasList()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmTemasList>(NavigationContextC);
            }
            catch(Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(),"Ok");
            }
        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        private async void SaveCommandExecute()
        {
            try
            {
                var res = await IFicSrvTemas.InsertTema(new eva_planeacion_temas()
                {
                    IdAsignatura = 1,
                    IdPlaneacion = 1,

                    DesTema = LabelDesTema,
                    Observaciones = LabelObservaciones,

                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = "ERNESTO",
                    UsuarioMod = "ERNESTO",
                    Activo = "S",
                    Borrado = "N"
                });

                if(res == "Ok")
                {
                    await new Page().DisplayAlert("Insert", "¡INSERTADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmTemasList>(NavigationContextC);
                }
                else
                {
                    await new Page().DisplayAlert("Insert", res.ToString(), "OK");
                }

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Alerta", e.Message.ToString(), "OK");
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
