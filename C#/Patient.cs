// Patient.cs

using System;

class Patient
{
    // Īpašības
    public string VisitPurpose { get; private set; }
    public double Temperature { get; private set; }
    public int Symptoms { get; private set; }
    public string FullName { get; private set; }
    public int Age { get; private set; }
    public string Gender { get; private set; }
    public string DiseaseSeverity { get; private set; }
    public string Condition { get; private set; }

    // Konstruktors
    public Patient(string visitPurpose, double temperature, string firstName, string lastName, int age, string gender, string diseaseSeverity, int symptoms)
    {
        VisitPurpose = visitPurpose;
        Temperature = temperature;
        Symptoms = symptoms;
        FullName = $"{firstName} {lastName}";
        Age = age;
        Gender = gender;
        DiseaseSeverity = diseaseSeverity;

    }

    // Metodes
    public bool WantTreatment()
    {
        while (true)
        {
            
            Console.Write($"Vai pacients {FullName} vēlas ārstēties? (ja/nē): ");
    
            string response = Console.ReadLine().ToLower();
    
            if (response == "ja" || response == "jā")
            {
                return true;
            }
            else if (response == "nē" || response == "ne")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Nepareiza atbilde. Lūdzu, ievadiet 'ja' vai 'nē'.");
            }
        }
}


    public void CheckDisease()
    {
        if (Temperature <= 38.5 || Symptoms <= 2)
        {
            Condition = "Gripa";
        }
        else if (Symptoms <= 5 && Symptoms >= 2)
        {
            Condition = "Coronavīruss";
        }
        else if (Temperature >= 38.5 && Symptoms <= 6 && DiseaseSeverity == "Vidējais" || DiseaseSeverity == "Smagais")
        {
            Condition = "Vīruss";
        }
        else
        {
            Condition = "Nezināma slimība";
        }
        Console.WriteLine($"slimība: {Condition}");
        
    }

    public void ChangeTemperature(string operation, double delta)
{

    if (operation == "+")
    {
        Temperature += delta;
    }
    else if (operation == "-")
    {
        Temperature -= delta;
    }
    else
    {
        Console.WriteLine("Nepareiza operācija temperatūrai. Ievadiet '+' vai '-'.");
    }
}

public void ChangeSymptoms(string operation, int delta)
{


    if (operation == "+")
    {
        Symptoms += delta;
    }
    else if (operation == "-")
    {
        Symptoms -= delta;
    }
    else
    {
        Console.WriteLine("Nepareiza operācija simptomiem. Ievadiet '+' vai '-'.");
    }
}


    public void Treat()
    {
        if (Symptoms > 0){
            Console.Write("Vai vēlaties palielināt (+) vai samazināt (-) simptomus? ");
            string symptomsOperation = Console.ReadLine().ToLower();
            Console.Write("Cik vienības? ");
            int symptomsDelta = Convert.ToInt32(Console.ReadLine());
            ChangeSymptoms(symptomsOperation, symptomsDelta);
            
        }
        if (Symptoms != 36.6){
        Console.Write("Vai vēlaties palielināt (+) vai samazināt (-) temperatūru? ");
        string temperatureOperation = Console.ReadLine().ToLower();
        Console.Write("Cik vienības? ");
        double temperatureDelta = Convert.ToDouble(Console.ReadLine());
        ChangeTemperature(temperatureOperation, temperatureDelta);
        }
        
        // public void Treat()
{
    if (Symptoms > 0)
    {
        Console.Write("Vai vēlaties palielināt (+) vai samazināt (-) simptomus? ");
        string symptomsOperation = Console.ReadLine().ToLower();

        if (symptomsOperation != "+" && symptomsOperation != "-")
        {
            Console.WriteLine("Nepareiza ievade. Lūdzu, ievadiet '+' vai '-'.");
            return; // Exit the method if the input is invalid
        }

        Console.Write("Cik vienības? ");
        if (!int.TryParse(Console.ReadLine(), out int symptomsDelta))
        {
            Console.WriteLine("Nepareiza ievade. Lūdzu, ievadiet veselu skaitli.");
            return; // Exit the method if the input is not a valid integer
        }

        ChangeSymptoms(symptomsOperation, symptomsDelta);
    }

    if (Symptoms != 36.6)
    {
        Console.Write("Vai vēlaties palielināt (+) vai samazināt (-) temperatūru? ");
        string temperatureOperation = Console.ReadLine().ToLower();

        if (temperatureOperation != "+" && temperatureOperation != "-")
        {
            Console.WriteLine("Nepareiza ievade. Lūdzu, ievadiet '+' vai '-'.");
            return; // Exit the method if the input is invalid
        }

        Console.Write("Cik vienības? ");
        if (!double.TryParse(Console.ReadLine(), out double temperatureDelta))
        {
            Console.WriteLine("Nepareiza ievade. Lūdzu, ievadiet decimālskaitli.");
            return; // Exit the method if the input is not a valid double
        }

        ChangeTemperature(temperatureOperation, temperatureDelta);
    }
}


        
    }
    public bool Check()
    {
        bool endTreat = false;
         Console.WriteLine($"Sākotnējais stāvoklis: Temperatūra - {Temperature} °C, Simptomi - {Symptoms}, Stāvoklis - {DiseaseSeverity}");
        if (Symptoms <= 0 && Temperature == 36.6)
        {
            Condition = "Viss ir vesels!";
            DiseaseSeverity = "Prom!";
            Console.WriteLine($"{Condition}, slimība ir {DiseaseSeverity}");
            endTreat = true;
            return endTreat;
            
        }
        else
        {
            Condition = "Vēl nav pilnībā izārstēts";
            return false;

        }
        
    }
}