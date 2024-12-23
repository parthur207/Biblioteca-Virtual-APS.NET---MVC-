using Biblioteca_Virtual.Models;
using Biblioteca_Virtual.Serviços.Livros;

namespace Biblioteca_Virtual.Serviços
{
    public interface IUsuarios_Interface : ILivro_Interface
    {

        Task<Resposta_Model<Usuarios_Features>> Cadastrar(string Email, string Senha, string Confirmar_Senha);
        Task<Resposta_Model<Usuarios_Features>> Login(string Email, string Senha);
        
        Task<Resposta_Model<Emprestimos_Model>> Pegar_Livro_Emprestado(int Usuario_Id, int Livro_Id);
        Task<Resposta_Model<Emprestimos_Model>> Devolucao_Livro(int Usuario_Id, int Livro_Id);

        Task <Resposta_Model<Emprestimos_Model>> Resetar_Senha(string Senha_Atual, string Nova_Senha);
    }
}
