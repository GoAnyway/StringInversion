using System;
using System.Text.Json;
using System.Threading.Tasks;
using Database;
using Database.Entities;
using Models;

namespace DataManager.LogRepositories
{
    public class DbLogRepository : ILogRepository
    {
        private readonly StringInversionDbContext _context;

        public DbLogRepository(StringInversionDbContext context)
        {
            _context = context;
        }

        public async Task AddLog(string infoJson)
        {
            var deserializedInfo = JsonSerializer.Deserialize<InformationModel>(infoJson);
            var log = new Log
            {
                Time = DateTime.UtcNow,
                Info = deserializedInfo?.Value,
                InformationId = deserializedInfo?.Id
            };

            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}