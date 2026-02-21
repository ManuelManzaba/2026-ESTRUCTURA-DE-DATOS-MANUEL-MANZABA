using System;
using System.Collections.Generic;
using System.Linq;

class ProgramaVacunacion
{
    static void Main()
    {
        Random random = new Random();

        // 1. Universo: 500 ciudadanos
        HashSet<string> ciudadanos = new HashSet<string>();

        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        // Convertimos a lista para selección aleatoria
        List<string> listaCiudadanos = ciudadanos.ToList();

        // 2. Conjunto Pfizer (75 aleatorios)
        HashSet<string> pfizer = new HashSet<string>();

        while (pfizer.Count < 75)
        {
            int indice = random.Next(listaCiudadanos.Count);
            pfizer.Add(listaCiudadanos[indice]);
        }

        // 3. Conjunto AstraZeneca (75 aleatorios)
        HashSet<string> astraZeneca = new HashSet<string>();

        while (astraZeneca.Count < 75)
        {
            int indice = random.Next(listaCiudadanos.Count);
            astraZeneca.Add(listaCiudadanos[indice]);
        }

        // ==============================
        // OPERACIONES DE TEORÍA DE CONJUNTOS
        // ==============================

        // Unión P ∪ A
        HashSet<string> unionVacunados = new HashSet<string>(pfizer);
        unionVacunados.UnionWith(astraZeneca);

        // No vacunados U - (P ∪ A)
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(unionVacunados);

        // Ambas dosis P ∩ A
        HashSet<string> ambasDosis = new HashSet<string>(pfizer);
        ambasDosis.IntersectWith(astraZeneca);

        // Solo Pfizer P - A
        HashSet<string> soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astraZeneca);

        // Solo AstraZeneca A - P
        HashSet<string> soloAstra = new HashSet<string>(astraZeneca);
        soloAstra.ExceptWith(pfizer);

        // ==============================
        // RESULTADOS
        // ==============================

        Console.WriteLine("===== RESULTADOS CAMPAÑA COVID-19 =====\n");

        Console.WriteLine($"No vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ambas dosis: {ambasDosis.Count}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca: {soloAstra.Count}");

        Console.WriteLine("\n--- LISTADO SOLO PFIZER ---");
        foreach (var c in soloPfizer)
            Console.WriteLine(c);

        Console.WriteLine("\n--- LISTADO SOLO ASTRAZENECA ---");
        foreach (var c in soloAstra)
            Console.WriteLine(c);

        Console.WriteLine("\n--- LISTADO AMBAS DOSIS ---");
        foreach (var c in ambasDosis)
            Console.WriteLine(c);

        Console.WriteLine("\n--- LISTADO NO VACUNADOS ---");
        foreach (var c in noVacunados)
            Console.WriteLine(c);
    }
}