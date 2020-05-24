
namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            this.Pecas = new Peca[this.Linhas, this.Colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return this.Pecas[linha, coluna];
        }

        public Peca peca(Posicao posicao)
        {
            return this.Pecas[posicao.Linha, posicao.Coluna];
        }

        public bool existePeca(Posicao posicao)
        {
            validarPosicao(posicao);
            return peca(posicao) != null;
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if(existePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição! ");
            }
            this.Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public bool posicaoValida(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= this.Linhas || posicao.Coluna < 0 || posicao.Coluna >= this.Colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao posicao)
        {
            if(!posicaoValida(posicao))
            {
                throw new TabuleiroException("Posição inváliuda! ");
            }
        }

    }
}