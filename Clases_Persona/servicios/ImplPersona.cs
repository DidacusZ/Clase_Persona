using Clases_Persona.entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Persona.servicios
{
    internal class ImplPersona: InterfacePersona
    {       
        public string Pedir(string mensaje)
        {
            Console.Write("\n\t\t{0}: ", mensaje);
            return Console.ReadLine();
        }

        public int CapturaEntero(string texto, int min, int max)
        {
            bool esCorrecto;
            int valor;
            do
            {
                Console.Write("{0} [{1}..{2}]:", texto, min, max);
                esCorrecto = Int32.TryParse(Console.ReadLine(), out valor);
                if (!esCorrecto)
                    Console.WriteLine("\n\n\t** Error: el valor introducido no es un número entero");
                else if (valor < min || valor > max)
                {
                    esCorrecto = false;
                    Console.WriteLine("\n\n\t** Error: el valor introducido no está dentro del rango");
                }
            } while (!esCorrecto);
            return valor;
        }

        public void MostrarPersonas(List<Persona> listaPersonas, StreamWriter sw)
        {
            for (int i = 0; i < listaPersonas.Count; i++)
            {
                Console.WriteLine(listaPersonas[i].ToString());
                sw.WriteLine(listaPersonas[i].ToString());
            }
            
            Console.Write("\n\n\t\tPulsa una tecla para continuar...");
            Console.ReadKey(true);
        }

        public List<Persona> AgregarPersona(List<Persona> listaPersonas)
        {
            Persona persona = new Persona();

            persona.Nombre = Pedir("Dime el nombre");
            persona.Apellidos = Pedir("Dime el apellido");
            persona.Dia = Convert.ToInt32(CapturaEntero("Dime la fecha de nacimiento (dia)", 1, 31));
            persona.Mes = Convert.ToInt32(CapturaEntero("Dime la fecha de nacimiento (mes)", 1, 12));
            persona.Anio = Convert.ToInt32(CapturaEntero("Dime la fecha de nacimiento (año)", 1942, 2023));
            listaPersonas.Add(persona);

            return listaPersonas;
        }
    }
}
