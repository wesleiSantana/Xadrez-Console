
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matrizMovimentosPossiveis = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            Posicao newposicao = new Posicao(0, 0);
            // acima
            newposicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);
            if (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
            }
            // Nordesti
            newposicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            if (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
            }
            // Direita
            newposicao.definirValores(this.Posicao.Linha, this.Posicao.Coluna + 1);
            if (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
            }
            // Sudesti
            newposicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            if (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
            }
            // Baixo
            newposicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
            if (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
            }
            // Sul do oeste
            newposicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
            if (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
            }
            // Esquerda
            newposicao.definirValores(this.Posicao.Linha, this.Posicao.Coluna - 1);
            if (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
            }
            // Noroeste
            newposicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
            if (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
            }
            return matrizMovimentosPossiveis;
        }

        public override string ToString()
        {
            return "R";
        }


    }
}