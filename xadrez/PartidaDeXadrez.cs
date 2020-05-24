using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;


        public PartidaDeXadrez()
        {
            this.Tabuleiro = new Tabuleiro(8, 8);
            this.Turno = 1;
            this.JogadorAtual = Cor.Branca;
            this.Terminada = false;
            this.Pecas = new HashSet<Peca>();
            this.Capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void executaMovimento(Posicao posicaoOrigem, Posicao posicaoDestino)
        {
            Peca peca = this.Tabuleiro.retirarPeca(posicaoOrigem);
            peca.incrementarQtdeMovimentos();
            Peca pecaCapturada = this.Tabuleiro.retirarPeca(posicaoDestino);
            this.Tabuleiro.ColocarPeca(peca, posicaoDestino);
            if(pecaCapturada != null)
            {
                this.Capturadas.Add(pecaCapturada);
            }
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

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca pecaCor in this.Capturadas)
            {
                if(pecaCor.Cor == cor)
                {
                    aux.Add(pecaCor);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca pecaCor in this.Pecas)
            {
                if(pecaCor.Cor == cor)
                {
                    aux.Add(pecaCor);
                }
            }

            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            this.Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            this.Pecas.Add(peca);
        }

        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Torre(this.Tabuleiro, Cor.Branca));

            colocarNovaPeca('d', 7, new Torre(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 8, new Torre(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 8, new Torre(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 8, new Torre(this.Tabuleiro, Cor.Preta));            
        }
    }
}