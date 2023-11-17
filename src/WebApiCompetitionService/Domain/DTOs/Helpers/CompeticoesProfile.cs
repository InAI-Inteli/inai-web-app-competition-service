using AutoMapper;
using WebAPICompetitionService.Domain.DTOs.Responses;
using WebAPICompetitionService.Domain.DTOs.ViewModels;
using WebAPICompetitionService.Domain.Entities;

namespace WebAPICompetitionService.Domain.DTOs.Helpers
{
    public class CompeticoesProfile : Profile
    {
        public CompeticoesProfile() 
        {
            CreateMap<CompeticoesAddViewModel, Competicoes>();
            CreateMap<Competicoes, CompeticoesAddViewModel>();
            CreateMap<CompeticoesUpdateViewModel, Competicoes>();
            CreateMap<Competicoes, CompeticoesUpdateViewModel>();
            CreateMap<CompeticoesDto, Competicoes>();
            CreateMap<Competicoes, CompeticoesDto>();
        }
    }
}
