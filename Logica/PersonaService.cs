using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PersonaService
    {
        PersonaRepository personaRepository = new PersonaRepository();
        public string Guardar(Persona persona)
        {
            
            try
            {
                personaRepository.Guarda(persona);
                return "Se guardaron los Datos Satisfactoriamente";
            }
            catch (Exception exception)
            {

                return "Se presentó el Siguiente error" + exception.Message;
            }
        }
    }
}
