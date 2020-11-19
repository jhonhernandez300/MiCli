using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MiCli
{
    class Instrucciones
    {
        private string elOtroModeloConElQueEstaRelacionado;               
                
        CrearControlador crearControlador = new CrearControlador();


        public void ReemplazarElUsingDelModelo()
        {
            string respuesta = "";

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
        }

        public void CrearClaseConElNombreDelModelo(string respuesta)
        {
            Console.WriteLine("");
            Console.WriteLine("Si no tiene la carpeta Models, créela");
            Console.WriteLine("Cree una nueva clase con el nombre del modelo");
            Clipboard.SetText(respuesta);
            Console.WriteLine("Pegue el modelo creado que ya está copiado en el portapapeles");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadLine();
        }

        public void CrearDto(string respuesta)
        {
            Console.WriteLine("");
            Console.WriteLine("Si no tiene la carpeta con el nombre del modelo + Dto, créela");
            Console.WriteLine("Cree una nueva clase con el nombre del modelo adicionando Dto");
            Clipboard.SetText(respuesta);
            Console.WriteLine("Pegue el modelo Dto creado que ya está copiado en el portapapeles");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadLine();
        }

        public void CrearControladorNuevoYAgregarUsing()
        {
            string respuesta;

            Console.WriteLine("");
            Console.WriteLine("Cree un controlador con el nombre del modelo y con vistas que usan EF");
            Console.WriteLine("Agregue estos using");
            respuesta = "using System;" + Environment.NewLine +
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
                           "using ManufacturaMVC.Migrations;" + Environment.NewLine + Environment.NewLine;

            Clipboard.SetText(respuesta);

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadLine();
            Console.WriteLine("");
        }

        public void CrearViewModel()
        {
            string viewModel = "";
            CrearViewModel crearViewModel = new CrearViewModel();

            Console.WriteLine(" ");
            Console.WriteLine("Cree una carpeta con nombre ViewModel");
            Console.WriteLine("Cree una clase con el nombre del ViewModel");
            Console.WriteLine("Ingrese el nombre del ViewModel a crear");
            viewModel = Console.ReadLine();
            
            viewModel = crearViewModel.ProducirGenerico(viewModel);
            Clipboard.SetText(viewModel);
            Console.WriteLine("Pegue el ViewModel generado");
        }

        public string AgregarControladorUsandoDosModelos(string modeloPrincipal, string modeloSecundario, string controlador)        
        {
            crearControlador.procesarElNombreDelModelo(modeloPrincipal);

            string elControlador = crearControlador.InyeccionDeDependencias() +
                crearControlador.CrearIndexConUnModelo();
                            
            return elControlador;
        }

        public string AgregarControladorUsandoUnModelo(string modeloPrincipal)
        {
            crearControlador.procesarElNombreDelModelo(modeloPrincipal);

            string elControlador =  crearControlador.InyeccionDeDependencias() +
                crearControlador.CrearIndexConUnModelo() +
                crearControlador.CrearDetailsConUnModelo() + 
                crearControlador.CrearCreateConUnModelo()
                ;

            return elControlador;
        }

        public void setModeloRelacionado()
        {
            Console.WriteLine("El otro modelo con el que está relacionado");
            elOtroModeloConElQueEstaRelacionado = Console.ReadLine();
        }

        public string getModeloRelacionado()
        {
            return elOtroModeloConElQueEstaRelacionado;
        }

    }
}
