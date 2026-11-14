using AutoMapper;
using SPR521_t2.BLL.Dtos.SushiType;
using SPR521_t2.DAL.Entities;

namespace SPR521_t2.BLL.Profiles;

public class SushiTypeProfile : Profile
{
    public SushiTypeProfile()
    {
        CreateMap<SushiType, SushiTypeResponseDto>();
        CreateMap<CreateSushiTypeDto, SushiType>();
        CreateMap<UpdateSushiTypeDto, SushiType>();
    }
}
