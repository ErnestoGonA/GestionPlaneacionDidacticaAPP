using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.Services.Planeacion_Apoyos;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Planeacion_Apoyos
{
    public class FicVmPlaneacionApoyosInsert : INotifyPropertyChanged
    {
        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvPlaneacionApoyos IFicSrvPlaneacionApoyos;
        private FicISrvPlaneacion IFicSrvPlaneacion;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelIdAsignatura;
        private string _LabelObservaciones;

        public Int16 _IdApoyodidactico;
        private List<string> _ApoyosDidacticos;

        //Botones
        private ICommand _FicMetRegesarPlaneacionApoyosListICommand, _SaveCommand;

        //Valor mandado de view padre a hija
        public object FicNavigationContextC { get; set; }

        public FicVmPlaneacionApoyosInsert(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvPlaneacionApoyos srvCompetencias, FicISrvPlaneacion iFicSrvPlaneacion)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvPlaneacionApoyos = srvCompetencias;
            _ApoyosDidacticos = GetListApoyosDidacticos().Result;
        }

        public async Task<List<string>> GetListApoyosDidacticos()
        {
            try
            {
                var apoyos = await IFicSrvPlaneacionApoyos.GetListApoyosDidacticos();
                if (apoyos != null)
                {
                    List<string> aux = new List<string>();
                    foreach (eva_cat_apoyos_didacticos com in apoyos)
                    {
                        aux.Add(com.DesApoyoDidactico);
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

        public Int16 IdApoyoDidactico
        {
            get
            {
                return _IdApoyodidactico;
            }
            set
            {
                _IdApoyodidactico = value;
            }
        }

        public List<string> ApoyosDidacticos
        {
            get { return _ApoyosDidacticos; }
            set
            {
                _ApoyosDidacticos = value;
                RaisePropertyChanged("_ApoyosDidacticos");
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

        public async void OnAppearing()
        {

            var source_eva_planeacion = FicNavigationContextC as eva_planeacion;
            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelIdAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        private async void SaveCommandExecute()
        {
            try
            {

                var source_eva_planeacion = FicNavigationContextC as eva_planeacion;

                var res = await IFicSrvPlaneacionApoyos.InsertPlaneacionApoyos(new eva_planeacion_apoyos()
                {
                    IdAsignatura = source_eva_planeacion.IdAsignatura,
                    IdPlaneacion = source_eva_planeacion.IdPlaneacion,
                    IdApoyoDidactico = (Int16)(this._IdApoyodidactico + 1),
                    Observaciones = LabelObservaciones,

                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = FicGlobalValues.USUARIO,
                    UsuarioMod = FicGlobalValues.USUARIO,
                    Activo = "S",
                    Borrado = "N"
                });

                if (res == "OK")
                {
                    await new Page().DisplayAlert("Insert", "¡INSERTADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacionApoyosList>(FicNavigationContextC);
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


        public ICommand FicMetRegesarPlaneacionApoyosListICommand
        {
            get
            {
                return _FicMetRegesarPlaneacionApoyosListICommand = _FicMetRegesarPlaneacionApoyosListICommand ??
                    new FicVmDelegateCommand(FicMetRegesarPlaneacionApoyos);
            }
        }

        private async void FicMetRegesarPlaneacionApoyos()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmPlaneacionApoyosList>(FicNavigationContextC);
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
