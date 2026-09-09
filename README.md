# Integration API

API REST para integração e consulta de dados de um sistema legado em **SQL Anywhere 12**, disponibilizando clientes, produtos, pedidos, empresas e demais cadastros por HTTP.

O projeto foi construído com **ASP.NET Core 8**, seguindo uma separação em camadas e usando **ODBC** para conexão com o banco legado. A API atualmente é somente leitura: não há endpoints de criação, alteração ou exclusão.

## Tecnologias

| Tecnologia | Uso |
| --- | --- |
| .NET 8 / ASP.NET Core | Runtime e framework da API REST |
| C# | Linguagem da aplicação |
| ASP.NET Core MVC Controllers | Definição dos endpoints HTTP |
| Dapper 2.1.79 | Micro-ORM para execução e mapeamento das consultas SQL |
| System.Data.Odbc 8.0 | Conexão com o banco legado por ODBC |
| SQL Anywhere 12 | Banco de dados legado consultado pela aplicação |
| Swashbuckle.AspNetCore 6.6.2 | Geração da especificação e interface Swagger/OpenAPI |
| Injeção de dependência nativa | Registro de serviços, repositórios e fábrica de conexões |
| ProblemDetails | Formato padronizado para respostas de erro |


## Arquitetura e camadas

```text
Cliente HTTP
    |
    v
Integration.Api
  Controllers + middleware de exceções
    |
    v
Integration.Application
  Services + DTOs + interfaces de serviço
    |
    v
Integration.Domain
  Entidades + interfaces de repositório + exceções de domínio
    ^
    |
Integration.Infra
  Repositórios Dapper + fábrica de conexão ODBC
    |
    v
SQL Anywhere 12 (DSN ODBC)
```

