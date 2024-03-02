using PracticeTask.Entitie;
using PracticeTask.Entities.Base;
using PracticeTask.Entities.Base.Base;
using PracticeTask.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask.Repository
{
    public class BaseRepository<T> : IBaseInterface<T> where T : BaseItem
    {
        public static List<T> _db;
        public BaseRepository()
        {
            _db = new List<T>();
        }
        public void Add(T item)
        {
            if (_db.Count == 0)
            {
                item.Id = 1;
                _db.Add(item);
            }
            else
            {
                item.Id = _db.Last().Id + 1;
                _db.Add(item);
            }
            
        }

        public void Delete(T item)
        {
            _db.Remove(item);
        }

        public void Delete(int Id)
        {
            var food = _db.FirstOrDefault(x => x.Id == Id);
            if (food != null)
            {
                Console.WriteLine("Can't find element");
            }
            else { _db.Remove(food); Console.WriteLine($"{food.Name} was deleted"); }
        }

        public T Get(T item)
        {
            return _db.Find(x => x.Name == item.Name);
        }

        public IList<T> GetAll()
        {
            return _db;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            var food = _db.FirstOrDefault(x => x.Id == item.Id);

            if (food != null)
            {
                _db.Remove(food);
                Add(item);
            }
        }
    }
}
