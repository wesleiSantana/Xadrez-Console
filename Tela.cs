using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int linha = 0; linha < tabuleiro.Linhas; linha++)
            {
                Console.Write(8 - linha + " ");

                for (int coluna = 0; coluna < tabuleiro.Colunas; coluna++)
                {
                    imprimirPeca(tabuleiro.peca(linha, coluna));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;


            for (int linha = 0; linha < tabuleiro.Linhas; linha++)
            {
                Console.Write(8 - linha + " ");

                for (int coluna = 0; coluna < tabuleiro.Colunas; coluna++)
                {
                    if (posicoesPossiveis[linha, coluna])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tabuleiro.peca(linha, coluna));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string escolhas = Console.ReadLine();
            char coluna = escolhas[0];
            int linha = int.Parse(escolhas[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}