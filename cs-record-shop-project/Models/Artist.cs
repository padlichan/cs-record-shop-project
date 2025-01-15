using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cs_record_shop_project.Models;

public class Artist
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Album> Albums { get; set; }
}
