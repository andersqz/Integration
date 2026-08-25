namespace IntegrationClient.WinForms.Models;

// Em vez de usar DataPropertyName (que exige uma lista fortemente tipada,
// tipo List<ClienteDto>), aqui cada coluna carrega sua própria "receita" de
// como extrair o texto a partir de QUALQUER objeto (ClienteDto, ProdutoDto,
// não importa). Isso é o que permite a mesma grade genérica servir pra
// Cliente, Empresa, Local, Produto e Vendedor sem repetir código de UI.
public class ColunaGrid
{
    public string Titulo { get; }
    public int Largura { get; }
    public Func<object, string> ObterValor { get; }

    public ColunaGrid(string titulo, int largura, Func<object, string> obterValor)
    {
        Titulo = titulo;
        Largura = largura;
        ObterValor = obterValor;
    }
}
