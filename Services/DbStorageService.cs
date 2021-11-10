using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using tasks.Data;

namespace tasks.Services
{
    public class DbStorageService : IStorageService
    {
        private readonly TaskDbContext _context;
        private readonly ILogger<DbStorageService> _logger;

        public DbStorageService(TaskDbContext context, ILogger<DbStorageService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<(bool IsSuccess, Exception exeption)> InsertTask(Entity.Task task)
        {
            try
            {
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Task inserted in DB: {task.Id}");
                return (true, null);
            }
            catch(Exception e)
            {
                _logger.LogInformation($"Inserting task to DB failed: {e.Message}",e);
                return (false, e);
            }
        }
    }
}