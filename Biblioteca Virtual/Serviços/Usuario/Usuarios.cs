using Biblioteca_Virtual.DataBase;
using Biblioteca_Virtual.Models;
using Biblioteca_Virtual.Serviços.Livros;

namespace Biblioteca_Virtual.Serviços
{
    public class Usuarios : Livro, IUsuarios_Interface
    {

        private readonly MeuDbContext _context;

        Usuarios(MeuDbContext context)
        {
            _context=context;
        }

        Task<Resposta_Model<Usuario_Model>> Login()
        {
            Resposta_Model<Usuarios>
        }
        Task<Resposta_Model<UsuariosLivros_Model>> Pegar_Livro_Emprestado(int Usuario_Id, int Livro_Id) 
        {
            Task<Resposta_Model<UsuariosLivros_Model>> resposta = new Task<Resposta_Model<UsuariosLivros_Model>>();

            try
            {
                resposta.
            }
            catch (Exception ex)
            {

            }


        }
        

    }
}
