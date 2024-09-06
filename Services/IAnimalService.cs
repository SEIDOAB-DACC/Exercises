using Models;
using Seido.Utilities.SeedGenerator;

namespace Services;


public interface IAnimalsService {

    public List<IAnimal> AfricanAnimals(int _count);
}
