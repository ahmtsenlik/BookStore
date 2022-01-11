using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Application.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        public readonly BookStoreDbContext _context ;
        public readonly IMapper _mapper ;
        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public List<AuthorsViewModel> Handle()
        {
            var authorsList=_context.Authors.OrderBy(x=>x.Id).ToList<Author>();
            List<AuthorsViewModel> vm= _mapper.Map<List<AuthorsViewModel>>(authorsList);
            return vm;
        }
    }
    public class AuthorsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}