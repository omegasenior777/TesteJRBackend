using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers
{
    [ApiController]
    // Inserido versionamento da API
    [Route("v1/[controller]")]
    public class TarefasController : ControllerBase
    {
        
        //[Authorize]
        // Remoção de definição endpoints por boa prática
        [HttpGet]
        // Melhoria da nomeclatura e definição de lista
        public ActionResult<List<TarefaDTO>> ListarTarefas()
        {
            try
            {
                // Retone as tarefas em uma lista no formato indicado no Model Tarefas
                return Ok(Tarefas.tarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Erro: {ex.Message}" });
            }
        }

        // Rota para pegar um item da lista pelo Id
        [HttpGet("{id}")]
        public ActionResult ListarTarefa(int id)
        {
            try
            {            
                // Identifica a tarefa pelo Id rececbido
                var tarefa = Tarefas.tarefas.Find(x => x.ID_TAREFA == id);

                // Se o Id não existir retorna a mensagem de "Tarefa não encontrada."
                if (tarefa == null) return NotFound(new { msg = "Tarefa não encontrada." });

                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Erro: {ex.Message}" });
            }
        }

        [HttpPost]
        public ActionResult InserirTarefa([FromBody] TarefaDTO request)
        {
            try
            {
                // Transforma a Id das tarefas para incremental
                request.ID_TAREFA = Tarefas.tarefas.Count + 1;

                //Adiciona a tarefa a lista
                Tarefas.tarefas.Add(request);

                // Retorna HTTP 201 Created com a nova tarefa
                return CreatedAtAction(nameof(ListarTarefa), new { id = request.ID_TAREFA },  request );
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Erro: {ex.Message}" });
            }
        }

        // Rota para atualizar um item da lista pelo Id
        [HttpPatch]
        public ActionResult AtualizarTarefa([FromBody] TarefaDTO dto)
        {
            try
            {
                // Identifica a tarefa pelo Id rececbido
                var tarefa = Tarefas.tarefas.Find(x => x.ID_TAREFA == dto.ID_TAREFA);

                // Se o Id não existir retorna a mensagem de "Tarefa não encontrada."
                if (tarefa == null) return NotFound(new { msg = "Tarefa não encontrada." });

                // Modifica a descrição da tarefa, se fornecida
                if (!string.IsNullOrEmpty(dto.DS_TAREFA))
                {
                    tarefa.ID_TAREFA = dto.ID_TAREFA;
                    tarefa.DS_TAREFA = dto.DS_TAREFA;
                }
                // Retorna lista de tarefas
                return Ok(Tarefas.tarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Erro: {ex.Message}" });
            }
        }

        // Usando método DELETE
        [HttpDelete]
        public ActionResult DeletarTarefa([FromQuery] int id)
        {
            try
            {
                // Identifica a tarefa pelo Id rececbido
                var tarefa = Tarefas.tarefas.Find(x => x.ID_TAREFA == id);

                // Se o Id não existir retorna a mensagem de "Tarefa não encontrada."
                if (tarefa == null) return NotFound(new { msg = "Tarefa não encontrada." });

                // Se existir a tarefa é removida de lista
                Tarefas.tarefas.Remove(tarefa);
                return Ok(new { msg = "Tarefa removida com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Erro: {ex.Message}" });
            }
        }
    }
}
