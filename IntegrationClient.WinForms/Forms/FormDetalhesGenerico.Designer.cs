namespace IntegrationClient.WinForms.Forms;

partial class FormDetalhesGenerico
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitulo;
    private TableLayoutPanel painelCampos;
    private Button btnFechar;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        painelCampos = new TableLayoutPanel();
        btnFechar = new Button();
        SuspendLayout();

        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblTitulo.Location = new Point(16, 12);
        lblTitulo.Name = "lblTitulo";

        // Aqui NÃO criamos as linhas (rótulo + valor) no Designer, como fizemos
        // na primeira versão do FormDetalhesCliente. As linhas são adicionadas
        // em tempo de execução (no FormDetalhesGenerico.cs), porque cada
        // entidade tem um conjunto diferente de campos - Cliente tem CEP,
        // Empresa não tem. O Designer só prepara o "container" vazio.
        painelCampos.ColumnCount = 2;
        painelCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
        painelCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        painelCampos.Location = new Point(16, 50);
        painelCampos.Name = "painelCampos";
        painelCampos.AutoSize = true;
        painelCampos.AutoScroll = true;
        painelCampos.Size = new Size(500, 400);
        painelCampos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

        btnFechar.Location = new Point(16, 460);
        btnFechar.Name = "btnFechar";
        btnFechar.Size = new Size(100, 30);
        btnFechar.Text = "Fechar";
        btnFechar.UseVisualStyleBackColor = true;
        btnFechar.DialogResult = DialogResult.Cancel;
        btnFechar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(536, 510);
        Controls.Add(btnFechar);
        Controls.Add(painelCampos);
        Controls.Add(lblTitulo);
        MinimumSize = new Size(420, 350);
        Name = "FormDetalhesGenerico";
        StartPosition = FormStartPosition.CenterParent;
        CancelButton = btnFechar;

        ResumeLayout(false);
        PerformLayout();
    }
}
