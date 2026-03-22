using System;

class NodoArbol
{
    public int Dato;
    public NodoArbol Izq;
    public NodoArbol Der;

    public NodoArbol(int dato)
    {
        Dato = dato;
        Izq = null;
        Der = null;
    }
}

class ArbolBusqueda
{
    public NodoArbol Raiz;

    // Insertar nodo
    public NodoArbol Agregar(NodoArbol nodo, int dato)
    {
        if (nodo == null)
            return new NodoArbol(dato);

        if (dato < nodo.Dato)
            nodo.Izq = Agregar(nodo.Izq, dato);
        else if (dato > nodo.Dato)
            nodo.Der = Agregar(nodo.Der, dato);

        return nodo;
    }

    // Buscar nodo
    public bool Existe(NodoArbol nodo, int dato)
    {
        if (nodo == null) return false;
        if (nodo.Dato == dato) return true;

        return dato < nodo.Dato ? Existe(nodo.Izq, dato) : Existe(nodo.Der, dato);
    }

    // Recorridos
    public void MostrarInorden(NodoArbol nodo)
    {
        if (nodo != null)
        {
            MostrarInorden(nodo.Izq);
            Console.Write(nodo.Dato + " ");
            MostrarInorden(nodo.Der);
        }
    }

    public void MostrarPreorden(NodoArbol nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Dato + " ");
            MostrarPreorden(nodo.Izq);
            MostrarPreorden(nodo.Der);
        }
    }

    public void MostrarPostorden(NodoArbol nodo)
    {
        if (nodo != null)
        {
            MostrarPostorden(nodo.Izq);
            MostrarPostorden(nodo.Der);
            Console.Write(nodo.Dato + " ");
        }
    }

    // Obtener mínimo
    public int ObtenerMin(NodoArbol nodo)
    {
        while (nodo.Izq != null)
            nodo = nodo.Izq;
        return nodo.Dato;
    }

    // Obtener máximo
    public int ObtenerMax(NodoArbol nodo)
    {
        while (nodo.Der != null)
            nodo = nodo.Der;
        return nodo.Dato;
    }

    // Altura
    public int CalcularAltura(NodoArbol nodo)
    {
        if (nodo == null) return -1;
        int izq = CalcularAltura(nodo.Izq);
        int der = CalcularAltura(nodo.Der);
        return 1 + Math.Max(izq, der);
    }

    // Eliminar nodo
    public NodoArbol Borrar(NodoArbol nodo, int dato)
    {
        if (nodo == null) return nodo;

        if (dato < nodo.Dato)
            nodo.Izq = Borrar(nodo.Izq, dato);
        else if (dato > nodo.Dato)
            nodo.Der = Borrar(nodo.Der, dato);
        else
        {
            if (nodo.Izq == null)
                return nodo.Der;
            else if (nodo.Der == null)
                return nodo.Izq;

            NodoArbol sucesor = nodo.Der;
            while (sucesor.Izq != null)
                sucesor = sucesor.Izq;

            nodo.Dato = sucesor.Dato;
            nodo.Der = Borrar(nodo.Der, sucesor.Dato);
        }

        return nodo;
    }

    // Limpiar árbol
    public void Vaciar()
    {
        Raiz = null;
    }
}

class Programa
{
    static void Main()
    {
        ArbolBusqueda arbol = new ArbolBusqueda();
        int op, num;

        do
        {
            Console.WriteLine("\n--- MENÚ ÁRBOL ---");
            Console.WriteLine("1. Agregar número");
            Console.WriteLine("2. Buscar número");
            Console.WriteLine("3. Eliminar número");
            Console.WriteLine("4. Mostrar recorridos");
            Console.WriteLine("5. Ver mínimo, máximo y altura");
            Console.WriteLine("6. Vaciar árbol");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.Write("Ingrese número: ");
                    num = int.Parse(Console.ReadLine());
                    arbol.Raiz = arbol.Agregar(arbol.Raiz, num);
                    break;

                case 2:
                    Console.Write("Número a buscar: ");
                    num = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Existe(arbol.Raiz, num) ? "Sí existe" : "No existe");
                    break;

                case 3:
                    Console.Write("Número a eliminar: ");
                    num = int.Parse(Console.ReadLine());
                    arbol.Raiz = arbol.Borrar(arbol.Raiz, num);
                    break;

                case 4:
                    Console.WriteLine("Inorden:");
                    arbol.MostrarInorden(arbol.Raiz);
                    Console.WriteLine("\nPreorden:");
                    arbol.MostrarPreorden(arbol.Raiz);
                    Console.WriteLine("\nPostorden:");
                    arbol.MostrarPostorden(arbol.Raiz);
                    Console.WriteLine();
                    break;

                case 5:
                    if (arbol.Raiz != null)
                    {
                        Console.WriteLine("Mínimo: " + arbol.ObtenerMin(arbol.Raiz));
                        Console.WriteLine("Máximo: " + arbol.ObtenerMax(arbol.Raiz));
                        Console.WriteLine("Altura: " + arbol.CalcularAltura(arbol.Raiz));
                    }
                    else
                    {
                        Console.WriteLine("El árbol está vacío");
                    }
                    break;

                case 6:
                    arbol.Vaciar();
                    Console.WriteLine("Árbol limpiado");
                    break;
            }

        } while (op != 0);
    }
}