using Configuration;
using Models;
using DbRepos;

using Seido.Utilities.SeedGenerator;

namespace Services;


public class csAnimalServiceDb: IAnimalsService {

    private IAnimalRepo _repo = null;


    public List<IAnimal> AfricanAnimals(int _count) => _repo.AfricanAnimals(_count).ToList<IAnimal>();

    public void Seed(int _count) => _repo.Seed(_count);
    
    
    public csAnimalServiceDb(IAnimalRepo repo)
    {
        _repo = repo;
    }
}