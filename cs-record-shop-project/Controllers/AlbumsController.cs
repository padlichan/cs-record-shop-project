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
        var AlbumByIdResult = albumService.GetAlbumById(id);
        if(AlbumByIdResult.IsSuccess) return Ok(AlbumByIdResult.Data);
        return NotFound(AlbumByIdResult.ErrorMessage);
    }

    [HttpPost]
    public IActionResult PostAlbum(AlbumDto albumDto)
    {
        var addedAlbum = albumService.AddAlbum(albumDto);
        return Ok(addedAlbum);
    }

    [HttpPost]
    public IActionResult PutAlbum(AlbumDto albumDto)
    {
        var updatedAlbumResult = albumService.UpdateAlbum(albumDto);
        if(updatedAlbumResult.IsSuccess) return Ok(updatedAlbumResult.Data);
        return NotFound();
    }
    
}
