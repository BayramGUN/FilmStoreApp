using FilmsApi.DBO;

namespace FilmsApi.Application.FilmOperations.DeleteFilm;

public class DeleteFilmCommand
{
    private readonly IFilmsDbContext _dbContext;
    public int FilmId { get; set; }
    public DeleteFilmCommand(IFilmsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Handle()
    {
        var film = _dbContext.Films.SingleOrDefault(ctx => ctx.Id == FilmId);
        if(film is null)
            throw new InvalidOperationException("Silinecek film bulunamadı!");

        _dbContext.Films.Remove(film);
        _dbContext.SaveChanges();
    }
}
