using MediatR;
using MeuCorre.Application.UseCases.Categorias.Commands;
using MeuCorre.Application.UseCases.Categorias.Dtos;
using MeuCorre.Application.UseCases.Categorias.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MeuCorre.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Cria uma nova tag para o usuário
        /// </summary>
        /// <param name="command">Os dados da nova tag</param>
        /// <returns>Retorna uma nova tag criada</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TagDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> CriarTag([FromBody] CriarTagCommad command)
        {
            var (mensagem, sucesso) = await _mediator.Send(command);
            if (sucesso)
            {
                return Ok(mensagem);
            }
            else
            {
                return Conflict(mensagem);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarTag([FromBody] AtualizarTagCommand command)
        {
            var (mensagem, sucesso) = await _mediator.Send(command);
            if (sucesso)
            {
                return Ok(mensagem);
            }
            else
            {
                return BadRequest(mensagem);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarTag([FromBody] DeletarTagCommad command)
        {
            var (mensagem, sucesso) = await _mediator.Send(command);
            if (sucesso)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(mensagem);
            }
        }

        [HttpPatch("ativar/{id}")]
        public async Task<IActionResult> AtivarTag(Guid id)
        {
            var command = new AtivarTagCommand { TagId = id };
            var (mensagem, sucesso) = await _mediator.Send(command);
            if (sucesso)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(mensagem);
            }
        }


        [HttpPatch("inativar/{id}")]
        public async Task<IActionResult> InativarTag(Guid id)
        {
            var command = new InativarTagCommand { TagId = id };
            var (mensagem, sucesso) = await _mediator.Send(command);
            if (sucesso)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(mensagem);
            }
        }


        [HttpGet]
        public async Task<IActionResult> ObterTagPorUsuario([FromQuery] ListarTodasCategoriasQuery query)
        {
            var categorias = await _mediator.Send(query);
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterTagPorId(Guid id)
        {
            var query = new ObterTagQuery() { TagId = id };
            var tag = await _mediator.Send(query);
            if (tag == null)
            {
                return NotFound("Tag não encontrada");
            }
            return Ok(Tag);
        }
    }

}
