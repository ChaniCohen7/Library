using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    class Bll
    {
        public Library2Entities db = new Library2Entities();
        public List<book> BooksList()
        {
            return db.book.ToList();
        }
        public void AddBook(book b)
        {
            db.book.Add(b);
            db.SaveChanges();
        }

    }
}
