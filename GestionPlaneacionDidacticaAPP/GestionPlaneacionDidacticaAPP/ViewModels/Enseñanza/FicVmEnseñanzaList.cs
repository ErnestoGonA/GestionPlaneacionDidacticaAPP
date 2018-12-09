using GestionPlaneacionDidacticaAPP.Interfaces.Navegacion;
using GestionPlaneacionDidacticaAPP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using GestionPlaneacionDidacticaAPP.Interfaces.Planeacion;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using GestionPlaneacionDidacticaAPP.ViewModels.Base;
using System.Threading.Tasks;
using GestionPlaneacionDidacticaAPP.Data;
using GestionPlaneacionDidacticaAPP.ViewModels.Temas;

namespace GestionPlaneacionDidacticaAPP.ViewModels.Enseñanza
{
    public class FicVmEnseñanzaList : INotifyPropertyChanged
    {


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName]string propertyname = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        #endregion
    }
}
