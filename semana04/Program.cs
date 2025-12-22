using System;
using System.Collections.Generic;

namespace AgendaTurnosClinica
{
    // Clase que representa un turno médico
    class Turno
    {
        public string NombrePaciente { get; set; }
        public string Cedula { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Especialidad { get; set; }

        public Turno(string nombrePaciente, string cedula, string fecha, string hora, string especialidad)
        {
            NombrePaciente = nombrePaciente;
            Cedula = cedula;
            Fecha = fecha;
            Hora = hora;
            Especialidad = especialidad;
        }

        public void MostrarTurno()
        {
            Console.WriteLine("Paciente      : " + NombrePaciente);
            Console.WriteLine("Cédula        : " + Cedula);
            Console.WriteLine("Fecha         : " + Fecha);
            Console.WriteLine("Hora          : " + Hora);
            Console.WriteLine("Especialidad  : " + Especialidad);
            Console.WriteLine("--------------------------------------");
        }
    }

    class Program
    {
        // Lista (estructura de datos) con turnos precargados
        static List<Turno> agendaTurnos = new List<Turno>()
        {
            new Turno("Manuel Manzaba", "1750253942", "10-01-2026", "13:00", "Odontología"),
            new Turno("Diana Cedeño", "1720703394", "21-01-2026", "14:30", "Ginecología"),
            new Turno("Nathalie Vera", "1747073211", "14-02-2026", "10:00", "Pediatría")
        };

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== AGENDA DE TURNOS DE PACIENTES ===");
                Console.WriteLine("1. Registrar nuevo turno");
                Console.WriteLine("2. Mostrar todos los turnos");
                Console.WriteLine("3. Buscar turno por paciente");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarTurno();
                        break;
                    case 2:
                        MostrarTurnos();
                        break;
                    case 3:
                        BuscarTurno();
                        break;
                    case 4:
                        Console.WriteLine("Sistema cerrado correctamente.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 4);
        }

        static void RegistrarTurno()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRO DE TURNO ===");

            Console.Write("Nombre del paciente: ");
            string nombre = Console.ReadLine();

            Console.Write("Cédula: ");
            string cedula = Console.ReadLine();

            Console.Write("Fecha (dd-mm-aaaa): ");
            string fecha = Console.ReadLine();

            Console.Write("Hora (hh:mm): ");
            string hora = Console.ReadLine();

            Console.Write("Especialidad: ");
            string especialidad = Console.ReadLine();

            agendaTurnos.Add(new Turno(nombre, cedula, fecha, hora, especialidad));

            Console.WriteLine("\nTurno registrado exitosamente.");
        }

        static void MostrarTurnos()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE TURNOS ===");

            if (agendaTurnos.Count == 0)
            {
                Console.WriteLine("No existen turnos registrados.");
            }
            else
            {
                foreach (Turno turno in agendaTurnos)
                {
                    turno.MostrarTurno();
                }
            }
        }

        static void BuscarTurno()
        {
            Console.Clear();
            Console.WriteLine("=== BÚSQUEDA DE TURNO ===");

            Console.Write("Ingrese el nombre del paciente: ");
            string nombreBuscado = Console.ReadLine();

            bool encontrado = false;

            foreach (Turno turno in agendaTurnos)
            {
                if (turno.NombrePaciente.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    turno.MostrarTurno();
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontró un turno para el paciente ingresado.");
            }
        }
    }
}