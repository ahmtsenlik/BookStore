using System;
using System.Linq;
using AutoMapper;
using WebApi.Application.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int Id;
        private readonly IBookStoreDbContext _context;
        public UpdateAuthorModel Model;
        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _context=context;
        }
        public void Handle()
        {
            var author=_context.Authors.SingleOrDefault(x=>x.Id==Id);
            if(author is null)
            {
                throw new InvalidOperationException("Böyle bir yazar bulunamadı.");
            }
            if(_context.Authors.Any(x=>x.Name.ToLower()==Model.Name.ToLower()&&x.Id!=Id))
            {
                throw new InvalidOperationException("Aynı isimli bir kitap türü zaten mevcut");
            }
            author.Name=string.IsNullOrEmpty(Model.Name.Trim())?author.Name:Model.Name;
            author.BirthDate=Model.BirthDate!=default ? Model.BirthDate:author.BirthDate;
            _context.SaveChanges();

        }
        
    }
    public class UpdateAuthorModel
    {
        
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}