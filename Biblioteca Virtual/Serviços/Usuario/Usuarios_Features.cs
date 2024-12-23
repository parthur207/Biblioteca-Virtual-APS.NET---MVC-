using Biblioteca_Virtual.DataBase;
using Biblioteca_Virtual.Models;
using Biblioteca_Virtual.Serviços.Livros;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Biblioteca_Virtual.Serviços
{
    public class Usuarios_Features : Livro, IUsuarios_Interface
    {

        private readonly MeuDbContext _context;

        Usuarios_Features(MeuDbContext context)
        {
            _context=context;
        }

        public async Task<Resposta_Model<Usuario_Model>> Login(string Email, )
        {
            Resposta_Model<Usuarios_Features>
        }
        public async Task <Resposta_Model<UsuariosLivros_Model>> Pegar_Livro_Emprestado(int Usuario_Id, int Livro_Id) 
        {
            Resposta_Model<UsuariosLivros_Model> resposta = new Resposta_Model<UsuariosLivros_Model>();
            try
            {
                bool val1= await _context.Usuarios.AnyAsync(x=>x.Id.Equals(Usuario_Id)); //Existencia do usuer
                bool val2 = await _context.Usuarios.AnyAsync(x => x.Quant_Livros_Posse <= 2); //Verificacao se o user possui mais de um livro
                bool val3 = await _context.UsuariosLivros.AnyAsync(x=>x.Livro_Id.Equals(Livro_Id)); // Verificação se o Id_Livro está disponível para emprestimo

                var Livro = Buscar_Livro_Id(Livro_Id).Result.Dado;
              
                if (val1!=true && val2!=true && val3 != true)
                {
                     resposta.Status = false;
                    return resposta;
                    string mensagem = $"Empréstimo realizado com sucesso: Livro ({Livro}) - Usuário ({})";
                    return
                }




                _context.UsuariosLivros.Add();
                resposta.
            }
            catch (Exception ex)
            {

            }


        }
        

    }
}
