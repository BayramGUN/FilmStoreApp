using AutoMapper;
using FilmsApi.Common;
using FilmsApi.DBO;

namespace FilmsApi.Application.FilmOperations.GetFilmDetail;

public class GetFilmDetailQuery
{
    private readonly IFilmsDbContext _dbContext;
    private readonly IMapper _mapper;
    public int FilmId { get; set;}
    public GetFilmDetailQuery(IFilmsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public FilmDetailViewModel Handle()
    {
        var film = _dbContext.Films.Where(film => film.Id == FilmId).SingleOrDefault();
        if(film is null)
            throw new InvalidOperationException("Film bulunamadı!");
            
        FilmDetailViewModel viewModel = _mapper.Map<FilmDetailViewModel>(film);

        return viewModel;
    }
}
public class FilmDetailViewModel
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Director { get; set; }
    public double? IMDB_Point  { get; set; }
    public string? ReleaseDate { get; set; }
}