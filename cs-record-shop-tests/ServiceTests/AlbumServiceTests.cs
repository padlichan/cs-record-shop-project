using cs_record_shop_project.Repositories;
using Moq;
using cs_record_shop_project.Services;
using cs_record_shop_project.Models;
using FluentAssertions;

namespace cs_record_shop_tests.ServiceTests;

internal class AlbumServiceTests
{
    private AlbumService albumService;
    private Mock<IAlbumRepository> albumRepo;
    private Album album1 = new Album("testTitle", "testDescription");
    private AlbumDto albumDto1 = new AlbumDto("testTitle", "testDescription");
    private int validId = 1;
    private int invalidId = 5;

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

        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(albums);

    }

    [Test]
    public void AddAlbum_ReturnsAddedAlbum()
    {
        var albumDto = new AlbumDto("testTitle", "testDescription");
        albumRepo.Setup(a => a.AddAlbum(albumDto)).Returns(album1);

        var result = albumService.AddAlbum(albumDto);

        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(album1);
    }

    [Test]
    public void AddAlbum_CallsCorrectRepositoryMethod()
    {
        var albumDto = new AlbumDto("testTitle", "testDescription");
        var result = albumService.AddAlbum(albumDto);

        albumRepo.Verify(a => a.AddAlbum(albumDto), Times.Once);
    }

    [Test]
    public void GetAlbumById_CallsCorrectRepositoryMethod()
    {
        albumService.GetAlbumById(validId);
        albumRepo.Verify(a => a.GetAlbumById(validId), Times.Once);
    }

    [Test]
    public void GetAlbumById_ReturnsCorrectAlbumForValidId()
    {
        albumRepo.Setup(a => a.GetAlbumById(validId)).Returns(album1);

        var result = albumService.GetAlbumById(validId);

        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(album1);
    }

    [Test]
    public void GetAlbumById_ReturnsNullForInvalidId()
    {
        albumRepo.Setup(a => a.GetAlbumById(invalidId)).Returns<Album>(null!);

        var result = albumService.GetAlbumById(invalidId);

        result.IsSuccess.Should().BeFalse();
        result.Data.Should().BeNull();
    }



    [Test]
    public void UpdateAlbum_CallsCorrectRepositoryMethod()
    {
        albumRepo.Setup(a => a.UpdateAlbum(validId, albumDto1)).Returns(album1);

        albumService.UpdateAlbum(validId, albumDto1);

        albumRepo.Verify(a => a.UpdateAlbum(validId, albumDto1), Times.Once);
    }

    [Test]
    public void UpdateAlbum_ReturnsSuccessForValidId()
    {
        albumRepo.Setup(a => a.UpdateAlbum(validId, albumDto1)).Returns(album1);

        var result = albumService.UpdateAlbum(validId, albumDto1);

        result.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void UpdateAlbum_ReturnsUpdatedAlbumForValidId()
    {
        Album updatedAlbum = new Album("updatedTitle", "updatedDescription");
        albumRepo.Setup(a => a.UpdateAlbum(validId, albumDto1)).Returns(updatedAlbum);

        var result = albumService.UpdateAlbum(validId, albumDto1);

        result.Data.Should().BeEquivalentTo(updatedAlbum);
    }

    [Test]
    public void UpdateAlbum_ReturnsErrorForInvalidId()
    {
        albumRepo.Setup(a => a.UpdateAlbum(invalidId, albumDto1)).Returns<Album?>(null!);

        var result = albumService.UpdateAlbum(invalidId, albumDto1);

        result.IsSuccess.Should().BeFalse();
        result.Data.Should().BeNull();
    }

    [Test]
    public void DeleteAlbum_CallsCorrectRepositoryMethod()
    {
        albumRepo.Setup(a => a.DeleteAlbum(validId)).Returns(true);

        albumService.DeleteAlbum(validId);

        albumRepo.Verify(a => a.DeleteAlbum(validId), Times.Once);
    }

    [Test]
    public void DeleteAlbum_ReturnsSuccessForValidId()
    {
        albumRepo.Setup(a => a.DeleteAlbum(validId)).Returns(true);

        var result = albumService.DeleteAlbum(validId);

        result.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void DeleteAlbum_ReturnsErrorForValidId()
    {
        albumRepo.Setup(a => a.DeleteAlbum(invalidId)).Returns(false);

        var result = albumService.DeleteAlbum(validId);

        result.IsSuccess.Should().BeFalse();
    }
}
