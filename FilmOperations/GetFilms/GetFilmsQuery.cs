using FilmsApi.DBO;
using FilmsApi.Common;
using AutoMapper;

namespace FilmsApi.FilmOperations.GetFilms;

public class GetFilmsQuery
{
    private readonly FilmsDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetFilmsQuery(FilmsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public List<FilmsViewModel> Handle()
    {
        var filmList = _dbContext.Films.OrderBy(ctx => ctx.Id).ToList<Film>();
        List<FilmsViewModel> viewModel = _mapper.Map<List<FilmsViewModel>>(filmList);
        
        return viewModel;
    }
}
public class FilmsViewModel
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Director { get; set; }
    public double? IMDB_Point  { get; set; }
    public string? ReleaseDate { get; set; }
}
