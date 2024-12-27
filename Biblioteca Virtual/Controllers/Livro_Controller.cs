using Biblioteca_Virtual.Models;
using Biblioteca_Virtual.Serviços.Livros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_Virtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Livro_Controller : ControllerBase
    {

        private readonly ILivro_Interface _livroInterface;

        Livro_Controller(ILivro_Interface livroInterface)
        {
            _livroInterface = livroInterface;
        }


        [Authorize("Usuario")]
        [HttpPost("AdicionarLivro")]
        public async Task<ActionResult<Resposta_Model<Livro_Model>>> AdicionarLivro(Livro_Model NovoLivro)
        {

            var Request = await _livroInterface.Adicionar_Livro(NovoLivro);
            if (Request.Status == true)
            {
                return Ok(Request.Mensagem);
            }
            return BadRequest(Request.Mensagem);
        }

        [Authorize("Usuario")]
        [HttpGet("BuscarLivrosDisponiveis")]
        public async Task<ActionResult<Resposta_Model<List<Livro_Model>>>> BuscarLivrosDisponiveis()
        {
            var Request = await _livroInterface.Listar_Disponiveis();
            if (Request.Status == true)
            {
                return Ok(Request.Dado);
            }
            return BadRequest(Request.Mensagem);
        }

        [Authorize("Usuario")]
        [HttpGet("BuscarLivroPorId")]
        public async Task<ActionResult<Resposta_Model<Livro_Model>>> BuscarLivroPorId(int LivroId)
        {
            var Request = await _livroInterface.Buscar_Livro_Id(LivroId);

            if (Request.Status == true)
            {
                return Ok(Request.Dado);
            }
            return BadRequest(Request.Mensagem);
        }


        [Authorize("Usuario")]
        [HttpGet("BuscarLivrosPorAutor")]
        public async Task <ActionResult<Resposta_Model<List<Livro_Model>>>> BuscarLivrosPorAutor(string Autor)
        {
            var Request= await _livroInterface.Listar_Livros_Autor(Autor);
            if (Request.Status == true)
            {
                return Ok(Request.Dado);
            }
            return BadRequest(Request.Mensagem);    
        }

        [Authorize("Usuario")]
        [HttpGet("BuscarLivrosPorEditora")]

        [Authorize("Usuario")]
        [HttpGet("BuscarLivrosPorAno")]




    }
}
