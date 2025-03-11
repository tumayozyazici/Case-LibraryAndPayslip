using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1
{
    public class Library
    {
        public Library()
        {
            Members = new List<IMember>();
            Books = new List<Book>();
        }

        public  List<IMember> Members { get; set; }
        public  List<Book> Books { get; set; }

        public void AddMember(IMember member)
        {
            Members.Add(member);
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public List<IMember> ShowMembers()
        {
            return Members.ToList();
        }

        public List<Book> ShowBooks()
        {
            return Books.OrderBy(book => book.Status).ToList();
        }

        public bool LendBook(List<Book> books, IMember member)
        {
            //Burada manuel bir transaction işlemi yazmak zorundayım çünkü işlem sırasında ödünç vermeye müsait olmayan bir kitap olursa işlemi geri almak zorundayım.

            //Backups
            List<Book> originalBooks = new List<Book>(Books);
            List<Book> borrowedBooksDuringProcess = new List<Book>();

            try
            {
                foreach (var book in books)
                {
                    if (book.Status == Status.Borrowable)
                    {
                        member.BorrowBook(book);
                        Books.Remove(book);
                        book.DecreaseStock();
                        borrowedBooksDuringProcess.Add(book);
                    }
                    else throw new Exception($"{book.Title} is not available");
                }
                return true;
            }
            catch (Exception)
            {
                //Rollback process
                Books.Clear();
                Books.AddRange(originalBooks);

                foreach(var book in borrowedBooksDuringProcess)
                {
                    member.ReturnBook(book);
                    book.IncreaseStock();
                }
                return false;
            }
        }

        public void RetrieveBook(List<Book> books, IMember member)
        {
            foreach (var book in books.ToList())
            {
                member.ReturnBook(book);
                Book x = Books.Find(b => b.ISBN == book.ISBN);
                Books.Remove(x);
                Books.Add(book);
                book.IncreaseStock();
            }
        }
    }
}
