using System;
using System.Collections.Generic;
using System.Linq;
using Homemade.Models;

namespace Homemade.DataAccess.EntityFramework
{
    public class BookDataAccessEF : IDataAccess<Book>
    {
        private LibraryDbContext _context;

        public BookDataAccessEF (LibraryDbContext context)
        {
            _context = context;
        }

        public bool Delete(Book obj)
        {
            if (obj != null && _context.Book.Any(T=>T.Id == obj.Id)) {
                _context.Book.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Book GetById(int id)
        {
            return _context.Book.FirstOrDefault(T=> T.Id == id);
        }

        public IList<Book> GetList()
        {
            return _context.Book.ToList();
        }

        public bool Insert(Book obj)
        {
            _context.Add(obj);
            int numberOfChanges = _context.SaveChanges();
            return Convert.ToBoolean(numberOfChanges);
        }

        public bool Update(Book obj)
        {
            if (obj != null && _context.Book.Any(T=> T.Id == obj.Id)) {
                _context.Book.Update(obj);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}