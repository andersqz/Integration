using System.Net.Http.Json;
using IntegrationClient.WinForms.Models;

namespace IntegrationClient.WinForms.Services;

// Um HttpClient só, reaproveitado pra todas as entidades - criar um HttpClient
// por chamada é um erro comum em .NET (esgota conexões TCP sob carga). Aqui a
// instância vive pelo tempo de vida do MainForm inteiro.
public class ApiIntegrationService
{
    private readonly HttpClient _http;

    public ApiIntegrationService()
    {
        _http = new HttpClient
        {
            // Porta do profile "http" do seu launchSettings.json.
            BaseAddress = new Uri("http://localhost:5028/")
        };
    }

    // ---------- Cliente ----------
    public Task<List<ClienteDto>> BuscarClientesAsync() => GetListaAsync<ClienteDto>("api/cliente");
    public Task<ClienteDetalhesDto?> BuscarClientePorIdAsync(int id) => GetPorIdAsync<ClienteDetalhesDto>($"api/cliente/{id}");

    // ---------- Empresa ----------
    public Task<List<EmpresaDto>> BuscarEmpresasAsync() => GetListaAsync<EmpresaDto>("api/empresa");
    public Task<EmpresaDto?> BuscarEmpresaPorIdAsync(int id) => GetPorIdAsync<EmpresaDto>($"api/empresa/{id}");

    // ---------- Local ----------
    public Task<List<LocalDto>> BuscarLocaisAsync() => GetListaAsync<LocalDto>("api/local");
    public Task<LocalDto?> BuscarLocalPorIdAsync(int id) => GetPorIdAsync<LocalDto>($"api/local/{id}");

    // ---------- Produto ----------
    public Task<List<ProdutoDto>> BuscarProdutosAsync() => GetListaAsync<ProdutoDto>("api/produto");
    public Task<ProdutoDetalhesDto?> BuscarProdutoPorIdAsync(int id) => GetPorIdAsync<ProdutoDetalhesDto>($"api/produto/{id}");

    // ---------- Vendedor ----------
    public Task<List<VendedorDto>> BuscarVendedoresAsync() => GetListaAsync<VendedorDto>("api/vendedor");
    public Task<VendedorDetalhesDto?> BuscarVendedorPorIdAsync(int id) => GetPorIdAsync<VendedorDetalhesDto>($"api/vendedor/{id}");

    // As 5 rotas de "listar todos" têm a mesma forma (GET -> array JSON), então
    // um único método genérico<T> resolve todas. O "T" aqui é só "qual classe
    // usar pra desserializar" - o comportamento HTTP é idêntico pra qualquer entidade.
    private async Task<List<T>> GetListaAsync<T>(string rota)
    {
        var itens = await _http.GetFromJsonAsync<List<T>>(rota);
        return itens ?? new List<T>();
    }

    // Mesma ideia pro "buscar por id": todas as rotas devolvem 404 quando não
    // existe, e aqui isso vira "null" em vez de exceção - quem chama decide
    // como avisar o usuário.
    private async Task<T?> GetPorIdAsync<T>(string rota) where T : class
    {
        var response = await _http.GetAsync(rota);
        if (!response.IsSuccessStatusCode) return null;
        return await response.Content.ReadFromJsonAsync<T>();
    }
}
