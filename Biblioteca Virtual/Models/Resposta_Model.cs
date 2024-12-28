namespace Biblioteca_Virtual.Models
{
    public class Resposta_Model <T>
    {
        public T? Dado { get; set; }

        public string Mensagem { get; set; } = string.Empty;

        public bool Status { get; set; } = true;
    }
}
