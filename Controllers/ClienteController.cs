using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{

    [Controller]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {

        private empresa_aguasContext dc;

        public ClienteController(empresa_aguasContext context)
        {
            this.dc = context;
        }

        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Cliente cliente)
        {
            dc.cliente.Add(cliente);
            await dc.SaveChangesAsync();
            return Created("Objeto Cliente", cliente);
        }

        [HttpGet("api")]
        public async Task<ActionResult> listar()
        {
            var dados = await dc.cliente.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("api/{codigo}")]
        public Cliente filtrar(int codigo)
        {
            Cliente cliente = dc.cliente.Find(codigo);
            return cliente;
        }

        [HttpPut("api")]
        public async Task<ActionResult> editar([FromBody] Cliente cliente)
        {
            dc.cliente.Update(cliente);
            await dc.SaveChangesAsync();
            return Ok(cliente);
        }

        [HttpDelete("api/{codigo}")]
        public async Task<ActionResult> remover(int codigo)
        {
            Cliente cliente = filtrar(codigo);
            if (cliente == null)
            {
                return NotFound();
            }
            dc.cliente.Remove(cliente);
            await dc.SaveChangesAsync();
            return Ok();
        }

    }
}