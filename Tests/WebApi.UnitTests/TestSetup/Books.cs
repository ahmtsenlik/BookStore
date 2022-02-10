using System;
using WebApi.Application.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                    new Book
                    {
                        Title="Lyean Startup",
                        GenreId=1,
                        AuthorId=1,
                        PageCount=200,
                        PublishDate=new DateTime(2001,06,20)
                    },
                    new Book
                    {
                        Title="Herland",
                        GenreId=2,
                        AuthorId=3,
                        PageCount=250,
                        PublishDate=new DateTime(2011,05,21)
                    },
                    new Book
                    {
                        Title="Dune",
                        GenreId=3,
                        AuthorId=2,
                        PageCount=130,
                        PublishDate=new DateTime(2003,02,14)     
                    }
                );
        }
    }
    
}