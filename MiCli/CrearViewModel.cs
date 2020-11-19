using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MiCli
{
    class CrearViewModel
    {
        public String ProducirGenerico(string viewModel)
        {

            String laRespuesta = "";
            switch (viewModel)
            {
                case "CustomerCountryRegion":
                    laRespuesta = "public int IdCustomerRegion { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "public int IdCustomerCategory { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "public int IdCustomerCountry { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "public string CustomerCountryName { get; set; }" + Environment.NewLine;                                
                    break;

                default:
                    laRespuesta = "ViewModel no encontrado, haga esta parte manualmente";
                    break;
            }

            return laRespuesta;
        }

    }
}
