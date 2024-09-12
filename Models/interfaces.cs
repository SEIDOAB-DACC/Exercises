using Configuration;
using Seido.Utilities.SeedGenerator;


namespace Models;

public interface IAnimal
{
    public Guid AnimalId { get; set; }
    public AnimalKind Kind { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IZoo Zoo { get; set; }
}

public interface IZoo
{
    public Guid ZooId { get; set;}
    public string Name { get; set; }
    public List<IAnimal> Animals { get; set; }
}