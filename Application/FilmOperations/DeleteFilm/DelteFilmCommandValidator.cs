using FluentValidation;

namespace FilmsApi.Application.FilmOperations.DeleteFilm;

public class DeleteFilmCommandValidator : AbstractValidator<DeleteFilmCommand>
{
    public DeleteFilmCommandValidator()
    {
        RuleFor(command => command.FilmId).GreaterThan(0);
    }
}