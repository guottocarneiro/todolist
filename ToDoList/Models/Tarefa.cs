using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Tarefa : BaseModel
    {
        public Tarefa ()
        {

        }

        public Tarefa (string nome, string descricao, Boolean status, Lista lista)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Status = status;
            this.Lista = lista;
        }
        
        [Required]
        public string Nome { get; private set; }
        [Required]
        public string Descricao { get; private set; }
        [Required]
        public Boolean Status { get; private set; }
        public Lista Lista { get; private set; }
    }
}
