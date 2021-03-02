using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PersonaRepository
    {

        string ruta = "Persona.txt";
        public void Guarda(Persona persona)
        {
            FileStream file = new FileStream(ruta,FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{persona.Identificacion};{persona.Nombre};{persona.Sexo};{persona.Edad};{persona.Pulsacion}");
            escritor.Close();
            file.Close();

        }

        public void Eliminar(string identificacion)
        {

        }

        public List<Persona> Consultar()
        {
            List<Persona> personas = new List<Persona>();
            return personas;
        }


        public void BuscarPorIdentificacion(string identificacion)
        {

        }

        public void Modificar(Persona personaNueva, string Identificacion)
        {

        }



    }
}
