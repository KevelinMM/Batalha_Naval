/*BATALHA NAVAL - REGRAS DO JOGO:

A cada partida, o programa deve iniciar um mapa limpo com 10 Linhas e 10 Colunas, e randomicamente posicionar no mapa, 
sem repetir posições, 10 porta aviões, 01 cruzador e 02 rebocadores, tudo de forma oculta para o jogador. 
Na sequencia o jogador tem 15 chances para indicar as coordenadas de onde deseja jogar bombas,
na tentativa de destruir os porta aviões, rebocadores e cruzador;

  A cada bomba atirada o programa deve:

         Se atingiu um porta avião:
           Adiciona 5 pontos para o jogador!
           Destacar no mapa, na cor VERMELHA, a posição e o tipo que foi abatido.

        Se atingiu um porta rebocador:
           Adiciona 10 pontos para o jogador!
           Destacar no mapa, na cor VERMELHA, a posição e o tipo que foi abatido.

        Se atingiu um porta cruzador:
           Adiciona 15 pontos para o jogador!
           Destacar no mapa, na cor VERMELHA, a posição e o tipo que foi abatido.

        Se não atingiu nada:
           Destacar no mapa , na cor VERDE , onde o tiro foi realiVerificaCoordenadasado e o tamanho do erro,
           por exemplo:

          1 - Caso num raio de 1 casa tenha algo (esquerda, direita, cima, baixo)
          2 - Caso num raio de 2 casas tenha algo (esquerda, direita, cima, baixo)
          3 - Caso num raio de 3 casas tenha algo (esquerda, direita, cima, baixo)
          M - Errou por muito!

Os destaques no mapa devem permanecer em todas as rodadas!

   Ao final das 15 tentativas , o programa deve:
     * Revelar no mapa a posição de todos os itens , mostrando o tipo do navio e 
     VerificaCoordenadas realizando um destaque em:
      VERMELHO nos abatidos e AVerificaCoordenadasUL nos que restaram.
     * Todas as bombas lançadas , como destaque em VERDE para as que não atingiram nada.
     * A pontuação do jogador.
   Após mostrar os resultados , dar a opção para SAIR ou iniciar uma nova partida. 
*/

