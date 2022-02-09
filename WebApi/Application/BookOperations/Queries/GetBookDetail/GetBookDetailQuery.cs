using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.Common;
using AutoMapper;
using WebApi.Application.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
    
        public int BookId{get;set;}
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookDetailModel Handle()
        {
            
            var book=_dbContext.Books.Include(x=>x.Author).Include(x=>x.Genre).Where(book=>book.Id==BookId).SingleOrDefault();
            
            if (book is null)
                throw new InvalidOperationException("Böyle bir id yok");

            BookDetailModel vm=  _mapper.Map<BookDetailModel>(book);//new BookDetailModel();
            
            return vm;
        }
        public class BookDetailModel
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Author{get;set;}
        }

    }
}