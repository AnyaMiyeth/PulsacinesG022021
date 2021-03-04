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
                if (personaRepository.BuscarPorIdentificacion(persona.Identificacion)==null)
                {
                    personaRepository.Guarda(persona);
                    return "Se guardaron los Datos Satisfactoriamente";
                }
                return $"No es posible Guardar a la Persona, La identificacion {persona.Identificacion} ya se encuentra registrada";
           
            }
            catch (Exception exception)
            {

                return "Se presentó el Siguiente error" + exception.Message;
            }
        }


        public string Eliminar(string identificacion)
        {
            try
            {
                if (personaRepository.BuscarPorIdentificacion(identificacion)!=null)
                {
                    personaRepository.Eliminar(identificacion);
                    return "Se Elimino Satisfactoriamente";
                }
                return "La persona que desea eliminar no se encuentra registrada";
            }
            catch (Exception exception)
            {

                return "Se presentó el Siguiente error" + exception.Message;
            }
        
        }


        public string Modificar(Persona personaNueva, string identificacion)
        {
            try
            {
                if (personaRepository.BuscarPorIdentificacion(identificacion) != null)
                {
                    personaRepository.Modificar(personaNueva,identificacion);
                   return "Se modifico la Información ";
                }
                return "La persona que desea Modificar no se encuentra registrada";
            }
            catch (Exception exception)
            {
                return "Se presentó el Siguiente error" + exception.Message;
            }
        }

        public ConsultaResponse Consultar() 
        {
            try
            {
                return new ConsultaResponse(personaRepository.Consultar());
            }
            catch (Exception exception)
            {
                return new ConsultaResponse("Se presentó el Siguiente error" + exception.Message);
            }
        }


        public ConsultaResponse ConsultarMayoresdeEdad()
        {
            try
            {
                return new ConsultaResponse(personaRepository.ConsultarMayoresDeEdad());
            }
            catch (Exception exception)
            {
                return new ConsultaResponse("Se presentó el Siguiente error" + exception.Message);
            }
        }


     

    }

    public class ConsultaResponse 
    {
        public List<Persona> Personas { get; set; }
        public string Mensaje { get; set; }

        public bool Error { get; set; }

        public ConsultaResponse(List<Persona> personas)
        {
            Personas = personas;
            Error = false;
        }

        public ConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }


  


}
