using tabuleiro;

namespace xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

        public override string ToString()
        {
            return "B";
        }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            //Noroeste
            posicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
            while (this.Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.peca(posicao) != null && this.Tabuleiro.peca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
            }

            //Nordeste
            posicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            while (this.Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.peca(posicao) != null && this.Tabuleiro.peca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
            }

            //Sudeste
            posicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            while (this.Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.peca(posicao) != null && this.Tabuleiro.peca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
            }

            //Suldoeste
            posicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
            while (this.Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
                if (this.Tabuleiro.peca(posicao) != null && this.Tabuleiro.peca(posicao).Cor != this.Cor)
                {
                    break;
                }
                posicao.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
            }

            return matriz;
        }
    }
}