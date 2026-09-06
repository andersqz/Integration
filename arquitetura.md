Análise completa do projeto Integration. Resumo:
Visão geral
API REST somente leitura que expõe dados de um sistema legado SQL Anywhere 12 via HTTP. Formato .slnx (requires SDK .NET 9+), mas todos os 4 projetos compilam para net8.0.
Arquitetura (camadas, inspirada em Clean Architecture)
- Integration.Domain — entidades anêmicas, interfaces de repositório, exceções (NotFoundException→404, RuleBusinessException→409, AppException). Zero dependências.
- Integration.Application — service layer clássico (10 interfaces + 10 serviços), DTOs, mapeamento manual, helper Util (datas do legado como int baseado em 1800-12-28).
- Integration.Infra — Dapper 2.1.79 + ODBC (DSN ABSGESTOR), 12 repositórios com SQL puro, aliases CLI001 AS ..., SET ROWCOUNT para limitar listagens, suporte à sintaxe SQL Anywhere (SELECT TOP ? START AT ?) na paginação de produtos.
- Integration.Api — 10 controllers GET, DI nativa (Program.cs), GlobalExceptionHandler (IExceptionHandler do .NET 8), Swagger.
Endpoints
- 9 recursos com GET /api/{recurso} e GET /api/{recurso}/{id} (clientes, empresas, fornecedores, locais, operações fiscais, produtos, séries fiscais, transportadoras, vendedores).
- GET /api/produto — único com paginação (Pagina, TamanhoPagina máx. 200).
- GET /api/pedido/{empresa}/{local}/{serie}/{data}/{doc} — rota composta, agrega cabeçalho + itens.
Pontos de atenção
1. Credenciais em texto puro no appsettings.json (UID=***REMOVIDO***;PWD=***REMOVIDO***).
2. Sem autenticação real — UseAuthorization() sem schemes.
3. Sem CORS, health checks, versionamento, caching, testes, Docker, CI.
4. obj/ commitados no git (higiene de repo).
5. README desatualizado — diz que GET /api/seriefiscal/{serie} retorna 200 sem corpo, mas o código retorna Ok(serieFiscal).
6. .slnx + net8.0 — sem global.json fixando o SDK 9+.