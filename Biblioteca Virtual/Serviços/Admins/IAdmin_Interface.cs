using Biblioteca_Virtual.Models;
using Biblioteca_Virtual.Serviços.Livros;

namespace Biblioteca_Virtual.Serviços.Admin
{
    public interface IAdminInterface : ILivro_Interface
    {
        Task<Resposta_Model<Usuarios_Features>> Deletar_Usuario(int Matricula);

        Task<Resposta_Model<Livro_Model>> Deletar_Livro(string Nome_Livro);

        Task<Resposta_Model<Livro_Model>> Editar_Livro(string Nome_Livro);

        Task<Resposta_Model<Livro_Model>> Bloquear_Usuario(int Matricula);

    }
}
