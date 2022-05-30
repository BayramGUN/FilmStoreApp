using FilmsApi.DBO;
using FilmsApi.Application.FilmOperations.GetFilms;
using FilmsApi.Application.FilmOperations.CreateFilm;
using FilmsApi.Application.FilmOperations.GetFilmDetail;
using FilmsApi.Application.FilmOperations.UpdateFilm;
using FilmsApi.Application.FilmOperations.DeleteFilm;
using FilmsApi.Application.FilmOperations.GetFilm;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace FilmsApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]s")]

public class FilmController : ControllerBase
{
    private readonly IFilmsDbContext _context;
    private readonly IMapper _mapper;
    public FilmController(IFilmsDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //Get Method
    [HttpGet]
    public IActionResult GetFilms()
    {
       GetFilmsQuery query = new GetFilmsQuery(_context, _mapper);
       var result = query.Handle();
       return Ok(result);
    }
    //Get method with id
    [HttpGet("{id}")]
    public IActionResult GetFilm(int id)
    {
        FilmDetailViewModel result;
        try
        {
            GetFilmDetailQuery query = new GetFilmDetailQuery(_context, _mapper);
            query.FilmId = id;
            GetFilmDetailQueryValidator validator = new GetFilmDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        

        return Ok(result);
    }
    /* [HttpGet]
    public Film Get([FromQuery] string id)
    {
        var film = FilmList.Where(film => film.Id == Convert.ToInt32(id)).SingleOrDefault();

        return film;
    } */
    //Post method
    [HttpPost]
    public IActionResult AddFilm([FromBody] CreateFilmModel newFilm)
    {
        try
        {
            CreateFilmCommand command = new CreateFilmCommand(_context, _mapper);
            command.Model = newFilm;
            CreateFilmCommandValidator validator = new CreateFilmCommandValidator();
            validator.ValidateAndThrow(command); 
                
            command.Handle();
               
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();   
    }
    
    //Put method
    [HttpPut("{id}")]
    public IActionResult UpdateFilm(int id, [FromBody] UpdateFilmModel updatedFilm)
    {
        try
        {
            UpdateFilmCommand command = new UpdateFilmCommand(_context);
            command.FilmId = id;
            command.Model = updatedFilm;
            UpdateFilmCommandValidator validator = new UpdateFilmCommandValidator();
            validator.ValidateAndThrow(command); 
            command.Handle();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }
    //Delete method
    [HttpDelete("{id}")]
    public IActionResult DeleteFilm(int id)
    {
        try
        {

            DeleteFilmCommand command = new DeleteFilmCommand(_context);
            command.FilmId = id;
            DeleteFilmCommandValidator validator = new DeleteFilmCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }    
} 