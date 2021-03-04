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

        string ruta = @"Persona.txt";
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
            List<Persona> personas = Consultar();
            FileStream file = new FileStream(ruta,FileMode.Create);
            file.Close();
            foreach (var item in personas)
            {
                if (!item.Identificacion.Equals(identificacion))
                {
                    Guarda(item);
                }
            }

        }

        public List<Persona> Consultar()
        {
            List<Persona> personas = new List<Persona>();
            FileStream file = new FileStream(ruta,FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {
                Persona persona = MapearPersona(linea);
                personas.Add(persona);
            }
            file.Close();
            reader.Close();
            return personas;
        }

        private static Persona MapearPersona(string linea)
        {
            string[] datosPersona = linea.Split(';');
            Persona persona = new Persona();
            persona.Identificacion = datosPersona[0];
            persona.Nombre = datosPersona[1];
            persona.Sexo = datosPersona[2];
            persona.Edad = int.Parse(datosPersona[3]);
            persona.Pulsacion = Convert.ToDecimal(datosPersona[4]);
            return persona;
        }

        public Persona BuscarPorIdentificacion(string identificacion)
        {
            foreach (var item in Consultar())
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }
            return null;
        }

        public void Modificar(Persona personaNueva, string identificacion)
        {
            List<Persona> personas = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();
            foreach (var item in personas)
            {
                if (!item.Identificacion.Equals(identificacion))
                {
                    Guarda(item);
                }
                else
                {
                    Guarda(personaNueva);
                }
            }
        }


        public List<Persona> ConsultarMayoresDeEdad() 
        {

            List<Persona> personas = new List<Persona>();
            // aun no hace el filtro;
            return personas;
        }



    }
}
