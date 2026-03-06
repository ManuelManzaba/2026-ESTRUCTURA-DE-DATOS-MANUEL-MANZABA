using System;
using System.Collections.Generic;

class TorneoFutbol
{
    static void Main()
    {
        HashSet<string> equipos = new HashSet<string>();
        Dictionary<string, List<string>> jugadores = new Dictionary<string, List<string>>();

        int opcion = -1;

        while (opcion != 0)
        {
            Console.WriteLine("\n===== SISTEMA TORNEO DE FÚTBOL =====");
            Console.WriteLine("1. Registrar equipo");
            Console.WriteLine("2. Registrar jugador");
            Console.WriteLine("3. Mostrar equipos y jugadores");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione opción: ");
            int.TryParse(Console.ReadLine(), out opcion);

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese nombre del equipo: ");
                    string equipo = Console.ReadLine();

                    if (equipos.Add(equipo))
                    {
                        jugadores[equipo] = new List<string>();
                        Console.WriteLine("Equipo registrado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("El equipo ya existe.");
                    }
                    break;

                case 2:
                    Console.Write("Ingrese nombre del equipo: ");
                    string equipoJugador = Console.ReadLine();

                    if (equipos.Contains(equipoJugador))
                    {
                        Console.Write("Ingrese nombre del jugador: ");
                        string jugador = Console.ReadLine();

                        if (!jugadores[equipoJugador].Contains(jugador))
                        {
                            jugadores[equipoJugador].Add(jugador);
                            Console.WriteLine("Jugador agregado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("El jugador ya está registrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El equipo no existe.");
                    }
                    break;

                case 3:
                    foreach (var item in jugadores)
                    {
                        Console.WriteLine("\nEquipo: " + item.Key);
                        foreach (var jug in item.Value)
                        {
                            Console.WriteLine(" - " + jug);
                        }
                    }
                    break;

                case 0:
                    Console.WriteLine("Sistema finalizado.");
                    break;
            }
        }
    }
}