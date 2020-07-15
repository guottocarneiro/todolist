using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Models
{
    public class Usuario : BaseModel
    {
        public Usuario ()
        {

        }

        public Usuario (string loginUsuario, string senhaUsuario)
        {
            this.Login = loginUsuario;
            this.Senha = senhaUsuario;
        }

        public void setUsuario (string loginUsuario, string senhaUsuario)
        {
            this.Login = loginUsuario;
            this.Senha = senhaUsuario;
        }
        
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
