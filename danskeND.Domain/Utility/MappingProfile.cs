using AutoMapper;
using danskeND.Domain.Model;
using danskeND.Repository.Entity;
using danskeND.Repository.Enum;

namespace danskeND.Domain.Utility;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SortEntity, SortModelDTO>().ForMember(x => x.Id, o => o.MapFrom(x => x.Id.ToString()));
        CreateMap<SortModelDTO, SortEntity>().ForMember(x => x.Id, o => o.MapFrom(x => Guid.Parse(x.Id)));

        CreateMap<MeasureResultEntity, MeasureResultDTO>().ForMember(x => x.Id, o => o.MapFrom(x => x.Id.ToString()))
            .ForMember(x => x.Algorithm, o => o.MapFrom(x => x.AlgorithmType.ToString()));
        CreateMap<MeasureResultDTO, MeasureResultEntity>().ForMember(x => x.Id, o => o.MapFrom(x => Guid.Parse(x.Id)))
            .ForMember(x => x.AlgorithmType,
                o => o.MapFrom(x => (SortingAlgorithmType)Enum.Parse(typeof(SortingAlgorithmType), x.Algorithm, true))); // mappina, kad viewe butu stringas, db int, o sistemoje enum.
    }
}