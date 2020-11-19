using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCli
{
    class CrearModelo
    {
        public String Generar(string elModelo)
        {

            String laRespuesta = "";
            switch (elModelo)
            {
                case "Categories":
                    laRespuesta = "[Key]" + Environment.NewLine +
                                "public int IdCustomerCategory { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[Required]" + Environment.NewLine +
                                "[StringLength(50, ErrorMessage = \"Longitud máxima para el nombre 50\")]" + Environment.NewLine +
                                "public string Name { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[StringLength(100, ErrorMessage = \"Longitud máxima para la descripción 100\")]" + Environment.NewLine +
                                "public string Description { get; set; }" + Environment.NewLine + Environment.NewLine;
                    break;
                case "CustomerCities":
                    laRespuesta = "[Key]" + Environment.NewLine +
                                "public int IdCustomerCity { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[Required]" + Environment.NewLine +
                                "[StringLength(50, ErrorMessage = \"Longitud máxima para el nombre de la ciudad 50\")]" + Environment.NewLine +
                                "public string CustomerCity  { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[Range(0, int.MaxValue, ErrorMessage = \"Debe ser un número entero entre cero y 2147483647\")]" + Environment.NewLine +
                                "public int PostalCode  { get; set; }" + Environment.NewLine + Environment.NewLine; ;
                    break;
                case "CustomerCountries":
                    laRespuesta = "[Key]" + Environment.NewLine +
                                "public int IdCustomerCountry { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[Required]" + Environment.NewLine +
                                "[StringLength(50, ErrorMessage = \"Longitud máxima para el país: 50\")]" + Environment.NewLine +
                                "public string CustomerCountryName { get; set; }" + Environment.NewLine + Environment.NewLine;
                    break;
                case "CustomerRegions":
                    laRespuesta = "[Key]" + Environment.NewLine +
                                "public int IdCustomerRegion { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[Required]" + Environment.NewLine +
                                "[StringLength(50, ErrorMessage = \"Longitud máxima para la región: 50\")]" + Environment.NewLine +
                                "public string CustomerRegionName { get; set; }" + Environment.NewLine + Environment.NewLine;
                    break;
                case "Employees":
                    laRespuesta = "[Key]" + Environment.NewLine +
                                "public int IdEmployee { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[Required]" + Environment.NewLine +
                                "[StringLength(30, ErrorMessage = \"Longitud máxima para el nombre: 30\")]" + Environment.NewLine +
                                "public string FirstName { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[Required]" + Environment.NewLine +
                                "[StringLength(30, ErrorMessage = \"Longitud máxima para el apellido: 30\")]" + Environment.NewLine +
                                "public string LastName { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[Required]" + Environment.NewLine +
                                "[StringLength(30, ErrorMessage = \"Longitud máxima para el apellido: 30\")]" + Environment.NewLine +
                                "public string LastName { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[Required]" + Environment.NewLine +
                                "[StringLength(30, ErrorMessage = \"Longitud máxima para la dirección: 30\")]" + Environment.NewLine +
                                "public string Address { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[StringLength(16, ErrorMessage = \"Longitud máxima para el teléfono fijo: 16\")]" + Environment.NewLine +
                                "public string Phone { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[Required]" + Environment.NewLine +
                                "[StringLength(16, ErrorMessage = \"Longitud máxima para el celular: 16\")]" + Environment.NewLine +
                                "public string Mobile { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "[StringLength(30, ErrorMessage = \"Longitud máxima para el correo: 30\")]" + Environment.NewLine +
                                "public string Email { get; set; }" + Environment.NewLine + Environment.NewLine +
                                 Environment.NewLine;
                    break;
                default:
                    laRespuesta = "No encontrado";
                    break;
            }

            return laRespuesta;
        }

        public String CrearDto(string elModelo)
        {

            String laRespuesta = "";
            switch (elModelo)
            {
                case "Categories":
                    laRespuesta = "public int IdCategory { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "public string Name { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "public string Description { get; set; }" + Environment.NewLine + Environment.NewLine;
                    break;
                case "CustomerCities":
                    laRespuesta = "public int IdCustomerCity { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "public string CustomerCity  { get; set; }" + Environment.NewLine + Environment.NewLine +
                                "public int PostalCode  { get; set; }" + Environment.NewLine + Environment.NewLine; ;
                    break;
                case "CustomerCountries":
                    laRespuesta = "public int IdCustomerCountry { get; set; }" + Environment.NewLine +
                                "public string CustomerCountryName  { get; set; }" + Environment.NewLine + Environment.NewLine;                                
                    break;
                default:
                    laRespuesta = "Modelo no encontrado";
                    break;
            }

            return laRespuesta;
        }


        public String ObtenerTipoDeDato(String theItem)
        {
            switch (theItem)
            {
                case "Address":
                    return "string";
                case "CompanyName":
                    return "string";
                case "Email":
                    return "string";
                case "Mobile":
                    return "string";
                case "Notes":
                    return "string";
                case "Phone":
                    return "string";
                case "WebPage":
                    return "string";
                default:
                    return "string";
            }
        }

        public bool EsRequerido(string theItem)
        {
            switch (theItem)
            {
                case "Address":
                    return false;
                case "CompanyName":
                    return true;
                case "Email":
                    return false;
                case "Mobile":
                    return false;
                case "Notes":
                    return false;
                case "Phone":
                    return false;
                case "WebPage":
                    return false;
                default:
                    return false;
            }
        }

        public String ObtenerDataAnnotation(string theItem)
        {
            switch (theItem)
            {
                case "Address":
                    return "[StringLength(50, ErrorMessage = \"Longitud máxima para la dirección: 50\")]";
                case "CompanyName":
                    return "[StringLength(50, ErrorMessage = \"Longitud máxima para el nombre de la compañía: 50\")]";
                case "Email":
                    return "[RegularExpression(\"^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-] +\\.)+[a-zA-Z]{ 2,6}$\", ErrorMessage = \"Formato no valido\")]\")]";
                case "Mobile":
                    return "[StringLength(16, ErrorMessage = \"Longitud máxima para el celular: 16\")]";
                case "Notes":
                    return "[StringLength(100, ErrorMessage = \"Longitud máxima para las notas: 100\")]";
                case "Phone":
                    return "[StringLength(16, ErrorMessage = \"Longitud máxima para el teléfono fijo: 16\")]";
                case "WebPage":
                    return "[StringLength(50, ErrorMessage = \"Longitud máxima para la página: 50\")]";
                default:
                    return "";
            }
        }

    }
}
