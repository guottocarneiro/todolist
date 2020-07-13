using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Lista : BaseModel
    {

        public Lista()
        {

        }

        public Lista(int idusuario)
        {
            this.IdUsuario = idusuario;
        }

        public string Nome { get; private set; }
        [Required]
        public int IdUsuario { get; private set; }
        public ICollection<Tarefa> Tarefas { get; private set; }
    }
}
