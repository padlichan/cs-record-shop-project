using cs_record_shop_project;
using cs_record_shop_project.Controllers;
using cs_record_shop_project.Services;
using cs_record_shop_project.Models;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace cs_record_shop_tests.ControllerTests;

internal class AlbumsControllerTests
{
    private AlbumsController albumsController;
    private Mock<IAlbumService> albumService;
    private AlbumInputDto albumInputDto1 = new AlbumInputDto("testTitle", "testDescription", 2000, 1);
    AlbumInputDto newAlbumInputDto = new AlbumInputDto("newTitle", "newDescription", 2000, 1);
    private Album album1;
    Album updatedAlbum;
    private int validId = 1;
    private int invalidId = 5;

    [SetUp] 
    public void Setup()
    {
        updatedAlbum = new Album(newAlbumInputDto);
        album1 = new Album(albumInputDto1);
        albumService = new Mock<IAlbumService>();
        albumsController = new AlbumsController(albumService.Object);
    }

    [Test]
    public void GetAllAlbums_CallsCorrectServiceMethod()
    {
        List<Album> albums = [album1];
        albumService.Setup(a => a.GetAllAlbums()).Returns(ServiceResult<List<Album>>.Success(albums));
        albumsController.GetAllAlbums();
        albumService.Verify(m => m.GetAllAlbums(), Times.Once);
    }

