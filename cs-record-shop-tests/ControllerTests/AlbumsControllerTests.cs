using cs_record_shop_project;
using cs_record_shop_project.Controllers;
using cs_record_shop_project.Services;
using cs_record_shop_project.Models;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace cs_record_shop_tests.ControllerTests
{
    internal class AlbumsControllerTests
    {
        private AlbumsController albumsController;
        private Mock<IAlbumService> albumService;
        private AlbumDto albumDto1 = new AlbumDto("testTitle", "testDescription");
        private Album album1 = new Album("testTitle", "testDescription");

        [SetUp] 
        public void Setup()
        {
            albumService = new Mock<IAlbumService>();
            albumsController = new AlbumsController(albumService.Object);
        }

        [Test]
        public void AlbumsController_CallsCorrectServiceMethod()
        {
            albumsController.GetAllAlbums();
            albumService.Verify(m => m.GetAllAlbums(), Times.Once);
        }

        [Test]
        public void AlbumsController_ReturnsCorrectAlbums()
        {
            //Assign
            List<Album> albums = [album1];
            albumService.Setup(m => m.GetAllAlbums()).Returns(albums);

            //Act
            var ObjectResult = albumsController.GetAllAlbums() as OkObjectResult;
            var result = ObjectResult?.Value as List<Album>;

            //Assert
            result.Should().BeEquivalentTo(albums);
        }

        [Test]
        public void AlbumsController_ReturnsOkObjectResult()
        {
            //Assign
            List<Album> albums = [album1];
            albumService.Setup(m => m.GetAllAlbums()).Returns(albums);

            //Act
            var result = albumsController.GetAllAlbums() as OkObjectResult;
            

            //Assert
            result.Should().NotBeNull();
        }

        [Test]
        public void PostAlbum_CallsCorrectServiceMethod()
        {
            albumsController.PostAlbum(albumDto1);
            albumService.Verify(a => a.AddAlbum(albumDto1), Times.Once);
        }

        [Test]
        public void PostAlbum_ReturnOkObjectResultForValidAlbum()
        {
            var result = albumsController.PostAlbum(albumDto1);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public void PostAlbum_ReturnsAddedAlbum()
        {
            albumService.Setup(a => a.AddAlbum(albumDto1)).Returns(album1);
            var resultObject = albumsController.PostAlbum(albumDto1) as OkObjectResult;
            var result = resultObject?.Value;
            result.Should().Be(album1);
        }

        [Test]
        public void GetAlbumById_CallsCorrectServiceMethod()
        {
            albumsController.GetAlbumById(1);

            albumService.Verify(a => a.GetAlbumById(1), Times.Once());
        }

        [Test]
        public void GetAlbumById_ReturnsCorrectAlbumForValidId()
        {
            albumService.Setup(a => a.GetAlbumById(1)).Returns(album1);

            var resultObject = albumsController.GetAlbumById(1) as OkObjectResult;
            var result = resultObject?.Value;
            result.Should().Be(album1);
        }

        [Test]
        public void GetAlbumById_ReturnsOkObjectResultForValidId()
        {
            int validId = 1;
            albumService.Setup(a => a.GetAlbumById(validId)).Returns(album1);

            var result = albumsController.GetAlbumById(validId);
            result.Should().BeOfType<OkObjectResult>();
        }
        [Test]
        public void GetAlbumById_ReturnsNotFoundForInvalidId()
        {
            int invalidId = 5; 
            albumService.Setup(a => a.GetAlbumById(invalidId)).Returns<Album>(null!);
            var result = albumsController.GetAlbumById(invalidId);

            result.Should().BeOfType<NotFoundResult>();
        }

        
    }
}
