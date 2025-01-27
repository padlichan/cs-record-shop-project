using System.ComponentModel.DataAnnotations;

namespace cs_record_shop_project.Models;

public class Artist
{
    public Artist(int id, string name)
    {
        Id = id;
        Name = name;
        Albums = [];
    }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Album> Albums { get; set; }
}
