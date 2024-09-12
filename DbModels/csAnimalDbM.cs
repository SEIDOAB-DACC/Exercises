
using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;

namespace DbModels;

public class csAnimalDbM : csAnimal, ISeed<csAnimalDbM>
{
    [Key]
    public override Guid AnimalId { get; set; } = Guid.NewGuid();

    public override csAnimalDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed(_seeder);
        return this;
    }
}
