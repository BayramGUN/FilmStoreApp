using FilmsApi.DBO;
using Microsoft.AspNetCore.Mvc;

namespace FilmsApi.Controllers;

[ApiController]
[Route("[controller]s")]

public class FilmController : ControllerBase
{
    private readonly FilmsDbContext _context;
    public FilmController(FilmsDbContext context)
    {
        _context = context;
    }

    //Get Method
    [HttpGet]
    public List<Film> GetFilms()
    {
        var filmList = _context.Films.OrderBy(ctx => ctx.Id).ToList<Film>();
        return filmList;
    }
    //Get method with id
    [HttpGet("{id}")]
    public Film GetFilm(int id)
    {
        var film = _context.Films.Where(film => film.Id == id).SingleOrDefault();

        return film;
    }
    /* [HttpGet]
    public Film Get([FromQuery] string id)
    {
        var film = FilmList.Where(film => film.Id == Convert.ToInt32(id)).SingleOrDefault();

        return film;
    } */
    //Post method
    [HttpPost]
    public IActionResult AddFilm([FromBody] Film newFilm)
    {
        var film = _context.Films.SingleOrDefault(ctx => ctx.Title == newFilm.Title);
        if(film is not null)
            return BadRequest();
        _context.Films.Add(newFilm);
        _context.SaveChanges();
        return Ok();   
    }
    //Put method
    [HttpPut("{id}")]
    public IActionResult UpdateFilm(int id, [FromBody] Film updatedFilm)
    {
        var film = _context.Films.SingleOrDefault(ctx => ctx.Id == updatedFilm.Id);
        if(film is null)
            return BadRequest();
        film.Title = updatedFilm.Title != default ? updatedFilm.Title : film.Title;
        film.Content = updatedFilm.Content != default ? updatedFilm.Content : film.Content;
        film.Director = updatedFilm.Director != default ? updatedFilm.Director : film.Director;
        film.ReleaseDate = updatedFilm.ReleaseDate != default ? updatedFilm.ReleaseDate : film.ReleaseDate;
        film.IMDB_Point = updatedFilm.IMDB_Point != default ? updatedFilm.IMDB_Point : film.IMDB_Point;

        _context.SaveChanges();
        
        return Ok();
    }
    //Delete method
    [HttpDelete("{id}")]
    public IActionResult DeleteFilm(int id)
    {
        var film = _context.Films.SingleOrDefault(ctx => ctx.Id == id);
        if(film is null)
            return BadRequest();
        _context.Films.Remove(film);
        _context.SaveChanges();
        return Ok();
    }    
} 