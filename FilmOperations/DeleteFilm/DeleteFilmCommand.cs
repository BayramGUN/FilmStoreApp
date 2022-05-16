using FilmsApi.DBO;

namespace FilmsApi.FilmOperations.DeleteFilm;

public class DeleteFilmCommand
{
    private readonly FilmsDbContext _dbContext;
    public int FilmId { get; set; }
    public DeleteFilmCommand(FilmsDbContext dbContext)
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
