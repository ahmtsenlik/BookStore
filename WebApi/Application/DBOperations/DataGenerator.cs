using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Application.DBOperations;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                    new Genre{
                        Name="Personal Growth"
                    },
                    new Genre{
                        Name="Sicience Fiction"
                    },
                    new Genre{
                        Name="Romance"
                    }               
                );
                 context.Authors.AddRange(
                    new Author{
                        Name="Ahmet Şenlik",
                        BirthDate=new DateTime(1996,06,02)
                    },
                    new Author{
                        Name="Batu Kutu",
                        BirthDate=new DateTime(1996,01,06)
                    },
                    new Author{
                        Name="Sevban Bayrak",
                        BirthDate=new DateTime(1996,05,20)
                    },
                    new Author{
                        Name="Erman Koca",
                        BirthDate=new DateTime(1995,02,11)
                    }               
                );

                context.Books.AddRange(
                    new Book
                    {
                      
                        Title="Lyean Startup",
                        GenreId=1,
                        AuthorId=1,
                        PageCount=200,
                        PublishDate=new DateTime(2001,06,20)
                    },
                    new Book
                    {
                        
                        Title="Herland",
                        GenreId=2,
                        AuthorId=3,
                        PageCount=250,
                        PublishDate=new DateTime(2011,05,21)
                    },
                    new Book
                    {
                       
                        Title="Dune",
                        GenreId=3,
                        AuthorId=2,
                        PageCount=130,
                        PublishDate=new DateTime(2003,02,14)     
                    }
                );
                
                context.SaveChanges();
            }


        }
    }
}