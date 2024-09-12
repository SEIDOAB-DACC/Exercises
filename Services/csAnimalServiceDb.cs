using Configuration;
using Models;
using DbContext;
using DbRepos;

using Seido.Utilities.SeedGenerator;

namespace Services;


public class csAnimalServiceDb: IAnimalsService {

    private IAnimalRepo _repo = null;


    public List<IAnimal> AfricanAnimals(int _count) => _repo.AfricanAnimals(_count);

    public void Seed(int _count) => _repo.Seed(_count);

    public List<IAnimal> SeedAndRead(int _count)
    {
        _repo.Seed(_count);
        var animals = _repo.AfricanAnimals(_count);

        return animals;
    }
    
    
    public csAnimalServiceDb(IAnimalRepo repo)
    {
        _repo = repo;
    }
}