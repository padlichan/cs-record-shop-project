using cs_record_shop_project.Models;
using cs_record_shop_project.Repositories;
using cs_record_shop_project.Services;
using FluentAssertions;
using Moq;

namespace cs_record_shop_tests.ServiceTests;

internal class AlbumServiceTests
{
    private AlbumService albumService;
    private Mock<IAlbumRepository> albumRepo;
    private Mock<IArtistRepository> artistRepo;
    private AlbumInputDto albumInputDto;
    AlbumInputDto newAlbumInputDto;
    private Album album;
    Album updatedAlbum;
    private int validAlbumId = 1;
    private int invalidAlbumId = 5;
    private int validArtistId = 1;
    private int invalidArtistId = 5;
    private string validArtistName = "Artist";
    private string validDescription = "description";
    private Artist validArtist;

    [SetUp]
    public void Setup()
    {
        validArtist = new Artist(validArtistId, validArtistName);

        albumInputDto = new AlbumInputDto("testTitle", 2000, validArtistName, "testDescription");
        newAlbumInputDto = new AlbumInputDto("newTitle", 2000, validArtistName, validDescription);

        updatedAlbum = new Album(newAlbumInputDto, validArtistId);
        album = new Album(albumInputDto, validArtistId);
        albumRepo = new Mock<IAlbumRepository>();
        artistRepo = new Mock<IArtistRepository>();
        albumService = new AlbumService(albumRepo.Object, artistRepo.Object);
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
        List<Album> albums = [album];
        albumRepo.Setup(a => a.GetAllAlbums()).Returns(albums);
        var result = albumService.GetAllAlbums();

        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(albums);

    }

    [Test]
    public void AddAlbum_ReturnsAddedAlbum()
    {

        artistRepo.Setup(a => a.IsValidArtist(validArtistId)).Returns(true);
        artistRepo.Setup(a => a.GetArtistByName(validArtistName)).Returns(validArtist);
        albumRepo.Setup(a => a.AddAlbum(albumInputDto, validArtistId)).Returns(album);


        var result = albumService.AddAlbum(albumInputDto);

        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(album);
    }

    [Test]
    public void AddAlbum_CallsCorrectRepositoryMethod()
    {
        artistRepo.Setup(a => a.IsValidArtist(validArtistId)).Returns(true);
        artistRepo.Setup(a => a.GetArtistByName(validArtistName)).Returns(validArtist);
        var result = albumService.AddAlbum(albumInputDto);

        albumRepo.Verify(a => a.AddAlbum(albumInputDto, validArtistId), Times.Once);
    }

    //TO DO: Tests for invalid artist ID

    [Test]
    public void GetAlbumById_CallsCorrectRepositoryMethod()
    {
        albumService.GetAlbumById(validAlbumId);
        albumRepo.Verify(a => a.GetAlbumById(validAlbumId), Times.Once);
    }

    [Test]
    public void GetAlbumById_ReturnsCorrectAlbumForValidId()
    {
        albumRepo.Setup(a => a.GetAlbumById(validAlbumId)).Returns(album);

        var result = albumService.GetAlbumById(validAlbumId);

        result.IsSuccess.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(album);
    }

    [Test]
    public void GetAlbumById_ReturnsNullForInvalidId()
    {
        albumRepo.Setup(a => a.GetAlbumById(invalidAlbumId)).Returns<Album>(null!);

        var result = albumService.GetAlbumById(invalidAlbumId);

        result.IsSuccess.Should().BeFalse();
        result.Data.Should().BeNull();
    }



    [Test]
    public void UpdateAlbum_CallsCorrectRepositoryMethod()
    {
        artistRepo.Setup(a => a.IsValidArtist(validArtistId)).Returns(true);
        artistRepo.Setup(a => a.GetArtistByName(validArtistName)).Returns(validArtist);
        albumRepo.Setup(a => a.UpdateAlbum(validAlbumId, albumInputDto, validArtistId)).Returns(album);

        albumService.UpdateAlbum(validAlbumId, albumInputDto);

        albumRepo.Verify(a => a.UpdateAlbum(validAlbumId, albumInputDto, validArtistId), Times.Once);
    }

    [Test]
    public void UpdateAlbum_ReturnsSuccessForValidId()
    {
        artistRepo.Setup(a => a.IsValidArtist(validArtistId)).Returns(true);
        artistRepo.Setup(a => a.GetArtistByName(validArtistName)).Returns(validArtist);
        albumRepo.Setup(a => a.UpdateAlbum(validAlbumId, albumInputDto, validArtistId)).Returns(album);

        var result = albumService.UpdateAlbum(validAlbumId, albumInputDto);

        result.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void UpdateAlbum_ReturnsUpdatedAlbumForValidId()
    {
        artistRepo.Setup(a => a.IsValidArtist(validArtistId)).Returns(true);
        artistRepo.Setup(a => a.GetArtistByName(validArtistName)).Returns(validArtist);
        albumRepo.Setup(a => a.UpdateAlbum(validAlbumId, newAlbumInputDto, validArtistId)).Returns(updatedAlbum);

        var result = albumService.UpdateAlbum(validAlbumId, newAlbumInputDto);

        result.Data.Should().BeEquivalentTo(updatedAlbum);
    }

    [Test]
    public void UpdateAlbum_ReturnsErrorForInvalidId()
    {
        albumRepo.Setup(a => a.UpdateAlbum(invalidAlbumId, albumInputDto, validArtistId)).Returns<Album?>(null!);

        var result = albumService.UpdateAlbum(invalidAlbumId, albumInputDto);

        result.IsSuccess.Should().BeFalse();
        result.Data.Should().BeNull();
    }

    //TO DO: Tests for invalid artist ID

    [Test]
    public void DeleteAlbum_CallsCorrectRepositoryMethod()
    {
        albumRepo.Setup(a => a.DeleteAlbum(validAlbumId)).Returns(true);

        albumService.DeleteAlbum(validAlbumId);

        albumRepo.Verify(a => a.DeleteAlbum(validAlbumId), Times.Once);
    }

    [Test]
    public void DeleteAlbum_ReturnsSuccessForValidId()
    {
        albumRepo.Setup(a => a.DeleteAlbum(validAlbumId)).Returns(true);

        var result = albumService.DeleteAlbum(validAlbumId);

        result.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void DeleteAlbum_ReturnsErrorForValidId()
    {
        albumRepo.Setup(a => a.DeleteAlbum(invalidAlbumId)).Returns(false);

        var result = albumService.DeleteAlbum(validAlbumId);

        result.IsSuccess.Should().BeFalse();
    }


}
