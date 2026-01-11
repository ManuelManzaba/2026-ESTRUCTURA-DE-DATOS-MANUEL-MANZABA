using System;
using System.Collections.Generic;
using System.Linq;

namespace DeberListasTuplasParte2
{
    // ===== EJERCICIO 6 =====
    class AsignaturasAprobadas
    {
        public List<string> Asignaturas { get; set; } =
            new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };

        public void Ejecutar()
        {
            List<string> reprobadas = new List<string>();

            foreach (var a in Asignaturas)
            {
                Console.Write($"Nota de {a}: ");
                int nota = int.Parse(Console.ReadLine());
                if (nota < 7)
                    reprobadas.Add(a);
            }

            Console.WriteLine("\nAsignaturas reprobadas:");
            foreach (var r in reprobadas)
                Console.WriteLine("- " + r);
        }
    }

    // ===== EJERCICIO 7 =====
    class AbecedarioInverso
    {
        public void Ejecutar()
        {
            List<char> letras = new List<char>();

            for (char c = 'a'; c <= 'z'; c++)
                letras.Add(c);

            letras.Reverse();
            Console.WriteLine(string.Join(", ", letras));
        }
    }

    // ===== EJERCICIO 8 =====
    class Palindromo
    {
        public void Ejecutar()
        {
            Console.Write("Ingrese una palabra: ");
            string palabra = Console.ReadLine().ToLower();

            string invertida = new string(palabra.Reverse().ToArray());

            if (palabra == invertida)
                Console.WriteLine("Es un palíndromo");
            else
                Console.WriteLine("No es un palíndromo");
        }
    }

    // ===== EJERCICIO 9 =====
    class ContarVocales
    {
        public void Ejecutar()
        {
            Console.Write("Ingrese una palabra: ");
            string palabra = Console.ReadLine().ToLower();

            Dictionary<char, int> vocales = new Dictionary<char, int>
            {
                {'a',0},{'e',0},{'i',0},{'o',0},{'u',0}
            };


            foreach (char c in palabra)
            {
                if (vocales.ContainsKey(c))
                    vocales[c]++;
            }

            foreach (var v in vocales)
                Console.WriteLine($"{v.Key}: {v.Value}");
        }
    }

    // ===== EJERCICIO 11 =====
    class NumerosUnicos
    {
        public void Ejecutar()
        {
            List<int> numeros = new List<int>();

            Console.WriteLine("Ingrese números (0 para terminar):");
            int n;
            do
            {
                n = int.Parse(Console.ReadLine());
                if (n != 0 && !numeros.Contains(n))
                    numeros.Add(n);
            } while (n != 0);

            numeros.Sort();
            Console.WriteLine("Números únicos ordenados:");
            Console.WriteLine(string.Join(", ", numeros));
        }
    }

    // ===== EJERCICIO 12 =====
    class VectorAleatorio
    {
        public void Ejecutar()
        {
            Random rnd = new Random();
            List<int> numeros = new List<int>();

            for (int i = 0; i < 10; i++)
                numeros.Add(rnd.Next(1, 101));

            Console.WriteLine("Lista generada:");
            Console.WriteLine(string.Join(", ", numeros));

            Console.WriteLine($"Mayor: {numeros.Max()}");
            Console.WriteLine($"Menor: {numeros.Min()}");
        }
    }

    // ===== EJERCICIO 13 =====
    class FrecuenciaPalabras
    {
        public void Ejecutar()
        {
            Console.Write("Ingrese una frase: ");
            string frase = Console.ReadLine().ToLower();

            string[] palabras = frase.Split(' ');
            Dictionary<string, int> conteo = new Dictionary<string, int>();

            foreach (string p in palabras)
            {
                if (conteo.ContainsKey(p))
                    conteo[p]++;
                else
                    conteo[p] = 1;
            }

            foreach (var item in conteo)
                Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    // ===== PROGRAMA PRINCIPAL =====
    class Program
    {
        static void Main()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("===== DEBER LISTAS Y TUPLAS (C#) =====");
                Console.WriteLine("6. Asignaturas reprobadas");
                Console.WriteLine("7. Abecedario inverso");
                Console.WriteLine("8. Palíndromo");
                Console.WriteLine("9. Contar vocales");
                Console.WriteLine("11. Números únicos");
                Console.WriteLine("12. Vector aleatorio");
                Console.WriteLine("13. Frecuencia de palabras");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                int.TryParse(Console.ReadLine(), out opcion);
                Console.WriteLine();

                switch (opcion)
                {
                    case 6:
                        Console.WriteLine("=== EJERCICIO 6 ===");
                        new AsignaturasAprobadas().Ejecutar();
                        break;

                    case 7:
                        Console.WriteLine("=== EJERCICIO 7 ===");
                        new AbecedarioInverso().Ejecutar();
                        break;

                    case 8:
                        Console.WriteLine("=== EJERCICIO 8 ===");
                        new Palindromo().Ejecutar();
                        break;

                    case 9:
                        Console.WriteLine("=== EJERCICIO 9 ===");
                        new ContarVocales().Ejecutar();
                        break;

                    case 11:
                        Console.WriteLine("=== EJERCICIO 11 ===");
                        new NumerosUnicos().Ejecutar();
                        break;

                    case 12:
                        Console.WriteLine("=== EJERCICIO 12 ===");
                        new VectorAleatorio().Ejecutar();
                        break;

                    case 13:
                        Console.WriteLine("=== EJERCICIO 13 ===");
                        new FrecuenciaPalabras().Ejecutar();
                        break;

                    case 0:
                        Console.WriteLine("Fin del programa");
                        break;

                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }
    }
}