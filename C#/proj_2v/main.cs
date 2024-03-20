using System;

class MainClass
{
    public static void Main(string[] args)
    {
        ShowBrochure();
    }

    public static void ShowBrochure()
    {
        bool isValidChoice = false;
        string izvele = "";

        while (!isValidChoice)
        {
            Console.WriteLine("Ko Jus izvēlēsieties: teatris/koncerts? (exit)");
            izvele = Console.ReadLine().ToLower();

            if (izvele == "teatris" || izvele == "koncerts")
            {
                isValidChoice = true;
            }
            else if (izvele == "exit")
            {
                return;
            }
            else
            {
                Console.WriteLine("Nepareiza izvēle!");
            }
        }

            while (true)
        {
            Izklaide koncertsInstance = new Koncerts("Rock Band", "Rock", 127, 3, new DateTime(2025, 07, 03, 21, 15, 0), "Metallica");
            Izklaide teatrisInstance = new Teatris("John Doe", "Teātris", 46, 4, new DateTime(2024, 05, 09, 9, 15, 0), "Hamlets");

            if (izvele == "teatris")
            {
                Console.WriteLine("====");
                Console.WriteLine("Teātra informācija:");
                teatrisInstance.AttelotTeatraInformaciju();
            }
            else if (izvele == "koncerts")
            {
                Console.WriteLine("====");
                Console.WriteLine("Teatra informācija:");
                koncertsInstance.AttelotTeatraInformaciju();
            }
            string atbilde;
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Vai vēlaties skatīties brošūru vēlreiz? (ja/exit)");
                atbilde = Console.ReadLine().ToLower();

                if (atbilde == "exit" || atbilde == "ja")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nepareiza atbilde! Lūdzu, ievadiet 'ja' vai 'exit'.");
                }
            }

            if (atbilde == "exit")
            {
                return;
            }

            // If the user wants to see the brochure again, return to the initial selection
            ShowBrochure();
        }
    }
}
