using Api.Core.Models;
using Api.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repositories
{
    public class RepositoryManager
    {
        private readonly DataContext _context;
        private IAlbumRepository _albumRepository;

        public IRepository<User> Users { get; }
        public IRepository<Log> Logs { get; }
        public IRepository<Images> Images { get; }
        public IRepository<Album> Albums { get; }
        public IRepository<AlbumFile> AlbumFiles { get; }

        public IUserrepository User { get; }
        public ILogRepository Log { get; }
        public IImageRepository Image { get; }
        public IAlbumRepository Album { get; }
        public IAlbumFileRepository AlbumFile { get; }

        public RepositoryManager(
         IRepository<User> users, IRepository<Log> logs, IRepository<Images> images,
         IRepository<Album> albums, IRepository<AlbumFile> albumFiles,
         IUserrepository user, ILogRepository log, IImageRepository image,
         IAlbumRepository album, IAlbumFileRepository albumFile)
        {
            Users = users;
            Logs = logs;
            Images = images;
            Albums = albums;
            AlbumFiles = albumFiles;

            User = user;
            Log = log;
            Image = image;
            Album = album;
            AlbumFile = albumFile;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}