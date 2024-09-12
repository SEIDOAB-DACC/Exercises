namespace DbRepos;

public interface IAnimalRepo
{
    public List<IAnimal> AfricanAnimals(int _count);
    public void Seed(int _count);
}