using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{

    [Controller]
    [Route("[controller]")]
    public class EscalaoController : ControllerBase
    {

        private empresa_aguasContext dc;

        public EscalaoController(empresa_aguasContext context)
        {
            this.dc = context;
        }

        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Escalao escalao)
        {
            dc.escalao.Add(escalao);
            await dc.SaveChangesAsync();
            return Created("Objeto Escalao", escalao);
        }

        [HttpGet("api")]
        public async Task<ActionResult> listar()
        {
            var dados = await dc.escalao.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("api/{codigo}")]
        public Escalao filtrar(int codigo)
        {
            Escalao escalao = dc.escalao.Find(codigo);
            return escalao;
        }

        [HttpPut("api")]
        public async Task<ActionResult> editar([FromBody] Escalao escalao)
        {
            dc.escalao.Update(escalao);
            await dc.SaveChangesAsync();
            return Ok(escalao);
        }

        [HttpDelete("api/{codigo}")]
        public async Task<ActionResult> remover(int codigo)
        {
            Escalao escalao = filtrar(codigo);
            if (escalao == null)
            {
                return NotFound();
            }
            dc.escalao.Remove(escalao);
            await dc.SaveChangesAsync();
            return Ok();
        }

    }
}