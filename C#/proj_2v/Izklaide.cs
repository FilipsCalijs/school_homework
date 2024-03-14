using System;



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
        Console.WriteLine($"Tēma: Teātris");
    }

    public override void AttelotInformaciju()
    {
        base.AttelotInformaciju();
        Console.WriteLine($"Izrades Nosaukums: {izradeNosaukums}");
    }

    public override void AttelotLaiku()
    {
        base.AttelotLaiku();
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

    public override void AttelotTemu()
    {
        Console.WriteLine("Tēma: Koncerts");
    }

    public override void AttelotInformaciju()
    {
        base.AttelotInformaciju();
        Console.WriteLine($"Grupas Nosaukums: {grupasNosaukums}");
    }

    public override void AttelotLaiku()
    {
        base.AttelotLaiku();
    }
}
