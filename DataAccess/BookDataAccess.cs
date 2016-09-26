using System.Linq;
using System.Collections.Generic;
using Homemade.Models;

namespace Homemade.DataAccess
{
    public class BookDataAccess : IDataAccess<Book>
    {
        private IList<Book> _cache = new List<Book>();

        public bool Delete(Book obj)
        {
            if (obj != null && _cache.Any(T => T.Id == obj.Id)) {
                var index = _cache.IndexOf(_cache.First(T => T.Id == obj.Id));
                _cache.RemoveAt(index);
                return true;
            }

            return false;
        }

        public Book GetById(int id)
        {
            return _cache.FirstOrDefault(T=> T.Id == id);
        }

        public IList<Book> GetList()
        {
            return _cache;
        }

        public bool Insert(Book obj)
        {
            if (obj.Id == -1) {
                if (_cache.Any()) {
                    obj.Id = _cache.Select(T=> T.Id).Max() + 1;
                }
                else {
                    obj.Id = 0;
                }                
            }

            if (obj != null && !_cache.Any(T => T.Id == obj.Id)) {
                _cache.Add(obj);
                return true;
            }
            
            return false;
        }

        public bool Update(Book obj)
        {
            if (obj != null && _cache.Any(T => T.Id == obj.Id)) {
                var index = _cache.IndexOf(_cache.First(T => T.Id == obj.Id));
                _cache[index] = obj;
                return true;
            }

            return false;
        }
    }
}