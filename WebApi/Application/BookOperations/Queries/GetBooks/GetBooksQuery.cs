using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.Common;
using AutoMapper;
using WebApi.Entities;
using WebApi.Application.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        public BooksViewModel Model{get;set;}
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList=_dbContext.Books.Include(x=>x.Author).Include(x=>x.Genre).OrderBy(x=>x.Id).ToList<Book>();
            List<BooksViewModel> vm= _mapper.Map<List<BooksViewModel>>(bookList);
          
            return vm;
        }
    }
    
    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Author{get;set;} 
    }
}