using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataManager.StringInversionRepositories
{
    public class DbStringInversionRepository : IStringInversionRepository
    {
        private readonly StringInversionDbContext _context;
        private readonly IMapper _mapper;

        public DbStringInversionRepository(StringInversionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SomeBigModel>> GetEntitiesAsModels() =>
            await _context.Information.ProjectTo<SomeBigModel>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<InformationModel> AddInfo(InformationModel informationModel)
        {
            var entity = await _context.Information.FindAsync(informationModel.Id);
            if (entity == null)
            {
                entity = _mapper.Map<Information>(informationModel);
                await _context.Information.AddAsync(entity);
            }
            else
            {
                _mapper.Map(informationModel, entity);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<InformationModel>(entity);
        }

        public async Task<SomeBigModel> GetNewModel(InformationModel newInfo)
        {
            var log = await _context.Logs.OrderByDescending(_ => _.Time)
                .FirstOrDefaultAsync(_ => _.InformationId == newInfo.Id);
        
            return new SomeBigModel
            {
                Information = newInfo,
                Log = _mapper.Map<LogModel>(log)
            };
        }
    }
}