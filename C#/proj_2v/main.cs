using System;

class MainClass
{
    public static void Main(string[] args)
    {
        bool isValidChoice = false;
        string izvele = "";

        while (!isValidChoice)
        {
            Console.WriteLine("Ko Jūs izvēlēsieties: teatris/koncerts? (exit)");
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
            if (izvele == "teatris")
            {
                Teatris teatrisInstance = new Teatris("John Doe", "Teātris", 100, 50, new DateTime(2024, 05, 09, 9, 15, 0), "Hamlets");
                Console.WriteLine("Teātra informācija:");
                teatrisInstance.AttelotTemu();
                teatrisInstance.AttelotInformaciju();
                teatrisInstance.AttelotLaiku();
                teatrisInstance.AttelotSakumaLaiku();
            }
            else if (izvele == "koncerts")
            {
                Koncerts koncertsInstance = new Koncerts("Rock Band", "Rock", 500, 300, new DateTime(2025, 07, 03, 21, 15, 0), "Metallica");
                Console.WriteLine("\nKoncerta informācija:");
                koncertsInstance.AttelotTemu();
                koncertsInstance.AttelotInformaciju();
                koncertsInstance.AttelotLaiku();
                koncertsInstance.AttelotSakumaLaiku();
            }

            Console.WriteLine("Vai vēlaties skatīties brošūru vēlreiz? (ja/exit)");
            string atbilde = Console.ReadLine().ToLower();

            if (atbilde == "exit")
            {
                return;
            }
            else if (atbilde != "ja")
            {
                Console.WriteLine("Nepareiza atbilde!");
                return;
            }
        }
    }
}
