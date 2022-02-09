using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.Application.DBOperations;
using AutoMapper;
using FluentValidation.Results;
using FluentValidation;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.CreateBook;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.DeleteBook;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Controllers{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController (IBookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query=new GetBooksQuery(_context, _mapper);
            var result=query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //BookDetailModel result;
            GetBookDetailQuery query=new GetBookDetailQuery(_context, _mapper);
           
            query.BookId=id;
            var result=query.Handle();
            return Ok(result);
                      
            

        }
    
        //Post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command=new CreateBookCommand(_context, _mapper);
            
            command.Model=newBook;
            CreateBookCommandValidator validator=new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
              
            command.Handle();
                
            return Ok();
        }

        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel bookModel)
        {
            UpdateBookCommand command=new UpdateBookCommand(_context);
            
            command.Id=id;
            command.Model=bookModel;
            command.Handle();
            return Ok();

        }

        //Delete
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command=new DeleteBookCommand(_context);
          
            command.Id=id;
            DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
              
            return Ok();

        }
    }


}