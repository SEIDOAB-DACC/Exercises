using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Seido.Utilities.SeedGenerator;
using Newtonsoft.Json;



namespace DbModels;

public class csAnimalDbM : csAnimal, ISeed<csAnimalDbM>
{
    [Key]
    public override Guid AnimalId { get; set; }

    
    [NotMapped]
    public override IZoo Zoo { get => ZooDbM; set => throw new NotImplementedException(); }

    [JsonIgnore]
    public  csZooDbM ZooDbM { get; set; }

    public override csAnimalDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed (_seeder);
        return this;
    }
}
