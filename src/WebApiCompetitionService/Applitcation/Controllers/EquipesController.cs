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
    [Route("[controller]")]
    [ApiController]
    public class EquipesController : ControllerBase
    {
        private readonly IEquipesService _equipesService;
        private readonly IMapper _mapper;

        public EquipesController(IEquipesService equipesService, IMapper mapper)
        {
            _equipesService = equipesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipesDto>>> GetEquipes()
        {
            IEnumerable<Equipes> equipes = await _equipesService.GetAllEquipesAsync();

            IEnumerable<EquipesDto> equipesResposta = _mapper.Map<IEnumerable<EquipesDto>>(equipes);

            return Ok(equipesResposta);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EquipesDto>> GetEquipeById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de equipe inválido");
            }

            Equipes? equipe = await _equipesService.GetEquipeByIdAsync(id);

            if (equipe == null)
            {
                return NotFound();
            }

            EquipesDto equipeResposta = _mapper.Map<EquipesDto>(equipe);

            return Ok(equipeResposta);
        }

        [HttpPost]
        public async Task<IActionResult> PostEquipes(EquipesAddViewModel equipe)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }

            Equipes equipeEntity = _mapper.Map<Equipes>(equipe);

            await _equipesService.PostEquipes(equipeEntity);

            string resourceUrl = $"/api/equipes/{equipeEntity.Id}";

            return Created(resourceUrl, null);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEquipe(int id, EquipesUpdateViewModel equipe)
        {
            if (id <= 0 || id != equipe.Id)
            {
                return BadRequest("ID de equipe inválido ou incompatível.");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return BadRequest(errors);
            }

            try
            {
                Equipes equipeEntity = _mapper.Map<Equipes>(equipe);
                await _equipesService.UpdateEquipeAsync(equipeEntity);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEquipe(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de equipe inválido.");
            }

            try
            {
                await _equipesService.DeleteEquipeAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
