using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Fuentes;
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

namespace GestionPlaneacionDidacticaAPP.ViewModels.Fuentes
{
    public class FicVmFuentesView : INotifyPropertyChanged
    {
        //Buttons
        private ICommand _FicMetRegresarFuentesICommand;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion, _LabelPrioridad;
        private string _LabelIdAsignatura;
        private string _LabelIdFuente,_LabelObservaciones,_LabelDesFuenteCompleta;
        private string _LabelFechaReg, _LabelUsuarioReg, _LabelFechaUltMod, _LabelUsuarioMod, _LabelActivo, _LabelBorrado;

        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvFuentes IFicSrvFuentes;

        public object[] FicNavigationContextC { get; set; }

        public FicVmFuentesView(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvFuentes srvFuentes)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvFuentes = srvFuentes;
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

        public string LabelAsignatura
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

        public string LabelIdFuente
        {
            get
            {
                return _LabelIdFuente;
            }
            set
            {
                if (value != null)
                {
                    _LabelIdFuente = value;
                    RaisePropertyChanged("LabelIdFuente");
                }
            }
        }

        public int LabelPrioridad
        {
            get
            {
                return _LabelPrioridad;
            }
            set
            {
                if (value != null)
                {
                    _LabelPrioridad = value;
                    RaisePropertyChanged("LabelPrioridad");
                }
            }
        }

        public string LabelObservaciones
        {
            get
            {
                return _LabelObservaciones;
            }
            set
            {
                if (value != null)
                {
                    _LabelObservaciones = value;
                    RaisePropertyChanged("LabelObservaciones");
                }
            }
        }

        public string LabelDesFuenteCompleta
        {
            get
            {
                return _LabelDesFuenteCompleta;
            }
            set
            {
                if (value != null)
                {
                    _LabelDesFuenteCompleta = value;
                    RaisePropertyChanged("LabelDesFuenteCompleta");
                }
            }
        }

        public string LabelFechaReg
        {
            get
            {
                return _LabelFechaReg;
            }
            set
            {
                if (value != null)
                {
                    _LabelFechaReg = value;
                    RaisePropertyChanged("LabelFechaReg");
                }
            }
        }
        public string LabelUsuarioReg
        {
            get
            {
                return _LabelUsuarioReg;
            }
            set
            {
                if (value != null)
                {
                    _LabelUsuarioReg = value;
                    RaisePropertyChanged("LabelUsuarioReg");
                }
            }
        }
        public string LabelFechaUltMod
        {
            get
            {
                return _LabelFechaUltMod;
            }
            set
            {
                if (value != null)
                {
                    _LabelFechaUltMod = value;
                    RaisePropertyChanged("LabelFechUltMod");
                }
            }
        }
        public string LabelUsuarioMod
        {
            get
            {
                return _LabelUsuarioMod;
            }
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
            get
            {
                return _LabelActivo;
            }
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
            get
            {
                return _LabelBorrado;
            }
            set
            {
                if (value != null)
                {
                    _LabelBorrado = value;
                    RaisePropertyChanged("LabelBorrado");
                }
            }
        }

        public async void OnAppearing()
        {
            var source_eva_planeacion_fuentes = FicNavigationContextC[0] as eva_planeacion_fuentes;

            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion_fuentes.IdPlaneacion;


            _LabelIdFuente = source_eva_planeacion_fuentes.IdFuente+"";
            _LabelPrioridad = source_eva_planeacion_fuentes.Prioridad;
            _LabelObservaciones = source_eva_planeacion_fuentes.Observaciones;

            _LabelFechaReg = source_eva_planeacion_fuentes.FechaReg.ToString();
            _LabelFechaUltMod = source_eva_planeacion_fuentes.FechaUltMod.ToString();
            _LabelUsuarioReg = source_eva_planeacion_fuentes.UsuarioReg;
            _LabelUsuarioMod = source_eva_planeacion_fuentes.UsuarioMod;
            _LabelActivo = source_eva_planeacion_fuentes.Activo;
            _LabelBorrado = source_eva_planeacion_fuentes.Borrado;

            eva_cat_fuentes_bibliograficas fuen = await IFicSrvFuentes.GetFuenteB(source_eva_planeacion_fuentes.IdFuente);

            _LabelDesFuenteCompleta = fuen.DesFuenteCompleta;
            RaisePropertyChanged("LabelDesFuenteCompleta");

            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdFuente");
            RaisePropertyChanged("LabelPrioridad");
            RaisePropertyChanged("LabelObservaciones");

            RaisePropertyChanged("LabelFechaReg");
            RaisePropertyChanged("LabelFechaMod");
            RaisePropertyChanged("LabelUsuarioReg");
            RaisePropertyChanged("LabelUsuarioMod");
            RaisePropertyChanged("LabelActivo");
            RaisePropertyChanged("LabelBorrado");

        }
    


        public ICommand FicMetRegresarFuentesICommand
        {
            get
            {
                return _FicMetRegresarFuentesICommand = _FicMetRegresarFuentesICommand ?? new FicVmDelegateCommand(FicMetRegresarFuentes);
            }
        }
        private async void FicMetRegresarFuentes()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmFuentesList>(FicNavigationContextC[1]);
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
