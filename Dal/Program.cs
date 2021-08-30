using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    class Program
    {
        static void Main(string[] args)
        {
            bl b = new bl();
            b.AddBook(new book() { name = "i am alive", writer_name = "chani", publish_year = 1345 });
        }
    }
}
