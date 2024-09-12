using Configuration;
using Models;
using DbContext;
using Seido.Utilities.SeedGenerator;

namespace DbRepos;

public class csAnimalRepo : IAnimalRepo
{

    private const string seedSource = "./friends-seeds1.json";

    public List<IAnimal> AfricanAnimals(int _count)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            List<IAnimal> animals = db.Animals.Take(_count).ToList<IAnimal>();
            return animals;        
        }
    }
    public void Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var animals = _seeder.ItemsToList<csAnimal>(_count);
            db.Animals.AddRange(animals);

            db.SaveChanges();

        }
    }
}
