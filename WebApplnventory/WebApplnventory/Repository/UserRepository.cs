using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplnventory.Data;
using WebApplnventory.Models;

namespace WebApplnventory.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _context;

        public UserRepository(DBContext context)
        {
            _context = context;
        }

        public void Create(MUsers item)
        {
            _context.User.Add(item);
            _context.SaveChanges();
        }

        public MUsers GetById(int Id)
        {
            return _context.User.FirstOrDefault(t => t.UserID == Id);
        }

        public List<MUsers> GetAll()
        {
            return _context.User.ToList();
        }
        
        public void Update(int id, MUsers item)
        {
            var entity = _context.User.Find(id);
            if (entity == null)
            {
                return;
            }

            _context.Entry(entity).CurrentValues.SetValues(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.User.Find(id);
            if (entity == null)
            {
                return;
            }
            _context.User.Remove(entity);
            _context.SaveChanges();
        }
    }
}
