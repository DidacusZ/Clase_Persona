using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Persona.entidades
{
    internal class Persona
    {
        //atributos
        string nombre;
        string apellidos;
        int anio, mes, dia;

        //constructor vacio
        public Persona()
        {
        }

        //constructor
        public Persona(string nombre, string apellidos, int dia, int mes, int anio)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.anio = anio;
            this.mes = mes;
            this.dia = dia;
        }

        //getters y setters
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Anio { get => anio; set => anio = value; }
        public int Mes { get => mes; set => mes = value; }
        public int Dia { get => dia; set => dia = value; }

        override// para sustituir el ToString de la clase object y que salga este 
        public string ToString()
        {
            string concatenacion = "";
            concatenacion = String.Format("{0},{1},{2},{3},{4}", nombre, apellidos, dia,mes,anio);
            return concatenacion;
        }
    }
}
