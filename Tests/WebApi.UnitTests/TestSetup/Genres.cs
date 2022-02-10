

using WebApi.Application.DBOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Sicience Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                );

        }

    }
}
