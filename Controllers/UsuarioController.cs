using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TESTE_API_ASPNETCORE.Model;
using TESTE_API_ASPNETCORE.Services;

namespace TESTE_API_ASPNETCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
           _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Usuario = _usuarioService.FindById(id);
            if (Usuario == null) return NotFound();
            return Ok(Usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null) return BadRequest();
            return Ok(_usuarioService.Create(usuario));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Usuario usuario)
        {
            if (usuario == null) return BadRequest();
            return Ok(_usuarioService.Update(usuario));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioService.Delete(id);
            return NoContent();
        }

    }
}
