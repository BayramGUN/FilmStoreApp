using AutoMapper;
using FilmsApi.Entities;
using FilmsApi.Application.FilmOperations.CreateFilm;
using FilmsApi.Application.FilmOperations.GetFilmDetail;
using FilmsApi.Application.FilmOperations.GetFilms;
using FilmsApi.Application.UserOperations.Commands.CreateUser;

namespace FilmsApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateFilmModel, Film>();
        CreateMap<Film, FilmDetailViewModel>().ForMember(
                                            dest => dest.Director, 
                                            opt => opt.MapFrom(src => ((DirectorEnum)src.DirectorID).ToString())
                                        );
        CreateMap<Film, FilmsViewModel>().ForMember(
                                            dest => dest.Director, 
                                            opt => opt.MapFrom(src => ((DirectorEnum)src.DirectorID).ToString())
                                        );
        CreateMap<CreateUserModel, User>();
    }
}