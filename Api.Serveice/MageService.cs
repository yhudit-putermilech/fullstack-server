using Api.Core.Models;
using Api.Core.Repositories;
using Api.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Api.Serveice
{
    public class MageService:IImageService
    {
        public readonly  IRepositoryManager _repositoryManager;

        public MageService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<Images>> GetAllAsync()
        {
            return await Task.Run(() => _repositoryManager.Images.GetAll());
        }
        public async Task <Images> GetByIdAsync(int id)
        {
            return await Task.Run(() => _repositoryManager.Images.GetById(id));
        }
        public async Task AddValueAsync(Images image)
        {
            _repositoryManager.Images.Add(image);
            await _repositoryManager.SaveAsync();
        }
        public async Task PutValueAsync(Images image)
        {
            _repositoryManager.Images.Update(image);
            await _repositoryManager.SaveAsync();
        }
        public async Task DeleteAsync(Images image)
        {
            _repositoryManager.Images.Delete(image);
            await _repositoryManager.SaveAsync();
        }
    }
}
