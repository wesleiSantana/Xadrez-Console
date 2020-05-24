using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            this.Tabuleiro = new Tabuleiro(8, 8);
            this.Turno = 1;
            this.JogadorAtual = Cor.Branca;
            this.Terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao posicaoOrigem, Posicao posicaoDestino)
        {
            Peca peca = this.Tabuleiro.retirarPeca(posicaoOrigem);
            peca.incrementarQtdeMovimentos();
            Peca pecaCapturada = this.Tabuleiro.retirarPeca(posicaoDestino);
            this.Tabuleiro.ColocarPeca(peca, posicaoDestino);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            this.Turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao posicao)
        {
            if(this.Tabuleiro.peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if(JogadorAtual != this.Tabuleiro.peca(posicao).Cor)
            {
                throw new TabuleiroException("A peça de oriem escolhida não e sua!");
            }

            if(!this.Tabuleiro.peca(posicao).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("não há movimentos possíveis para a peça de origem escolhida! ");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if(!this.Tabuleiro.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida! ");
            }
        }

        private void mudaJogador()
        {
            if (this.JogadorAtual == Cor.Branca)
            {
                this.JogadorAtual = Cor.Preta;
            }
            else
            {
                this.JogadorAtual = Cor.Branca;
            }
        }

        private void colocarPecas()
        {
            this.Tabuleiro.ColocarPeca(new Torre(this.Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
            this.Tabuleiro.ColocarPeca(new Rei(this.Tabuleiro, Cor.Branca), new PosicaoXadrez('b', 1).toPosicao());

            this.Tabuleiro.ColocarPeca(new Torre(this.Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            this.Tabuleiro.ColocarPeca(new Rei(this.Tabuleiro, Cor.Preta), new PosicaoXadrez('b', 8).toPosicao());
        }
    }
}