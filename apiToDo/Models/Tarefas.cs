using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public static class Tarefas
    {
        public static List<TarefaDTO> tarefas = new List<TarefaDTO>
        {
            new TarefaDTO { ID_TAREFA = 1, DS_TAREFA = "Fazer Compras" },
            new TarefaDTO { ID_TAREFA = 2, DS_TAREFA = "Fazer Atividade da Faculdade" },
            new TarefaDTO { ID_TAREFA = 3, DS_TAREFA = "Subir Projeto de Teste no GitHub" }
        };
    }
}