internal class Program
{
    static void Main(string[] args)
    {
        //Declaracao de variaveis
        Random RandNum = new Random();
        int PosicionarElemento = 1;
        int Pontos = 0;
        decimal[,] Tabuleiro = new decimal[10, 10];
        string Mensagem = "Errou por muito!!";

        //Posicionar 10 porta aviões (case5)
        while (PosicionarElemento <= 10)
        {
            int EixoX = RandNum.Next(0, 10);
            int EixoY = RandNum.Next(0, 10);

            if (Tabuleiro[EixoY, EixoX] == 0)
            {
                Tabuleiro[EixoY, EixoX] = 5;
                PosicionarElemento++;
            }
        }
        PosicionarElemento = 1;

        //Posicionar 1 rebocador (case6)
        while (PosicionarElemento <= 1)
        {
            int EixoX = RandNum.Next(0, 10);
            int EixoY = RandNum.Next(0, 10);

            if (Tabuleiro[EixoY, EixoX] == 0)
            {
                Tabuleiro[EixoY, EixoX] = 6;
                PosicionarElemento++;
            }
        }
        PosicionarElemento = 1;

        //Posicionar 3 cruzadores (case7)
        while (PosicionarElemento <= 3)
        {
            int EixoX = RandNum.Next(0, 10);
            int EixoY = RandNum.Next(0, 10);

            if (Tabuleiro[EixoY, EixoX] == 0)
            {
                Tabuleiro[EixoY, EixoX] = 7;
                PosicionarElemento++;
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Escolha valores entre 1 e 10 para as coordenadas: ");
        Console.ForegroundColor = ConsoleColor.White;

        //comeco do jogo
        for (int y = 1; y <= 15; y++)
        {
            Console.WriteLine("Coordenada X: ");
            int JogadaX = int.TryParse(Console.ReadLine(), out int auxValorX) ? auxValorX : default;
            JogadaX--;

            Console.WriteLine("Coordenada Y: ");
            int JogadaY = int.TryParse(Console.ReadLine(), out int auxValorY) ? auxValorY : default;
            JogadaY--;

            if (JogadaX < 0 || JogadaX > 9 || JogadaY < 0 || JogadaY > 9)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Verifique se os valores são de 1 a 10 e tente novamente, letras não funcionam!");
                Console.ForegroundColor = ConsoleColor.White;
                y--;
            }
            else
            {
                //Verifica o que tem nas cordenadas
                switch (Tabuleiro[JogadaY, JogadaX])
                {
                    //Nao encontrou...
                    case 0:
                        Tabuleiro[JogadaY, JogadaX] = 4;

                        for (int VerificaCoordenadas = 1; VerificaCoordenadas <= 3; VerificaCoordenadas++)
                        {
                            // ==> x
                            if ((JogadaX + VerificaCoordenadas) < 10 && Tabuleiro[JogadaY, (JogadaX + VerificaCoordenadas)] != 0 && Tabuleiro[JogadaY, (JogadaX + VerificaCoordenadas)] != 1 && Tabuleiro[JogadaY, (JogadaX + VerificaCoordenadas)] != 2 && Tabuleiro[JogadaY, (JogadaX + VerificaCoordenadas)] != 3 && Tabuleiro[JogadaY, (JogadaX + VerificaCoordenadas)] != 4 && VerificaCoordenadas < Tabuleiro[JogadaY, JogadaX])
                            {
                                Mensagem = "Existe um inimigo próximo.";
                                Tabuleiro[JogadaY, JogadaX] = VerificaCoordenadas;
                            }
                            // <== x
                            else if ((JogadaX - VerificaCoordenadas) > 0 && Tabuleiro[JogadaY, (JogadaX - VerificaCoordenadas)] != 0 && Tabuleiro[JogadaY, (JogadaX - VerificaCoordenadas)] != 1 && Tabuleiro[JogadaY, (JogadaX - VerificaCoordenadas)] != 2 && Tabuleiro[JogadaY, (JogadaX - VerificaCoordenadas)] != 3 && Tabuleiro[JogadaY, (JogadaX - VerificaCoordenadas)] != 4 && VerificaCoordenadas < Tabuleiro[JogadaY, JogadaX])
                            {
                                Mensagem = "Existe um inimigo próximo.";
                                Tabuleiro[JogadaY, JogadaX] = VerificaCoordenadas;
                            }
                            // ↑ y
                            else if ((JogadaY + VerificaCoordenadas) < 10 && Tabuleiro[(JogadaY + VerificaCoordenadas), JogadaX] != 0 && Tabuleiro[(JogadaY + VerificaCoordenadas), JogadaX] != 1 && Tabuleiro[(JogadaY + VerificaCoordenadas), JogadaX] != 2 && Tabuleiro[(JogadaY + VerificaCoordenadas), JogadaX] != 3 && Tabuleiro[(JogadaY + VerificaCoordenadas), JogadaX] != 4 && VerificaCoordenadas < Tabuleiro[(JogadaY + VerificaCoordenadas), JogadaX])
                            {
                                Mensagem = "Existe um inimigo próximo.";
                                Tabuleiro[JogadaY, JogadaX] = VerificaCoordenadas;
                            }
                            // ↓ y
                            else if ((JogadaY - VerificaCoordenadas) > 0 && Tabuleiro[(JogadaY - VerificaCoordenadas), JogadaX] != 0 && Tabuleiro[(JogadaY - VerificaCoordenadas), JogadaX] != 1 && Tabuleiro[(JogadaY - VerificaCoordenadas), JogadaX] != 2 && Tabuleiro[(JogadaY - VerificaCoordenadas), JogadaX] != 3 && Tabuleiro[(JogadaY - VerificaCoordenadas), JogadaX] != 4 && VerificaCoordenadas < Tabuleiro[(JogadaY - VerificaCoordenadas), JogadaX])
                            {
                                Mensagem = "Existe um inimigo próximo.";
                                Tabuleiro[JogadaY, JogadaX] = VerificaCoordenadas;
                            }
                        }
                        break;

                    //encontrou...
                    case 5:
                        Tabuleiro[JogadaY, JogadaX] = 8;
                        Pontos += 5;
                        Mensagem = "Voce ACERTOU um PORTA AVIOES + 5 pontos!";
                        break;

                    case 6:
                        Tabuleiro[JogadaY, JogadaX] = 9;
                        Pontos += 15;
                        Mensagem = "Voce ACERTOU um REBOCADOR + 15 pontos!";
                        break;

                    case 7:
                        Tabuleiro[JogadaY, JogadaX] = 10;
                        Pontos += 10;
                        Mensagem = "Voce ACERTOU um cruzador + 10 pontos!";
                        break;
                }

                //Renderizacao durante o jogo
                Console.WriteLine("  1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10");
                for (int Linha = 0; Linha < Tabuleiro.GetLength(0); ++Linha)
                {
                    Console.WriteLine("-----------------------------------------");
                    for (int Coluna = 0; Coluna < Tabuleiro.GetLength(1); ++Coluna)
                    {

                        switch (Tabuleiro[Linha, Coluna])
                        {
                            case 0:
                                Console.Write("|   ");
                                break;

                            //Inimigo a 1 casa 
                            case 1:
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" 1 ");
                                break;

                            //Inimigo a 2 casas
                            case 2:
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" 2 ");
                                break;

                            //Inimigo a 3 casas
                            case 3:
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" 3 ");
                                break;

                            //Errou muito
                            case 4:
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" M ");
                                break;

                            //Porta Aviao - hidden
                            case 5:
                                Console.Write("|");
                                Console.Write("   ");
                                break;

                            //Rebocador - hidden
                            case 6:
                                Console.Write("|");
                                Console.Write("   ");
                                break;

                            //cruzador - hidden
                            case 7:
                                Console.Write("|");
                                Console.Write("   ");
                                break;

                            //Acerto Porta Aviao
                            case 8:
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" p ");
                                break;

                            //Acerto Rebocador
                            case 9:
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" r ");
                                break;

                            //Acerto cruzador
                            case 10:
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" c ");
                                break;
                        }
                        //Reseta a cor do console
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                    Console.WriteLine("| {0}", (Linha + 1));
                }
                Console.WriteLine("-----------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(Mensagem);
                Mensagem = "...";
                Console.WriteLine("Restam {0} jogadas! ", (15 - y));
                Console.WriteLine("Pontos: {0}", Pontos);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //Encerramento do jogo - renderizacao final 
        Console.WriteLine("  1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10");
        for (int Linha = 0; Linha < Tabuleiro.GetLength(0); ++Linha)
        {
            Console.WriteLine("-----------------------------------------");
            for (int Coluna = 0; Coluna < Tabuleiro.GetLength(1); ++Coluna)
            {
                switch (Tabuleiro[Linha, Coluna])
                {
                    //Verifica Coordenada
                    case 0:
                        Console.Write("|   ");
                        break;

                    //Inimigo a 1 casa 
                    case 1:
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" 1 ");
                        break;

                    //Inimigo a 2 casas
                    case 2:
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" 2 ");
                        break;

                    //Inimigo a 3 casas
                    case 3:
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" 3 ");
                        break;

                    //Erro
                    case 4:
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" M ");
                        break;

                    //Porta Aviao
                    case 5:
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" P ");
                        break;

                    //Rebocador
                    case 6:
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" C ");
                        break;

                    //cruzador
                    case 7:
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" R ");
                        break;

                    //Acerto Porta Aviao
                    case 8:
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" p ");
                        break;

                    //Acerto Rebocador
                    case 9:
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" r ");
                        break;

                    //Acerto cruzador
                    case 10:
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" c ");
                        break;
                }
                //Reseta a cor do console
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("| {0}", (Linha + 1));
        }
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("Jogo encerrado!");
        Console.WriteLine("Sua pontuação foi de: {0}", Pontos);
    }
}
