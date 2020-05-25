
using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.peca(posicao);
            return peca != null || peca.Cor != this.Cor;
        }

        private bool livre(Posicao posicao)
        {
            return this.Tabuleiro.peca(posicao) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            if (this.Cor == Cor.Branca)
            {
                posicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);
                if (this.Tabuleiro.posicaoValida(posicao) && livre(posicao))
                {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.definirValores(this.Posicao.Linha - 2, this.Posicao.Coluna);
                if (this.Tabuleiro.posicaoValida(posicao) && livre(posicao) && this.QteMovimentos == 0)
                {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
                if (this.Tabuleiro.posicaoValida(posicao) && existeInimigo(posicao))
                {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
                if (this.Tabuleiro.posicaoValida(posicao) && existeInimigo(posicao))
                {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }
            }
            else
            {
                posicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
                if (this.Tabuleiro.posicaoValida(posicao) && livre(posicao))
                {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.definirValores(this.Posicao.Linha + 2, this.Posicao.Coluna);
                if (this.Tabuleiro.posicaoValida(posicao) && livre(posicao) && this.QteMovimentos == 0)
                {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.definirValores(this.Posicao.Linha +1, this.Posicao.Coluna + 1);
                if (this.Tabuleiro.posicaoValida(posicao) && existeInimigo(posicao))
                {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
                if (this.Tabuleiro.posicaoValida(posicao) && existeInimigo(posicao))
                {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }
            }
            return matriz;
        }
    }
}