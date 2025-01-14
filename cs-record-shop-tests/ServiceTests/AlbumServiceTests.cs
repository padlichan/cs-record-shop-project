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
        private Album album1 = new Album("testTitle", "testDescription");

        [SetUp]
        public void Setup()
        {
            albumRepo = new Mock<IAlbumRepository>();
            albumService = new AlbumService(albumRepo.Object);
        }

        [Test]
        public void GetAllAlbums_CallsCorrectRepositoryMethod()
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

        [Test]
        public void AddAlbum_ReturnsAddedAlbum()
        {
            var albumDto = new AlbumDto("testTitle", "testDescription");
            albumRepo.Setup(a => a.AddAlbum(albumDto)).Returns(album1);

            var result = albumService.AddAlbum(albumDto);

            result.Should().BeEquivalentTo(album1);
        }

        [Test]
        public void AddAlbum_CallsCorrectRepositoryMethod()
        {
            var albumDto = new AlbumDto("testTitle", "testDescription");
            var result = albumService.AddAlbum(albumDto);

            albumRepo.Verify(a => a.AddAlbum(albumDto), Times.Once);
        }

        [Test]
        public void GetAlbumById_ReturnsCorrectAlbumForValidId()
        {
            int validId = 1;
            albumRepo.Setup(a => a.GetAlbumById(validId)).Returns(album1);

            var result = albumService.GetAlbumById(validId);

            result.Should().BeEquivalentTo(album1);
        }

        [Test]
        public void GetAlbumById_ReturnsNullForInvalidId()
        {
            int invalidId = 5;
            albumRepo.Setup(a => a.GetAlbumById(invalidId)).Returns<Album>(null!);

            var result = albumService.GetAlbumById(invalidId);

            result.Should().BeNull();
        }

        [Test]
        public void GetAlbumById_CallsCorrectRepositoryMethod()
        {
            albumService.GetAlbumById(1);
            albumRepo.Verify(a => a.GetAlbumById(1), Times.Once);
        }
    }
}
