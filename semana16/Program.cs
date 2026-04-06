using System;
using System.Collections.Generic;

class GrafoVuelos
{
    private Dictionary<string, List<(string destino, int costo)>> grafo;

    public GrafoVuelos()
    {
        grafo = new Dictionary<string, List<(string, int)>>();
    }

    public void AgregarConexion(string origen, string destino, int costo)
    {
        if (!grafo.ContainsKey(origen))
            grafo[origen] = new List<(string, int)>();

        grafo[origen].Add((destino, costo));
    }

    public void Mostrar()
    {
        foreach (var ciudad in grafo)
        {
            Console.Write(ciudad.Key + " -> ");
            foreach (var conexion in ciudad.Value)
            {
                Console.Write($"{conexion.destino}(${conexion.costo}) ");
            }
            Console.WriteLine();
        }
    }

    public void RutaMasCorta(string inicio)
    {
        var distancias = new Dictionary<string, int>();
        var visitados = new HashSet<string>();

        foreach (var nodo in grafo.Keys)
            distancias[nodo] = int.MaxValue;

        distancias[inicio] = 0;

        while (visitados.Count < grafo.Count)
        {
            string actual = null;
            int menor = int.MaxValue;

            foreach (var nodo in distancias)
            {
                if (!visitados.Contains(nodo.Key) && nodo.Value < menor)
                {
                    menor = nodo.Value;
                    actual = nodo.Key;
                }
            }

            if (actual == null) break;

            visitados.Add(actual);

            foreach (var vecino in grafo[actual])
            {
                int nueva = distancias[actual] + vecino.costo;

                if (!distancias.ContainsKey(vecino.destino) || nueva < distancias[vecino.destino])
                {
                    distancias[vecino.destino] = nueva;
                }
            }
        }

        Console.WriteLine("\nCostos mínimos desde " + inicio + ":");
        foreach (var d in distancias)
        {
            Console.WriteLine(d.Key + ": $" + d.Value);
        }
    }
}

class Program
{
    static void Main()
    {
        GrafoVuelos vuelos = new GrafoVuelos();

        vuelos.AgregarConexion("Quito", "Guayaquil", 50);
        vuelos.AgregarConexion("Quito", "Cuenca", 40);
        vuelos.AgregarConexion("Cuenca", "Guayaquil", 30);
        vuelos.AgregarConexion("Guayaquil", "Manta", 20);

        Console.WriteLine("Rutas disponibles:");
        vuelos.Mostrar();

        vuelos.RutaMasCorta("Quito");

        Console.ReadKey();
    }
}