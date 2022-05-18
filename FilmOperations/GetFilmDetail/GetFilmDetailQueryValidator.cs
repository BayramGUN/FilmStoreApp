using FilmsApi.FilmOperations.GetFilmDetail;
using FluentValidation;

namespace FilmsApi.FilmOperations.GetFilm;
public class GetFilmDetailQueryValidator : AbstractValidator<GetFilmDetailQuery>
{
    public GetFilmDetailQueryValidator()
    {
        RuleFor(query => query.FilmId).GreaterThan(0);
    }
}