namespace IntegrationClient.WinForms.Forms;

public partial class FormDetalhesGenerico : Form
{
    // Recebe o título e uma lista de pares (rótulo, valor) já prontos - quem
    // decide QUAIS campos mostrar e QUAL o texto de cada um é o código que
    // chamou esse form (a configuração de cada entidade, no MainForm), não
    // este arquivo. Este form só sabe desenhar pares de texto numa tabela.
    public FormDetalhesGenerico(string titulo, List<(string Rotulo, string Valor)> campos)
    {
        InitializeComponent();

        Text = titulo;
        lblTitulo.Text = titulo;

        foreach (var (rotulo, valor) in campos)
        {
            AdicionarLinha(rotulo, valor);
        }
    }

    private void AdicionarLinha(string rotulo, string valor)
    {
        int linha = painelCampos.RowCount;
        painelCampos.RowCount = linha + 1;
        painelCampos.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        var lblRotulo = new Label
        {
            Text = rotulo,
            AutoSize = true,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            Margin = new Padding(3, 6, 3, 6)
        };

        var lblValor = new Label
        {
            Text = string.IsNullOrWhiteSpace(valor) ? "-" : valor,
            AutoSize = true,
            Margin = new Padding(3, 6, 3, 6)
        };

        painelCampos.Controls.Add(lblRotulo, 0, linha);
        painelCampos.Controls.Add(lblValor, 1, linha);
    }
}
