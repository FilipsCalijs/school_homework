
// Main.cs
// Try to run only on OnlineGDB


using System;
using System.Collections.Generic;

class MainClass
{
    static void Main()
    {
        // Izveidojam pacientus
        Patient patient1 = new Patient("Galvassāpes", 39.5, "John", "Doe", 25, "Vīrietis", "Liegais", 0);
        Patient patient2 = new Patient("Izsitumi", 37.2, "Jane", "Smith", 30, "Sieviete", "Smagais", 2);

        // Pārbaudam un ārstējam pacientus
        TreatPatient(patient1);
        TreatPatient(patient2);
    }

    static void TreatPatient(Patient patient)
    {
        Console.WriteLine($"Pacients {patient.FullName} iegriežas ar sūdzību: {patient.VisitPurpose}");
        
        // Pārbaude, vai pacients vēlas ārstēties
        if (patient.WantTreatment())
        {
           Console.Write("No jūsu rezultātiem, mēs uzinājām, ka jūms ");
           patient.CheckDisease();
           Console.WriteLine($"Sākotnējais stāvoklis: Temperatūra - {patient.Temperature} °C, Simptomi - {patient.Symptoms}, Stāvoklis - {patient.DiseaseSeverity}");

           bool continueTreatment = true;
           while (continueTreatment)
            {

                if (patient.WantTreatment()){
                    Console.WriteLine($"Sākotnējais stāvoklis: Temperatūra - {patient.Temperature} °C, Simptomi - {patient.Symptoms}, Stāvoklis - {patient.DiseaseSeverity}");
                    patient.Treat();
                    if (patient.Check()){
                        Console.WriteLine($" {patient.FullName} ir vesels, var iet prom! ");
                        Console.WriteLine();
                        break;
                    }
                    
                }else{
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