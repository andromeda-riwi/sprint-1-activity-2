//realizado por abrahan
﻿using System;
using System.Collections.Generic;

// Guardar varias notas en una lista de enteros
List<int> notas = new List<int>();
bool seguirAgregando = true;

Console.WriteLine("***Ingrese las notas de los estudiantes (números enteros del 1 al 5)***");
Console.WriteLine("***Escriba 'salir' cuando haya terminado de ingresar notas***");

// Bucle para que el usuario ingrese las notas
while (seguirAgregando)
{
    Console.Write("Ingrese una nota: ");
    string entrada = Console.ReadLine(); 

    if (entrada.ToLower() == "salir")
    {
        seguirAgregando = false; 
    }
    else
    {
        int nota;
        // Intentamos convertir el texto a un número entero.
        // También validamos que la nota esté en el rango correcto (1-5).
        if (int.TryParse(entrada, out nota) && nota >= 1 && nota <= 5)
        {
            notas.Add(nota); 
        }
        else
        {
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero entre 1 y 5.");
        }
    }
}

// Verificamos si se ingresaron notas antes de continuar
if (notas.Count > 0)
{
    // Mostrar todas las notas en pantalla
    Console.WriteLine("\n***Listado de todas las notas***");
    foreach (int nota in notas)
    {
        Console.WriteLine($"Nota: {nota}");
    }

    // Decir cuáles notas aprobaron
    Console.WriteLine("\n***Estado de las notas (Aprobado / Reprobado)***");
    foreach (int nota in notas)
    {
        if (nota >= 3)
        {
            Console.WriteLine($"La nota {nota} es APROBADA.");
        }
        else
        {
            Console.WriteLine($"La nota {nota} es REPROBADA.");
        }
    }

    //Calcular el promedio del grupo
    int sumaDeNotas = 0;
    foreach (int nota in notas)
    {
        sumaDeNotas += nota; // Recorremos la lista y sumamos cada nota
    }

    // Convertimos la suma a 'double' para obtener un promedio con decimales
    double promedio = (double)sumaDeNotas / notas.Count;
    
    // 'F2' formatea el número para mostrar solo dos decimales
    Console.WriteLine($"\n*** Promedio del grupo ***");
    Console.WriteLine($"El promedio de las notas es: {promedio:F2}");

    //Mostrar mensaje de alerta si hay notas muy bajas
    bool hayNotasBajas = false;
    foreach (int nota in notas)
    {
        if (nota < 2)
        {
            hayNotasBajas = true;
            break; 
        }
    }

    if (hayNotasBajas)
    {
        Console.WriteLine("\n*** ¡Alerta! ***");
        Console.WriteLine("Hay estudiantes en riesgo académico.");
    }
}
else
{
    Console.WriteLine("\nNo se ingresaron notas para analizar.");
}

Console.WriteLine("\n*** salir del programa ***");
