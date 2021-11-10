using System;
using System.Threading.Tasks;

namespace tasks.Services
{
    public interface IStorageService
    {
        Task<(bool IsSuccess, Exception exeption)> InsertTask(Entity.Task task);
    }
}