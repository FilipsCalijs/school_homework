using System;

// add piejamo pieejamoVietu and buy ticket? aswell as ASKII art


//доделать майн.cs и проверит все как ты понял и знаешь

// абстрактный класс нельзя использовать напрямую, а только в наследниках, нужен для того чтобы описать нечто абстрактное
    //protected объявляет метод или свойство защищенными (похоже на private)
// virtual - для того чтобы иметь возможность переопределить какой-то метод, который находится в базовом классе,
    // без virtual новую реализацию (перепись кода) мы сделать не можем
    // override - для того чтобы в классе наследние сделать новую реализацию/переопределить метод базового класса


public abstract class Izklaide
{
    protected string izpilditajs;
    protected string koncertaTips;
    protected int pieejamoVietu;
    protected int aiznemtoVietu;
    protected DateTime sakumaLaiks;
    protected bool nopirktBilete;

    public abstract void AttelotTemu();

    public virtual void AttelotInformaciju()
    {
        Console.WriteLine($"Persona: {izpilditajs} {koncertaTips}");
    }

    public virtual void AttelotLaiku()
    {
        TimeSpan atlikusaisLaiks = sakumaLaiks - DateTime.Now;

        if (atlikusaisLaiks.TotalSeconds < 0)
        {
            Console.WriteLine("Pasākums ir beidzies!");
        }
        else
        {
            Console.WriteLine($"Atlikušais laiks: {atlikusaisLaiks.Days} dienas, {atlikusaisLaiks.Hours} stundas, {atlikusaisLaiks.Minutes} minūtes, {atlikusaisLaiks.Seconds} sekundes");
        }
    }

    public virtual void AttelotSakumaLaiku()
    {
        Console.WriteLine($"Sākuma laiks: {sakumaLaiks}");
    }

    public virtual void AttelotTeatraInformaciju()
    {
        AttelotTemu();
        Askii();
        AttelotInformaciju();
        AttelotLaiku();
        AttelotSakumaLaiku();
        AttelotPieejamoVietu();
        Biletes();
        Console.WriteLine("====");
        
    }
    public virtual void Askii()
    {}
    public virtual void AttelotPieejamoVietu()
    {
        Console.WriteLine($"Pieejamo vietu: {pieejamoVietu}");
        Console.WriteLine($"Aizņemto vietu: {aiznemtoVietu}");
    }
    
    public virtual void Biletes()
    {
      
    }
    
    public virtual void buyBiletes()
{
    if (pieejamoVietu > 0) 
    {
        Console.WriteLine("Biļetes ir iegādātas!");
        pieejamoVietu = pieejamoVietu - 1;
        aiznemtoVietu = aiznemtoVietu + 1;
        Console.WriteLine($"Pieejamo vietu: {pieejamoVietu}");
        Console.WriteLine($"Aizņemto vietu: {aiznemtoVietu}");
    }
    else
    {
        Console.WriteLine("Atvainojiet, visas vietas ir aizņemtas!");
    }
}

}

public class Koncerts : Izklaide
{
    private string grupasNosaukums;

    public Koncerts(string izpilditajs, string koncertaTips, int pieejamoVietu, int aiznemtoVietu, DateTime sakumaLaiks, string grupasNosaukums)
    {
        this.izpilditajs = izpilditajs;
        this.koncertaTips = koncertaTips;
        this.pieejamoVietu = pieejamoVietu;
        this.aiznemtoVietu = aiznemtoVietu;
        this.sakumaLaiks = sakumaLaiks;
        this.grupasNosaukums = grupasNosaukums;
    }
     public override void Askii()
    {
        string asciiArt = @"
        
          ________________________
         ///\\//\\//\\//\\//\\//\\/\\\
       //\{}//\\//\\//\\//\\//\\//{}/\\
      ///&%&%&%&/~~~~~~~~~~~~\&%&%&%&\\\
      ||&%&%&_.'              '._&%&%&||
      ||&%'''                    '''%&||
      ||&%&                ~c      &%&||
      ||&%&     o   )____  <)\/    &%&||
      ||&%&    /_=-/_____|  /\     &%&||
