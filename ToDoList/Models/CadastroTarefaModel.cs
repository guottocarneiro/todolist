using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class CadastroTarefaModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Boolean Status { get; set; }
        public int IdLista { get; set; }
    }
}
