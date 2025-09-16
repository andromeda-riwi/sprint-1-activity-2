// Ejercicio 1: Notas de un curso.

/*
List<int> grades = new();

bool goOn = false;

for (int i = 1; i < 6; i++)
{
    Console.WriteLine($"Ingrese la nota del estudiante {i} (Solo números enteros de 1 a 5):");

    while (!goOn)
    {
        try
        {
            int grade = int.Parse(Console.ReadLine().Trim());
            if (grade is >= 1 and <= 5)
            {
                grades.Add(grade);
                goOn = true;
            }
            Console.WriteLine($"{grade} no es una nota válida, por favor inténtelo de nuevo");
        }
        catch (FormatException)
        {
            Console.WriteLine("El valor que ingresaste no es válido, por favor inténtelo de nuevo");
        }
    }
}

int j = 1;
foreach (int grade in grades)
{
    string isApproved = "";
    if (grade >= 3) isApproved = "aprobado";
    else isApproved = "reprobado";
    Console.WriteLine($"El estudiante {j} ha {isApproved} con una nota de {grade}.");
    j++;
}

double acumulated = 0;
double average = 0;
foreach (int grade in grades)
{
    acumulated += grade;
}
average = acumulated / grades.Count;

Console.WriteLine($"\nEl promedio de las notas es: {average:F2}");
j = 0;
foreach (int grade in grades)
{
    if (grade < 3)
    {
        j++;
    }
}

Console.WriteLine($"\nHay {j} estudiante(s) en riesgo académico.");
*/

// Ejercicio 2: Concurso de canto.

/*
List<string> participants = new();

bool goOn = false;

bool end = false;

int i = 1;

do
{
    goOn = false;
    Console.WriteLine($"Escribe el nombre del participante {i}");

    while (!goOn)
    {
        try
        {
            string participant = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(participant))
            {
                Console.WriteLine("El nombre del participante no es válido por favor intentelo de nuevo");
                continue;
            }
            participants.Add(participant);
            goOn = true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Ha habido un error, por favor intentelo de nuevo");
        }
        i++;
    }
    Console.WriteLine("¿Deseas agregar a otro usuario? (s/n)");
    char uContinueinp = char.Parse(Console.ReadLine());
    if (uContinueinp is 'n' or 'N') end = true;

} while (!end);

int participantsCount = participants.Count;
Console.WriteLine($"El número de participantes es {participantsCount}");

Console.WriteLine("Los participantes registrados son:");
i = 1;

foreach (string participant in participants)
{
    Console.WriteLine($"{i}. {participant}");
    i++;
}

end = false;

while (!end)
{
    Console.WriteLine("¿Desea ver si una persona está participando? (s/n)");

    char seekParticipant = 'n';

    goOn = false;

    while (!goOn)
    {
        try
        {
            seekParticipant = char.Parse(Console.ReadLine());
            switch (seekParticipant)
            {
                case 's' or 'S':
                    goOn = true;
                    break;
                
                case 'n' or 'N':
                    goOn = true;
                    end = true;
                    break;
                
                default:
                    Console.WriteLine("Opción no válida, por favor intente de nuevo");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Opción no válida, por favor intente de nuevo");
        }
    }

    if (seekParticipant is 's' or 'S')
    {
        Console.WriteLine("¿Cuál es el nombre del participante?");
        string participantName = Console.ReadLine();
        bool isParticipant = participants.Contains(participantName);
        if (isParticipant) Console.WriteLine($"{participantName} está participando");
        else Console.WriteLine($"{participantName} no está participando");
    }
}

Dictionary<string, int> countByFirstLetter = participants
    .GroupBy(n => n.Substring(0, 1).ToUpper()) 
    .ToDictionary(
        g => g.Key,
        g => g.Count()
    );

foreach (KeyValuePair<string, int> par in countByFirstLetter)
{
    Console.WriteLine($"Hay {par.Value} nombres que empiezan con la letra '{par.Key}'");
}
*/

// Ejercicio 3: Carrito de compras

