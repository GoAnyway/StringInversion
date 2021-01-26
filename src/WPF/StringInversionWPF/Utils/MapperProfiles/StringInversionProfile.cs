using System.Linq;
using AutoMapper;
using Database.Entities;
using Models;

namespace StringInversionWPF.Utils.MapperProfiles
{
    public class StringInversionProfile : Profile
    {
        public StringInversionProfile()
        {
            CreateMap<Information, InformationModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Value, opt => opt.MapFrom(s => s.Value));
            CreateMap<InformationModel, Information>()
                .ForMember(_ => _.Id, opt =>
                {
                    opt.Condition(s => s.Id != default);
                    opt.MapFrom(s => s.Id);
                })
                .ForMember(_ => _.Value, opt => opt.MapFrom(s => s.Value));

            CreateMap<Log, LogModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Time, opt => opt.MapFrom(s => s.Time))
                .ForMember(_ => _.Info, opt => opt.MapFrom(s => s.Info))
                .ForMember(_ => _.InformationId, opt => opt.MapFrom(s => s.InformationId));
            CreateMap<LogModel, Log>()
                .ForMember(_ => _.Id, opt =>
                {
                    opt.Condition(s => s.Id != default);
                    opt.MapFrom(s => s.Id);
                })
                .ForMember(_ => _.Time, opt => opt.MapFrom(s => s.Time))
                .ForMember(_ => _.Info, opt => opt.MapFrom(s => s.Info))
                .ForMember(_ => _.InformationId, opt => opt.MapFrom(s => s.InformationId));

            CreateMap<Information, SomeBigModel>()
                .ForMember(_ => _.Information, opt => opt.MapFrom(s => s))
                .ForMember(_ => _.Log, opt => opt.MapFrom(s => s.Logs.OrderByDescending(_ => _.Time).FirstOrDefault()));
        }
    }
}