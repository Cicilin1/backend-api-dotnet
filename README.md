# API-.NET

Uma API REST simples feita com ASP.NET Core para realizar operações de **CREATE**, **READ**, **UPDATE** e **DELETE** dados.

---

## Tecnologias

- ASP.NET Core
- Entity Framework Core
- SQL Server
---

## ▶ Como rodar o projeto

### Pré-requisitos

- .NET SDK instalado (recomendo a versão 7.0 ou superior)
- SQL Server ou outro banco de dados relacional

### Passos para executar:

```bash
# 1. Clone o repositório
git clone [https://github.com/seu-usuario/nome-do-repo.git](https://github.com/Cicilin1/backend-api-dotnet.git)

# 2. Acesse a pasta do projeto
cd nome-do-repo

# 3. Restaure os pacotes
dotnet restore

# 4. Crie o banco de dados (se não existir) e aplique as migrations
dotnet ef database update

# 5. Rode o projeto
dotnet run
```

### Rotas principais

- **POST**    "/student" – Cria um novo estudante se o nome ainda não existir.
- **GET**     "/student" – Retorna a lista de estudantes ativos.
- **PUT**     "/student/{id}" – Atualiza o nome de um estudante pelo ID.
- **DELETE**  "/student/{id}" – Desativa (não remove) um estudante pelo ID.


## Autor

**Guilherme Cicilini**  
[LinkedIn](https://www.linkedin.com/in/guilherme-cicilini/) • [Github](https://github.com/Cicilin1)

