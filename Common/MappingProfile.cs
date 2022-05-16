using AutoMapper;
using FilmsApi.FilmOperations.CreateFilm;
using FilmsApi.FilmOperations.GetFilmDetail;
using FilmsApi.FilmOperations.GetFilms;

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
    }
}