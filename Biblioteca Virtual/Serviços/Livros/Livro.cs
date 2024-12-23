using Biblioteca_Virtual.DataBase;
using Biblioteca_Virtual.Migrations;
using Biblioteca_Virtual.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Biblioteca_Virtual.Serviços.Livros
{
    public class Livro : ILivroInterface
    {

        private readonly MeuDbContext _context;

        public Livro(MeuDbContext context)
        {
            _context = context;
        }

        public async Task<Resposta_Model<Livro_Model>> Buscar_Livro_Id(int _Id)
        {
            Resposta_Model<Livro_Model> resposta = new Resposta_Model<Livro_Model>();

            try
            {
                var Livro_Id = await _context.Livros.FirstOrDefaultAsync(x => x.Id == _Id);

                resposta.Dado = Livro_Id;

                return resposta;
            }

            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public Task<Resposta_Model<List<Livro_Model>>> Listar_Ano(int _Ano)
        {
            throw new NotImplementedException();
        }

        public async Task<Resposta_Model<List<Livro_Model>>> Listar_Autor(string _Autor)
        {

            Resposta_Model <List<Livro_Model>>resposta = new Resposta_Model<List<Livro_Model>>();
            try
            {
                var Livros_Autor = await _context.Livros.Where(x => x.Autor.Equals(_Autor, StringComparison.OrdinalIgnoreCase)).ToListAsync();

                resposta.Dado = Livros_Autor;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    

        public async Task<Resposta_Model<List<Livro_Model>>> Listar_Disponiveis()
        {
            Resposta_Model<List<Livro_Model>> resposta = new Resposta_Model<List<Livro_Model>>();


            try
            {
                var Livros_Disponiveis = await _context.Livros.Where(x => x.Emprestado == false).ToListAsync();

                resposta.Dado = Livros_Disponiveis;

                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Resposta_Model<List<Livro_Model>>> Listar_Editora(string _Editora)
        {
            Resposta_Model <List<Livro_Model>>resposta=new Resposta_Model<List<Livro_Model>>();

            try
            {
                var Livros_Editora = await _context.Livros.Where(x => x.Editora.Equals(_Editora, StringComparison.OrdinalIgnoreCase)).ToListAsync();

                resposta.Dado = Livros_Editora;

                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Resposta_Model<List<Livro_Model>>> Listar_Emprestados()
        {
            Resposta_Model<List<Livro_Model>> resposta = new Resposta_Model<List<Livro_Model>>();

            try
            {
                var Livros_Emprestados = await _context.Livros.Where(x => x.Emprestado == true).ToListAsync();

                resposta.Dado = Livros_Emprestados;

                return resposta;

            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Resposta_Model<List<Livro_Model>>> Listar_Todos_Livros()
        {
            Resposta_Model<List<Livro_Model>> resposta = new Resposta_Model<List<Livro_Model>>();

            try
            {
                var Todos_Livros = await _context.Livros.ToListAsync();
                resposta.Dado = Todos_Livros;

                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
