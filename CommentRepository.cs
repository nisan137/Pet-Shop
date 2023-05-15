using PetShopApp.Data;
using PetShopApp.Models;

namespace PetShopApp.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private readonly PetShopContext _context;

        public CommentRepository(PetShopContext context)
        {
            _context = context;
        }
        public void Add(Comment entity)
        {
            _context.Comments.Add(entity);
            Save();
        }

        public void Delete(int id)
        {
            var c = Get(id);
            if (c == null) return;
            _context.Comments.Remove(c);
            Save();
        }

        public Comment? Get(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            var comment = Get(entity.Id);
            if (comment == null) return;
            comment.CommentText = entity.CommentText;
            comment.AnimalId = entity.AnimalId;
        }
    }
}
