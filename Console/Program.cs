using CSProjeDemo1;
using System.Security.Cryptography.X509Certificates;

namespace System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            #region Seed Data
            Book book1 = new HistoryBook
            {
                ISBN = "1234567890",
                Title = "HistoryBook2",
                Author = "Anonymous",
                InStock = 5,
                PublishDate = DateTime.Now,
                Status = Status.Borrowable
            };

            Book book2 = new HistoryBook
            {
                ISBN = "1234567891",
                Title = "HistoryBook3",
                Author = "Anonymous",
                InStock = 2,
                PublishDate = DateTime.Now,
                Status = Status.Borrowed
            };

            Book book3 = new HistoryBook
            {
                ISBN = "1234567892",
                Title = "HistoryBook4",
                Author = "Anonymous",
                InStock = 1,
                PublishDate = DateTime.Now,
                Status = Status.Borrowable
            };

            Book book4 = new HistoryBook
            {
                ISBN = "1234567893",
                Title = "HistoryBook5",
                Author = "Anonymous",
                InStock = 1,
                PublishDate = DateTime.Now,
                Status = Status.Borrowable
            };

            Book book5 = new ScienceBook
            {
                ISBN = "1234567892",
                Title = "ScienceBook1",
                Author = "Anonymous",
                InStock = 3,
                PublishDate = DateTime.Now,
                Status = Status.Borrowable
            };

            Book book6 = new ScienceBook
            {
                ISBN = "1234567893",
                Title = "ScienceBook2",
                Author = "Anonymous",
                InStock = 0,
                PublishDate = DateTime.Now,
                Status = Status.NotAvailable
            };

            Book book7 = new ScienceBook
            {
                ISBN = "1234567894",
                Title = "ScienceBook3",
                Author = "Anonymous",
                InStock = 1,
                PublishDate = DateTime.Now,
                Status = Status.Borrowable
            };

            Book book8 = new FictionalBook
            {
                ISBN = "1234567895",
                Title = "FictionalBook1",
                Author = "Anonymous",
                InStock = 4,
                PublishDate = DateTime.Now,
                Status = Status.Borrowable
            };

            Book book9 = new FictionalBook
            {
                ISBN = "1234567896",
                Title = "FictionalBook2",
                Author = "Anonymous",
                InStock = 2,
                PublishDate = DateTime.Now,
                Status = Status.Borrowable
            };

            Book book10 = new FictionalBook
            {
                ISBN = "1234567897",
                Title = "FictionalBook3",
                Author = "Anonymous",
                InStock = 1,
                PublishDate = DateTime.Now,
                Status = Status.Borrowable
            };

            library.Books.Add(book1);
            library.Books.Add(book2);
            library.Books.Add(book3);
            library.Books.Add(book4);
            library.Books.Add(book5);
            library.Books.Add(book6);
            library.Books.Add(book7);
            library.Books.Add(book8);
            library.Books.Add(book9);
            library.Books.Add(book10);

            Member member1 = new Member
            {
                Name = "John",
                Surname = "Doe"
            };
            member1.BorrowedBooks.Add(book8);
            member1.BorrowedBooks.Add(book9);
            member1.BorrowedBooks.Add(book10);

            Member member2 = new Member { Name = "Jane", Surname = "Doe" };
            Member member3 = new Member { Name = "Jack", Surname = "Doe" };
            Member member4 = new Member { Name = "Jill", Surname = "Doe" };

            library.Members.Add(member1);
            library.Members.Add(member2);
            library.Members.Add(member3);
            library.Members.Add(member4);

            #endregion

            #region ShowAllMembers

            //library.ShowMembers().ForEach(member =>
            //{
            //    Console.WriteLine($"Name: {member.Name} Surname: {member.Surname}");
            //});

            //var result = library.ShowMembers();

            #endregion

            #region ShowBorrowedMembers

            //library.ShowMembers().ForEach(member =>
            //{
            //    foreach (var book in member.GetBorrowedBooks())
            //    {
            //        Console.WriteLine($"Name: {member.Name} Surname: {member.Surname} Book: {book.Title}");
            //    }
            //});

            #endregion

            #region ShowBookStatusForEachType

            //library.ShowBooks().ForEach(book =>
            //{
            //    if (book.Status == Status.Borrowable)
            //    {
            //        Console.WriteLine($"Title: {book.Title} Author: {book.Author} is available. Stock is {book.InStock}");
            //    }
            //    else if (book.Status == Status.Borrowed)
            //    {
            //        Console.WriteLine($"Title: {book.Title} Author: {book.Author} is borrowed. Stock is {book.InStock}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Title: {book.Title} Author: {book.Author} is not available. Stock is {book.InStock}");
            //    }
            //});

            #endregion

            #region ShowBooksThatLibraryOwns

            //library.ShowBooks().ForEach(book =>
            //{
            //    Console.WriteLine($"Title: {book.Title} Author: {book.Author}");
            //});

            #endregion
        }
    }
}
