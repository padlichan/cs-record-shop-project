using cs_record_shop_project.Services;
using cs_record_shop_project.Models;
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

    [HttpGet]
    [Route("{id}")]

    public IActionResult GetAlbumById(int id)
    {
        Album? albumById = albumService.GetAlbumById(id);
        if(albumById == null) return NotFound();
        return Ok(albumById);
    }

    [HttpPost]
    public IActionResult PostAlbum(AlbumDto albumDto)
    {
        var addedAlbum = albumService.AddAlbum(albumDto);
        return Ok(addedAlbum);
    }
    
}
