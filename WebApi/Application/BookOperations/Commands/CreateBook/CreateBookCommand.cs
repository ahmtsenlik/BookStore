using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.Common;
using AutoMapper;
using WebApi.Entities;
using WebApi.Application.DBOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model{get;set;}
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext=dbContext;
            _mapper=mapper;
        }
        public void Handle()
        {
            
            var book=_dbContext.Books.SingleOrDefault(x=> x.Title==Model.Title);
            if (book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut");
                
            book= _mapper.Map<Book>(Model);//new Book();
            
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}