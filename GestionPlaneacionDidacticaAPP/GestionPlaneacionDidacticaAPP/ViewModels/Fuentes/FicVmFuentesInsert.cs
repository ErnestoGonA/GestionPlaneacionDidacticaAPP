using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.Interfaces.Fuentes;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using GestionPlaneacionDidacticaAPP.Models;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;
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
    public class FicVmFuentesInsert : INotifyPropertyChanged
    {
        //Interfaces
        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicSrvFuentes IFicSrvFuentes;
        private FicISrvPlaneacion IFicSrvPlaneacion;


        //Labels
        private string _LabelUsuario;
        private int _LabelIdPlaneacion;
        private string _LabelIdAsignatura;


        public List<string> _ListFuentesB;
        public string _Fuente;
        public Int16 _FuIndex=0;

        private short _LabelPrioridad;
        private string _LabelObservaciones;

        //Botones
        private ICommand _MetRegresarTemasListICommand, _SaveCommand;

        //Valor mandado de view padre a hija
        public object FicNavigationContextC { get; set; }

        public FicVmFuentesInsert(IFicSrvNavigationInventario ficSrvNavigationInventario, IFicSrvFuentes srvTemas, FicISrvPlaneacion iFicSrvPlaneacion)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            IFicSrvFuentes = srvTemas;
            IFicSrvPlaneacion = iFicSrvPlaneacion;
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

        public string Fuente
        {
            get
            {
                return _Fuente;
            }
            set
            {
                _Fuente = value;
                RaisePropertyChanged("Fuente");
            }
        }

        public short FuIndex
        {
            get
            {
                return _FuIndex;
            }
            set
            {
                _FuIndex = value;
                RaisePropertyChanged("FuIndex");
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
        

        public short LabelPrioridad
        {
            get { return _LabelPrioridad; }
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

        public ICommand MetRegresarFuentesListICommand
        {
            get
            {
                return _MetRegresarTemasListICommand = _MetRegresarTemasListICommand ?? new FicVmDelegateCommand(MetRegresarFuentesList);
            }
        }

        private async void MetRegresarFuentesList()
        {
            try
            {
                IFicSrvNavigationInventario.FicMetNavigateTo<FicVmFuentesList>(FicNavigationContextC);
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

                var source_eva_planeacion = FicNavigationContextC as eva_planeacion;

                var res = await IFicSrvFuentes.InsertFuente(new eva_planeacion_fuentes()
                {
                    IdAsignatura = source_eva_planeacion.IdAsignatura,
                    IdPlaneacion = source_eva_planeacion.IdPlaneacion,
                    IdFuente = (Int16)(FuIndex+1),
                    Prioridad = LabelPrioridad,
                    Observaciones = LabelObservaciones,

                    FechaReg = DateTime.Now,
                    FechaUltMod = DateTime.Now,
                    UsuarioReg = FicGlobalValues.USUARIO,
                    UsuarioMod = FicGlobalValues.USUARIO,
                    Activo = "S",
                    Borrado = "N"
                });

                if (res == "Ok")
                {
                    await new Page().DisplayAlert("Insert", "¡INSERTADO CON EXITO!", "OK");
                    IFicSrvNavigationInventario.FicMetNavigateTo<FicVmFuentesList>(FicNavigationContextC);
                }
                else if (res == "Exists")
                {
                    await new Page().DisplayAlert("Insert", "¡La fuente ya existe, intenta con otra!", "OK");
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

        public async void OnAppearing()
        {

            var source_eva_planeacion = FicNavigationContextC as eva_planeacion;
            _LabelUsuario = FicGlobalValues.USUARIO;
            _LabelIdAsignatura = FicGlobalValues.ASIGNATURA;
            _LabelIdPlaneacion = source_eva_planeacion.IdPlaneacion;

            RaisePropertyChanged("ListFuentesB");
            RaisePropertyChanged("LabelUsuario");
            RaisePropertyChanged("LabelIdAsignatura");
            RaisePropertyChanged("LabelIdPlaneacion");
            RaisePropertyChanged("LabelObservaciones");
            RaisePropertyChanged("LabelIdFuente");
            RaisePropertyChanged("LabelPrioridad");
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
