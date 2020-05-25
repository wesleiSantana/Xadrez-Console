
using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez partidaDeXadrez;

        public Peao(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partidaDeXadrez) : base(tabuleiro, cor)
        {
            this.partidaDeXadrez = partidaDeXadrez;
        }

        private bool existeInimigo(Posicao posicao)
        {
            Peca peca = this.Tabuleiro.peca(posicao);
            return peca != null && peca.Cor != Cor;
        }

        private bool livre(Posicao posicao)
        {
            return this.Tabuleiro.peca(posicao) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[this.Tabuleiro.Linhas, this.Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            if (Cor == Cor.Branca)
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

                // en passanr
                if (this.Posicao.Linha == 3)
                {
                    Posicao posicaoEsquerda = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
                    if (this.Tabuleiro.posicaoValida(posicaoEsquerda) && existeInimigo(posicaoEsquerda) && this.Tabuleiro.peca(posicaoEsquerda) == this.partidaDeXadrez.vulneravelEnPassant)
                    {
                        matriz[posicaoEsquerda.Linha - 1, posicaoEsquerda.Coluna] = true;
                    }

                    Posicao posicaoDireita = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
                    if (this.Tabuleiro.posicaoValida(posicaoDireita) && existeInimigo(posicaoDireita) && this.Tabuleiro.peca(posicaoDireita) == this.partidaDeXadrez.vulneravelEnPassant)
                    {
                        matriz[posicaoDireita.Linha - 1, posicaoDireita.Coluna] = true;
                    }
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

                posicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
                if (this.Tabuleiro.posicaoValida(posicao) && existeInimigo(posicao))
                {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.definirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
                if (this.Tabuleiro.posicaoValida(posicao) && existeInimigo(posicao))
                {
                    matriz[posicao.Linha, posicao.Coluna] = true;
                }

                // en passanr
                if (this.Posicao.Linha == 4)
                {
                    Posicao posicaoEsquerda = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
                    if (this.Tabuleiro.posicaoValida(posicaoEsquerda) && existeInimigo(posicaoEsquerda) && this.Tabuleiro.peca(posicaoEsquerda) == this.partidaDeXadrez.vulneravelEnPassant)
                    {
                        matriz[posicaoEsquerda.Linha + 1, posicaoEsquerda.Coluna] = true;
                    }

                    Posicao posicaoDireita = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
                    if (this.Tabuleiro.posicaoValida(posicaoDireita) && existeInimigo(posicaoDireita) && this.Tabuleiro.peca(posicaoDireita) == this.partidaDeXadrez.vulneravelEnPassant)
                    {
                        matriz[posicaoDireita.Linha + 1, posicaoDireita.Coluna] = true;
                    }
                }
            }
            return matriz;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}