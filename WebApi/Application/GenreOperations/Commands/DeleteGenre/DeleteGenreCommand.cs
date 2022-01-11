using System;
using System.Linq;
using WebApi.Application.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId {get;set;}
        private readonly BookStoreDbContext _context;
        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre=_context.Genres.SingleOrDefault(x=>x.Id==GenreId);
            var book=_context.Books.SingleOrDefault(x=>x.GenreId==GenreId);
            if(genre is null)
            {
                throw new InvalidOperationException("Kitap Türü Bulunamadı!");
            }
            if(book is not null)
            {
                throw new InvalidOperationException("Bu Kategoriye ait bir kitap var!");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}