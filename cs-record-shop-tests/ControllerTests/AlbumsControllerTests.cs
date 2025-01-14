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
        private Mock<IAlbumService> albumServiceMock;
        private Album album1 = new Album("testTitle", "testDescription");

        [SetUp]
        public void Setup()
        {
            albumServiceMock = new Mock<IAlbumService>();
            albumsController = new AlbumsController(albumServiceMock.Object);
        }

        [Test]
        public void AlbumsController_CallsCorrectServiceMethod()
        {
            albumsController.GetAllAlbums();
            albumServiceMock.Verify(m => m.GetAllAlbums(), Times.Once);
        }

        [Test]
        public void AlbumsController_ReturnsCorrectAlbums()
        {
            //Assign
            List<Album> albums = [album1];
            albumServiceMock.Setup(m => m.GetAllAlbums()).Returns(albums);

            //Act
            var ObjectResult = albumsController.GetAllAlbums() as OkObjectResult;
            var result = ObjectResult?.Value as List<Album>;

            //Assert
            result.Should().BeEquivalentTo(albums);
        }

        [Test]
        public void AlbumsController_IsOkObjectResult()
        {
            //Assign
            List<Album> albums = [album1];
            albumServiceMock.Setup(m => m.GetAllAlbums()).Returns(albums);

            //Act
            var result = albumsController.GetAllAlbums() as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
        }
    }
}
