using cs_record_shop_project.Models;
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
        var albumsResult = albumService.GetAllAlbums();
        if (albumsResult.IsSuccess && albumsResult.Data != null)
        {
            var output = albumsResult.Data!.Select(a => new AlbumOutputDto(a)).ToList();
            return Ok(output);
        }
        return BadRequest();
    }

    [HttpGet]
    [Route("{id}")]

    public IActionResult GetAlbumById(int id)
    {
        var AlbumByIdResult = albumService.GetAlbumById(id);
        if (AlbumByIdResult.IsSuccess && AlbumByIdResult.Data != null)
        {
            var output = new AlbumOutputDto(AlbumByIdResult.Data);
            return Ok(output);
        }
        return NotFound(AlbumByIdResult.ErrorMessage);
    }

    [HttpPost]
    public IActionResult PostAlbum(AlbumInputDto albumDto)
    {
        var addedAlbumResult = albumService.AddAlbum(albumDto);
        if (addedAlbumResult.IsSuccess && addedAlbumResult.Data != null)
        {
            AlbumOutputDto output = new AlbumOutputDto(addedAlbumResult.Data);
            return Ok(output);
        }
        return BadRequest(addedAlbumResult.ErrorMessage);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult PutAlbum(int id, AlbumInputDto albumDto)
    {
        var updatedAlbumResult = albumService.UpdateAlbum(id, albumDto);
        if (updatedAlbumResult.IsSuccess && updatedAlbumResult.Data != null)
        {
            var output = new AlbumOutputDto(updatedAlbumResult.Data);
            return Ok(output);
        }
        return NotFound(updatedAlbumResult.ErrorMessage);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteAlbum(int id)
    {
        ServiceResult<Album> deletedAlbumResult = albumService.DeleteAlbum(id);
        if (deletedAlbumResult.IsSuccess) return NoContent();
        else return NotFound(deletedAlbumResult.ErrorMessage);
    }
}
