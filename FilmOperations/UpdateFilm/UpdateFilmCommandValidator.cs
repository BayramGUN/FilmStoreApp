using FluentValidation;

namespace FilmsApi.FilmOperations.UpdateFilm;

public class UpdateFilmCommandValidator : AbstractValidator<UpdateFilmCommand>
{
    public UpdateFilmCommandValidator()
    {
        RuleFor(command => command.FilmId).GreaterThan(0);
        RuleFor(command => command.Model.IMDB_Point).GreaterThan(0);
        RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(5);
        RuleFor(command => command.Model.Content).NotEmpty().MinimumLength(5);
    }
}