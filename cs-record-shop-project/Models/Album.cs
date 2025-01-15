using System.ComponentModel.DataAnnotations;

namespace cs_record_shop_project.Models;

public class Album
{
    public Album(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public Album(AlbumDto albumDto)
    {
        Title = albumDto.Title;
        Description = albumDto.Description;
    }
    [Key]
    public int Id { get; init; }
    public string Title { get; set; }
    public string Description { get; set; }
}
