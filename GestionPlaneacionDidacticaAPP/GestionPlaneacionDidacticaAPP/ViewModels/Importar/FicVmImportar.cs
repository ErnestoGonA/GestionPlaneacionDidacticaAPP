using GestionPlaneacionDidacticaAPP.Interfaces.Importar;
using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Importar
{
    public class FicVmImportar
    {
        public ICommand _Importar, _Exportar;

        private IFicSrvNavigationInventario IFicSrvNavigationInventario;
        private IFicImportar IFicImportar;

        public FicVmImportar(IFicSrvNavigationInventario ficSrvNavigationInventario,
            IFicImportar IFicImportar)
        {
            IFicSrvNavigationInventario = ficSrvNavigationInventario;
            this.IFicImportar = IFicImportar;
            this.IFicImportar = IFicImportar;
        }
        public async void OnAppearing()
        {

        }
        public ICommand Importar
        {
            get { return _Importar = _Importar ?? new FicVmDelegateCommand(ImportarCommandExecute); }
        }
        private async void ImportarCommandExecute()
        {
            try
            {
                var res = await IFicImportar.FicMetExportar();

                if (res == "OK")
                {
                    await new Page().DisplayAlert("Importar", "Importados correctamente!", "OK");
                }
                else
                {
                    await new Page().DisplayAlert("Error al importar", res.ToString(), "OK");
                }

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Exception", e.Message.ToString(), "OK");
            }
        }
        public ICommand Exportar
        {
            get { return _Exportar = _Exportar ?? new FicVmDelegateCommand(ImportarCommandExecute); }
        }
        private async void ExportarCommandExecute()
        {
            try
            {
                var res = await IFicImportar.FicMetExportar();

                if (res == "OK")
                {
                    await new Page().DisplayAlert("Importar", "Importados correctamente!", "OK");
                }
                else
                {
                    await new Page().DisplayAlert("Error al importar", res.ToString(), "OK");
                }

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Exception", e.Message.ToString(), "OK");
            }
        }

    }
}
