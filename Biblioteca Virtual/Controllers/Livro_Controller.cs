using Biblioteca_Virtual.Identity;
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


        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles ="Admin")]
        [HttpDelete("DeletarLivro")]
        public async Task<ActionResult<Resposta_Model<Livro_Model>>> DeletarLivro(int LivroId)
        {

            var Request = await _livroInterface.Excluir_Livro(LivroId);


            if (Request.Status == true)
            {
                return Ok(Request.Mensagem);
            }
            return BadRequest(Request.Mensagem);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("AtualizarAtributo")]
        public async Task<ActionResult<Livro_Model>> AtualizarAtributo(int LivroId, AtributosLivro TipoAtributo, string NovoAtributo)
        {

            var Request = await _livroInterface.Atualizar_Atributo(LivroId, TipoAtributo, NovoAtributo);
            if (Request.Status==true)
            {
                return Ok(Request.Mensagem);
            }
            return BadRequest(Request.Mensagem);
        }


        [HttpGet("ListarTodosOsLivros")]
        public async Task <ActionResult<List<Livro_Model>>> ListarTodosOsLivros()
        {
            var Request=await _livroInterface.Listar_Todos_Livros();

            if (Request.Status==true)
            {
                return Ok(Request.Dado);
            }
            return BadRequest(Request.Mensagem);    
        } 

    
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


        [HttpGet("BuscarLivrosPorAutor")]
        public async Task<ActionResult<Resposta_Model<List<Livro_Model>>>> BuscarLivrosPorAutor(string Autor)
        {
            var Request = await _livroInterface.Listar_Livros_Autor(Autor);

            if (Request.Status == true)
            {
                return Ok(Request.Dado);
            }
            return BadRequest(Request.Mensagem);
        }


        [HttpGet("BuscarLivrosPorEditora")]
        public async Task <ActionResult<List<Livro_Model>>> BuscarLivrosPorEditora(string Editora)
        {
            var Request= await _livroInterface.Listar_Livros_Editora(Editora);

            if (Request.Status == true)
            {
                return Ok(Request.Dado);
            }    
            return BadRequest(Request.Mensagem);
        }


        [HttpGet("BuscarLivrosPorAno")]
        public async Task <ActionResult<List<Livro_Model>>> BuscarLivrosPorAno(int Ano)
        {

            var Request = await _livroInterface.Listar_Livros_Ano(Ano);

            if (Request.Status == true)
            {
                return Ok(Request.Dado);
            }
            return BadRequest(Request.Mensagem);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("LivrosEmprestados")]
        public async Task <ActionResult<List<Livro_Model>>> BuscarLivrosEmprestados()
        {
            var Request = await _livroInterface.Listar_Emprestados();

            if (Request.Status == true)
            {
                return Ok(Request.Dado);
            }
            return BadRequest(Request.Mensagem);
        }







    }
}