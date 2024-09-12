using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;


namespace DbModels;


public class csZooDbM : csZoo, ISeed<csZooDbM>
{
    [Key]
    public override Guid ZooId { get; set; }

    [NotMapped]
    public override List<IAnimal> Animals { get; set; }

    public List<csAnimalDbM> AnimalsDbM { get; set; }

    public override csZooDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}