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
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Fuentes
{
    public class FicVmFuentesUpdate : INotifyPropertyChanged
    {
        private ICommand _FicMetRegresarFuentesICommand, _SaveCommand;

        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion, _LabelPrioridad;
        public Int16 _IdFuente;
        private string _LabelIdAsignatura;
        private string _LabelObservaciones;
        private string _LabelFechaReg, _LabelUsuarioReg, _LabelFechaUltMod, _LabelUsuarioMod, _LabelActivo, _LabelBorrado;
        public List<string> _ListFuentesB;
        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvFuentes IFicSrvFuentes;

        public object[] FicNavigationContextC { get; set; }

        public FicVmFuentesUpdate(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvFuentes srvFuentes)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvFuentes = srvFuentes;
            _ListFuentesB = GetListFuentesB().Result;
        }

        public async Task<List<string>> GetListFuentesB()
        {
            var listaAsignaturas = await IFicSrvFuentes.FicMetGetListFuentesB();
            List<string> aux = new List<string>();
            if (listaAsignaturas != null)
            {
                foreach (eva_cat_fuentes_bibliograficas asignaturas in listaAsignaturas)
                {
                    aux.Add(asignaturas.DesFuenteCompleta);
                }
                return aux;
            }
            return null;
        }

        public short IdFuente
        {
            get { return _IdFuente; }
            set
            {
                if (value != null)
                {
                    _IdFuente = value;
                    RaisePropertyChanged("IdFuente");
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

        public List<string> ListFuentesB
        {
            get
            {
                return _ListFuentesB;
            }
            set
            {
                if (value != null)
                {
                    _ListFuentesB = value;
                    RaisePropertyChanged("ListFuentesB");
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

            
            _LabelPrioridad = source_eva_planeacion_fuentes.Prioridad;
            _LabelObservaciones = source_eva_planeacion_fuentes.Observaciones;
            
            _IdFuente = (Int16)(source_eva_planeacion_fuentes.IdFuente - 1);


            RaisePropertyChanged("IdFuente");
            RaisePropertyChanged("LabelAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelIdFuente");
            RaisePropertyChanged("LabelPrioridad");
            RaisePropertyChanged("LabelObservaciones");
        }


        public ICommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new FicVmDelegateCommand(SaveCommandExecute); }
        }

        private async void SaveCommandExecute()
        {
            var source_eva_planeacion_fuentes = FicNavigationContextC[0] as eva_planeacion_fuentes;
            var source_eva_planecion = FicNavigationContextC[1] as eva_planeacion;
            try
            {
                var RespuestaInsert = await IFicSrvFuentes.UpdateFuente(new eva_planeacion_fuentes()
                {
                    IdAsignatura = source_eva_planeacion_fuentes.IdAsignatura,
                    IdPlaneacion = source_eva_planecion.IdPlaneacion,
                    IdFuente = (Int16)(this._IdFuente + 1),

                    Prioridad = (short)LabelPrioridad,
                    Observaciones = LabelObservaciones,

                    FechaReg = source_eva_planeacion_fuentes.FechaReg,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = source_eva_planeacion_fuentes.UsuarioReg,
                    UsuarioMod = LabelUsuario,
                    Activo = "S",
                    Borrado = "N"
                });

                if (RespuestaInsert == "OK")
                {
                    await new Page().DisplayAlert("ADD", "¡EDITADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmFuentesList>(FicNavigationContextC[1]);
                }
                else if (RespuestaInsert == "Exists")
                {
                    await new Page().DisplayAlert("Insert", "¡La fuente ya existe, intenta con otra!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmFuentesList>(FicNavigationContextC[1]);
                }
                else
                {
                    await new Page().DisplayAlert("ADD", RespuestaInsert.ToString(), "OK");
                }//SE INSERTO EL CONTEO?
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }//MANEJO GLOBAL DE ERRORES
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
