using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface IEntityBase<T> where T:Entity
    {
        int Insert(T item);
        int Update(T item);
        int Delete(T item);
        bool Exists(T item);
        T GetById(int id);
        List<T> GetAll();
    }
}
