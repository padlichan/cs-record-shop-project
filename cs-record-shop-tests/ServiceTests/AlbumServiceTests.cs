using cs_record_shop_project.Repositories;
using Moq;
using cs_record_shop_project.Services;
using cs_record_shop_project.Models;
using FluentAssertions;

namespace cs_record_shop_tests.ServiceTests
{
    internal class AlbumServiceTests
    {
        private AlbumService albumService;
        private Mock<IAlbumRepository> albumRepo;

        [SetUp]
        public void Setup()
        {
            albumRepo = new Mock<IAlbumRepository>();
            albumService = new AlbumService(albumRepo.Object);
        }

        [Test]
        public void GetAllAlbums_CallsCorrectRepositoryMethodOnce()
        {
            albumService.GetAllAlbums();
            albumRepo.Verify(r => r.GetAllAlbums(), Times.Once);
        }

        [Test]
        public void GetAllAlbums_ReturnsCorrectAlbums()
        {
            List<Album> albums = [new Album("testTitle", "testDescription")];
            albumRepo.Setup(a => a.GetAllAlbums()).Returns(albums);
            var result = albumService.GetAllAlbums();
            result.Should().BeEquivalentTo(albums);

        }
    }
}
