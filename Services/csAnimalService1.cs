using Models;
using Seido.Utilities.SeedGenerator;

namespace Services;


public class csAnimalsService1: IAnimalsService {

        private const string seedSource = "./friends-seeds1.json";

        public List<csAnimal> AfricanAnimals(int _count)
        {
            var fn = Path.GetFullPath(seedSource);
            var _seeder = new csSeedGenerator(fn);

            //var animal = new csAnimal().Seed(_seeder);

            var animals = _seeder.ItemsToList<csAnimal>(_count);
            return animals;
        }
}