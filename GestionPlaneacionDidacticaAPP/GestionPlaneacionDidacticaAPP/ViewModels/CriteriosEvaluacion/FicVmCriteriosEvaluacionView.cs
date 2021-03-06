﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Asignatura;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Temas;
using GestionPlaneacionDidacticaAPP.Interfaces.CriteriosEvaluacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.Data;

namespace GestionPlaneacionDidacticaAPP.ViewModels.CriteriosEvaluacion
{
    public class FicVmCriteriosEvaluacionView : INotifyPropertyChanged
    {
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private FicISrvPlaneacion IFicSrvPlaneacion;

        private string _LabelDesTema, _LabelDesCriterio, _LabelFechaReg, _LabelFechaMod, _LabelUsuarioReg, _LabelUsuarioMod, _LabelActivo, _LabelBorrado;
        private short  _LabelIdTema;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelAsignatura;
        private string _LabelPeriodo;
        private string _LabelCompetencia;
        private string _LabelPorcentaje;

        private ICommand _FicMetRegesarCatEdificiosListICommand;

        public object[] FicNavigationContextC { get; set; }

        public FicVmCriteriosEvaluacionView(IFicSrvNavigationInventario IFicSrvNavigationInventario, FicISrvPlaneacion iFicSrvPlaneacion)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
            IFicSrvPlaneacion = iFicSrvPlaneacion;
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

        public short LabelIdTema
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

        public string LabelCompetencia
        {
            get { return _LabelCompetencia; }
            set
            {
                if (value != null)
                {
                    _LabelCompetencia = value;
                    RaisePropertyChanged("LabelCompetencia");
                }
            }
        }

        public string LabelDesCriterio
        {
            get { return _LabelDesCriterio; }
            set
            {
                if (value != null)
                {
                    _LabelDesCriterio = value;
                    RaisePropertyChanged("LabelDesCriterio");
                }
            }
        }

        public string LabelPorcentaje
        {
            get { return _LabelPorcentaje; }
            set
            {
                if (value != null)
                {
                    _LabelPorcentaje = value;
                    RaisePropertyChanged("LabelPorcentaje");
                }
            }
        }

        public string LabelFechaReg
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

        public string LabelFechaMod
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

        public string LabelUsuarioReg
        {
            get { return _LabelUsuarioReg; }
            set
            {
                if (value != null)
                {
                    _LabelUsuarioReg = value;
                    RaisePropertyChanged("LabelUsuarioReg");
                }
            }
        }

        public string LabelUsuarioMod
        {
            get { return _LabelUsuarioMod; }
            set
            {
                if (value != null)
                {
                    _LabelUsuarioMod = value;
                    RaisePropertyChanged("LabelUsuarioMod");
                }
            }
        }

        public string LabelActivo
        {
            get { return _LabelActivo; }
            set
            {
                if (value != null)
                {
                    _LabelActivo = value;
                    RaisePropertyChanged("LabelActivo");
                }
            }
        }

        public string LabelBorrado
        {
            get { return _LabelBorrado; }
            set
            {
                if (value != null)
                {
                    _LabelBorrado = value;
                    RaisePropertyChanged("LabelBorrado");
                }
            }
        }

        public string LabelPeriodo
        {
            get { return _LabelPeriodo; }
            set
            {
                if (value != null)
                {
                    _LabelPeriodo = value;
                    RaisePropertyChanged("LabelPeriodo");
                }
            }
        }

        public async void OnAppearing()
        {
            var source_eva_planeacion_temas = FicNavigationContextC[0] as eva_planeacion_temas;
            var source_eva_planeacion = FicNavigationContextC[1] as eva_planeacion;
            var eptc = FicNavigationContextC[2] as eva_planeacion_temas_competencias;
            var criterio = FicNavigationContextC[3] as eva_planeacion_criterios_evalua;

            cat_periodos periodo = await IFicSrvPlaneacion.GetListPeriodos(source_eva_planeacion.IdPeriodo);

            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelPeriodo = periodo.DesPeriodo;
            _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;
            _LabelDesTema = source_eva_planeacion_temas.DesTema;
            _LabelCompetencia = eptc.Observaciones;


            _LabelDesCriterio = criterio.DesCriterio;
            _LabelPorcentaje = criterio.Porcentaje+"";
            
            _LabelFechaReg = criterio.FechaReg.ToString();
            _LabelFechaMod = criterio.FechaUltMod.ToString();
            _LabelUsuarioReg = criterio.UsuarioReg;
            _LabelUsuarioMod = criterio.UsuarioMod;
            _LabelActivo = criterio.Activo;
            _LabelBorrado = criterio.Borrado;

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelDesTema");
            RaisePropertyChanged("LabelCompetencia");

            RaisePropertyChanged("LabelDesCriterio");
            RaisePropertyChanged("LabelPorcentaje");


            RaisePropertyChanged("LabelFechaReg");
            RaisePropertyChanged("LabelFechaMod");
            RaisePropertyChanged("LabelUsuarioReg");
            RaisePropertyChanged("LabelUsuarioMod");
            RaisePropertyChanged("LabelActivo");
            RaisePropertyChanged("LabelBorrado");

        }

        public ICommand MetRegresarCriteriosEvaluacionListICommand
        {
            get
            {
                return _FicMetRegesarCatEdificiosListICommand = _FicMetRegesarCatEdificiosListICommand ??
                    new FicVmDelegateCommand(FicMetRegresarCriteriosList);
            }
        }

        private async void FicMetRegresarCriteriosList()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmCriteriosEvaluacionList>(new object[] {
                    FicNavigationContextC[0],
                    FicNavigationContextC[1],
                    FicNavigationContextC[2]});
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
