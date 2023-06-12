using Clases_Persona.entidades;
using System;
using System.Collections;
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

        public void Error(string txt)
        {
            Console.Write("\n\n\t\t{0}....",txt);
            Console.ReadKey(true);
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

        public void MostrarPersonas(List<Persona> listaPersonas)
        {
            StreamReader sr = new StreamReader("Personas.txt", Encoding.Default);//asi      
            List<string> listaLineas = new List<string>();

            //leo todo el fichero
            Console.WriteLine("\n\t---Leemos el fichero completo----\n");
            while (!(sr.EndOfStream)) // Mientras no estoy en el final del fichero
            {
                string linea;
                linea = sr.ReadLine();
                Console.WriteLine(linea);
                listaLineas.Add(linea); // guardo en la lista de todas las lineas del fichero
            }

            listaPersonas.Clear();//borramos el contenido de la lista para que no haya duplicados
            Console.WriteLine("\n\t---Leemos listaLineas a partir de la segunda linea----\n");
            for (int i = 1; i < listaLineas.Count; i++)
            {
                Console.WriteLine(listaLineas[i]);
                string[] vLineas= listaLineas[i].Split(','); // separo los campos en el vector

                //guardamos los campos en el objeto persona
                Persona persona = new Persona();

                persona.Nombre = vLineas[0];
                persona.Apellidos = vLineas[1];
                persona.Dia = Convert.ToInt32(vLineas[2]);
                persona.Mes = Convert.ToInt32(vLineas[3]);
                persona.Anio = Convert.ToInt32(vLineas[4]);

                //añadimos objeto a lista              
                listaPersonas.Add(persona);                    
            }
            
            Console.WriteLine("\n\t---Leemos de la listaPersonas----\n");
            for (int i = 0; i < listaPersonas.Count; i++)
            {
                Console.WriteLine(listaPersonas[i].ToString());
            }
            
            sr.Close();
            Console.Write("\n\n\t\tPulsa una tecla para continuar...");
            Console.ReadKey(true);
        }

        public void AgregarPersona()
        {
            StreamWriter sw;

            if (File.Exists("Personas.txt"))
            {
                sw = File.AppendText("Personas.txt");                
            }
            else
            {
                sw = File.AppendText("Personas.txt");
                sw.WriteLine("Nombre,Apellido,Dia,Mes,Anio");
            }     

            Persona persona = new Persona();

            persona.Nombre = Pedir("Dime el nombre");
            persona.Apellidos = Pedir("Dime el apellido");
            persona.Dia = Convert.ToInt32(CapturaEntero("Dime la fecha de nacimiento (dia)", 1, 31));
            persona.Mes = Convert.ToInt32(CapturaEntero("Dime la fecha de nacimiento (mes)", 1, 12));
            persona.Anio = Convert.ToInt32(CapturaEntero("Dime la fecha de nacimiento (año)", 1942, 2023));
            sw.WriteLine(persona.ToString());
            sw.Close();
            
        }

    }
}
