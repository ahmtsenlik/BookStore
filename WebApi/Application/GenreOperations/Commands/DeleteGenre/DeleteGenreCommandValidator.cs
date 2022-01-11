using FluentValidation;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command=>command.GenreId).GreaterThan(0);
        }
    }
}