using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{

    [Controller]
    [Route("[controller]")]
    public class ConsumoController : ControllerBase
    {

        private empresa_aguasContext dc;

        public ConsumoController(empresa_aguasContext context)
        {
            this.dc = context;
        }

        [HttpPost("api/{idClient}")]
        public async Task<ActionResult> cadastrar([FromBody] Consumo consumo, int idClient)
        {
            Cliente cliente = dc.cliente.Find(idClient);
            if(cliente == null) {
                return NotFound("Not Found Cliente");
            }
            consumo.Cliente = cliente;
            dc.consumo.Add(consumo);
            await dc.SaveChangesAsync();
            return Created("Objeto Consumo", consumo);
        }

        [HttpGet("api")]
        public async Task<ActionResult> listar()
        {
            var dados = await dc.consumo.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("api/{codigo}")]
        public Consumo filtrar(int codigo)
        {
            Consumo consumo = dc.consumo.Find(codigo);
            return consumo;
        }

        [HttpPut("api")]
        public async Task<ActionResult> editar([FromBody] Consumo consumo)
        {
            dc.consumo.Update(consumo);
            await dc.SaveChangesAsync();
            return Ok(consumo);
        }

        [HttpDelete("api/{codigo}")]
        public async Task<ActionResult> remover(int codigo)
        {
            Consumo consumo = filtrar(codigo);
            if (consumo == null)
            {
                return NotFound();
            }
            dc.consumo.Remove(consumo);
            await dc.SaveChangesAsync();
            return Ok();
        }

    }
}