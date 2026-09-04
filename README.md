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

Não são utilizados Entity Framework Core, `DbContext` ou migrations; o acesso ao banco é feito diretamente por SQL e Dapper.

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

### `Integration.Api`

É a camada de entrada da aplicação:

- configura o pipeline HTTP e a injeção de dependências em `Program.cs`;
- expõe os controllers REST;
- habilita Swagger somente no ambiente `Development`;
- aplica redirecionamento HTTPS e autorização;
- usa `GlobalExceptionHandler` para converter exceções em respostas `ProblemDetails`.

### `Integration.Application`

Contém os casos de uso da aplicação, sem conhecer detalhes de ODBC:

- interfaces de serviço (`IClienteService`, `IPedidoService` etc.);
- implementações dos serviços;
- DTOs de listagem e detalhe;
- mapeamento de entidades para contratos HTTP;
- conversão das datas numéricas do legado para `DateOnly`.

Os serviços chamam interfaces do domínio e concentram regras como composição do cabeçalho e dos itens de um pedido.

Na consulta detalhada de produtos, o serviço combina os dados básicos do produto com os dados fiscais. Na consulta detalhada de pedidos, combina o cabeçalho com seus itens.

### `Integration.Domain`

É o núcleo do modelo:

- entidades como `Cliente`, `Produto`, `Pedido`, `PedidoItem`, `Empresa`, `Fornecedor`, `Local`, `OperacaoFiscal`, `SerieFiscal`, `Transportadora` e `Vendedor`;
- interfaces dos repositórios;
- exceções de domínio (`NotFoundException`, `RuleBusinessException` e `AppException`).

Essa camada não depende de infraestrutura ou de ASP.NET Core.

### `Integration.Infra`

Implementa a persistência e a integração com o legado:

- `OdbcConnectionFactory` abre conexões usando a string configurada;
- repositórios executam SQL parametrizado com Dapper;
- aliases SQL convertem nomes de colunas legadas (por exemplo, `CLI001`) para propriedades das entidades;
- as consultas usam `SET ROWCOUNT` para limitar algumas listagens.

## Recursos e endpoints

Todos os endpoints usam o prefixo `/api` e retornam JSON.

| Recurso | Listagem | Consulta individual |
| --- | --- | --- |
| Clientes | `GET /api/cliente` | `GET /api/cliente/{id}` |
| Empresas | `GET /api/empresa` | `GET /api/empresa/{id}` |
| Fornecedores | `GET /api/fornecedor` | `GET /api/fornecedor/{id}` |
| Locais | `GET /api/local` | `GET /api/local/{id}` |
| Produtos | `GET /api/produto` | `GET /api/produto/{id}` |
| Operações fiscais | `GET /api/operacaofiscal` | `GET /api/operacaofiscal/{id}` |
| Séries fiscais | `GET /api/seriefiscal` | `GET /api/seriefiscal/{serie}` |
| Transportadoras | `GET /api/transportadora` | `GET /api/transportadora/{id}` |
| Vendedores | `GET /api/vendedor` | `GET /api/vendedor/{id}` |
| Pedidos | `GET /api/pedido` | `GET /api/pedido/{empresa}/{local}/{serie}/{data}/{doc}` |

No pedido, `data` é vinculada ao parâmetro `DateOnly` e deve ser enviada em formato compatível com o model binder do ASP.NET Core, normalmente `yyyy-MM-dd`.

As listagens retornam DTOs resumidos. As consultas individuais retornam DTOs com mais detalhes; para pedidos, a resposta também agrega os itens consultados na tabela `GES_235`.

## Mapeamento do legado

| Domínio | Tabela consultada |
| --- | --- |
| Clientes | `GES_040` |
| Empresas | `EMPRESAS` |
| Locais | `GES_008` |
| Séries fiscais | `GES_063` |
| Operações fiscais | `GES_064` |
| Produtos e dados fiscais | `GES_080` |
| Fornecedores | `GES_042` |
| Vendedores | `GES_068` |
| Transportadoras | `GES_074` |
| Pedidos - cabeçalho | `GES_230` |
| Pedidos - itens | `GES_235` |

```

Com o perfil `https`, a configuração atual usa:

- Swagger: `https://localhost:7010/swagger`
- HTTP: `http://localhost:5028`

O Swagger é registrado apenas quando `ASPNETCORE_ENVIRONMENT=Development`.

## Fluxo de uma requisição

1. O controller recebe e valida os parâmetros HTTP.
2. O controller chama a interface do serviço da aplicação.
3. O serviço chama uma ou mais interfaces de repositório.
4. O repositório abre uma conexão pela `IDbConnectionFactory`.
5. O Dapper executa a consulta parametrizada no SQL Anywhere via ODBC.
6. O serviço mapeia a entidade para um DTO.
7. A API retorna `200 OK`, `404 Not Found` ou o erro padronizado correspondente.

## Tratamento de erros

O middleware global retorna `ProblemDetails` com `status`, `title`, `detail` e `instance`:

- `NotFoundException` resulta em `404`;
- `RuleBusinessException` resulta em `409`;
- outras exceções resultam em `500` e são registradas no log.

## Estrutura do repositório

```text
Integration.slnx
├── Integration.Api
│   ├── Controllers
│   ├── Middlewares
│   └── Program.cs
├── Integration.Application
│   ├── Dtos
│   ├── Interfaces
│   ├── Services
│   └── Utils
├── Integration.Domain
│   ├── Entities
│   ├── Exceptions
│   └── Interfaces
├── Integration.Infra
│   ├── Data
│   └── Repositories
└── DCT_Dicionário de Dados 31.2.docx.pdf
```

## Estado atual e próximos passos

- Não foram encontrados projetos de testes automatizados, arquivos Docker ou pipelines de CI no repositório.
- Não há autenticação configurada atualmente; `UseAuthorization()` está presente, mas não existem esquemas/policies registrados.
- Não há CORS, health checks, versionamento de API ou paginação por parâmetros HTTP configurados.
- As listagens possuem limites definidos diretamente nas consultas (`ROWCOUNT`), sem paginação via parâmetros HTTP.
- O endpoint de séries fiscais executa a busca, mas atualmente retorna `200 OK` sem incluir o resultado no corpo; esse comportamento deve ser revisado antes de tratá-lo como contrato público.
- Recomenda-se manter credenciais fora do controle de versão, adicionar testes de integração contra um ambiente controlado e documentar a versão/driver ODBC utilizado em cada ambiente.

## Licença

Nenhuma licença foi definida no repositório até o momento.
