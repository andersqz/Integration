namespace Integration.Application.Dtos
{
    public class PaginacaoDto<T>
    {
        public IEnumerable<T> Itens { get; set; } = Enumerable.Empty<T>();
        public int PaginaAtual { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas => (int)Math.Ceiling(TotalRegistros / (double)TamanhoPagina);
    }
}