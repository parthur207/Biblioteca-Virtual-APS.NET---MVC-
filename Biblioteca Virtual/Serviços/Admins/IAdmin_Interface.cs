using Biblioteca_Virtual.Models;
using Biblioteca_Virtual.Serviços.Livros;

namespace Biblioteca_Virtual.Serviços.Admin
{
    public interface IAdminInterface : ILivro_Interface
    {
        Task<Resposta_Model<List<UsuariosLivros_Model>>> Listar_Emprestados();

        Task<Resposta_Model<Usuarios>> Deletar_Usuario();

    }
}
