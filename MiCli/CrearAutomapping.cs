using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MiCli
{
    public class CrearAutomapping
    {
        public string MapeoParaNombreEnLugarDeClaveForanea(string modelo, string viewModel, string campo)
        {
            string mapeo = "CreateMap<" + modelo + ", " + viewModel + ">()" + Environment.NewLine +
                ".ForMember(x => x." + campo + ", opt => opt.MapFrom(z => z." + modelo + "." + campo + "));" + Environment.NewLine + Environment.NewLine;

            return mapeo;
        }


    }
}
