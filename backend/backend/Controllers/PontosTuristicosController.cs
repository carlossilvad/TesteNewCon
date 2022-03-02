using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using backend.Models;
using backend.Services.Interfaces;
using backend.Services.Pagination;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontosTuristicosController : ControllerBase
    {
        private IPontoTuristicoService _pontoTuristicoService;

        public PontosTuristicosController(IPontoTuristicoService pontoTuristicoService)
        {
            _pontoTuristicoService = pontoTuristicoService;
        }

        #region Listar todos os produtos com paginação
        [HttpGet]
        public ActionResult<IAsyncEnumerable<PontoTuristico>> GetPontosTuristicos([FromQuery] PontoTuristicoParameters pontoTuristicoParameters)
        {

            var pontosTuristicos = _pontoTuristicoService.ObterPontosTuristicos(pontoTuristicoParameters);

            var metadata = new
            {
                pontosTuristicos.TotalCount,
                pontosTuristicos.PageSize,
                pontosTuristicos.CurrentPage,
                pontosTuristicos.TotalPage,
                pontosTuristicos.HasNext,
                pontosTuristicos.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            Response.Headers["X-Total-Registros"] = pontosTuristicos.TotalCount.ToString();
            Response.Headers["X-Numero-Pagina"] = pontosTuristicos.TotalPage.ToString();

            return Ok(pontosTuristicos);
        }
        #endregion

        #region Buscar produto por id
        [HttpGet("{id}", Name = "ObterProduto")]
        public async Task<ActionResult<PontoTuristico>> Get(int id)
        {
            var pontoTuristico = await _pontoTuristicoService.ObterPontoTuristicoPorId(id);

            if (pontoTuristico == null)
            {
                return NotFound();
            }

            return Ok(pontoTuristico);
        }

        #endregion

        #region Criar produto
        [HttpPost]
        public async Task<ActionResult<PontoTuristico>> Post([FromBody] PontoTuristico pontoTuristico)
        {
            var pontoTuristicoCriado = await _pontoTuristicoService.CriarPontoTuristico(pontoTuristico);

            return Ok(pontoTuristicoCriado);
        }
        #endregion

        #region Atualizar produto
        [HttpPut("{id}")]
        public async Task<ActionResult<PontoTuristico>> Put(int id, [FromBody] PontoTuristico pontoTuristico)
        {
            var pontoTuristicoAtualizado = await _pontoTuristicoService.AtualizarPontoTuristico(id, pontoTuristico);

            return Ok(pontoTuristicoAtualizado);
        }

        #endregion

        #region Deletar produto
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pontoTuristicoService.DeletarPontoTuristico(id);

            return Ok();
        }
        #endregion

    }
}