/*
class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    
    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
    
    public void ShowInfo()
    {
        Console.WriteLine($"Nombre: {Name}, Precio: {Price}, Cantidad: {Quantity}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        bool exit = false;
        int i = 1;

        while (!exit)
        {
            Console.WriteLine("\n--- GESTIÓN DE PRODUCTOS ---");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Listar productos");
            Console.WriteLine("3. Consultar total productos");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    bool goOn = false;

                    bool end = false;
                    
                    string name = "";
                    double price = 0;
                    int quantity = 0;

                    do
                    {
                        goOn = false;
                        Console.Write($"Ingrese el nombre del producto {i}: ");

                        while (!goOn)
                        {
                            try
                            {
                                name = Console.ReadLine().Trim();
                                if (String.IsNullOrEmpty(name))
                                {
                                    Console.WriteLine(
                                        "El nombre del producto no es válido por favor intentelo de nuevo");
                                    continue;
                                }

                                goOn = true;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ha habido un error, por favor intentelo de nuevo");
                                continue;
                            }

                            Console.Write("Ingrese el precio: ");

                            while (true)
                            {
                                try
                                {
                                    price = Convert.ToDouble(Console.ReadLine().Trim());
                                    if (price <= 0)
                                    {
                                        Console.WriteLine("El precio debe ser mayor que 0.");
                                        continue;
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Por favor ingrese un número");
                                    continue;
                                }

                                break;
                            }

                            Console.Write("Ingrese la cantidad: ");
                            while (true)
                            {
                                try
                                {
                                    quantity = Convert.ToInt32(Console.ReadLine().Trim());
                                    if (quantity < 0)
                                    {
                                        Console.WriteLine("La cantidad no puede ser negativa.");
                                        continue;
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Por favor ingrese un número");
                                    continue;
                                }

                                break;
                            }

                            Product p = new Product(name, price, quantity);
                            products.Add(p);

                            Console.WriteLine("Producto agregado con éxito!");

                            i++;
                        }

                        while (true)
                        {

                            Console.WriteLine("¿Deseas agregar otro producto? (s/n)");
                            char uContinueinp = char.Parse(Console.ReadLine());
                            switch (uContinueinp)
                            {
                                case 's' or 'S':
                                    break;
                                case 'n' or 'N':
                                    end = true;
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida");
                                    break;
                            }

                            if (uContinueinp is 's' or 'S' or 'n' or 'N') break;
                        }
                    } while (!end);
                    
                    break;

                case "2":
                    Console.WriteLine("\n--- LISTA DE PRODUCTOS ---");
                    if (products.Count == 0)
                    {
                        Console.WriteLine("No hay productos registrados.\nPresione cualquier tecla para continuar.");
                        Console.ReadKey();
                    }
                    else
                    {
                        foreach (Product product in products)
                        {
                            product.ShowInfo();
                        }

                        foreach (Product product in products)
                        {
                            if (product.Quantity == 0) Console.WriteLine($"⚠ Advertencia: No hay cantidad registrada para {product.Name}.");
                        }

                        Console.WriteLine("Presione cualquier tecla para continuar.");
                        Console.ReadKey();
                    }
                    break;
                
                case "3":
                    
                    double totalPrice = 0;
                    foreach (Product product in products)
                    {
                        double totalProductPrice = product.Price*product.Quantity;
                        totalPrice += totalProductPrice;
                    }

                    if (totalPrice > 200)
                    {
                        Console.WriteLine($"El precio de los procductos registrados es {totalPrice:F2}");
                        Console.WriteLine("Por la compra superior a 200, obtuviste un 10% de descuento.");
                        Console.WriteLine($"El valor final es {totalPrice*0.9:F2}");
                    }
                    else
                    {
                        Console.WriteLine($"El precio de los procductos registrados es {totalPrice:F2}");
                        Console.WriteLine($"El valor final es {totalPrice:F2}");
                    }
                    
                    Console.WriteLine("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    break;
                    
                case "4":
                    exit = true;
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}





