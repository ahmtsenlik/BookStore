using FluentAssertions;
using TestSetup;
using WebApi.Application.DBOperations;
using WebApi.BookOperations.DeleteBook;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteBookCommandValidatorTests(CommonTestFixture testFixture)
        {
            _context=testFixture.Context;
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnError(int id)
        {
            //arrenge
            var book= new Book{Id=id ,Title = "WhenInvalidInputAreGiven_Validator_ShouldBeReturnError", PageCount = 100, PublishDate = new System.DateTime(1990, 01, 10), GenreId = 1, AuthorId = 1};
            _context.Books.Add(book);
            
            DeleteBookCommand command =new DeleteBookCommand(_context);
            command.Id=id;
        
            // act
            DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
            var result=validator.Validate(command);
            
            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }
        [Fact]
        public void WhenValidInputIsGiven_Validator_ShouldBeNotReturnError()
        {
            // arrange
            var book= new Book{Id=10, Title = "WhenInvalidInputAreGiven_Validator_ShouldBeReturnError", PageCount = 100, PublishDate = new System.DateTime(1990, 01, 10), GenreId = 1, AuthorId = 1};
            _context.Books.Add(book);

            DeleteBookCommand command =new DeleteBookCommand(_context);
            command.Id=10;

            // act
            DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
            var result=validator.Validate(command);
        
            // assert
            result.Errors.Count.Should().Be(0);
        }
    }
}