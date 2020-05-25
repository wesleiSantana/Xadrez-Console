
using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

        public override string ToString()
        {
            return "C";
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

            posicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 2);
            if (this.Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.definirValores(this.Posicao.Linha - 2, this.Posicao.Coluna - 1);
            if (this.Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.definirValores(this.Posicao.Linha - 2, this.Posicao.Coluna + 1);
            if (this.Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 2);
            if (this.Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 2);
            if (this.Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.definirValores(this.Posicao.Linha + 2, this.Posicao.Coluna + 1);
            if (this.Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.definirValores(this.Posicao.Linha + 2, this.Posicao.Coluna - 1);
            if (this.Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            posicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 2);
            if (this.Tabuleiro.posicaoValida(posicao) && podeMover(posicao))
            {
                matriz[posicao.Linha, posicao.Coluna] = true;
            }

            return matriz;
        }
    }
}