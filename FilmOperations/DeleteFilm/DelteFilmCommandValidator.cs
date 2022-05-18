using FluentValidation;

namespace FilmsApi.FilmOperations.DeleteFilm;

public class DeleteFilmCommandValidator : AbstractValidator<DeleteFilmCommand>
{
    public DeleteFilmCommandValidator()
    {
        RuleFor(command => command.FilmId).GreaterThan(0);
    }
}