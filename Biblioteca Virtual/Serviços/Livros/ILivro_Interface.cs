using Biblioteca_Virtual.Models;
using System.Threading.Tasks;

namespace Biblioteca_Virtual.Serviços.Livros
{
    public interface ILivro_Interface
    {
        Task<Resposta_Model<Livro_Model>> Atualizar_Atributo(int IdLivro, AtributosLivro AtributoId, string NovoAtributo);
        Task<Resposta_Model<Livro_Model>> Adicionar_Livro(Livro_Model NovoLivro);
        Task<Resposta_Model<List<Livro_Model>>> Listar_Todos_Livros();
        Task<Resposta_Model<Livro_Model>> Buscar_Livro_Id(int id);

        Task<Resposta_Model<List<Livro_Model>>> Listar_Emprestados();
        Task<Resposta_Model<List<Livro_Model>>> Listar_Disponiveis();
        Task<Resposta_Model<List<Livro_Model>>> Listar_Livros_Autor(string Autor);
        Task<Resposta_Model<List<Livro_Model>>> Listar_Livros_Editora(string Editora);
        Task<Resposta_Model<List<Livro_Model>>> Listar_Livros_Ano(int Ano);
        Task<Resposta_Model<Livro_Model>> Excluir_Livro(int LivroId);
        
    }
}
