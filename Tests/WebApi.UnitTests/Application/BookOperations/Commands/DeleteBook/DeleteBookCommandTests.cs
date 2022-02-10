using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.DBOperations;
using WebApi.BookOperations.DeleteBook;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        

        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
        }
        [Fact]
        public void WhenNonexistBookIdIsGiven_InvalidOperationException_ShouldBeReturn()
        {
             //arrange (Hazırlık)
            var Id=1000;
            
            //act and assert
            DeleteBookCommand command=new DeleteBookCommand(_context);
            command.Id=Id;
            
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Böyle bir kitap yok");
        }
        [Fact]
        public void  WhenValidIdAreGiven_Book_ShouldBeDeleted()
        {
            //arrange
            var book = new Book() {Id=10 ,Title = "WhenValidIdAreGiven_Book_ShouldBeDeleted", PageCount = 100, PublishDate = new System.DateTime(1990, 01, 10), GenreId = 1, AuthorId = 1};
            _context.Books.Add(book);
            _context.SaveChanges();

            //act
            DeleteBookCommand command =new DeleteBookCommand(_context);
            command.Id=book.Id;
            command.Handle();

            //assert
            var result=_context.Books.SingleOrDefault(x=>x.Id==book.Id);
            result.Should().BeNull();

        }
    }
}