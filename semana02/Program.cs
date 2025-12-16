using System;

// Clase Circulo
// Esta clase representa un círculo y contiene métodos
// para calcular su área y su perímetro
class Circulo
{
    // Atributo privado de tipo double
    // Encapsula el radio del círculo
    private double radio;

    // Constructor de la clase Circulo
    // Inicializa el valor del radio
    public Circulo(double radio)
    {
        this.radio = radio;
    }

    // CalcularArea es una función que devuelve un valor double
    // Se utiliza para calcular el área de un círculo
    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    // CalcularPerimetro es una función que devuelve un valor double
    // Se utiliza para calcular el perímetro del círculo
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }
}

// Clase Rectangulo
// Esta clase representa un rectángulo y contiene métodos
// para calcular su área y su perímetro
class Rectangulo
{
    // Atributos privados de tipo double
    // Encapsulan la base y la altura del rectángulo
    private double baseRectangulo;
    private double altura;

    // Constructor de la clase Rectangulo
    // Inicializa la base y la altura
    public Rectangulo(double baseRectangulo, double altura)
    {
        this.baseRectangulo = baseRectangulo;
        this.altura = altura;
    }

    // CalcularArea es una función que devuelve un valor double
    // Se utiliza para calcular el área del rectángulo
    public double CalcularArea()
    {
        return baseRectangulo * altura;
    }

    // CalcularPerimetro es una función que devuelve un valor double
    // Se utiliza para calcular el perímetro del rectángulo
    public double CalcularPerimetro()
    {
        return 2 * (baseRectangulo + altura);
    }
}

// Clase principal
class Program
{
    static void Main(string[] args)
    {
        // Creación de un objeto de la clase Circulo
        Circulo circulo = new Circulo(5);

        Console.WriteLine("CÍRCULO");
        Console.WriteLine("Área: " + circulo.CalcularArea());
        Console.WriteLine("Perímetro: " + circulo.CalcularPerimetro());

        Console.WriteLine();

        // Creación de un objeto de la clase Rectangulo
        Rectangulo rectangulo = new Rectangulo(4, 6);

        Console.WriteLine("RECTÁNGULO");
        Console.WriteLine("Área: " + rectangulo.CalcularArea());
        Console.WriteLine("Perímetro: " + rectangulo.CalcularPerimetro());
    }
}
