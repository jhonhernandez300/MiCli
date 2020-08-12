using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MiCli
{
    class Helpers
    {        
        
        public void Instrucciones(String laRespuesta)
        {
            Clipboard.SetText(laRespuesta);
            Console.WriteLine("Adicione los modelos con los DataAnnotations que ya están copiados en el portapapeles");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadLine();
        }

        public string PonerPalabraEnMinuscula(String cadena)
        {
            string primeraLetra = "";
            string restoDeLaPalabra = "";

            primeraLetra = cadena.Substring(0, 1);
            primeraLetra = primeraLetra.ToLower();
            restoDeLaPalabra = cadena.Substring(2);
            return primeraLetra + restoDeLaPalabra;
        }

        public String QuitarPlural(String elPlural)
        {
            int longitud = elPlural.Length;

            String antePenultimaPalabra = elPlural.Substring(longitud - 3, 1);
            String palabraArmada = "";
            String penultimaPalabra = elPlural.Substring(longitud - 2, 1);
            String ultimaPalabra = elPlural.Substring(longitud - 1, 1);

            if (antePenultimaPalabra == "i" && penultimaPalabra == "e" && ultimaPalabra == "s")//Categories ies
            {
                palabraArmada = elPlural.Substring(0, longitud - 3) + "y"; //Category y
            }
            else if (ultimaPalabra == "s")
            {
                palabraArmada = elPlural.Substring(0, longitud - 1); //Region s
            }

            return palabraArmada;
        }

        /*public String PonerIf()
        {
            Console.WriteLine("1/1 Condición");
            /*uno = Console.ReadLine();
            return "if(" + uno + ") {" + Environment.NewLine + Environment.NewLine + "}";*/
        /*}*/

    }
}
