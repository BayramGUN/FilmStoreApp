using FluentValidation;

namespace FilmsApi.FilmOperations.CreateFilm;

public class CreateFilmCommandValidator : AbstractValidator<CreateFilmCommand>
{
    public CreateFilmCommandValidator()
    {
        RuleFor(command => command.Model.DirectorID).IsInEnum();
        RuleFor(command => command.Model.IMDB_Point).GreaterThan(0);
        RuleFor(command => command.Model.ReleaseDate).NotEmpty().LessThan(DateTime.Now.Date);
        RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(5);
        RuleFor(command => command.Model.Content).NotEmpty().MinimumLength(5);
    }
}