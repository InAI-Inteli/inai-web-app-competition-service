using AutoMapper;
using WebAPICompetitionService.Domain.DTOs.Responses;
using WebAPICompetitionService.Domain.DTOs.ViewModels;
using WebAPICompetitionService.Domain.Entities;

namespace WebAPICompetitionService.Domain.DTOs.Helpers
{
    public class EquipesProfile : Profile
    {
        public EquipesProfile()
        {
            CreateMap<EquipesAddViewModel, Equipes>();
            CreateMap<Equipes, EquipesAddViewModel>();
            CreateMap<EquipesUpdateViewModel, Equipes>();
            CreateMap<Equipes, EquipesUpdateViewModel>();
            CreateMap<EquipesDto, Equipes>();
            CreateMap<Equipes, EquipesDto>();
        }
    }
}
