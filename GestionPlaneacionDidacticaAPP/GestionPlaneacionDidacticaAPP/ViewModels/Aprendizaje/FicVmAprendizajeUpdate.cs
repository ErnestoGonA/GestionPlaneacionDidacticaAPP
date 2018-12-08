using GestionPlaneacionDidacticaAPP.Interfaces.Apredizaje;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Aprendizaje
{
    public class FicVmAprendizajeUpdate : INotifyPropertyChanged
    {
        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvAprendizaje IFicSrvAprendizaje;

        private short _LabelIdPlanAprendizaje, _LabelIdAsignatura, _LabelIdTema;
        private int _LabelIdPlaneacion, _LabelIdCompetencia, _LabelIdActAprendizaje;
        private string _LabelAct, _LabelBor, _LabelUsuReg, _LabelUsuMod;
        private DateTime _LabelFechaReg, _LabelFechaMod;

        //Botones
        private ICommand _MetRegesarCompetenciaListICommand, _SaveCommand;

        //Valor mandado de view padre a hija
        public object NavigationContextC { get; set; }

        public FicVmAprendizajeUpdate(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvAprendizaje iFicSrvAprendizaje)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvAprendizaje = iFicSrvAprendizaje;
        }
        public short LabelIdAsignatura
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

        public short LabelIdTema
        {
            get { return _LabelIdTema; }
            set
            {
                if (value != null)
                {
                    _LabelIdPlaneacion = value;
                    RaisePropertyChanged("LabelIdTema");
                }
            }
        }

        public int LabelIdCompetencia
        {
            get { return _LabelIdCompetencia; }
            set
            {
                if (value != null)
                {
                    _LabelIdCompetencia = value;
                    RaisePropertyChanged("LabelIdCompetencia");
                }
            }
        }

        public int LabelIdActAprendizaje
        {
            get { return _LabelIdActAprendizaje; }
            set
            {
                if (value != null)
                {
                    _LabelIdActAprendizaje = value;
                    RaisePropertyChanged("LabelIdActAprendizaje");
                }
            }
        }

        public short LabelIdPlanAprendizaje
        {
            get { return _LabelIdPlanAprendizaje; }
            set
            {
                if (value != null)
                {
                    _LabelIdPlanAprendizaje = value;
                    RaisePropertyChanged("LabelIdPlanAprendizaje");
                }
            }
        }
        public DateTime LabelFechaReg
        {
            get { return _LabelFechaReg; }
            set
            {
                if (value != null)
                {
                    _LabelFechaReg = value;
                    RaisePropertyChanged("LabelFechaReg");
                }
            }
        }

        public DateTime LabelFechaMod
        {
            get { return _LabelFechaMod; }
            set
            {
                if (value != null)
                {
                    _LabelFechaMod = value;
                    RaisePropertyChanged("LabelFechaMod");
                }
            }
        }
        public string LabelUsuReg
        {
            get { return _LabelUsuReg; }
            set
            {
                if (value != null)
                {
                    _LabelUsuReg = value;
                    RaisePropertyChanged("LabelUsuReg");
                }
            }
        }

        public string LabelUsuMod
        {
            get { return _LabelUsuMod; }
            set
            {
                if (value != null)
                {
                    _LabelUsuMod = value;
                    RaisePropertyChanged("LabelUsuMod");
                }
            }
        }
        public string LabelAct
        {
            get { return _LabelAct; }
            set
            {
                if (value != null)
                {
                    _LabelAct = value;
                    RaisePropertyChanged("LabelAct");
                }
            }
        }
        public string LabelBor
        {
            get { return _LabelBor; }
            set
            {
                if (value != null)
                {
                    _LabelBor = value;
                    RaisePropertyChanged("LabelBor");
                }
            }
        }

        public async void OnAppering()
        {
            var aprendizaje = NavigationContextC as eva_planeacion_aprendizaje;
            _LabelIdPlanAprendizaje = aprendizaje.IdPlaneacionAprendizaje;
            _LabelIdAsignatura = aprendizaje.IdAsignatura;
            _LabelIdPlaneacion = aprendizaje.IdPlaneacion;
            _LabelIdTema = aprendizaje.IdTema;
            _LabelIdCompetencia = aprendizaje.IdCompetencia;
            _LabelIdActAprendizaje = aprendizaje.IdActividadAprendizaje;
            _LabelFechaReg = aprendizaje.FechaReg;
            _LabelFechaMod = aprendizaje.FechaUltMod;
            _LabelUsuReg = aprendizaje.UsuarioReg;
            _LabelUsuMod = aprendizaje.UsuarioMod;
            _LabelAct = aprendizaje.Activo;
            _LabelBor = aprendizaje.Borrado;

            RaisePropertyChanged("LabelIdPlanAprendizaje");
            RaisePropertyChanged("LabelIdAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdTema");
            RaisePropertyChanged("LabelIdCompetencia");
            RaisePropertyChanged("LabelIdActAprendizaje");
            RaisePropertyChanged("LabelFechaReg");
            RaisePropertyChanged("LabelFechaMod");
            RaisePropertyChanged("LabelUsuReg");
            RaisePropertyChanged("LabelUsuMod");
            RaisePropertyChanged("LabelAct");
            RaisePropertyChanged("LabelBor");
        }

        public ICommand MetRegresarCompetenciaListICommand
        {
            get
            {
                return _MetRegesarCompetenciaListICommand = _MetRegesarCompetenciaListICommand ?? new FicVmDelegateCommand(MetRegresarCompetenciaList);
            }
        }

        private async void MetRegresarCompetenciaList()
        {
            try
            {
                //IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompeteciaList>(NavigationContextC);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "Ok");
            }
        }

        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        private async void SaveCommandExecute()
        {
            var apredizaje = NavigationContextC as eva_planeacion_aprendizaje; 
            try
            {
                var res = await IFicSrvAprendizaje.UpdateAprendizaje(new eva_planeacion_aprendizaje
                {
                    IdPlaneacionAprendizaje = apredizaje.IdPlaneacionAprendizaje,
                    IdAsignatura = LabelIdAsignatura,
                    IdPlaneacion = LabelIdPlaneacion,
                    IdTema = LabelIdTema,
                    IdCompetencia = LabelIdCompetencia,
                    IdActividadAprendizaje = LabelIdActAprendizaje,
                    FechaReg = apredizaje.FechaReg,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = apredizaje.UsuarioReg,
                    UsuarioMod = "Ana",
                    Activo = LabelAct,
                    Borrado = LabelBor
                });

                if (res == "Ok")
                {
                    await new Page().DisplayAlert("UPDATE", "¡ACTUALIZADO CON EXITO!", "OK");
                    //IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCompetenciaList>(NavigationContextC);
                }
                else
                {
                    await new Page().DisplayAlert("UPDATE", res.ToString(), "OK");
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
