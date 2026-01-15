using System;

namespace ListasEnlazadasUnidas
{
    // ===== CLASE NODO =====
    class Nodo
    {
        public int Dato;
        public Nodo Siguiente;

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // ===== CLASE LISTA ENLAZADA =====
    class ListaEnlazada
    {
        private Nodo cabeza;

        // Insertar al final
        public void InsertarFinal(int dato)
        {
            Nodo nuevo = new Nodo(dato);

            if (cabeza == null)
                cabeza = nuevo;
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                    actual = actual.Siguiente;
                actual.Siguiente = nuevo;
            }
        }

        // Insertar al inicio
        public void InsertarInicio(int dato)
        {
            Nodo nuevo = new Nodo(dato);
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
        }

        // ===== EJERCICIO 3 =====
        // Buscar dato y contar cuántas veces aparece
        public int Buscar(int valor)
        {
            int contador = 0;
            Nodo actual = cabeza;

            while (actual != null)
            {
                if (actual.Dato == valor)
                    contador++;
                actual = actual.Siguiente;
            }

            if (contador == 0)
                Console.WriteLine("El dato no fue encontrado.");

            return contador;
        }

        // ===== EJERCICIO 4 =====
        // Eliminar nodos fuera del rango
        public void EliminarFueraDeRango(int min, int max)
        {
            while (cabeza != null && (cabeza.Dato < min || cabeza.Dato > max))
                cabeza = cabeza.Siguiente;

            Nodo actual = cabeza;

            while (actual != null && actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato < min || actual.Siguiente.Dato > max)
                    actual.Siguiente = actual.Siguiente.Siguiente;
                else
                    actual = actual.Siguiente;
            }
        }

        // Mostrar lista
        public void Mostrar()
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Dato + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }

        // Limpiar lista
        public void Limpiar()
        {
            cabeza = null;
        }
    }

    // ===== PROGRAMA PRINCIPAL =====
    class Program
    {
        static void Main()
        {
            ListaEnlazada lista = new ListaEnlazada();
            Random rnd = new Random();
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ LISTAS ENLAZADAS =====");
                Console.WriteLine("1. Ejercicio 3 - Buscar dato");
                Console.WriteLine("2. Ejercicio 4 - Eliminar fuera de rango");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        // ---------- EJERCICIO 3 ----------
                        lista.Limpiar();
                        lista.InsertarFinal(5);
                        lista.InsertarFinal(10);
                        lista.InsertarFinal(5);
                        lista.InsertarFinal(20);
                        lista.InsertarFinal(5);

                        Console.WriteLine("\nLista:");
                        lista.Mostrar();

                        Console.Write("\nIngrese valor a buscar: ");
                        int valor = int.Parse(Console.ReadLine());

                        int veces = lista.Buscar(valor);
                        Console.WriteLine("El valor aparece " + veces + " veces.");
                        Console.ReadKey();
                        break;

                    case 2:
                        // ---------- EJERCICIO 4 ----------
                        lista.Limpiar();

                        for (int i = 0; i < 50; i++)
                            lista.InsertarInicio(rnd.Next(1, 1000));

                        Console.WriteLine("\nLista original:");
                        lista.Mostrar();

                        Console.Write("\nIngrese valor mínimo: ");
                        int min = int.Parse(Console.ReadLine());

                        Console.Write("Ingrese valor máximo: ");
                        int max = int.Parse(Console.ReadLine());

                        lista.EliminarFueraDeRango(min, max);

                        Console.WriteLine("\nLista después de eliminar fuera del rango:");
                        lista.Mostrar();
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 3);
        }
    }
}