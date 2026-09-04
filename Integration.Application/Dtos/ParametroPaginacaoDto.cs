namespace Integration.Application.Dtos
{
    public class ParametrosPaginacaoDto
    {
        private const int TamanhoMaximo = 200;

        private int _tamanhoPagina = 50;
        private int _pagina = 1;

        public int Pagina
        {
            get
            {
                return _pagina;
            }
            set
            {
                if (value < 1)
                {
                    _pagina = 1;
                }
                else
                {
                    _pagina = value;
                }
            }
        }

        public int TamanhoPagina
        {
            get
            {
                return _tamanhoPagina;
            }
            set
            {
                if (value < 1)
                {
                    _tamanhoPagina = 50;
                }
                else if (value > TamanhoMaximo)
                {
                    _tamanhoPagina = TamanhoMaximo;
                }
                else
                {
                    _tamanhoPagina = value;
                }
            }
        }
    }
}