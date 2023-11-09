using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICompetitionService.Domain.DTOs.Responses;
using WebAPICompetitionService.Domain.DTOs.ViewModels;
using WebAPICompetitionService.Domain.Entities;
using WebAPICompetitionService.Service.Interfaces;

namespace WebAPICompetitionService.Applitcation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompeticoesController : ControllerBase
    {
        private readonly ICompeticoesService _competicoesService;
        private readonly IMapper _mapper;

        public CompeticoesController(ICompeticoesService competicoesService, IMapper mapper)
        {
            _competicoesService = competicoesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompeticoesDto>>> GetCompeticoes()
        {
            IEnumerable<Competicoes> competicoes = await _competicoesService.GetAllCompeticoesAsync();

            IEnumerable<CompeticoesDto> competicoesResposta = _mapper.Map<IEnumerable<CompeticoesDto>>(competicoes);

            return Ok(competicoesResposta);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CompeticoesDto>> GetCompeticaoById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de competição inválido");
            }

            Competicoes? competicao = await _competicoesService.GetCompeticaoByIdAsync(id);

            if (competicao == null)
            {
                return NotFound();
            }

            CompeticoesDto competicaoResposta = _mapper.Map<CompeticoesDto>(competicao);

            return Ok(competicaoResposta);
        }

        [HttpPost]
        public async Task<IActionResult> PostCompeticoes(CompeticoesAddViewModel competicao)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }

            Competicoes competicaoEntity = _mapper.Map<Competicoes>(competicao);

            await _competicoesService.PostCompeticoesAsync(competicaoEntity);

            string resourceUrl = $"/api/competicoes/{competicaoEntity.Id}";

            return Created(resourceUrl, null);
        }

        [HttpPut("editar/{id:int}")]
        public async Task<IActionResult> UpdateCompeticao(int id, CompeticoesUpdateViewModel competicao)
        {
            if (id <= 0 || id != competicao.Id)
            {
                return BadRequest("ID de competição inválido ou incompatível.");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }

            try
            {
                Competicoes competicaoEntity = _mapper.Map<Competicoes>(competicao);
                await _competicoesService.UpdateCompeticaoAsync(competicaoEntity);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCompeticao(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de competição inválido.");
            }

            try
            {
                await _competicoesService.DeleteCompeticaoAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
