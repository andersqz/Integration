using IntegrationClient.WinForms.Controls;
using IntegrationClient.WinForms.Models;
using IntegrationClient.WinForms.Services;

namespace IntegrationClient.WinForms.Forms;

public partial class MainForm : Form
{
    private readonly ApiIntegrationService _api = new();

    private readonly PainelListaGenerica _painelCliente = new();
    private readonly PainelListaGenerica _painelEmpresa = new();
    private readonly PainelListaGenerica _painelLocal = new();
    private readonly PainelListaGenerica _painelProduto = new();
    private readonly PainelListaGenerica _painelVendedor = new();

    // Guarda quais abas já foram carregadas, pra não buscar da API de novo
    // toda vez que o usuário clica na mesma aba.
    private readonly HashSet<TabPage> _abasCarregadas = new();

    public MainForm()
    {
        InitializeComponent();
        MontarPaineis();
    }

    private void MontarPaineis()
    {
        // Dock.Fill dentro da TabPage faz o painel ocupar toda a área útil da aba.
        _painelCliente.Dock = DockStyle.Fill;
        _painelEmpresa.Dock = DockStyle.Fill;
        _painelLocal.Dock = DockStyle.Fill;
        _painelProduto.Dock = DockStyle.Fill;
        _painelVendedor.Dock = DockStyle.Fill;

        tabCliente.Controls.Add(_painelCliente);
        tabEmpresa.Controls.Add(_painelEmpresa);
        tabLocal.Controls.Add(_painelLocal);
        tabProduto.Controls.Add(_painelProduto);
        tabVendedor.Controls.Add(_painelVendedor);

        ConfigurarCliente();
        ConfigurarEmpresa();
        ConfigurarLocal();
        ConfigurarProduto();
        ConfigurarVendedor();
    }

