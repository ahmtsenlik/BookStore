using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.Common;
using WebApi.Application.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public int Id{get;set;}
        private readonly BookStoreDbContext _dbContext;
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public void Handle()
        {
            var book=_dbContext.Books.SingleOrDefault(x=>x.Id==Id);
            if(book is null)
            throw new InvalidOperationException("Böyle bir kitap yok");   

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}