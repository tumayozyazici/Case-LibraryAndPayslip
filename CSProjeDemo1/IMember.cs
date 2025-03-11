using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1
{
    public interface IMember
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MemberNumber { get; set; }
        public List<Book>? BorrowedBooks { get; set; }


        public List<Book> GetBorrowedBooks();
        public void BorrowBook(Book book);
        public void ReturnBook(Book book);
    }
}
