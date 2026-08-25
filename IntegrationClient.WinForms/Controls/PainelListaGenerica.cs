using IntegrationClient.WinForms.Forms;
using IntegrationClient.WinForms.Models;

namespace IntegrationClient.WinForms.Controls;

public partial class PainelListaGenerica : UserControl
{
    // As 5 "regras de negócio" que mudam de entidade pra entidade ficam guardadas
    // aqui como delegates (funções passadas como valor). O painel em si não sabe
    // o que é um "Cliente" ou um "Produto" - ele só sabe chamar essas funções
    // no momento certo. Isso é o que permite reaproveitar o mesmo painel 5 vezes.
    private List<ColunaGrid> _colunas = new();
    private Func<Task<List<object>>>? _carregarTodosAsync;
    private Func<object, string, bool>? _combinaComTexto;
    private Func<object, Task<List<(string Rotulo, string Valor)>>>? _obterDetalhesAsync;
    private string _tituloDetalhes = "Detalhes";

    private List<object> _itensCompletos = new();

    public PainelListaGenerica()
    {
        InitializeComponent();
    }

    // Chamado uma vez, logo depois de criar o painel (no MainForm), pra "ensinar"
    // pra ele como buscar e exibir os dados de uma entidade específica.
    public void Configurar(
        List<ColunaGrid> colunas,
        Func<Task<List<object>>> carregarTodosAsync,
        Func<object, string, bool> combinaComTexto,
        Func<object, Task<List<(string Rotulo, string Valor)>>> obterDetalhesAsync,
        string tituloDetalhes)
    {
        _colunas = colunas;
        _carregarTodosAsync = carregarTodosAsync;
        _combinaComTexto = combinaComTexto;
        _obterDetalhesAsync = obterDetalhesAsync;
        _tituloDetalhes = tituloDetalhes;

        dgv.Columns.Clear();
        foreach (var coluna in _colunas)
        {
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = coluna.Titulo,
                Width = coluna.Largura,
                ReadOnly = true
            });
        }
    }

    // Chamado pelo MainForm depois de Configurar(), pra disparar a primeira
    // carga de dados (equivalente ao que o evento Load fazia no FormListaClientes).
    public async Task CarregarAsync()
    {
        if (_carregarTodosAsync is null) return;

        try
        {
            lblStatus.Text = "Carregando...";
            dgv.Enabled = false;

            _itensCompletos = await _carregarTodosAsync();
            PreencherGrid(_itensCompletos);
            lblStatus.Text = $"{_itensCompletos.Count} registro(s) carregado(s).";
        }
        catch (HttpRequestException)
        {
            lblStatus.Text = "Não foi possível conectar à API.";
            MessageBox.Show(
                "Não consegui conectar à Integration.Api em http://localhost:5028.\n" +
                "Confirme se ela está rodando.",
                "Erro de conexão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            dgv.Enabled = true;
        }
    }

    private async void BtnAtualizar_Click(object? sender, EventArgs e)
    {
        txtBusca.Clear();
        await CarregarAsync();
    }

    private void BtnBuscar_Click(object? sender, EventArgs e) => AplicarFiltro();

    private void TxtBusca_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            AplicarFiltro();
        }
    }

    private void AplicarFiltro()
    {
        var termo = txtBusca.Text.Trim();

        if (string.IsNullOrEmpty(termo) || _combinaComTexto is null)
        {
            PreencherGrid(_itensCompletos);
            return;
        }

        var filtrados = _itensCompletos.Where(item => _combinaComTexto(item, termo)).ToList();
        PreencherGrid(filtrados);
        lblStatus.Text = $"{filtrados.Count} resultado(s) para \"{termo}\".";
    }

    private void PreencherGrid(List<object> itens)
    {
        dgv.Rows.Clear();

        foreach (var item in itens)
        {
            // Pra cada item, calculamos o texto de cada coluna chamando a receita
            // (ObterValor) que veio configurada em ColunaGrid.
            var valores = _colunas.Select(c => (object)c.ObterValor(item)).ToArray();
            int indiceLinha = dgv.Rows.Add(valores);

            // Tag é uma propriedade "livre" que todo controle WinForms tem, pra
            // guardar qualquer objeto associado. Aqui guardamos o item ORIGINAL
            // (ClienteDto, ProdutoDto, etc.) por trás da linha, pra recuperar no duplo clique.
            dgv.Rows[indiceLinha].Tag = item;
        }
    }

    // Mesmo padrão do DgvClientes_CellDoubleClick que você já viu: RowIndex < 0
    // quando o clique cai no cabeçalho, senão pega o item guardado no Tag.
    private async void Dgv_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || _obterDetalhesAsync is null) return;

        var item = dgv.Rows[e.RowIndex].Tag;
        if (item is null) return;

        try
        {
            Cursor = Cursors.WaitCursor;
            var campos = await _obterDetalhesAsync(item);

            if (campos.Count == 0)
            {
                MessageBox.Show("Registro não encontrado.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var formDetalhes = new FormDetalhesGenerico(_tituloDetalhes, campos);
            formDetalhes.ShowDialog(FindForm()); // FindForm() = a janela (Form) que hospeda este UserControl
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }
}