    [Test]
    public void GetAllAlbums_ReturnsCorrectAlbums()
    {
        //Assign
        List<Album> albums = [album1];
        var expectedResult = albums.Select(a => new AlbumOutputDto(a)).ToList();
        albumService.Setup(m => m.GetAllAlbums()).Returns(ServiceResult<List<Album>>.Success(albums));

        //Act
        var ObjectResult = albumsController.GetAllAlbums();
        var result = ((OkObjectResult)ObjectResult)?.Value as List<AlbumOutputDto>;

        //Assert
        ObjectResult.Should().BeOfType<OkObjectResult>();
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void GetAllAlbums_ReturnsOkObjectResult()
    {
        //Assign
        List<Album> albums = [album1];
        albumService.Setup(m => m.GetAllAlbums()).Returns(ServiceResult<List<Album>>.Success(albums));

        //Act
        var result = albumsController.GetAllAlbums() as OkObjectResult;
        

        //Assert
        result.Should().NotBeNull();
    }

    [Test]
    public void PostAlbum_CallsCorrectServiceMethod()
    {
        albumService.Setup(a => a.AddAlbum(albumInputDto1)).Returns(ServiceResult<Album>.Success(album1));
        albumsController.PostAlbum(albumInputDto1);
        albumService.Verify(a => a.AddAlbum(albumInputDto1), Times.Once);
    }

    [Test]
    public void PostAlbum_ReturnOkObjectResultForValidAlbum()
    {
        albumService.Setup(a => a.AddAlbum(albumInputDto1)).Returns(ServiceResult<Album>.Success(album1));
        var result = albumsController.PostAlbum(albumInputDto1);
        result.Should().BeOfType<OkObjectResult>();
    }

    [Test]
    public void PostAlbum_ReturnsAddedAlbum()
    {
        var expectedResult = new AlbumOutputDto(album1); 
        albumService.Setup(a => a.AddAlbum(albumInputDto1)).Returns(ServiceResult<Album>.Success(album1));
        var resultObject = albumsController.PostAlbum(albumInputDto1) as OkObjectResult;
        var result = resultObject?.Value;
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void GetAlbumById_CallsCorrectServiceMethod()
    {
        albumService.Setup(a => a.GetAlbumById(validId)).Returns(ServiceResult<Album>.Success(album1));
        albumsController.GetAlbumById(validId);

        albumService.Verify(a => a.GetAlbumById(validId), Times.Once());
    }

    [Test]
    public void GetAlbumById_ReturnsCorrectAlbumForValidId()
    {
        albumService.Setup(a => a.GetAlbumById(1)).Returns(ServiceResult<Album>.Success(album1));
        var expectedResult = new AlbumOutputDto(album1);

        var resultObject = albumsController.GetAlbumById(1) as OkObjectResult;
        var result = resultObject?.Value;
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void GetAlbumById_ReturnsOkObjectResultForValidId()
    {
        albumService.Setup(a => a.GetAlbumById(validId)).Returns(ServiceResult<Album>.Success(album1));

        var result = albumsController.GetAlbumById(validId);
        result.Should().BeOfType<OkObjectResult>();
    }
    [Test]
    public void GetAlbumById_ReturnsNotFoundForInvalidId()
    {
        var serviceReturnValue = ServiceResult<Album>.Error(AlbumService.NOT_FOUND_ERROR_MESSAGE);
        albumService.Setup(a => a.GetAlbumById(invalidId)).Returns(serviceReturnValue);
        var result = albumsController.GetAlbumById(invalidId);

        result.Should().BeOfType<NotFoundObjectResult>();
    }

    [Test]

    public void UpdateAlbum_CallsCorrectServiceMethod()
    {
        albumService.Setup(a => a.UpdateAlbum(validId, newAlbumInputDto))
                                 .Returns(ServiceResult<Album>.Success(updatedAlbum));


        albumsController.PutAlbum(validId, newAlbumInputDto);

        albumService.Verify(a => a.UpdateAlbum(validId, newAlbumInputDto), Times.Once);
    }
    [Test]
    public void UpdateAlbum_ReturnsUpdatedAlbumForValidId()
    {
        var expectedResult = new AlbumOutputDto(updatedAlbum);
        albumService.Setup(a => a.UpdateAlbum(validId, newAlbumInputDto))
                    .Returns(ServiceResult<Album>.Success(updatedAlbum));


        var result = albumsController.PutAlbum(validId, newAlbumInputDto) as OkObjectResult;
        result.Should().NotBeNull();
        result.Value.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void UpdateAlbum_ReturnsOkObjectResultForValidId()
    {
        albumService.Setup(a => a.UpdateAlbum(validId, newAlbumInputDto))
                    .Returns(ServiceResult<Album>.Success(updatedAlbum));

        var result = albumsController.PutAlbum(validId, newAlbumInputDto);

        result.Should().BeOfType<OkObjectResult>();
    }
    
    [Test]
    public void UpdateAlbum_ReturnsNotFoundForInvalidId()
    {
        albumService.Setup(a => a.UpdateAlbum(invalidId, newAlbumInputDto))
                    .Returns(ServiceResult<Album>.Error(AlbumService.NOT_FOUND_ERROR_MESSAGE));

        var result = albumsController.PutAlbum(invalidId, newAlbumInputDto);

        result.Should().BeOfType<NotFoundObjectResult>();
    }

    [Test]
    public void DeleteAlbum_CallsCorrectServiceMethod()
    {
        albumService.Setup(a => a.DeleteAlbum(validId))
                    .Returns(ServiceResult<Album>.SuccessNoData());

        var result = albumsController.DeleteAlbum(validId);

        albumService.Verify(a => a.DeleteAlbum(validId), Times.Once);
    }

    [Test]
    public void DeleteAlbum_ReturnsNoContentForValidId()
    {
        albumService.Setup(a => a.DeleteAlbum(validId))
                    .Returns(ServiceResult<Album>.SuccessNoData());

        var result = albumsController.DeleteAlbum(validId);

        result.Should().BeOfType<NoContentResult>();
    }

    [Test]
    public void DeleteAlbum_ReturnsNotFoundForInvalidId()
    {
        albumService.Setup(a => a.DeleteAlbum(invalidId))
                    .Returns(ServiceResult<Album>.Error(AlbumService.NOT_FOUND_ERROR_MESSAGE));

        var result = albumsController.DeleteAlbum(invalidId);

        result.Should().BeOfType<NotFoundObjectResult>();
    }
}
