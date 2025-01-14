using cs_record_shop_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace cs_record_shop_project.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumsController : ControllerBase
{
    private IAlbumService albumService;

    public AlbumsController(IAlbumService albumService)
    {
        this.albumService = albumService;
    }

    [HttpGet]
    public IActionResult GetAllAlbums()
    {
        var albums = albumService.GetAllAlbums();
        return Ok(albums);

    }
}
