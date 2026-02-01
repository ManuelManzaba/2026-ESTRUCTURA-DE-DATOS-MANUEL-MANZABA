using System;
using System.Collections.Generic;

class Persona
{
    public string Nombre { get; set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }
}

class SistemaAsientos
{
    private Queue<Persona> cola = new Queue<Persona>();
    private const int MAX_ASIENTOS = 30;

    public void LlegarPersona(string nombre)
    {
        if (cola.Count < MAX_ASIENTOS)
        {
            cola.Enqueue(new Persona(nombre));
            Console.WriteLine(nombre + " ingresó a la cola.");
        }
        else
        {
            Console.WriteLine("No hay asientos disponibles.");
        }
    }

    public void AsignarAsiento()
    {
        if (cola.Count > 0)
        {
            Persona p = cola.Dequeue();
            Console.WriteLine("Asiento asignado a: " + p.Nombre);
        }
        else
        {
            Console.WriteLine("La cola está vacía.");
        }
    }

    public void MostrarCola()
    {
        Console.WriteLine("\nPersonas en la cola:");
        if (cola.Count == 0)
        {
            Console.WriteLine("Cola vacía.");
        }
        else
        {
            foreach (Persona p in cola)
            {
                Console.WriteLine("- " + p.Nombre);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        SistemaAsientos sistema = new SistemaAsientos();

        // Nombres de prueba
        string[] personas = {
            "Ana", "Carlos", "María", "Luis", "Sofía",
            "Pedro", "Lucía", "Juan", "Elena", "Diego"
        };

        Console.WriteLine("INGRESO DE PERSONAS\n");

        foreach (string nombre in personas)
        {
            sistema.LlegarPersona(nombre);
        }

        sistema.MostrarCola();

        Console.WriteLine("\nASIGNACIÓN DE ASIENTOS\n");

        sistema.AsignarAsiento();
        sistema.AsignarAsiento();
        sistema.AsignarAsiento();

        sistema.MostrarCola();

        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
}