﻿using cs_record_shop_project.Repositories;
using cs_record_shop_project.Models;

namespace cs_record_shop_project.Services;

public class AlbumService : IAlbumService
{
    public const string NOT_FOUND_ERROR_MESSAGE = "Album not found.";
    private IAlbumRepository albumRepo;

    public AlbumService(IAlbumRepository albumRepo)
    {
        this.albumRepo = albumRepo;
    }

    public ServiceResult<List<Album>> GetAllAlbums()
    {
        return ServiceResult<List<Album>>.Success(albumRepo.GetAllAlbums());
    }

    public ServiceResult<Album> AddAlbum(AlbumDto albumDto)
    {
        return ServiceResult<Album>.Success( albumRepo.AddAlbum(albumDto));
    }

    public ServiceResult<Album?> GetAlbumById(int id)
    {
        Album? album = albumRepo.GetAlbumById(id);
        if (album == null) return ServiceResult<Album?>.Error(NOT_FOUND_ERROR_MESSAGE);
        return ServiceResult<Album?>.Success(album);
    }

    public ServiceResult<Album?> UpdateAlbum(AlbumDto albumDto)
    {
        var updatedAlbum = albumRepo.UpdateAlbum(albumDto);
        return ServiceResult<Album?>.Success(new Album(albumDto));
    }
}
