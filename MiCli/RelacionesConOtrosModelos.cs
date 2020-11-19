using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MiCli
{
    class RelacionesConOtrosModelos
    {
        private int[] CantidadDeRelaciones = new int[2];        //En cada posición se guardará la cantidad de relaciones. En la posición 0 las Uno a Muchos, en la 1 Muchos a uno, etc.

        public string tipoDeRelacion { get; set; }

        Helpers helpers = new Helpers();

        public String Calcular(String elModelo, string elOtroModeloConElQueEstaRelacionado)
        {
            bool hayVariasRelaciones = true;

            String laRespuesta = "";
            String claveForanea = "";
            String laRelacion = "";                     

            Console.WriteLine("Ingrese las relación");

            do
            {
                Console.WriteLine(Environment.NewLine +
                                  "1. Uno a Muchos");
                Console.WriteLine("2. Muchos a Uno");
                Console.WriteLine("3. Uno a Uno");
                Console.WriteLine("4. No tiene más");
                laRelacion = Console.ReadLine();                

                switch (laRelacion)
                {
                    case "1":                        
                        laRespuesta = laRespuesta + Environment.NewLine +
                        "public ICollection<" + elOtroModeloConElQueEstaRelacionado + ">" + elOtroModeloConElQueEstaRelacionado + " {get; set;}" + Environment.NewLine;
                        Console.WriteLine("Relación agregada");
                        this.tipoDeRelacion = "Uno a Muchos";
                        CantidadDeRelaciones[0] += 1; 
                        break;
                    case "2":                                                
                        Console.WriteLine("Cuál es la clave foránea");
                        claveForanea = Console.ReadLine();

                        laRespuesta = laRespuesta + Environment.NewLine +
                            "[ForeignKey(\"" + claveForanea + "\")]" + Environment.NewLine +
                            "public int " + claveForanea + " { get; set; }" + Environment.NewLine +
                        "public " + elOtroModeloConElQueEstaRelacionado + helpers.QuitarPlural(elOtroModeloConElQueEstaRelacionado) + " {get; set;}" + Environment.NewLine;
                        Console.WriteLine("Relación agregada");
                        break;
                    case "3":
                        Console.WriteLine("El otro modelo con el que está relacionado");
                        elOtroModeloConElQueEstaRelacionado = Console.ReadLine();
                        laRespuesta = laRespuesta + Environment.NewLine +
                        "public " + elOtroModeloConElQueEstaRelacionado + helpers.QuitarPlural(elOtroModeloConElQueEstaRelacionado) + " {get; set;}" + Environment.NewLine;
                        Console.WriteLine("Relación agregada");
                        this.tipoDeRelacion = "Uno a Muchos";
                        break;
                    default:
                        hayVariasRelaciones = false;
                        if (this.tipoDeRelacion == "") { this.tipoDeRelacion = "No tiene ninguna"; } //No ha escogido alguna de las opciones anteriores
                        break;
                }
            } while (hayVariasRelaciones == true);

            return laRespuesta;
        }

        

    }
}
