
    int NumberNotes;

    bool studentrisk = false;

    bool flag = true;

    List<float> notes = new List<float>();

    List<float> Approve = new List<float>();

    while (flag)
    {
        int Counter = 0;
        
        Console.WriteLine("Ingrese el número de notas que desea ingresar: ");
        NumberNotes = int.Parse(Console.ReadLine());

        for (int i = 0; i < NumberNotes; i++)
        {
            Counter++;

            float note;

            Console.WriteLine($"Ingrese la nota número {Counter}: ");
            note = float.Parse(Console.ReadLine());

            if (note < 1 || note > 5)
            {
                Console.WriteLine("Nota invalida");
                break;
            }

            if (note > 3)
            {
                Approve.Add(note);
            }

            if (note < 2)
            {
                studentrisk = true;
            }
            
            notes.Add(note);
        }
        
        flag = false;
        
    }

    if (studentrisk)
    {
        Console.WriteLine("El estudiante esta en riesgo académico");
    }
    else
    {
        Console.WriteLine("Notas:");

        for (int i = 0; i < notes.Count; i++)
        {
            Console.WriteLine(notes[i]);
        }
        
        float average = notes.Average();
        
        Console.WriteLine($"El promedio de notas es: {average}");

    }



