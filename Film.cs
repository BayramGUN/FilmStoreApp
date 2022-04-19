using System.ComponentModel.DataAnnotations.Schema;

namespace FilmsApi;

public class Film 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Director { get; set; }
    public double IMDB_Point  { get; set; }
    public DateTime ReleaseDate { get; set; }
}