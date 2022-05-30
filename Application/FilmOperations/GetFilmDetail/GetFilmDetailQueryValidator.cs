using FilmsApi.Application.FilmOperations.GetFilmDetail;
using FluentValidation;

namespace FilmsApi.Application.FilmOperations.GetFilm;
public class GetFilmDetailQueryValidator : AbstractValidator<GetFilmDetailQuery>
{
    public GetFilmDetailQueryValidator()
    {
        RuleFor(query => query.FilmId).GreaterThan(0);
    }
}