using Clases_Persona.entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Persona.servicios
{
    internal interface InterfacePersona
    {
        string Pedir(string mensaje);

        int CapturaEntero(string texto, int min, int max);

        List<Persona> AgregarPersona(List<Persona> listaPersonas);

        void MostrarPersonas(List<Persona> listaPersonas, StreamWriter sw);
    }
}
