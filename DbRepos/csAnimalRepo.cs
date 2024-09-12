using Configuration;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;

namespace DbRepos;

public class csAnimalRepo : IAnimalRepo
{

    private const string seedSource = "./friends-seeds1.json";

    public List<csAnimalDbM> AfricanAnimals(int _count)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            List<csAnimalDbM> animals = db.Animals.Take(_count).ToList();
            return animals;        
        }
    }
    public void Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var animals = _seeder.ItemsToList<csAnimalDbM>(_count);
            db.Animals.AddRange(animals);

            db.SaveChanges();

        }
    }
}
