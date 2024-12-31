using Biblioteca_Virtual.DataBase;
using Biblioteca_Virtual.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Biblioteca_Virtual.Serviços.Livros
{
    public class Livro_Features : ILivro_Interface
    {

        private readonly MeuDbContext _context;

        public Livro_Features(MeuDbContext context)
        {
            _context = context;
        }

        public async Task<Resposta_Model<Livro_Model>> Adicionar_Livro(Livro_Model Novo_Livro)
        {
            Resposta_Model<Livro_Model> resposta = new Resposta_Model<Livro_Model>();

            var Request = await Buscar_Livro_Id(Novo_Livro.Id);

            if (Request.Status == false)
            {
                resposta.Mensagem = "Livro já cadastrado.";
                return resposta;
            }

            try
            {
                await _context.Livros.AddAsync(Novo_Livro);
                resposta.Mensagem = "Livro adicionado com sucesso.";
                return resposta;
            }
            catch
            {
                resposta.Status = false;
                resposta.Mensagem = "Erro ao adicionar um novo livro.";
                return resposta;
            }   
        }


        public async Task<Resposta_Model<Livro_Model>> Excluir_Livro(int LivroId)
        {
            Resposta_Model<Livro_Model> resposta= new Resposta_Model<Livro_Model>();

            var Request = await Buscar_Livro_Id(LivroId);

            if (Request.Status==false)
            {
                resposta.Mensagem = "O livro não existe.";
                return resposta;
            }

            try
            {
                _context.Livros.Remove(Request.Dado);

                resposta.Mensagem= "Livro excluído com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = "Erro ao excluir o livro.";
                resposta.Status = false;
                return resposta;
            }
        }


        public async Task<Resposta_Model<Livro_Model>> Atualizar_Atributo(int IdLivro, AtributosLivro TipoAtributo, string NovoAtributo)
        {
            Resposta_Model<Livro_Model> resposta = new Resposta_Model<Livro_Model>();

            var Request = await Buscar_Livro_Id(IdLivro);

            if (Request.Status == false)
            {
                resposta.Mensagem = "Livro não encontrado.";
                return resposta;
            }

            try
            {
                var Livro_Atualizado = await _context.Livros.FirstOrDefaultAsync(x => x.Id == IdLivro);

                switch (TipoAtributo)
                {
                    case AtributosLivro.Nome_Livro://1
                        Livro_Atualizado.Nome_Livro = NovoAtributo;
                        break;

                    case AtributosLivro.Editora://2
                        Livro_Atualizado.Autor = NovoAtributo;
                        break;

                    case AtributosLivro.Autor://3
                        Livro_Atualizado.Editora = NovoAtributo;
                        break;

                    case AtributosLivro.Ano://4
                        Livro_Atualizado.Ano = int.Parse(NovoAtributo);
                        break;

                    default:
                        resposta.Mensagem = "Atributo não encontrado.";
                        return resposta;
                }

                _context.Livros.Update(Livro_Atualizado);
                await _context.SaveChangesAsync();

                resposta.Mensagem = "Atributo atualizado com sucesso.";
                return resposta;
            }
            catch
            {
                resposta.Mensagem = "Erro ao atualizar o atributo.";
                resposta.Status = false;
                return resposta;
            }
        }


        public async Task<Resposta_Model<Livro_Model>> Buscar_Livro_Id(int LivroId)
        {
            Resposta_Model<Livro_Model> resposta = new Resposta_Model<Livro_Model>();

            try
            {
                var Livro = await _context.Livros.FirstOrDefaultAsync(x => x.Id == LivroId);

                resposta.Dado = Livro;

                return resposta;
            }

            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<Resposta_Model<List<Livro_Model>>> Listar_Livros_Ano(int ano)
        {
            Resposta_Model<List<Livro_Model>> resposta=new Resposta_Model<List<Livro_Model>>();

            try
            {
                var Livros_Ano = await _context.Livros.Where(x => x.Ano.Equals(ano)).ToListAsync();
                resposta.Dado= Livros_Ano;
                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem=ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


        public async Task<Resposta_Model<List<Livro_Model>>> Listar_Livros_Autor(string autor)
        {

            Resposta_Model <List<Livro_Model>>resposta = new Resposta_Model<List<Livro_Model>>();
            try
            {
                var Livros_Autor = await _context.Livros.Where(x => x.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase)).ToListAsync();

                resposta.Dado = Livros_Autor;

                return resposta;
            }
            catch 
            {
                resposta.Mensagem = "Erro na tentativa de buscar livros com autor ({}).";
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

        public async Task<Resposta_Model<List<Livro_Model>>> Listar_Livros_Editora(string _Editora)
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
