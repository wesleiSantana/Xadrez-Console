
using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez Partida;

        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor)
        {
            this.Partida = partida;
        }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != this.Cor;
        }

        private bool testeDeTorreParaRoque(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.peca(posicao);
            return peca != null && peca is Torre && peca.Cor == Cor && peca.QteMovimentos == 0;
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

            // Jogada diferenciada
            if (this.QteMovimentos == 0 && !this.Partida.xeque)
            {
                // roque-pequeno
                Posicao roquePequeno = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 3);
                if (testeDeTorreParaRoque(roquePequeno))
                {
                    Posicao casasVaziasEspaco1 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
                    Posicao casasVaziasEspaco2 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 2);

                    if (this.Tabuleiro.peca(casasVaziasEspaco1) == null && this.Tabuleiro.peca(casasVaziasEspaco2) == null)
                    {
                        matrizMovimentosPossiveis[this.Posicao.Linha, this.Posicao.Coluna + 2] = true;
                    }
                }

                // roque-grande
                Posicao roqueGrande = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 4);
                if (testeDeTorreParaRoque(roquePequeno))
                {
                    Posicao casasVaziasEspaco1 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
                    Posicao casasVaziasEspaco2 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 2);
                    Posicao casasVaziasEspaco3 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 3);

                    if (this.Tabuleiro.peca(casasVaziasEspaco1) == null && this.Tabuleiro.peca(casasVaziasEspaco2) == null && this.Tabuleiro.peca(casasVaziasEspaco3) == null)
                    {
                        matrizMovimentosPossiveis[this.Posicao.Linha, this.Posicao.Coluna - 2] = true;
                    }
                }
            }

            return matrizMovimentosPossiveis;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}