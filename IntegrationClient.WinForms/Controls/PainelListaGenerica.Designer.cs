namespace IntegrationClient.WinForms.Controls;

// UserControl é como um Form, mas em vez de ser uma janela, é um "pedaço de
// tela" que você encaixa dentro de outro container - no nosso caso, dentro
// de cada TabPage do MainForm. A lógica de eventos (Click, CellDoubleClick,
// KeyDown) é IDÊNTICA à de um Form - só muda que aqui vive dentro de outra janela.
partial class PainelListaGenerica
{
    private System.ComponentModel.IContainer components = null;

    private TextBox txtBusca;
    private Button btnBuscar;
    private Button btnAtualizar;
    private DataGridView dgv;
    private Label lblStatus;

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
        txtBusca = new TextBox();
        btnBuscar = new Button();
        btnAtualizar = new Button();
        dgv = new DataGridView();
        lblStatus = new Label();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        SuspendLayout();

        txtBusca.Location = new Point(8, 8);
        txtBusca.Name = "txtBusca";
        txtBusca.PlaceholderText = "Buscar...";
        txtBusca.Size = new Size(300, 27);
        txtBusca.KeyDown += TxtBusca_KeyDown;

        btnBuscar.Location = new Point(314, 7);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new Size(90, 29);
        btnBuscar.Text = "Buscar";
        btnBuscar.UseVisualStyleBackColor = true;
        btnBuscar.Click += BtnBuscar_Click;

        btnAtualizar.Location = new Point(410, 7);
        btnAtualizar.Name = "btnAtualizar";
        btnAtualizar.Size = new Size(110, 29);
        btnAtualizar.Text = "Recarregar";
        btnAtualizar.UseVisualStyleBackColor = true;
        btnAtualizar.Click += BtnAtualizar_Click;

        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.ReadOnly = true;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.MultiSelect = false;
        dgv.AutoGenerateColumns = false; // as colunas são criadas por nós via ColunaGrid, não por reflexão
        dgv.Location = new Point(8, 46);
        dgv.Name = "dgv";
        dgv.Size = new Size(900, 420);
        dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgv.CellDoubleClick += Dgv_CellDoubleClick;

        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(8, 472);
        lblStatus.Name = "lblStatus";
        lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

        Controls.Add(lblStatus);
        Controls.Add(dgv);
        Controls.Add(btnAtualizar);
        Controls.Add(btnBuscar);
        Controls.Add(txtBusca);
        Name = "PainelListaGenerica";
        Size = new Size(920, 500);

        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
