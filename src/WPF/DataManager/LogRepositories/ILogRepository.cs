using System.Threading.Tasks;

namespace DataManager.LogRepositories
{
    public interface ILogRepository
    {
        Task AddLog(string infoJson);
    }
}