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
    public class LogService:ILogService
    {
        public readonly IRepositoryManager _repositoryManager;

        public LogService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<Log>> GetAllAsync()
        {
            return await Task.Run(() => _repositoryManager.Logs.GetAll());
        }
        public async Task<Log> GetByIdAsync(int id)
        {
            return await Task.Run(() => _repositoryManager.Logs.GetById(id));
        }
        public async Task AddValueAsync(Log log)
        {
            _repositoryManager.Logs.Add(log);
            await _repositoryManager.SaveAsync();
        }
        public async Task PutValueAsync(Log log)
        {
            _repositoryManager.Logs.Update(log);
            await _repositoryManager.SaveAsync();
        }
        public async Task DeleteAsync(Log log)
        {
            _repositoryManager.Logs.Delete(log);
            await _repositoryManager.SaveAsync();
        }
    }
}
