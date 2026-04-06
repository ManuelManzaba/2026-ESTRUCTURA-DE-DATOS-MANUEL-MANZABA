using System;
using System.Collections.Generic;

class Grafo
{
    private Dictionary<string, List<string>> lista;

    public Grafo()
    {
        lista = new Dictionary<string, List<string>>();
    }

    public void AgregarNodo(string nodo)
    {
        if (!lista.ContainsKey(nodo))
            lista[nodo] = new List<string>();
    }

    public void AgregarArista(string origen, string destino)
    {
        lista[origen].Add(destino);
        lista[destino].Add(origen);
    }

    public void Mostrar()
    {
        foreach (var nodo in lista)
        {
            Console.Write(nodo.Key + " -> ");
            foreach (var vecino in nodo.Value)
            {
                Console.Write(vecino + " ");
            }
            Console.WriteLine();
        }
    }

    public void BFS(string inicio)
    {
        var visitados = new HashSet<string>();
        var cola = new Queue<string>();

        cola.Enqueue(inicio);
        visitados.Add(inicio);

        Console.WriteLine("\nRecorrido BFS:");

        while (cola.Count > 0)
        {
            var actual = cola.Dequeue();
            Console.Write(actual + " ");

            foreach (var vecino in lista[actual])
            {
                if (!visitados.Contains(vecino))
                {
                    visitados.Add(vecino);
                    cola.Enqueue(vecino);
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Grafo g = new Grafo();

        g.AgregarNodo("A");
        g.AgregarNodo("B");
        g.AgregarNodo("C");
        g.AgregarNodo("D");

        g.AgregarArista("A", "B");
        g.AgregarArista("A", "C");
        g.AgregarArista("B", "D");

        Console.WriteLine("Grafo:");
        g.Mostrar();

        g.BFS("A");

        Console.ReadKey();
    }
}