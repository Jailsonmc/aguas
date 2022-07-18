using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{

    [Controller]
    [Route("[controller]")]
    public class FaturacaoController : ControllerBase
    {

        private empresa_aguasContext dc;

        public FaturacaoController(empresa_aguasContext context)
        {
            this.dc = context;
        }

        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Faturacao faturacao)
        {
            dc.faturacao.Add(faturacao);
            await dc.SaveChangesAsync();
            return Created("Objeto Faturacao", faturacao);
        }

        [HttpGet("api")]
        public async Task<ActionResult> listar()
        {
            var dados = await dc.faturacao.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("api/{codigo}")]
        public Faturacao filtrar(int codigo)
        {
            Faturacao faturacao = dc.faturacao.Find(codigo);
            return faturacao;
        }

        [HttpPut("api")]
        public async Task<ActionResult> editar([FromBody] Faturacao faturacao)
        {
            dc.faturacao.Update(faturacao);
            await dc.SaveChangesAsync();
            return Ok(faturacao);
        }

        [HttpDelete("api/{codigo}")]
        public async Task<ActionResult> remover(int codigo)
        {
            Faturacao faturacao = filtrar(codigo);
            if (faturacao == null)
            {
                return NotFound();
            }
            dc.faturacao.Remove(faturacao);
            await dc.SaveChangesAsync();
            return Ok();
        }

    }
}