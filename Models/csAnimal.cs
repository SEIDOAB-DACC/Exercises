using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public interface IAnimal
{
    public AnimalKind Kind { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}


public enum AnimalKind {Zebra, Elephant, Lion, Leopard, Gasell}
public class csAnimal :ISeed<csAnimal>, IAnimal
{
    public AnimalKind Kind { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    #region seeder
    public bool Seeded { get; set; } = false;

    public csAnimal Seed (csSeedGenerator _seeder)
    {
        Seeded = true;
        Kind = _seeder.FromEnum<AnimalKind>();
        Age = _seeder.Next(0, 11);
        Name = _seeder.PetName;
        Description = _seeder.LatinSentence;

        return this;
    }
    #endregion
    
}