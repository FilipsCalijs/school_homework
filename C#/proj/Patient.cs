// Patient.cs
// Pievienot komentārus latviešu valodā

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
    private static int counter = 0;
    
    // Kopējais pacientu skaits
    public static int Counter
    {
        get { return counter; }
    }

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
        counter++;
    }

    // Metodes
    public bool WantTreatment()
    {
        while (true)
        {
            // Iegūst pacienta vēlmi ārstēties
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
        // Pārbauda slimību un nosaka stāvokli
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
        // Maina temperatūru atkarībā no operācijas
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
        // Maina simptomus atkarībā no operācijas
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
        if (Symptoms > 0)
        {
            bool validSymptomsInput = false;

            while (!validSymptomsInput)
            {
                // Ārstē simptomus, ja tie ir klāt
                Console.Write("Vai vēlaties palielināt (+) vai samazināt (-) simptomus? ");
                string symptomsOperation = Console.ReadLine().ToLower();

                if (symptomsOperation == "+" || symptomsOperation == "-")
                {
                    Console.Write("Cik vienības? ");

                    if (int.TryParse(Console.ReadLine(), out int symptomsDelta))
                    {
                        ChangeSymptoms(symptomsOperation, symptomsDelta);
                        validSymptomsInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Nederīga ievade. Lūdzu, ievadiet skaitli.");
                    }
                }
                else
                {
                    Console.WriteLine("Nederīga ievade. Lūdzu, ievadiet '+' vai '-'.");
                }
            }
        }
    
        // Ja temperatūra nav normāla, ārstē arī temperatūru
        if (Temperature != 36.6)
        {
            bool validTemperatureInput = false;

            while (!validTemperatureInput)
            {
                Console.Write("Vai vēlaties palielināt (+) vai samazināt (-) temperatūru? ");
                string temperatureOperation = Console.ReadLine().ToLower();

                if (temperatureOperation == "+" || temperatureOperation == "-")
                {
                    Console.Write("Cik vienības? ");

                    if (double.TryParse(Console.ReadLine(), out double temperatureDelta))
                    {
                        ChangeTemperature(temperatureOperation, temperatureDelta);
                        validTemperatureInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Nederīga ievade. Lūdzu, ievadiet skaitli.");
                    }
                }
                else
                {
                    Console.WriteLine("Nederīga ievade. Lūdzu, ievadiet '+' vai '-'.");
                }
            }
        }
    }

    // Pārbauda pacienta stāvokli
    public bool Check()
    {
        Console.WriteLine($"Sākotnējais stāvoklis: Temperatūra - {Temperature} °C, Simptomi - {Symptoms}, Stāvoklis - {DiseaseSeverity}");

        if (Symptoms <= 0 && (Temperature >= 36.4 && Temperature <= 36.9))
        {
            Condition = "ir vesels!";
            DiseaseSeverity = "Prom!";

            return true;  // Pacients tiek uzskatīts par pilnībā izārstētu un vairs nav dzīvs.
        }
        else if (Temperature > 44 || Temperature < 26.6 || Symptoms > 10)
        {
            Condition = "ir miris!";
            DiseaseSeverity = "N/A";

            return true;  // Pacients tiek uzskatīts par mirušu.
        }
        else
        {
            Condition = "vēl nav pilnībā izārstēts";
            return false;  // Pacients ir dzīvs un vēl nav pilnībā izārstēts.
        }
    }

    // Pārbauda, vai pacients ir dzīvs
    public bool IsPatientAlive()
    {
        return !(Temperature > 44 || Temperature < 26.6 || Symptoms > 10);
    }
}


