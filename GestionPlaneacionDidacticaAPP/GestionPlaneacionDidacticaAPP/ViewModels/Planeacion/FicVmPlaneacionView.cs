﻿using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Planeacion
{
    public class FicVmPlaneacionView : INotifyPropertyChanged
    {
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;

        public int _IdPlaneacion;
        public Int16 _IdPeriodo;
        private string _ReferenciaNorma, _Revision, _Actual, _PlantillaOriginal, _CompetenciaAsignatura, _AportacionPerfilEgreso, _FechaReg, _UsuarioReg, _FechaUltMod, _UsuarioMod, _Activo, _Borrado;
        private ICommand _FicMetRegresarPlaneacionICommand;
        public object FicNavigationContextC { get; set; }

        public FicVmPlaneacionView(IFicSrvNavigationInventario IFicSrvNavigationInventario)
        {
            this.IFicSrvNavigationInventario = IFicSrvNavigationInventario;
        }

        public int IdPlaneacion
        {
            get
            {
                return _IdPlaneacion;
            }
            set
            {
                _IdPlaneacion = value;
                RaisePropertyChanged("IdPlaneacion");
            }
        }
        public Int16 IdPeriodo
        {
            get
            {
                return _IdPeriodo;
            }
            set
            {
                _IdPeriodo = value;
                RaisePropertyChanged("IdPeriodo");
            }
        }
        public string ReferenciaNorma
        {
            get
            {
                return _ReferenciaNorma;
            }
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
            get
            {
                return _Revision;
            }
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
            get
            {
                return _Actual;
            }
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
            get
            {
                return _PlantillaOriginal;
            }
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
            get
            {
                return _CompetenciaAsignatura;
            }
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
            get
            {
                return _AportacionPerfilEgreso;
            }
            set
            {
                if (value != null)
                {
                    _AportacionPerfilEgreso = value;
                    RaisePropertyChanged("AportacionPerfilEgreso");
                }
            }
        }
        public string FechaReg
        {
            get
            {
                return _FechaReg;
            }
            set
            {
                if (value != null)
                {
                    _FechaReg = value;
                    RaisePropertyChanged("FechaReg");
                }
            }
        }
        public string UsuarioReg
        {
            get
            {
                return _UsuarioReg;
            }
            set
            {
                if (value != null)
                {
                    _UsuarioReg = value;
                    RaisePropertyChanged("UsuarioReg");
                }
            }
        }
        public string FechaUltMod
        {
            get
            {
                return _FechaUltMod;
            }
            set
            {
                if (value != null)
                {
                    _FechaUltMod = value;
                    RaisePropertyChanged("FechUltMod");
                }
            }
        }
        public string UsuarioMod
        {
            get
            {
                return _UsuarioMod;
            }
            set
            {
                if (value != null)
                {
                    _UsuarioMod = value;
                    RaisePropertyChanged("UsuarioMod");
                }
            }
        }
        public string Activo
        {
            get
            {
                return _Activo;
            }
            set
            {
                if (value != null)
                {
                    _Activo = value;
                    RaisePropertyChanged("Activo");
                }
            }
        }
        public string Borrado
        {
            get
            {
                return _Borrado;
            }
            set
            {
                if (value != null)
                {
                    _Borrado = value;
                    RaisePropertyChanged("Borrado");
                }
            }
        }

        public async void OnAppearing()
        {
            var source_eva_planeacion = FicNavigationContextC as eva_planeacion;

            _IdPlaneacion = source_eva_planeacion.IdPlaneacion;
            _IdPeriodo = source_eva_planeacion.IdPeriodo;
            _ReferenciaNorma = source_eva_planeacion.ReferenciaNorma;
            _Revision = source_eva_planeacion.Revision;
            _Actual = source_eva_planeacion.Actual;
            _PlantillaOriginal = source_eva_planeacion.PlantillaOriginal;
            _CompetenciaAsignatura = source_eva_planeacion.CompetenciaAsignatura;
            _AportacionPerfilEgreso = source_eva_planeacion.AportacionPerfilEgreso;
            _FechaReg = source_eva_planeacion.FechaReg.ToString();
            _UsuarioReg = source_eva_planeacion.UsuarioReg;
            _FechaUltMod = source_eva_planeacion.FechaUltMod.ToString();
            _UsuarioMod = source_eva_planeacion.UsuarioMod;
            _Activo = source_eva_planeacion.Activo;
            _Borrado = source_eva_planeacion.Borrado;

            RaisePropertyChanged("IdPlaneacion");
            RaisePropertyChanged("IdPeriodo");
            RaisePropertyChanged("ReferenciaNorma");
            RaisePropertyChanged("Revision");
            RaisePropertyChanged("Actual");
            RaisePropertyChanged("PlantillaOriginal");
            RaisePropertyChanged("CompetenciaAsignatura");
            RaisePropertyChanged("AportacionPerfilEgreso");
            RaisePropertyChanged("FechaReg");
            RaisePropertyChanged("UsuarioReg");
            RaisePropertyChanged("FechaUltMod");
            RaisePropertyChanged("UsuarioMod");
            RaisePropertyChanged("Activo");
            RaisePropertyChanged("Borrado");

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
            }catch(Exception e)
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
