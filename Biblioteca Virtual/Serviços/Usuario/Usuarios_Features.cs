using Biblioteca_Virtual.DataBase;
using Biblioteca_Virtual.Models;
using Biblioteca_Virtual.Serviços.Livros;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Biblioteca_Virtual.Serviços
{
    public class Usuarios_Features : Livro_Feature, IUsuarios_Interface
    {

        private readonly MeuDbContext _context;

        Usuarios_Features(MeuDbContext context)
        {
            _context=context;
        }

    
        public async Task<Resposta_Model<Usuario_Model>> Login(string _Email, string _Senha)
        {
            Resposta_Model<Usuarios_Features> resposta = new Resposta_Model<Usuarios_Features>();

            bool autentificacao1 = true;

            try
            {
                
                var _Id = _context.Usuarios.Where(x=>x.Email.Equals(_Email)).Select(x=>x.Id).FirstOrDefault();
                if (string.IsNullOrEmpty(_Id.ToString()))
                {
                    autentificacao1 = false;
                  return 
                } 
                var autentificacao2 = _context.Usuarios.Where(x => x.Id == _Id).Any(x => x.Senha.Equals(_Senha));
                
                resposta.Status=autentificacao1 &= autentificacao2;
                
            }
            catch (Exception ex)
            {

            }
        }
        public async Task <Resposta_Model<UsuariosLivros_Model>> Pegar_Livro_Emprestado(int Usuario_Id, int Livro_Id) 
        {
            Resposta_Model<Emprestimos_Model> resposta = new Resposta_Model<Emprestimos_Model>();
            try
            {
                bool val1= await _context.Usuarios.AnyAsync(x=>x.Id.Equals(Usuario_Id)); //Existencia do usuer
                bool val2 = await _context.Usuarios.AnyAsync(x => x.Quant_Livros_Posse <= 2); //Verificacao se o user possui mais de um livro
                bool val3 = await _context.Emprestimos.AnyAsync(x=>x.Livro_Id.Equals(Livro_Id)); // Verificação se o Id_Livro está disponível para emprestimo

                var Livro = B(Livro_Id).Dado;
              
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
