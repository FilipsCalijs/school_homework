using System;

public abstract class Izklaide
{
    // Personas vārds un uzvārds
    protected string vards;
    protected string uzvards;

    public string Vards
    {
        get { return vards; }
    }

    public string Uzvards
    {
        get { return uzvards; }
    }

    // Abstraktas un virtuālas metodes
    public abstract void AttelotTemu();
    public virtual void AttelotInformaciju()
    {
        Console.WriteLine($"Persona: {Vards} {Uzvards}");
    }
}

public class Teatris : Izklaide
{
    // Papildu rekvizīts Teātra klasei
    private string izradeNosaukums;

    public string IzradeNosaukums
    {
        get { return izradeNosaukums; }
    }

    // Teātra klases konstruktors
    public Teatris(string vards, string uzvards, string izradeNosaukums)
    {
        this.vards = vards;
        this.uzvards = uzvards;
        this.izradeNosaukums = izradeNosaukums;
    }

    // Pārdefinētas metodes
    public override void AttelotTemu()
    {
        Console.WriteLine("Tēma: Teātris");
    }

    public override void AttelotInformaciju()
    {
        base.AttelotInformaciju();
        Console.WriteLine($"Izrades Nosaukums: {IzradeNosaukums}");
    }
}

public class Koncerts : Izklaide
{
    // Papildu rekvizīts Koncerta klasei
    private string grupasNosaukums;

    public string GrupasNosaukums
    {
        get { return grupasNosaukums; }
    }

    // Koncerta klases konstruktors
    public Koncerts(string vards, string uzvards, string grupasNosaukums)
    {
        this.vards = vards;
        this.uzvards = uzvards;
        this.grupasNosaukums = grupasNosaukums;
    }

    // Pārdefinētas metodes
    public override void AttelotTemu()
    {
        Console.WriteLine("Tēma: Koncerts");
    }

    public override void AttelotInformaciju()
    {
        base.AttelotInformaciju();
        Console.WriteLine($"Grupas Nosaukums: {GrupasNosaukums}");
    }
}