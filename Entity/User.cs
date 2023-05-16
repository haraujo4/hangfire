using Microsoft.AspNetCore.Server.IIS.Core;

namespace hagnfireJob.Entity
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }

        public User(string nome, string email, string senha, bool status)
        {
            UserID = Guid.NewGuid() ;
            Nome = nome;
            Email = email;
            Senha = senha;
            Status = status;
        }
        public User(){ }
    }
}
