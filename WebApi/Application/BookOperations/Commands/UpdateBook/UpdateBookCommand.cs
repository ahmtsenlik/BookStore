using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.Common;
using WebApi.Application.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public int Id{get;set;}
        public UpdateBookModel Model{get;set;}
        private readonly IBookStoreDbContext _dbContext;
        public UpdateBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public void Handle(){
            var book=_dbContext.Books.SingleOrDefault(x=>x.Id==Id);
            if(book is null)
                throw new InvalidOperationException("Böyle bir kitap yok");

            book.GenreId=Model.GenreId!=default ? Model.GenreId:book.GenreId; 
            book.PageCount=Model.PageCount!=default ? Model.PageCount:book.PageCount;
            book.PublishDate=Model.PublishDate!=default ? Model.PublishDate:book.PublishDate;
            book.Title=Model.Title!= default? Model.Title:book.Title;
            _dbContext.SaveChanges();
        }
        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}