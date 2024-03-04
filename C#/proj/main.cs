// Main.cs

using System;
using System.Collections.Generic;

class MainClass
{
    static void Main()
    {
        // Izveidojam pacientus
        Patient patient1 = new Patient("Galvassāpes", 39.5, "John", "Doe", 25, "Vīrietis", "Liegais", 0);
        Patient patient2 = new Patient("Izsitumi", 37.2, "Jane", "Smith", 30, "Sieviete", "Smagais", 2);

        Console.WriteLine(Patient.Counter);
        // Pārbaudam un ārstējam pacientus
        TreatPatient(patient1);
        TreatPatient(patient2);
    }

    static void TreatPatient(Patient patient)
    {
        // Izvada pacienta informāciju
        Console.WriteLine($"Pacients {patient.FullName} iegriežas ar sūdzību: {patient.VisitPurpose}");
        
        // Pārbaude, vai pacients ir dzīvs
        if (patient.IsPatientAlive())
        {
            Console.Write("No jūsu rezultātiem, mēs uzinājām, ka jūms ");
            patient.CheckDisease();
            Console.WriteLine($"Sākotnējais stāvoklis: Temperatūra - {patient.Temperature} °C, Simptomi - {patient.Symptoms}, Stāvoklis - {patient.DiseaseSeverity}");
            Console.WriteLine();
            bool continueTreatment = true;
            while (continueTreatment)
            {
                // Pārbaude, vai pacients vēlas ārstēties
                if (patient.WantTreatment())
                {
                    Console.WriteLine($"Sākotnējais stāvoklis: Temperatūra - {patient.Temperature} °C, Simptomi - {patient.Symptoms}, Stāvoklis - {patient.DiseaseSeverity}");
                    Console.WriteLine();
                    patient.Treat();
                    continueTreatment = !patient.Check();  // Turpina ārstēšanu, kamēr pacients nav pilnībā izārstēts
                    Console.WriteLine($"{patient.FullName} {patient.Condition} ");
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine($"Pacients {patient.FullName} atteicās no ārstēšanas.");
            Console.WriteLine();
        }
    }
}
