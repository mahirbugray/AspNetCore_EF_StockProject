using AspNetCoreMvc_EF_Stock.Data;
using AspNetCoreMvc_EF_Stock.Models;

namespace AspNetCoreMvc_EF_Stock.Repositories
{
    public class CategoryRepository
    {
        StockDbContext _context = new StockDbContext();

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
        public Category GetById(int id) 
        {
            //return _context.Categories.FirstOrDefault(c => c.Id == id);
            return _context.Categories.Find(id);
        }
        public void Add(Category category)
        {
            _context.Categories.Add(category); //ara katmana ekler.
            _context.SaveChanges(); //veritabanıyla eşleştirir.
        }
        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
