using System;
using System.Collections.Generic;

class PilasEjerciciosAvanzados
{
    static void Main()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("APLICACIONES DE PILAS (STACKS) EN C#");
        Console.WriteLine("==================================================");

        // ============================
        // EJERCICIO 1
        // ============================
        Console.WriteLine("\nEJERCICIO 1: VALIDACIÓN DE EXPRESIÓN ARITMÉTICA");
        string expresion = "(8 + 2) * {5 - [3 + (1 * 2)]}";

        if (ValidarExpresion(expresion))
            Console.WriteLine("La expresión está correctamente balanceada.");
        else
            Console.WriteLine("La expresión NO está balanceada.");

        // ============================
        // EJERCICIO 2
        // ============================
        Console.WriteLine("\nEJERCICIO 2: INVERSIÓN DE NÚMEROS");
        int numero = 123456;
        Console.WriteLine("Número original : " + numero);
        Console.WriteLine("Número invertido: " + InvertirNumero(numero));

        // ============================
        // EJERCICIO 3
        // ============================
        Console.WriteLine("\nEJERCICIO 3: EVALUACIÓN DE EXPRESIÓN POSFIJA");
        string posfija = "52+83-*";
        Console.WriteLine("Expresión posfija: " + posfija);
        Console.WriteLine("Resultado: " + EvaluarPosfija(posfija));

        // ============================
        // EJERCICIO 4
        // ============================
        Console.WriteLine("\nEJERCICIO 4: SIMULACIÓN DE HISTORIAL DE NAVEGACIÓN");
        SimularNavegacion();
    }

    // ==================================================
    // EJERCICIO 1: VALIDAR EXPRESIÓN BALANCEADA
    // ==================================================
    static bool ValidarExpresion(string expresion)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in expresion)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0)
                    return false;

                char ultimo = pila.Pop();

                if (!Coincide(ultimo, c))
                    return false;
            }
        }

        return pila.Count == 0;
    }

    static bool Coincide(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }

    // ==================================================
    // EJERCICIO 2: INVERTIR UN NÚMERO
    // ==================================================
    static int InvertirNumero(int numero)
    {
        Stack<int> pila = new Stack<int>();

        while (numero > 0)
        {
            pila.Push(numero % 10);
            numero /= 10;
        }

        int invertido = 0;
        int factor = 1;

        while (pila.Count > 0)
        {
            invertido += pila.Pop() * factor;
            factor *= 10;
        }

        return invertido;
    }

    // ==================================================
    // EJERCICIO 3: EVALUAR EXPRESIÓN POSFIJA
    // ==================================================
    static int EvaluarPosfija(string expresion)
    {
        Stack<int> pila = new Stack<int>();

        foreach (char c in expresion)
        {
            if (char.IsDigit(c))
            {
                pila.Push(c - '0');
            }
            else
            {
                int b = pila.Pop();
                int a = pila.Pop();

                switch (c)
                {
                    case '+': pila.Push(a + b); break;
                    case '-': pila.Push(a - b); break;
                    case '*': pila.Push(a * b); break;
                    case '/': pila.Push(a / b); break;
                }
            }
        }

        return pila.Pop();
    }

    // ==================================================
    // EJERCICIO 4: HISTORIAL DE NAVEGACIÓN
    // ==================================================
    static void SimularNavegacion()
    {
        Stack<string> historial = new Stack<string>();

        historial.Push("www.google.com");
        historial.Push("www.wikipedia.org");
        historial.Push("www.microsoft.com");
        historial.Push("www.github.com");

        Console.WriteLine("Páginas visitadas:");

        foreach (string pagina in historial)
        {
            Console.WriteLine("- " + pagina);
        }

        Console.WriteLine("\nRetrocediendo páginas:");

        while (historial.Count > 0)
        {
            Console.WriteLine("Volver desde: " + historial.Pop());
        }
    }
}