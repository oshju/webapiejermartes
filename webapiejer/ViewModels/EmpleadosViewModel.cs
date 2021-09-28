using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using webapiejer.Helpers;
using webapiejer.Models;
using webapiejer.ViewModels.Base;

namespace webapiejer.ViewModels
{
    public class EmpleadosViewModel : ViewModelBase
    {
        HelperEmpleadosAzure helper;

        public EmpleadosViewModel()
        {
            helper = new HelperEmpleadosAzure();
            Task.Run(async () => {
                List<Empleados> lista = await helper.GetEmpleados();
                this.Empleado = new ObservableCollection<Empleados>(lista);
            });
        }

        private ObservableCollection<Empleados> _Empleado;

        public ObservableCollection<Empleados> Empleado
        {
            get { return this._Empleado; }
            set
            {
                this._Empleado = value;
                OnPropertyChanged("Empleado");
            }
        }

    }
}
