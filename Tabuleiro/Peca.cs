

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.Posicao = null;
            this.Tabuleiro = tabuleiro;
            this.Cor = cor;
            this.QteMovimentos = 0;
        }

        public void incrementarQtdeMovimentos()
        {
            this.QteMovimentos++;
        }

        public void decrementarQtdeMovimentos()
        {
            this.QteMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] matriz = movimentosPossiveis();
            for(int linha = 0; linha < this.Tabuleiro.Linhas; linha++)
            {
                for(int coluna = 0; coluna < this.Tabuleiro.Colunas; coluna++)
                {
                    if(matriz[linha, coluna])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao posicao)
        {
            return movimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }

        public abstract bool[,] movimentosPossiveis();
    }
}