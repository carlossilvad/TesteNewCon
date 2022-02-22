using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteNewCon1.Model;
using TesteNewCon1.Services;

namespace TesteNewCon1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontosTuristicosController : ControllerBase
    {
        private IPontoTuristico _pontoTuristicoService;

        public PontosTuristicosController(IPontoTuristico pontoTuristicoService)
        {
            _pontoTuristicoService = pontoTuristicoService;
        }

        [HttpGet]

        public async Task<ActionResult<IAsyncEnumerable<PontoTuristico>>> GetPontosTuristicos()
        {
            try
            {
                var pontosTuristicos = await _pontoTuristicoService.GetPontosTuristicos();
                return Ok(pontosTuristicos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter pontos turísticos");
            }
        }

        [HttpGet("PontosTuristicosPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<PontoTuristico>>> GetPontosTuristicosByName([FromQuery] string nome)
        {
            try
            {
                var pontosTuristicos = await _pontoTuristicoService.GetPontosTuristicosByNome(nome);

                if (pontosTuristicos == null)
                    return NotFound($"Não existem pontos turísticos com o nome {nome}");

                return Ok(pontosTuristicos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter pontos turísticos");
            }
        }

        [HttpGet("{id:int}", Name="GetPontoTuristico")]
        public async Task<ActionResult<PontoTuristico>> GetPontoTuristico(int id)
        {
            try
            {
                var pontoTuristico = await _pontoTuristicoService.GetPontoTuristico(id);

                if (pontoTuristico == null)
                    return NotFound($"Não existe um ponto turístico com id {id}");

                return Ok(pontoTuristico);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter pontos turísticos");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(PontoTuristico pontoTuristico)
        {
            try
            {
                await _pontoTuristicoService.CreatePontoTuristico(pontoTuristico);
                return CreatedAtRoute(nameof(GetPontoTuristico), new { id = pontoTuristico.Id }, pontoTuristico);
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] PontoTuristico pontoTuristico)
        {
            try
            {
                if (pontoTuristico.Id == id)
                {
                    await _pontoTuristicoService.UpdatePontoTuristico(pontoTuristico);
                    return Ok($"Ponto Turístico de id {id} atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados incosistentes");
                }
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var pontoTuristico = await _pontoTuristicoService.GetPontoTuristico(id);
                if(pontoTuristico != null)
                {
                    await _pontoTuristicoService.DeletePontoTuristico(pontoTuristico);
                    return Ok($"Ponto Turístico de id {id} excluído com sucesso");
                }
                else
                {
                    return NotFound($"Ponto turístico de id {id} não encontrado");
                }
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }
    }
}
