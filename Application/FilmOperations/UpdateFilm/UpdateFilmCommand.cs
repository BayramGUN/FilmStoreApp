using FilmsApi.DBO;

namespace FilmsApi.Application.FilmOperations.UpdateFilm;

public class UpdateFilmCommand
{
    private readonly IFilmsDbContext _context;
    public int FilmId { get; set; }
    public UpdateFilmModel Model { get; set; }

    public UpdateFilmCommand(IFilmsDbContext context)
    {
        _context = context;
    }
    public void Handle()
    {
        var film = _context.Films.SingleOrDefault(ctx => ctx.Id == FilmId);
        if(film is null)
            throw new InvalidOperationException("Güncellenecek film bulunamadı!");
            
        film.Title = Model.Title != default ? Model.Title : film.Title;
        film.Content = Model.Content != default ? Model.Content : film.Content;
        film.IMDB_Point = Model.IMDB_Point != default ? Model.IMDB_Point : film.IMDB_Point;

        _context.SaveChanges();        
    }
}

public class UpdateFilmModel
{
    public string? Title { get; set; }
    public double IMDB_Point { get; set; }
    public string? Content { get; set; }
}