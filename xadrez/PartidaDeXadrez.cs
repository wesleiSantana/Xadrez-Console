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
        public bool xeque { get; private set; }



        public PartidaDeXadrez()
        {
            this.Tabuleiro = new Tabuleiro(8, 8);
            this.Turno = 1;
            this.JogadorAtual = Cor.Branca;
            this.Terminada = false;
            this.xeque = false;
            this.Pecas = new HashSet<Peca>();
            this.Capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executaMovimento(Posicao posicaoOrigem, Posicao posicaoDestino)
        {
            Peca peca = this.Tabuleiro.retirarPeca(posicaoOrigem);
            peca.incrementarQtdeMovimentos();
            Peca pecaCapturada = this.Tabuleiro.retirarPeca(posicaoDestino);
            this.Tabuleiro.ColocarPeca(peca, posicaoDestino);
            if (pecaCapturada != null)
            {
                this.Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca peca = this.Tabuleiro.retirarPeca(destino);
            peca.decrementarQtdeMovimentos();
            if (pecaCapturada != null)
            {
                this.Tabuleiro.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            this.Tabuleiro.ColocarPeca(peca, origem);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if (estaEmXeque(JogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (estaEmXeque(adversaria(JogadorAtual)))
            {
                this.xeque = true;
            }
            else
            {
                this.xeque = false;
            }

            if (testeXequemate(adversaria(JogadorAtual)))
            {
                this.Terminada = true;
            }
            else
            {
                this.Turno++;
                mudaJogador();
            }
        }

        public void validarPosicaoDeOrigem(Posicao posicao)
        {
            if (this.Tabuleiro.peca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if (JogadorAtual != this.Tabuleiro.peca(posicao).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não e sua!");
            }

            if (!this.Tabuleiro.peca(posicao).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("não há movimentos possíveis para a peça de origem escolhida! ");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!this.Tabuleiro.peca(origem).movimentoPossivel(destino))
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
            foreach (Peca pecaCor in this.Capturadas)
            {
                if (pecaCor.Cor == cor)
                {
                    aux.Add(pecaCor);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca pecaCor in this.Pecas)
            {
                if (pecaCor.Cor == cor)
                {
                    aux.Add(pecaCor);
                }
            }

            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor)
        {
            foreach (Peca pecaCor in pecasEmJogo(cor))
            {
                if (pecaCor is Rei)
                {
                    return pecaCor;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException($"Não Possui rei da cor {cor} no tabuleiro!");
            }

            foreach (Peca pecaCor in pecasEmJogo(adversaria(cor)))
            {
                bool[,] matriz = pecaCor.movimentosPossiveis();
                if (matriz[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testeXequemate(Cor cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }

            foreach (Peca pecaCor in pecasEmJogo(cor))
            {
                bool[,] matriz = pecaCor.movimentosPossiveis();
                for (int linha = 0; linha < this.Tabuleiro.Linhas; linha++)
                {
                    for (int coluna = 0; coluna < this.Tabuleiro.Colunas; coluna++)
                    {
                        if (matriz[linha, coluna])
                        {
                            Posicao origem = pecaCor.Posicao;
                            Posicao destino = new Posicao(linha, coluna);

                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            this.Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            this.Pecas.Add(peca);
        }

        private void colocarPecas()
        {
            // Pecas Brancas
            colocarNovaPeca('a', 1, new Torre(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Dama(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('f', 1, new Bispo(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('a', 2, new Peao(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('b', 2, new Peao(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 2, new Peao(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 2, new Peao(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 2, new Peao(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('f', 2, new Peao(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('g', 2, new Peao(this.Tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 2, new Peao(this.Tabuleiro, Cor.Branca));


            // Pecas Pretas
             colocarNovaPeca('a', 8, new Torre(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 8, new Dama(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 8, new Rei(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('f', 8, new Bispo(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(this.Tabuleiro, Cor.Preta));           
            colocarNovaPeca('a', 7, new Peao(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('b', 7, new Peao(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('c', 7, new Peao(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 7, new Peao(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 7, new Peao(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('f', 7, new Peao(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('g', 7, new Peao(this.Tabuleiro, Cor.Preta));
            colocarNovaPeca('h', 7, new Peao(this.Tabuleiro, Cor.Preta));
        }
    }
}