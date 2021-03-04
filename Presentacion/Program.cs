using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre, identificacion, sexo;
            int edad;
         

            Console.WriteLine("Digite la Identificacion:");
            identificacion = Console.ReadLine();

            Console.WriteLine("Digite el Nombre:");
            nombre = Console.ReadLine();

            Console.WriteLine("Digite el Sexo F/M:");
            sexo = Console.ReadLine();

            Console.WriteLine("Digite la Edad:");
            edad = int.Parse(Console.ReadLine());

           


            Persona persona = new Persona()
            {
                Identificacion = identificacion,
                Nombre = nombre,
                Sexo=sexo,
                Edad=edad,
            
            };

            persona.CalcularPulsacion();

            Console.WriteLine($"Su Pulsacion es {persona.Pulsacion}");
            PersonaService personaService = new PersonaService();
            Console.WriteLine(personaService.Guardar(persona));


            Console.WriteLine("/// Consulta de Personas///");
            ConsultaResponse response= personaService.Consultar();
            if (!response.Error) 
            {
                foreach (var item in response.Personas)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine(response.Mensaje);
            }

            Console.ReadKey();
        }
    }
}
