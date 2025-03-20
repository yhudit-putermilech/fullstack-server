using Api.Core.Models;
using Api.Core.Repositories;
using Api.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Serveice
{
    public class AlbumFileService : IAlbumFileService
    {
        private readonly IRepositoryManager _userRepository;
        public AlbumFileService(IRepositoryManager userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<AlbumFile>> GetAllAsync()
        {
            return await Task.Run(() => _userRepository.AlbumFiles.GetAll());
        }
        public async Task<AlbumFile> GetByIdAsync(int id)
        {
            return await Task.Run(() => _userRepository.AlbumFiles.GetById(id));
        }
        public async Task AddValueAsync(AlbumFile albumFile)
        {
            _userRepository.AlbumFiles.Add(albumFile);
            await _userRepository.SaveAsync();
        }
        public async Task PutValueAsync(AlbumFile albumFile)
        {
            _userRepository.AlbumFiles.Update(albumFile);
            await _userRepository.SaveAsync();
        }
        public async Task DeleteAsync(AlbumFile albumFile)
        {
            _userRepository.AlbumFiles.Delete(albumFile);
            await _userRepository.SaveAsync();
        }
    }
}
