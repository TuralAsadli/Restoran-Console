using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask.Repository.Interfaces
{
    internal interface IBaseInterface<T> where T : class
    {
        void Add(T item);
        IList<T> GetAll();
        T Get(T item);
        T GetById(int id);
        void Delete(T item);

        void Delete(int Id);

        void Update(T item);
        
    }
}
