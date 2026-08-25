namespace IntegrationClient.WinForms.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private TabControl tabPrincipal;
    private TabPage tabCliente;
    private TabPage tabEmpresa;
    private TabPage tabLocal;
    private TabPage tabProduto;
    private TabPage tabVendedor;

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
        tabPrincipal = new TabControl();
        tabCliente = new TabPage();
        tabEmpresa = new TabPage();
        tabLocal = new TabPage();
        tabProduto = new TabPage();
        tabVendedor = new TabPage();
        SuspendLayout();

        tabCliente.Text = "Clientes";
        tabCliente.Padding = new Padding(6);
        tabEmpresa.Text = "Empresas";
        tabEmpresa.Padding = new Padding(6);
        tabLocal.Text = "Locais";
        tabLocal.Padding = new Padding(6);
        tabProduto.Text = "Produtos";
        tabProduto.Padding = new Padding(6);
        tabVendedor.Text = "Vendedores";
        tabVendedor.Padding = new Padding(6);

        // Dock.Fill = "ocupa todo o espaço disponível do pai". É o equivalente
        // WinForms de width:100%; height:100% no CSS.
        tabPrincipal.Dock = DockStyle.Fill;
        tabPrincipal.Controls.Add(tabCliente);
        tabPrincipal.Controls.Add(tabEmpresa);
        tabPrincipal.Controls.Add(tabLocal);
        tabPrincipal.Controls.Add(tabProduto);
        tabPrincipal.Controls.Add(tabVendedor);
        // Disparado toda vez que o usuário troca de aba - usamos isso pra
        // carregar os dados de cada aba só na primeira vez que ela é aberta.
        tabPrincipal.SelectedIndexChanged += TabPrincipal_SelectedIndexChanged;

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(960, 560);
        Controls.Add(tabPrincipal);
        MinimumSize = new Size(700, 400);
        Name = "MainForm";
        Text = "Integration.Api - Cadastros";
        Load += MainForm_Load;

        ResumeLayout(false);
    }
}
