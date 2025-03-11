using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1
{
    public class Member : IMember
    {
        public Member()
        {
            BorrowedBooks = new List<Book>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string MemberNumber { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public void BorrowBook(Book book)
        {
            BorrowedBooks.Add(book);
        }

        public List<Book> GetBorrowedBooks()
        {
            if (BorrowedBooks != null) return BorrowedBooks;
            return new List<Book>();
        }

        public void ReturnBook(Book book)
        {
            BorrowedBooks.Remove(book);

        }
    }
}
