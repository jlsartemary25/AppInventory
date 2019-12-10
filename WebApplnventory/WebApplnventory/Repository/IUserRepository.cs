using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplnventory.Models;

namespace WebApplnventory.Repository
{
    public interface IUserRepository
    {
        void Create(MUsers item);
        MUsers GetById(int Id);
        List<MUsers> GetAll();
        void Update(int id, MUsers item);
        void Delete(int Id);
    }
}