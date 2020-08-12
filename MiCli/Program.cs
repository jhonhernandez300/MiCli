using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;


namespace MiCli
{   

    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            int cantidadDePropiedades = 99;            
            //int[] vector;

            //Se usan muchas variables string porque es más fácil trabajar así con parámetros de entrada de consola
            String comando = "Inicio";            
            String dataAnnotation = "";            
            String EnMinuscula = "";            
            String items = "";
            String item = "";
            String modelo = "";            
            String modeloSinPlural = "";
            String porDefecto = "1";
            String primeraLetra = "";
            String propiedad = "";
            String propiedadesListas = "";
            String relacionesConOtrosModelos = "";
            String requerido = "";
            String restoDeLaPalabra;
            String respuesta = "";
            String respuestaTemporal = "";            
            String tipoDeDato = "";
            String uno = "";
                       

            Console.WriteLine("CLI .net Core");
            Console.WriteLine("Introduzca su opción");
            Console.WriteLine("1 Con dto crear controlador, modelo y automapping");

            do
            {
                comando = Console.ReadLine();
                                
                switch (comando)
                {
                    
                    case "d":  //details
                        Console.WriteLine("Nombre del modelo ");
                        uno = Console.ReadLine();
                        primeraLetra = uno.Substring(0, 1);
                        primeraLetra = primeraLetra.ToLower();
                        restoDeLaPalabra = uno.Substring(1, uno.Length - 1);
                        EnMinuscula = primeraLetra + restoDeLaPalabra;
                        respuesta = "// GET: " + uno + "/Detail" + Environment.NewLine + "public ActionResult Detail(int? id)" 
                            + Environment.NewLine + "{" 
                            + Environment.NewLine + "   if (id == null)"
                            + Environment.NewLine + "   {"
                            + Environment.NewLine + "       return new HttpStatusCodeResult(HttpStatusCode.BadRequest);"
                            + Environment.NewLine + "   }"
                            + Environment.NewLine + "   var " + EnMinuscula + " = _context." + uno + "s" + ".SingleOrDefault(e => e."
                            + uno + ".Id == id);" + Environment.NewLine 
                            + Environment.NewLine + "   if (" + EnMinuscula + " == null)"
                            + Environment.NewLine + "   {"
                            + Environment.NewLine + "       return HttpNotFound();"
                            + Environment.NewLine + "   }"
                          + Environment.NewLine + "   return View(" + EnMinuscula + ");" 
                          + Environment.NewLine + "}" 
                          + Environment.NewLine +
                           Environment.NewLine;
                        break;                    
                    //case "fa":  //for con anchor  Angular
                    //    Console.WriteLine("1/2 Nombre del modelo ");
                    //    modelo = Console.ReadLine();
                    //    Console.WriteLine("2/2 Cuántas propiedades ");
                    //    cantidadDePropiedades = Convert.ToInt32(Console.ReadLine());
                    //    modeloSinPlural = modelo.Substring(0, modelo.Length - 1);

                    //    for (int i = 1; i <= cantidadDePropiedades; i++)
                    //    {
                    //        Console.WriteLine("Siguiente propiedad");
                    //        propiedad = Console.ReadLine();
                    //        propiedadesListas = propiedadesListas + "<h3>{{ " + modeloSinPlural + "." + propiedad + " }}</h3>" + Environment.NewLine;
                    //    }
                    //    propiedadesListas = propiedadesListas + "</div>" + Environment.NewLine;

                    //    respuesta = "<div *ngFor=\"let " + modeloSinPlural + " of " + modelo + "\"> " + Environment.NewLine + propiedadesListas;
                    //    break;
                    case "fh":  //for con header  Angular
                        Console.WriteLine("Nombre del modelo ");
                        uno = Console.ReadLine();
                        Console.WriteLine("Cuántas propiedades ");
                        cantidadDePropiedades = Convert.ToInt32(Console.ReadLine());
                        modeloSinPlural = uno.Substring(0, uno.Length - 1);

                        for (int i = 1; i <= cantidadDePropiedades; i++)
                        {
                            Console.WriteLine("Siguiente propiedad");
                            propiedad = Console.ReadLine();
                            propiedadesListas = propiedadesListas + "<h3>{{ " + modeloSinPlural + "." + propiedad + " }}</h3>" + Environment.NewLine;
                        }
                        propiedadesListas = propiedadesListas + "</div>" + Environment.NewLine;

                        respuesta = "<div *ngFor=\"let " + modeloSinPlural + " of " + uno + "\"> " + Environment.NewLine + propiedadesListas;
                        break;                                        
                    case "1":  //Controlador, modelo y automapping                 ******************************************************************
                        Console.WriteLine("Cree una clase con el nombre del modelo");
                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadLine();

                        Console.WriteLine("");
                        Console.WriteLine("Reemplace los using con los que ya están copiados en el portapapeles");
                        respuesta = "using System;" + Environment.NewLine +
                            "using System.Collections.Generic;" + Environment.NewLine +
                            "using System.ComponentModel.DataAnnotations;" + Environment.NewLine +
                            "using System.Linq;" + Environment.NewLine +
                            "using System.Threading.Tasks;" + Environment.NewLine;
                        Clipboard.SetText(respuesta);
                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadLine();

                        Console.WriteLine("Digite 1 si desea el modelo por defecto, 2 si quiere ingresar los campos");
                        porDefecto = Console.ReadLine();
                        RelacionesConOtrosModelos relaciones = new RelacionesConOtrosModelos();
                        Helpers helpers = new Helpers();
                        CrearModelo crearModelo = new CrearModelo();

                        if (porDefecto == "1")                       {
                            

                            Console.WriteLine("Modelo");
                            modelo = Console.ReadLine();

                            if (modelo.Length > 25)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("El modelo no sirve porque es muy largo");
                            }
                            else
                            {
                                respuesta = crearModelo.Generar(modelo);
                                relacionesConOtrosModelos = relaciones.Calcular(modelo);
                                respuesta = respuesta + relacionesConOtrosModelos;

                                Console.WriteLine("");
                                Console.WriteLine("Si no tiene la carpeta Models, créela");
                                Console.WriteLine("Cree una nueva clase con el nombre del modelo");
                                Clipboard.SetText(respuesta);
                                Console.WriteLine("Pegue el modelo creado que ya está copiado en el portapapeles");
                                Console.WriteLine("Presione una tecla para continuar");
                                Console.ReadLine();

                                Console.WriteLine("using System;" + Environment.NewLine +
                                               "using System.Collections.Generic;" + Environment.NewLine +
                                               "using System.ComponentModel.DataAnnotations;" + Environment.NewLine +
                                               "using System.ComponentModel.DataAnnotations.Schema;" + Environment.NewLine +
                                               "using System.Linq;" + Environment.NewLine +
                                               "using System.Threading.Tasks;" + Environment.NewLine + Environment.NewLine
                                               );
                                Clipboard.SetText(respuesta);
                                Console.WriteLine("Agregue los using copiados en el portapapeles");
                                Console.ReadLine();

                                respuesta = crearModelo.CrearDto(modelo);
                                respuesta = respuesta + relacionesConOtrosModelos;

                                Console.WriteLine("");
                                Console.WriteLine("Si no tiene la carpeta con el nombre del modelo + Dto, créela");
                                Console.WriteLine("Cree una nueva clase con el nombre del modelo adicionando Dto");
                                Clipboard.SetText(respuesta);
                                Console.WriteLine("Pegue el modelo Dto creado que ya está copiado en el portapapeles");
                                Console.WriteLine("Presione una tecla para continuar");
                                Console.ReadLine();

                                Console.WriteLine("");
                                Console.WriteLine("Cree un controlador con el nombre del modelo con vistas que usan EF");
                                Console.WriteLine("Modifique el controlador");
                                Console.WriteLine("Agregue estos using");
                                Console.WriteLine("using System;" + Environment.NewLine +
                                               "using System.Collections.Generic;" + Environment.NewLine +
                                               "using System.Linq;" + Environment.NewLine +
                                               "using System.Threading.Tasks;" + Environment.NewLine +
                                               "using Microsoft.AspNetCore.Mvc;" + Environment.NewLine +
                                               "using Microsoft.AspNetCore.Mvc.Rendering;" + Environment.NewLine +
                                               "using Microsoft.EntityFrameworkCore;" + Environment.NewLine +
                                               "using ManufacturaMVC.Models;" + Environment.NewLine +
                                               "using AutoMapper;" + Environment.NewLine +
                                               "using ManufacturaMVC.ViewModels;" + Environment.NewLine +
                                               "using ManufacturaMVC.Dto;" + Environment.NewLine +
                                               "using ManufacturaMVC.Migrations;" + Environment.NewLine + Environment.NewLine
                                               );

                                Console.WriteLine("Presione una tecla para continuar");
                                Console.ReadLine();

                                Console.WriteLine("");
                            }
                        }
                        else if (porDefecto == "2")
                        {
                            Console.WriteLine("Ingrese los ítems del modelo. Se agregará Id como clave primaria");
                            Console.WriteLine("Cuántos items va a ingresar");
                            items = Console.ReadLine();
                            respuesta = "";

                            for (int i = 1; i <= Convert.ToInt32(items); i++)
                            {
                                Console.WriteLine("Item " + i);
                                item = Console.ReadLine();
                                tipoDeDato = crearModelo.ObtenerTipoDeDato(item);
                                requerido = crearModelo.EsRequerido(item) ? "[Required]" : " ";
                                dataAnnotation = crearModelo.ObtenerDataAnnotation(item);

                                respuestaTemporal = requerido + Environment.NewLine +
                                    dataAnnotation + Environment.NewLine +
                                    "public " + tipoDeDato + " " + item + " { get; set;}" + Environment.NewLine +
                                    Environment.NewLine;
                                respuesta = respuesta + respuestaTemporal;
                            }
                                                        
                            relacionesConOtrosModelos = relaciones.Calcular(modelo);
                            respuesta = respuesta + relacionesConOtrosModelos;
                            //Instrucciones(respuesta);
                        }
                        else 
                        {
                            Console.WriteLine("Las opciones son 1 o 2");
                            Console.ReadLine();
                        }
                        break;

                }

                Console.WriteLine(Environment.NewLine + Environment.NewLine);
                Console.WriteLine("********************   Introduzca su opción ***********************");
                Console.WriteLine("1 Con dto crear controlador, vistas y automapping");
                Console.WriteLine("99 Salir");
            } while (comando != "99");

            Environment.Exit(1);

            

            

            


            //vector[i] = Int32.Parse(Console.ReadLine());
            //Console.WriteLine("-------------");
            //Console.ReadLine();
        }
    }
}
