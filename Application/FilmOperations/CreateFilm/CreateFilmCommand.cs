using AutoMapper;
using FilmsApi.DBO;
using FilmsApi.Entities;
namespace FilmsApi.Application.FilmOperations.CreateFilm;

public class CreateFilmCommand
{
    public CreateFilmModel Model { get; set; }
    private readonly IFilmsDbContext _dbContext;
    private readonly IMapper _mapper;
    public CreateFilmCommand(IFilmsDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public void Handle()
    {
        var film = _dbContext.Films.SingleOrDefault(ctx => ctx.Title.ToLower() == Model.Title.ToLower());
        if(film is not null)
            throw new InvalidOperationException("Film zaten mevcut!");
        film = _mapper.Map<Film>(Model);

        _dbContext.Films.Add(film);
        _dbContext.SaveChanges();
    }


}

public class CreateFilmModel
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int DirectorID { get; set; }
    public double IMDB_Point  { get; set; }
    public DateTime ReleaseDate { get; set; }
}