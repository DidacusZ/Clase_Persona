﻿using Clases_Persona.entidades;
using Clases_Persona.servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Persona
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variables
            int opcion;

            //constructor vacio
            Persona persona = new Persona();

            //implementamos los constructores con la interfaz
            InterfaceMenu menu = new ImplMenu();
            InterfacePersona util = new ImplPersona();

            //lista de personas
            List<Persona> listaPersonas = new List<Persona>();

            //● Con AppendText, si el fichero existe escribirá a continuación.  si no lo crea
            //StreamWriter sw = File.AppendText("Personas.txt");

            //StreamReader sr = new StreamReader("Personas.txt", Encoding.Default);//asi


            do
            {
                opcion = menu.Menu();
                Console.Clear();
                switch (opcion)
                {
                    //nueva persona
                    case 1:
                        util.AgregarPersona();
                        break;

                    //mostrar personas
                    case 2:
                        util.MostrarPersonas(listaPersonas);
                        break;

                    //salir
                    case 0:
                        break;

                    //control error
                    default:
                        Console.Write("\n\n\t\tOpción no válida, pulsa una tecla para volver al menu");
                        Console.ReadKey(true);
                        break;
                }
            } while (opcion!=0);

            //sw.Close();
            Console.Write("\n\n\t\tPulsa una tecla para SALIR...");
            Console.ReadKey(true);
        }
    }
}
