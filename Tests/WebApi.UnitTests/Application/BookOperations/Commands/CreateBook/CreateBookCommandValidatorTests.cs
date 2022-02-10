using AutoMapper;
using FluentAssertions;
using System;
using TestSetup;
using WebApi.Application.DBOperations;
using WebApi.BookOperations.CreateBook;
using WebApi.Entities;
using Xunit;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("Lord of the rings",0,0)]
        [InlineData("Lord of the rings",0,1)]
        [InlineData("Lord of the rings",100,0)]
        [InlineData("",0,0)]
        [InlineData("",100,1)]
        [InlineData("",0,1)]
        [InlineData("Lor",100,1)]
        [InlineData("Lord",100,0)]
        [InlineData("Lord",0,1)]
        [InlineData(" ",100,1)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string title,int pageCount,int genreId)
        {
            //arrance
            CreateBookCommand command =new CreateBookCommand(null,null);
            command.Model=new CreateBookModel(){
                Title=title,
                PageCount=pageCount,
                PublishDate=DateTime.Now.Date.AddYears(-1),
                GenreId=genreId
            };

            //act
            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            var result=validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
             //arrance
            CreateBookCommand command =new CreateBookCommand(null,null);
            command.Model=new CreateBookModel(){
                Title="Lord of the rings",
                PageCount=963,
                PublishDate=DateTime.Now.Date,
                GenreId=1
            };
            //act

            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            var result=validator.Validate(command);
            
            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            //arrance
            CreateBookCommand command =new CreateBookCommand(null,null);
            command.Model=new CreateBookModel(){
                Title="Lord of the rings",
                PageCount=963,
                PublishDate=DateTime.Now.Date.AddYears(-2),
                GenreId=1
            };
            //act

            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            var result=validator.Validate(command);
            
            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}