    private void ConfigurarCliente()
    {
        var colunas = new List<ColunaGrid>
        {
            new("ID", 60, o => ((ClienteDto)o).IdCliente.ToString()),
            new("Nome", 240, o => ((ClienteDto)o).Nome),
            new("CPF/CNPJ", 140, o => ((ClienteDto)o).CpfCnpj),
            new("Telefone", 120, o => ((ClienteDto)o).Telefone),
            new("E-mail", 160, o => ((ClienteDto)o).Email),
        };

        _painelCliente.Configurar(
            colunas: colunas,
            carregarTodosAsync: async () => (await _api.BuscarClientesAsync()).Cast<object>().ToList(),
            combinaComTexto: (o, termo) =>
            {
                var c = (ClienteDto)o;
                return c.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase)
                    || c.CpfCnpj.Contains(termo, StringComparison.OrdinalIgnoreCase);
            },
            obterDetalhesAsync: async o =>
            {
                var c = (ClienteDto)o;
                var d = await _api.BuscarClientePorIdAsync(c.IdCliente);
                if (d is null) return new List<(string, string)>();

                return new List<(string, string)>
                {
                    ("Nome", d.Nome),
                    ("Nome fantasia", d.NomeFantasia),
                    ("CPF/CNPJ", d.CpfCnpj),
                    ("Tipo de pessoa", d.TipoPessoa == 'F' ? "Física" : d.TipoPessoa == 'J' ? "Jurídica" : d.TipoPessoa.ToString()),
                    ("Telefone", d.Telefone),
                    ("E-mail", d.Email),
                    ("Endereço", d.Endereco),
                    ("Bairro", d.Bairro),
                    ("Cidade", d.Cidade),
                    ("CEP", d.CEP),
                    ("Inscrição estadual", d.InscricaoEstadual),
                    ("Data de nascimento", d.DataNascimento.ToString("dd/MM/yyyy")),
                    ("Sexo", d.Sexo ?? "-"),
                };
            },
            tituloDetalhes: "Detalhes do cliente");
    }

    private void ConfigurarEmpresa()
    {
        var colunas = new List<ColunaGrid>
        {
            new("Código", 70, o => ((EmpresaDto)o).CodigoEmpresa.ToString()),
            new("Nome", 260, o => ((EmpresaDto)o).NomeEmpresa),
            new("Tipo", 100, o => ((EmpresaDto)o).TipoEmpresa),
            new("Nome fantasia", 220, o => ((EmpresaDto)o).NomeFantasia),
        };

        _painelEmpresa.Configurar(
            colunas: colunas,
            carregarTodosAsync: async () => (await _api.BuscarEmpresasAsync()).Cast<object>().ToList(),
            combinaComTexto: (o, termo) =>
            {
                var e = (EmpresaDto)o;
                return e.NomeEmpresa.Contains(termo, StringComparison.OrdinalIgnoreCase)
                    || e.NomeFantasia.Contains(termo, StringComparison.OrdinalIgnoreCase);
            },
            obterDetalhesAsync: async o =>
            {
                var e = (EmpresaDto)o;
                var d = await _api.BuscarEmpresaPorIdAsync(e.CodigoEmpresa);
                if (d is null) return new List<(string, string)>();

                return new List<(string, string)>
                {
                    ("Código", d.CodigoEmpresa.ToString()),
                    ("Nome", d.NomeEmpresa),
                    ("Tipo", d.TipoEmpresa),
                    ("Nome fantasia", d.NomeFantasia),
                };
            },
            tituloDetalhes: "Detalhes da empresa");
    }

    private void ConfigurarLocal()
    {
        var colunas = new List<ColunaGrid>
        {
            new("ID", 60, o => ((LocalDto)o).LocalId.ToString()),
            new("Descrição", 220, o => ((LocalDto)o).Descricao),
            new("CNPJ", 140, o => ((LocalDto)o).CNPJ),
            new("UF", 50, o => ((LocalDto)o).UF),
            new("Telefone", 120, o => ((LocalDto)o).Telefone),
        };

        _painelLocal.Configurar(
            colunas: colunas,
            carregarTodosAsync: async () => (await _api.BuscarLocaisAsync()).Cast<object>().ToList(),
            combinaComTexto: (o, termo) =>
            {
                var l = (LocalDto)o;
                return l.Descricao.Contains(termo, StringComparison.OrdinalIgnoreCase)
                    || l.CNPJ.Contains(termo, StringComparison.OrdinalIgnoreCase);
            },
            obterDetalhesAsync: async o =>
            {
                var l = (LocalDto)o;
                var d = await _api.BuscarLocalPorIdAsync(l.LocalId);
                if (d is null) return new List<(string, string)>();

                return new List<(string, string)>
                {
                    ("Descrição", d.Descricao),
                    ("CNPJ", d.CNPJ),
                    ("Inscrição estadual", d.InscricaoEstadual),
                    ("Endereço", d.Endereco),
                    ("Bairro", d.Bairro),
                    ("CEP", d.CEP),
                    ("UF", d.UF),
                    ("Telefone", d.Telefone),
                    ("E-mail", d.Email),
                };
            },
            tituloDetalhes: "Detalhes do local");
    }

    private void ConfigurarProduto()
    {
        var colunas = new List<ColunaGrid>
        {
            new("ID", 90, o => ((ProdutoDto)o).IdProduto),
            new("EAN", 130, o => ((ProdutoDto)o).CodigoEAN),
            new("Descrição", 260, o => ((ProdutoDto)o).Descricao),
            new("Fora de linha", 90, o => ((ProdutoDto)o).ForaDeLinha ? "Sim" : "Não"),
        };

        _painelProduto.Configurar(
            colunas: colunas,
            carregarTodosAsync: async () => (await _api.BuscarProdutosAsync()).Cast<object>().ToList(),
            combinaComTexto: (o, termo) =>
            {
                var p = (ProdutoDto)o;
                return p.Descricao.Contains(termo, StringComparison.OrdinalIgnoreCase)
                    || p.IdProduto.Contains(termo, StringComparison.OrdinalIgnoreCase)
                    || p.CodigoEAN.Contains(termo, StringComparison.OrdinalIgnoreCase);
            },
            obterDetalhesAsync: async o =>
            {
                var p = (ProdutoDto)o;

                // IdProduto chega como string da API (CAST no SQL), mas a rota
                // GetById(int id) espera número - por isso o parse aqui.
                if (!int.TryParse(p.IdProduto, out int id))
                    return new List<(string, string)>();

                var d = await _api.BuscarProdutoPorIdAsync(id);
                if (d is null) return new List<(string, string)>();

                return new List<(string, string)>
                {
                    ("Descrição", d.Descricao),
                    ("Descrição reduzida", d.DescricaoReduzida),
                    ("Código EAN", d.CodigoEAN),
                    ("Grupo", d.CodigoGrupo.ToString()),
                    ("Subgrupo", d.CodigoSubgrupo.ToString()),
                    ("Marca", d.CodigoMarca.ToString()),
                    ("Fornecedor principal", d.CodigoPrincipalFornecedor.ToString()),
                    ("Unidade de medida", d.UnidadeMedida),
                    ("Peso bruto", d.PesoBruto.ToString("N3")),
                    ("Peso líquido", d.PesoLiquido.ToString("N3")),
                    ("Fora de linha", d.ForaDeLinha ? "Sim" : "Não"),
                    ("Controla estoque", d.ControlaEstoque ? "Sim" : "Não"),
                    ("Disponível internet", d.DisponivelInternet ? "Sim" : "Não"),
                    ("Data de cadastro", d.DataCadastro.ToString("dd/MM/yyyy")),
                    ("Data de alteração", d.DataAlteracao.ToString("dd/MM/yyyy")),
                    ("NCM", d.Ncm),
                    ("CST", d.Cst),
                    ("CEST", d.Cest),
                    ("Origem da mercadoria", d.OrigemMercadoria.ToString()),
                    ("Preço pauta (ICMS ST)", d.PrecoPauta.ToString("C2")),
                };
            },
            tituloDetalhes: "Detalhes do produto");
    }

    private void ConfigurarVendedor()
    {
        var colunas = new List<ColunaGrid>
        {
            new("ID", 60, o => ((VendedorDto)o).VendedorId.ToString()),
            new("Nome", 240, o => ((VendedorDto)o).Nome),
            new("Tipo", 60, o => ((VendedorDto)o).Tipo.ToString()),
            new("Ativo", 60, o => ((VendedorDto)o).VendedorAtivo ? "Sim" : "Não"),
            new("CPF/CNPJ", 140, o => ((VendedorDto)o).CpfCnpj),
            new("Telefone", 120, o => ((VendedorDto)o).Telefone),
        };

        _painelVendedor.Configurar(
            colunas: colunas,
            carregarTodosAsync: async () => (await _api.BuscarVendedoresAsync()).Cast<object>().ToList(),
            combinaComTexto: (o, termo) =>
            {
                var v = (VendedorDto)o;
                return v.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase)
                    || v.CpfCnpj.Contains(termo, StringComparison.OrdinalIgnoreCase);
            },
            obterDetalhesAsync: async o =>
            {
                var v = (VendedorDto)o;
                var d = await _api.BuscarVendedorPorIdAsync(v.VendedorId);
                if (d is null) return new List<(string, string)>();

                return new List<(string, string)>
                {
                    ("Nome", d.Nome),
                    ("Tipo", d.Tipo.ToString()),
                    ("Ativo", d.VendedorAtivo ? "Sim" : "Não"),
                    ("Calcula comissão", d.CalculaComissao ? "Sim" : "Não"),
                    ("Percentual de comissão", d.PercentualComissao.ToString("N2") + "%"),
                    ("Percentual máx. comissão", d.PercMaximoComissao.ToString("N2") + "%"),
                    ("Percentual máx. desconto", d.PercMaximoDesc.ToString("N2") + "%"),
                    ("Tipo de pessoa", d.TipoPessoa),
                    ("CPF/CNPJ", d.CpfCnpj),
                    ("Endereço", d.Endereco),
                    ("CEP", d.CEP),
                    ("Telefone", d.Telefone),
                    ("E-mail", d.Email),
                };
            },
            tituloDetalhes: "Detalhes do vendedor");
    }

    // Ao abrir a janela, carrega só a primeira aba (Clientes) - as outras
    // carregam sob demanda quando o usuário clicar nelas (ver abaixo).
    private async void MainForm_Load(object? sender, EventArgs e)
    {
        await CarregarAbaAtualSeNecessario();
    }

    private async void TabPrincipal_SelectedIndexChanged(object? sender, EventArgs e)
    {
        await CarregarAbaAtualSeNecessario();
    }

    private async Task CarregarAbaAtualSeNecessario()
    {
        var abaAtual = tabPrincipal.SelectedTab;
        if (abaAtual is null || _abasCarregadas.Contains(abaAtual)) return;

        _abasCarregadas.Add(abaAtual);

        var painel = abaAtual.Controls.OfType<PainelListaGenerica>().FirstOrDefault();
        if (painel is not null)
            await painel.CarregarAsync();
    }
}
