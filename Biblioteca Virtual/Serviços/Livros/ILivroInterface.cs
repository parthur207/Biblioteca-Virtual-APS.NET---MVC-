using Biblioteca_Virtual.Models;
using System.Threading.Tasks;

namespace Biblioteca_Virtual.Serviços.Livros
{
    public interface ILivroInterface
    {

        Task<Resposta_Model<List<Livro_Model>>> Listar_Todos_Livros();
        Task<Resposta_Model<Livro_Model>> Buscar_Livro_Id(int id);
        Task<Resposta_Model<List<Livro_Model>>> Listar_Disponiveis();
        Task<Resposta_Model<List<Livro_Model>>> Listar_Emprestados();

        Task<Resposta_Model<List<Livro_Model>>> Listar_Autor(string Autor);
        Task<Resposta_Model<List<Livro_Model>>> Listar_Editora(string Editora);
        Task<Resposta_Model<List<Livro_Model>>> Listar_Ano(int Ano);



    }
}
