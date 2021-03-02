using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Console.ReadKey();
        }
    }
}
