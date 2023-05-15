using PetShopApp.Data;
using PetShopApp.Models;

namespace PetShopApp.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly PetShopContext _context;

        public CategoryRepository(PetShopContext context) => _context = context;
        public void Add(Category entity)
        {
            _context.Categories.Add(entity);    
            Save();
        }

        public void Delete(int id)
        {
            var c = Get(id);
            if (c == null) return;
            _context.Categories.Remove(c);
            Save();
        }

        public Category? Get(int id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category entity)
        {
            var category = Get(entity.Id);
            if (category == null) return;
            category.Name = entity.Name;            
        }
    }
}
