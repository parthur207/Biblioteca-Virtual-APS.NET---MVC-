using Biblioteca_Virtual.DataBase;
using Biblioteca_Virtual.Models;
using Biblioteca_Virtual.Serviços.Livros;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Virtual.Serviços
{
    public class Usuarios : Livro, IUsuarios_Interface
    {

        private readonly MeuDbContext _context;

        Usuarios(MeuDbContext context)
        {
            _context=context;
        }

        public async Task<Resposta_Model<Usuario_Model>> Login()
        {
            Resposta_Model<Usuarios>
        }
        public async Task <Resposta_Model<UsuariosLivros_Model>> Pegar_Livro_Emprestado(int Usuario_Id, int Livro_Id) 
        {
            Resposta_Model<UsuariosLivros_Model> resposta = new Resposta_Model<UsuariosLivros_Model>();
            try
            {
                bool val1= await _context.Usuarios.AnyAsync(x=>x.Id.Equals(Usuario_Id)); //Existencia do usuer
                bool val2 = await _context.Usuarios.AnyAsync(x => x.Quant_Livros_Posse <= 2); //Verificacao se o user possui mais de um livro
                bool val3 = await _context.UsuariosLivros.AnyAsync(x=>x.Livro_Id.Equals(Livro_Id)); // Verificação se o Id_Livro está disponível para emprestimo

                if(val1!=true && val2!=true && val3 != true)
                {
                     resposta.Status = false;
                    return resposta;
                    string mensagem = $"O livro {}";
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
