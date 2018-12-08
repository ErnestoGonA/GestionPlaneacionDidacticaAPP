using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Apredizaje;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Aprendizaje
{
    public class FicVmAprendizajeInsert : INotifyPropertyChanged
    {
        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvAprendizaje IFicSrvAprendizaje;

        private short _LabelIdPlanAprendizaje, _LabelIdAsignatura,  _LabelIdTema;
        private int _LabelIdPlaneacion, _LabelIdCompetencia, _LabelIdActAprendizaje;
        //Botones
        private ICommand _MetRegesarCompetenciaListICommand, _SaveCommand;

        //Valor mandado de view padre a hija
        public object NavigationContextC { get; set; }

        public FicVmAprendizajeInsert(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvAprendizaje iFicSrvAprendizaje)
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
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajeList>(NavigationContextC);
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
            try
            {
                var source_eva_planecion = NavigationContextC as eva_planeacion;
                var source_eva_cat_competencia = NavigationContextC as eva_cat_competencias;
                var source_eva_cat_actapre = NavigationContextC as eva_cat_actividades_aprendizaje;
                var source_eva_planecion_tema = NavigationContextC as eva_planeacion_temas;
                var res = await IFicSrvAprendizaje.InsertAprendizaje(new eva_planeacion_aprendizaje
                {
                    IdPlaneacionAprendizaje = LabelIdPlanAprendizaje,
                    IdAsignatura = source_eva_planecion.IdAsignatura,
                    IdPlaneacion = source_eva_planecion.IdPlaneacion,
                    IdTema = source_eva_planecion_tema.IdTema,
                    IdCompetencia = source_eva_cat_competencia.IdCompetencia,
                    IdActividadAprendizaje = source_eva_cat_actapre.IdActividadAprendizaje,

                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = "Ana",
                    UsuarioMod = "Ana",
                    Activo = "S",
                    Borrado = "S"
                });

                if (res == "Ok")
                {
                    await new Page().DisplayAlert("Insert", "¡INSERTADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmAprendizajeList>(NavigationContextC);
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

        public async void OnAppering()
        {
            var source_eva_planecion = NavigationContextC as eva_planeacion;
            var source_eva_cat_competencia = NavigationContextC as eva_cat_competencias;
            var source_eva_cat_actapre = NavigationContextC as eva_cat_actividades_aprendizaje;
            var source_eva_planecion_tema = NavigationContextC as eva_planeacion_temas;
            _LabelIdAsignatura = source_eva_planecion.IdAsignatura;
            _LabelIdPlaneacion = source_eva_planecion.IdPlaneacion;
            _LabelIdTema = source_eva_planecion_tema.IdTema;
            _LabelIdCompetencia = source_eva_cat_competencia.IdCompetencia;
            _LabelIdActAprendizaje = source_eva_cat_actapre.IdActividadAprendizaje;

            RaisePropertyChanged("LabelIdAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdTema");
            RaisePropertyChanged("LabelIdCompetencia");
            RaisePropertyChanged("LabelIdActAprendizaje");            

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
