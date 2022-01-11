using System;
using System.Linq;
using AutoMapper;
using WebApi.Application.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId;
        private readonly BookStoreDbContext _context;
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context=context;
        }
        public void Handle()
        {
            var author=_context.Authors.SingleOrDefault(x=>x.Id==AuthorId);
            var book=_context.Books.SingleOrDefault(x=>x.AuthorId==AuthorId);
            if(author is null)
            {
                throw new InvalidOperationException("Böyle bir yazar bulunamadı.");
            }
            if(book is not null)
            {
                  throw new InvalidOperationException("Bu yazarın bir kitabı mevcut.");
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
    
}