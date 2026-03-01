using System;
using System.Collections.Generic;

class TraductorApp
{
    static void Main()
    {
        Dictionary<string, string> dicIngEsp = new Dictionary<string, string>()
        {
            {"book", "libro"},
            {"house", "casa"},
            {"school", "escuela"},
            {"water", "agua"},
            {"food", "comida"},
            {"friend", "amigo"},
            {"family", "familia"},
            {"car", "auto"},
            {"city", "ciudad"},
            {"country", "país"},
            {"music", "música"},
            {"love", "amor"}
        };

        Dictionary<string, string> dicEspIng = new Dictionary<string, string>();

        // Crear diccionario inverso automáticamente
        foreach (var palabra in dicIngEsp)
        {
            dicEspIng[palabra.Value] = palabra.Key;
        }

        int opcion = -1;

        while (opcion != 0)
        {
            Console.WriteLine("=========== MENÚ ===========");
            Console.WriteLine("1. Inglés → Español");
            Console.WriteLine("2. Español → Inglés");
            Console.WriteLine("3. Agregar nueva palabra");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese un número válido.\n");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Traducir(dicIngEsp);
                    break;

                case 2:
                    Traducir(dicEspIng);
                    break;

                case 3:
                    AgregarPalabras(dicIngEsp, dicEspIng);
                    break;

                case 0:
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opción incorrecta.\n");
                    break;
            }
        }
    }

    static void Traducir(Dictionary<string, string> diccionario)
    {
        Console.Write("Ingrese una frase: ");
        string frase = Console.ReadLine().ToLower();

        string[] palabras = frase.Split(' ');
        string resultado = "";

        foreach (string palabra in palabras)
        {
            string limpia = palabra.Trim('.', ',', ';', ':', '¿', '?', '¡', '!');

            if (diccionario.TryGetValue(limpia, out string traduccion))
            {
                resultado += traduccion + " ";
            }
            else
            {
                resultado += palabra + " ";
            }
        }

        Console.WriteLine("\nResultado: " + resultado + "\n");
    }

    static void AgregarPalabras(Dictionary<string, string> ingEsp, 
                                 Dictionary<string, string> espIng)
    {
        Console.Write("¿Cuántas palabras desea agregar?: ");
        int cantidad;

        if (!int.TryParse(Console.ReadLine(), out cantidad))
        {
            Console.WriteLine("Número inválido.\n");
            return;
        }

        for (int i = 0; i < cantidad; i++)
        {
            Console.Write("Palabra en inglés: ");
            string ingles = Console.ReadLine().ToLower();

            Console.Write("Traducción en español: ");
            string espanol = Console.ReadLine().ToLower();

            if (!ingEsp.ContainsKey(ingles))
            {
                ingEsp.Add(ingles, espanol);
                espIng.Add(espanol, ingles);
                Console.WriteLine("Agregada correctamente.\n");
            }
            else
            {
                Console.WriteLine("La palabra ya existe.\n");
            }
        }
    }
}