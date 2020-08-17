using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class CadastroTarefaModel
    {
        public CadastroTarefaModel()
        {

        }
        public CadastroTarefaModel(int idTarefa, string nome, string descricao, int idLista, bool status)
        {
            IdTarefa = idTarefa;
            Nome = nome;
            Descricao = descricao;
            IdLista = idLista;
            Status = status;
        }

        public int IdTarefa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdLista { get; set; }
        public Boolean Status { get; set; }
    }
}
