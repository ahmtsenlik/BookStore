using AutoMapper;
using WebApi.BookOperations.GetBooks;
using WebApi.Entities;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();


            CreateMap<Book,BookDetailModel>()
            .ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.Author,opt=>opt.MapFrom(src=>src.Author.Name));

            CreateMap<Book,BooksViewModel>()
            .ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.Author,opt=>opt.MapFrom(src=>src.Author.Name));


            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<Author,AuthorsViewModel>();
            CreateMap<Author,AuthorDetailViewModel>();
            CreateMap<CreateAuthorModel,Author>();
            

        }
    }
}