ejm97 ||&%&&  ( /\.|     | /~/    &&%&||
______||&%&&======================&&%&||______

";

        Console.WriteLine(asciiArt);
    }

    public override void AttelotTemu()
    {
        Console.WriteLine("Tēma: Koncerts");
    }

    public override void Biletes()
    {
        Console.WriteLine("Vai vēlaties iegādāties biļeti uz Koncertu? (ja/ne)");
        string atbilde = Console.ReadLine().ToLower();
    
        if (atbilde == "ja")
        {
            buyBiletes();
        }
        else
        {
            Console.WriteLine("Nav problēmu, paldies!");
        }
    }

    public override void AttelotInformaciju()
    {
        base.AttelotInformaciju();
        Console.WriteLine($"Grupas Nosaukums: {grupasNosaukums}");
    }

    public override void AttelotSakumaLaiku()
    {
        Console.WriteLine($"Koncerta sakuma laiks: {sakumaLaiks}");
    }
    public override void AttelotPieejamoVietu()
    {
        Console.WriteLine($"Pieejamo vietu: {pieejamoVietu}");
        Console.WriteLine($"Aizņemto vietu: {aiznemtoVietu}");
    }
}

public class Teatris : Izklaide
{
    private string izradeNosaukums;

    public Teatris(string izpilditajs, string koncertaTips, int pieejamoVietu, int aiznemtoVietu, DateTime sakumaLaiks, string izradeNosaukums)
    {
        this.izpilditajs = izpilditajs;
        this.koncertaTips = koncertaTips;
        this.pieejamoVietu = pieejamoVietu;
        this.aiznemtoVietu = aiznemtoVietu;
        this.sakumaLaiks = sakumaLaiks;
        this.izradeNosaukums = izradeNosaukums;
    }

    public override void AttelotTemu()
    {
        Console.WriteLine($"Nosaukums: Teātris");
    }

    public override void Askii()
    {
        string asciiArt = @"
         ____________________________________________
      ///\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\\
    /\\{}//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\{}/\
   /\/&%&%&%&/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\&%&%&%&\/\
   ||&%&%&_.'                                   '._&%&%&||
   ||&%&.'                         _____           '.&%&||
   ||&%&                          | |   \            &%&||
   ||&%&                          | |    \           &%&||
   ||&%&                          | |     \___       &%&||
   ||&%&                          | |         \      &%&||
   ||&%&                          | |          \     &%&||
   ||&%&                 ~~0    __|_|___________|    &%&||
   ||&%&    0 /           /\/  /____|____________)   &%&||
   ||&%&   /_oo-#=  __ . /  \_|__________________|   &%&||
   ||&%&    | \/   /_/ |/__    | )(            )(    &%&||
   ||&%&    |\      |  | |\\  :| )(            )(    &%&||
   ||&%&    / \     |,                               &%&||
   ||&%&&   ~  ~   /|\                              &&%&||
   ||ejm97                                         &&&%&||
___||&%&&&&=======================================&&&&%&||___";

        Console.WriteLine(asciiArt);
    }
    
    public override void Biletes()
{
    string atbilde;

    do
    {
        Console.WriteLine("Vai vēlaties iegādāties biļeti uz Teatris? (ja/ne)");
        atbilde = Console.ReadLine().ToLower();

        if (atbilde != "ja" && atbilde != "ne")
        {
            Console.WriteLine("Lūdzu, ievadiet 'ja' vai 'ne'.");
        }
    } while (atbilde != "ja" && atbilde != "ne");

    if (atbilde == "ja")
    {
        buyBiletes();
    }
    else
    {
        Console.WriteLine("Nav problēmu, paldies!");
    }
}


    public override void AttelotInformaciju()
    {
        base.AttelotInformaciju();
        Console.WriteLine($"Izrades Nosaukums: {izradeNosaukums}");
    }
    
    public override void AttelotPieejamoVietu()
    {
        Console.WriteLine($"Pieejamo vietu: {pieejamoVietu}");
        Console.WriteLine($"Aizņemto vietu: {aiznemtoVietu}");
    }
    
    
}