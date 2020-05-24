using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                    bool[,] posicoesPossiveis = partida.Tabuleiro.peca(origem).movimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.executaMovimento(origem, destino);
                }

                Tela.ImprimirTabuleiro(partida.Tabuleiro);
            }
            catch (TabuleiroException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
