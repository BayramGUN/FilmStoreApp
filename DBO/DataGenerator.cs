using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace FilmsApi.DBO;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var context = new FilmsDbContext(serviceProvider.GetRequiredService<DbContextOptions<FilmsDbContext>>());
        using (context)
        {
            if(context.Films.Any())
            {
                return;
            }
            context.Films.AddRange(
                new Film {
                    Title = "Once Upon a Time in Anatolia",
                    DirectorID = 0,
                    IMDB_Point = 7.9,
                    ReleaseDate = new DateTime(2011,09,23),
                    Content = "A group of men are searching for the dead body of a murder victim in the Anatolian steppes.",
                },
                new Film {
                    Title = "Once Upon a Time in America",
                    DirectorID = 1,
                    IMDB_Point = 8.4,
                    ReleaseDate = new DateTime(1984,10,01),
                    Content = "Noodles, a former gangster during the Prohibition Era, returns to New York after a self-imposed" +
                                " exile to confront his past and make amends for his mistakes.",
                },
                new Film {
                    Title = "The Godfather",
                    DirectorID = 2,
                    IMDB_Point = 9.2,
                    ReleaseDate = new DateTime(1973,10,01 ),
                    Content = "Don Vito Corleone, head of a mafia family, decides to hand over his empire to his youngest son Michael. " 
                            + "However, his decision unintentionally puts the lives of his loved ones in grave danger.",
                }
            );

            context.SaveChanges();
        }
    }
}

