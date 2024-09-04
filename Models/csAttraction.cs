using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public class csAttraction :ISeed<csAttraction>
{
    public string Name { get; set; }
    public List<string> Comments { get; set; }

    #region seeder
    public bool Seeded { get; set; } = false;

    public csAttraction Seed (csSeedGenerator _seeder)
    {
        Seeded = true;

        Name = _seeder.FromString("Muju, Mammas cafe, coffee house");
        Comments  = _seeder.LatinSentences(_seeder.Next(0,21));

        return this;
    }
    #endregion
    
}