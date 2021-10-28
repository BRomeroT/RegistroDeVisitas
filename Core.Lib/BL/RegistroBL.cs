using Core.Model;
using Sysne.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.BL
{
    internal class RegistroBL : ObservableObject
    {
        public bool RegistrarVisita(Visita visita)
        {
            Debug.WriteLine(visita);
            return true;
        }
    }
}
