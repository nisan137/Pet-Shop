using PetShopApp.Data;
using PetShopApp.Models;

namespace PetShopApp.Repositories
{
    public class AnimalRepository : IRepository<Animal>
    {
        private readonly PetShopContext _context;

        public AnimalRepository(PetShopContext context) => _context = context;
        public void Add(Animal entity)
        {
            _context.Animals.Add(entity);
            Save();
        }

        public void Delete(int id)
        {
            var a = Get(id);
            if (a == null)
                return;
            _context.Animals.Remove(a);
            Save();
        }

        public Animal? Get(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Animal> GetAll()
        {
            return _context.Animals;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Animal entity)
        {
            var animal = Get(entity.Id);
            if (animal == null) return;
            animal.Age = entity.Age;
            animal.Name = entity.Name;
            animal.Description = entity.Description;
            animal.PhotoUrl = entity.PhotoUrl;
            animal.Comments = entity.Comments;
            animal.CategoryId = entity.CategoryId;
            Save();
        }
    }
}
