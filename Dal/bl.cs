using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
   public class bl
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
        public List<book> ShowOneBook(int num)
        {
            List<book> l = new List<book>();
            foreach(var i in db.book)
            {
                if (num == i.id)
                {
                    l.Add(i);
                }
            }
            return l.ToList();
        }
        public void SetOneBook(int id,string name,string writer,int year)
        {
            foreach (var i in db.book)
            {
                if (id == i.id)
                {
                    if (name != null)
                        i.name = name;
                    if (writer != null)
                        i.writer_name = writer;
                    if (year != null)
                        i.publish_year = year;
                }
            }
            db.SaveChanges();
        }
        public List<book> BorrowsBook()
        {
            List<book> l = new List<book>();
            foreach(var i in db.book)
            {
                foreach (var j in db.borrows)
                    if (i.id == j.book_id)
                    {
                        l.Add(i);
                    }
            }
            return l;
        }
        public bool IsBookBorrowed(int id)
        {
            foreach (var i in db.book)
            {
                if(i.id==id)
                foreach (var j in db.borrows)
                    if (i.id == j.book_id)
                    {
                        return true;
                    }
            }
            return false;
        }
        public void Borrow(int ide,string barrownane,int bookid)
        {
            borrows b = new borrows()
            {
                borrow_name = barrownane,
                book_id = bookid,
                id = ide
            };
            db.borrows.Add(b);
            db.SaveChanges();
        }
        public book ShowPopular()
        {
            //List<book> l = new List<book>();
            book l = new book();
            int max = 0;
            foreach(var i in db.book)
            {
                int popular = 0;
                foreach(var j in db.borrows)
                {
                    if (i.id == j.book_id)
                        popular++;
                }
                if(popular>max)
                {
                    max = popular;
                    l=i;
                }    
            }
            return l;
        }
    }
}
