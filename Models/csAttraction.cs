using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public class csAttraction :ISeed<csAttraction>
{
    public string Name { get; set; }
    public List<csComment> Comments { get; set; }

    #region seeder
    public bool Seeded { get; set; } = false;

    public csAttraction Seed (csSeedGenerator _seeder)
    {
        Seeded = true;

        Name = _seeder.FromString("Muju, Mammas cafe, coffee house");

        return this;
    }
    #endregion
    
}