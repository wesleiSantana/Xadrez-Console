
using tabuleiro;

namespace xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) { }

        private bool podeMover(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.peca(posicao);
            return peca == null || peca.Cor != Cor;  
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matrizMovimentosPossiveis = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            Posicao newposicao = new Posicao(0, 0);

            // acima
            newposicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna); 
            while (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
                if (this.Tabuleiro.peca(newposicao) != null && this.Tabuleiro.peca(newposicao).Cor != this.Cor)
                {
                    break;
                }
                newposicao.Linha = newposicao.Linha - 1;
            }

            // Baixo
            newposicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
            while (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
                if (this.Tabuleiro.peca(newposicao) != null && this.Tabuleiro.peca(newposicao).Cor != this.Cor)
                {
                    break;
                }
                newposicao.Linha = newposicao.Linha + 1;
            }

            // Direita
            newposicao.definirValores(this.Posicao.Linha, this.Posicao.Coluna + 1);
            while (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
                if (this.Tabuleiro.peca(newposicao) != null && this.Tabuleiro.peca(newposicao).Cor != this.Cor)
                {
                    break;
                }
                newposicao.Coluna = newposicao.Coluna + 1;
            }

            // Esquerda
            newposicao.definirValores(this.Posicao.Linha, this.Posicao.Coluna - 1);
            while (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
                if (this.Tabuleiro.peca(newposicao) != null && this.Tabuleiro.peca(newposicao).Cor != this.Cor)
                {
                    break;
                }
                newposicao.Coluna = newposicao.Coluna - 1;
            }



             //Noroeste
            newposicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
            while (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
                if (this.Tabuleiro.peca(newposicao) != null && this.Tabuleiro.peca(newposicao).Cor != this.Cor)
                {
                    break;
                }
                newposicao.definirValores(newposicao.Linha - 1, newposicao.Coluna - 1);
            }

            //Nordeste
            newposicao.definirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            while (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
                if (this.Tabuleiro.peca(newposicao) != null && this.Tabuleiro.peca(newposicao).Cor != this.Cor)
                {
                    break;
                }
                newposicao.definirValores(newposicao.Linha - 1, newposicao.Coluna + 1);
            }

            //Sudeste
            newposicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            while (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
                if (this.Tabuleiro.peca(newposicao) != null && this.Tabuleiro.peca(newposicao).Cor != this.Cor)
                {
                    break;
                }
                newposicao.definirValores(newposicao.Linha + 1, newposicao.Coluna + 1);
            }

            //Suldoeste
            newposicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
            while (this.Tabuleiro.posicaoValida(newposicao) && podeMover(newposicao))
            {
                matrizMovimentosPossiveis[newposicao.Linha, newposicao.Coluna] = true;
                if (this.Tabuleiro.peca(newposicao) != null && this.Tabuleiro.peca(newposicao).Cor != this.Cor)
                {
                    break;
                }
                newposicao.definirValores(newposicao.Linha + 1, newposicao.Coluna - 1);
            }

            return matrizMovimentosPossiveis;
        }

        public override string ToString()
        {
            return "D";
        }
    }
}