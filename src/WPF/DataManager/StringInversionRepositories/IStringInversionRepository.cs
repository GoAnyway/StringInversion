using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace DataManager.StringInversionRepositories
{
    public interface IStringInversionRepository
    {
        Task<IEnumerable<SomeBigModel>> GetEntitiesAsModels();
        Task<InformationModel> AddInfo(InformationModel informationModel);
        Task<SomeBigModel> GetNewModel(InformationModel newInfo);
    }
}