using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command=>command.Model.Name).NotEmpty();
            RuleFor(command=>command.Model.BirthDate).NotEmpty().LessThan(System.DateTime.Now.Date);
        }
    }
}