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
using GestionPlaneacionDidacticaAPP.Interfaces.Competencias;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.Services.Competencias;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Competencias
{
    public class FicVmCompetenciasInsert : INotifyPropertyChanged
    {
        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvCompetencias IFicSrvCompetencias;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelIdAsignatura;
        private string _LabelIdTema;

        private string _LabelObservaciones;

        public int _IdCompetencia;
        private List<string> _Competencias;

        //Botones
        private ICommand _FicMetRegesarCompetenciasListICommand, _SaveCommand;

        //Valor mandado de view padre a hija
        public object[] FicNavigationContextC { get; set; }

        public FicVmCompetenciasInsert(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvCompetencias srvCompetencias)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvCompetencias = srvCompetencias;
            _Competencias = GetListCompetencias().Result;
        }

        public async Task<List<string>> GetListCompetencias()
        {
            try
            {
                var competencias = await IFicSrvCompetencias.GetListCompetencias();
                if (competencias != null)
                {
                    List<string> aux = new List<string>();
                    foreach (eva_cat_competencias com in competencias)
                    {
                        aux.Add(com.DesCompetencia);
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

        public int IdCompetencia
        {
            get
            {
                return _IdCompetencia;
            }
            set
            {
                _IdCompetencia = value;
            }
        }

        public string LabelIdTema
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

        public string LabelObservaciones
        {
            get { return _LabelObservaciones; }
            set
            {
                if (value != null)
                {
                    _LabelObservaciones = value;
                    RaisePropertyChanged("LabelObservaciones");
                }
            }
        }

        public List<string> Competencias
        {
            get { return _Competencias; }
            set
            {
                _Competencias = value;
                RaisePropertyChanged("Competencias");
            }
        }

        public async void OnAppearing()
        {

            var source_eva_planeacion_temas = FicNavigationContextC[0] as eva_planeacion_temas;
            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion_temas.IdPlaneacion;
            _LabelIdTema = source_eva_planeacion_temas.DesTema;

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelIdAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdTema");
        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        private async void SaveCommandExecute()
        {
            try
            {

                var source_eva_planeacion_tema = FicNavigationContextC[0] as eva_planeacion_temas;

                var res = await IFicSrvCompetencias.InsertCompetencia(new eva_planeacion_temas_competencias()
                {
                    IdAsignatura = source_eva_planeacion_tema.IdAsignatura,
                    IdPlaneacion = source_eva_planeacion_tema.IdPlaneacion,
                    IdTema = source_eva_planeacion_tema.IdTema,
                    IdCompetencia = (int)(this._IdCompetencia + 1),

                    Observaciones = _LabelObservaciones,

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
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasList>(FicNavigationContextC);
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

        public ICommand FicMetRegesarCompetenciasListICommand
        {
            get
            {
                return _FicMetRegesarCompetenciasListICommand = _FicMetRegesarCompetenciasListICommand ??
                    new FicVmDelegateCommand(FicMetRegresarCompetencias);
            }
        }

        private async void FicMetRegresarCompetencias()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciasList>(FicNavigationContextC);
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
