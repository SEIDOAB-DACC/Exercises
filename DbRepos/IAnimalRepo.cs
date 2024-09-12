using Models;
using DbModels;
namespace DbRepos;

public interface IAnimalRepo
{
    public List<csAnimalDbM> AfricanAnimals(int _count);
    public void Seed(int _count);
}