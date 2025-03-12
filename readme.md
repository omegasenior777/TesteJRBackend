# API ToDo - Documentação

## Descrição
Esta API permite a criação, leitura, atualização e remoção de tarefas. Ela foi desenvolvida utilizando **ASP.NET Core** e segue boas práticas de desenvolvimento de APIs RESTful.

## Tecnologias Utilizadas
- .NET 5+
- ASP.NET Core
- C#

## Como Executar o Projeto
### **Requisitos**
- .NET 5 ou superior instalado
- Editor de código como Visual Studio ou VS Code

### **Passos para execução**
1. Clone o repositório:
   ```sh
   git clone https://github.com/seu-repositorio/apiToDo.git
   ```
2. Acesse a pasta do projeto:
   ```sh
   cd apiToDo
   ```
3. Execute o projeto:
   ```sh
   dotnet run
   ```
4. Acesse a API via navegador ou ferramenta como Postman:
   ```sh
   http://localhost:5000/v1/tarefas
   ```

---

## **Rotas da API**

### **Listar todas as tarefas**
- **Endpoint:** `GET /v1/tarefas`
- **Retorno:**
  ```json
  [
    {
      "iD_TAREFA": 1,
      "dS_TAREFA": "Fazer Compras"
    },
    {
      "iD_TAREFA": 2,
      "dS_TAREFA": "Fazer Atividade da Faculdade"
    },
    {
      "iD_TAREFA": 3,
      "dS_TAREFA": "Subir Projeto de Teste no GitHub"
    }
  ]
  ```

### **Listar uma tarefa pelo ID**
- **Endpoint:** `GET /v1/tarefas/{id}`
- **Exemplo de Resposta:**
  ```json
  {
    "ID_TAREFA": 1,
    "DS_TAREFA": "Minha primeira tarefa"
  }
  ```

### **Criar uma nova tarefa**
- **Endpoint:** `POST /v1/tarefas`
- **Body:**
  ```json
  {
    "DS_TAREFA": "Nova tarefa"
  }
  ```
- **Resposta:**
  ```json
  {
    "ID_TAREFA": 4,
    "DS_TAREFA": "Nova tarefa"
  }
  ```
- **Status HTTP:** `201 Created`

### **Atualizar uma tarefa existente**
- **Endpoint:** `PATCH /v1/tarefas`
- **Body:**
  ```json
  {
    "ID_TAREFA": 1,
    "DS_TAREFA": "Tarefa atualizada"
  }
  ```
- **Resposta:**
  ```json
  [
    {
      "ID_TAREFA": 1,
      "DS_TAREFA": "Tarefa atualizada"
    }
  ]
  ```

### **Excluir uma tarefa pelo ID**
- **Endpoint:** `DELETE /v1/tarefas?id={id}`
- **Resposta:**
  ```json
  {
    "msg": "Tarefa removida com sucesso!"
  }
  ```

