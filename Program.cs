/*BATALHA NAVAL - REGRAS DO JOGO:

A cada partida, o programa deve iniciar um mapa limpo com 10 linhas e 10 colunas, e randomicamente posicionar no mapa, 
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
           Destacar no mapa , na cor VERDE , onde o tiro foi realizado e o tamanho do erro , por exemplo :
          1 - Caso num raio de 1 casa tenha algo (esquerda, direita, cima, baixo)
          2 - Caso num raio de 2 casas tenha algo (esquerda, direita, cima, baixo)
          3 - Caso num raio de 3 casas tenha algo (esquerda, direita, cima, baixo)
          M - Errou por muito!

Os destaques no mapa devem permanecer em todas as rodadas!

   Ao final das 15 tentativas , o programa deve :
     * Revelar no mapa a posição de todos os itens , mostrando o tipo do navio e realizando um destaque em:
      VERMELHO nos abatidos e AZUL nos que restaram.
     * Todas as bombas lançadas , como destaque em VERDE para as que não atingiram nada.
     * A pontuação do jogador.
   Após mostrar os resultados , dar a opção para SAIR ou iniciar uma nova partida. 
*/

internal class Program
{
    static void Main(string[] args)
    {
        //Declaracao de variaveis
        Random randNum = new Random();
        int i = 1;
        int score = 0;
        decimal[,] array2D = new decimal[10, 10];
        string mensagem = "...";

        //Posicionar 10 porta aviões (case5)
        while (i <= 10)
        {
            int x = randNum.Next(0, 10);
            int y = randNum.Next(0, 10);

            if (array2D[y, x] == 0)
            {
                array2D[y, x] = 5;
                i++;
            }
        }
        i = 1;

        //Posicionar 1 rebocador (case6)
        while (i <= 1)
        {
            int x = randNum.Next(0, 10);
            int y = randNum.Next(0, 10);

            if (array2D[y, x] == 0)
            {
                array2D[y, x] = 6;
                i++;
            }
        }
        i = 1;

        //Posicionar 3 cruzadores (case7)
        while (i <= 3)
        {
            int x = randNum.Next(0, 10);
            int y = randNum.Next(0, 10);

            if (array2D[y, x] == 0)
            {
                array2D[y, x] = 7;
                i++;
            }
        }
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Escolha valores entre 1 e 10 para as coordenadas: ");
        Console.ForegroundColor = ConsoleColor.White;

        //comeco do jogo
        for (int y = 1; y <= 15; y++)
        {
            Console.WriteLine("Coordenada X: ");
            string entrada1 = Console.ReadLine();

            Console.WriteLine("Coordenada Y: ");
            string entrada2 = Console.ReadLine();

            //converte string pra int 
            int userX = (int.Parse(entrada1) - 1);
            int userY = (int.Parse(entrada2) - 1);

            if (userX < 0 || userX > 9 || userY < 0 || userY > 9)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Verifique se os valores são de 1 a 10 e tente novamente!");
                Console.ForegroundColor = ConsoleColor.White;
                y--;
            }
            else
            {
                //Verifica o que tem nas cordenadas
                switch (array2D[userY, userX])
                {
                    //Nao encontrou...
                    case 0:
                        array2D[userY, userX] = 4;

                        for (int z = 1; z <= 3; z++)
                        {
                            // ==> x
                            if ((userX + z) < 10 && array2D[userY, (userX + z)] != 0 && array2D[userY, (userX + z)] != 1 && array2D[userY, (userX + z)] != 2 && array2D[userY, (userX + z)] != 3 && array2D[userY, (userX + z)] != 4 && z < array2D[userY, userX])
                            {
                                mensagem = "Existe um inimigo próximo.";
                                array2D[userY, userX] = z;
                            }
                            // <== x
                            else if ((userX - z) > 0 && array2D[userY, (userX - z)] != 0 && array2D[userY, (userX - z)] != 1 && array2D[userY, (userX - z)] != 2 && array2D[userY, (userX - z)] != 3 && array2D[userY, (userX - z)] != 4 && z < array2D[userY, userX])
                            {
                                mensagem = "Existe um inimigo próximo.";
                                array2D[userY, userX] = z;
                            }
                            // ↑ y
                            else if ((userY + z) < 10 && array2D[(userY + z), userX] != 0 && array2D[(userY + z), userX] != 1 && array2D[(userY + z), userX] != 2 && array2D[(userY + z), userX] != 3 && array2D[(userY + z), userX] != 4 && z < array2D[(userY + z), userX])
                            {
                                mensagem = "Existe um inimigo próximo.";
                                array2D[userY, userX] = z;
                            }
                            // ↓ y
                            else if ((userY - z) > 0 && array2D[(userY - z), userX] != 0 && array2D[(userY - z), userX] != 1 && array2D[(userY - z), userX] != 2 && array2D[(userY - z), userX] != 3 && array2D[(userY - z), userX] != 4 && z < array2D[(userY - z), userX])
                            {
                                mensagem = "Existe um inimigo próximo.";
                                array2D[userY, userX] = z;
                            }
                        }
                        break;

                    //encontrou...
                    case 5:
                        array2D[userY, userX] = 8;
                        score += 5;
                        mensagem = "Voce ACERTOU um PORTA AVIOES + 5 pontos!";
                        break;

                    case 6:
                        array2D[userY, userX] = 9;
                        score += 15;
                        mensagem = "Voce ACERTOU um REBOCADOR + 15 pontos!";
                        break;

                    case 7:
                        array2D[userY, userX] = 10;
                        score += 10;
                        mensagem = "Voce ACERTOU um CRUZADOR + 10 pontos!";
                        break;
                }

                //Renderizacao durante o jogo
                Console.WriteLine("  1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10");
                for (int linha = 0; linha < array2D.GetLength(0); ++linha)
                {
                    Console.WriteLine("-----------------------------------------");
                    for (int coluna = 0; coluna < array2D.GetLength(1); ++coluna)
                    {

                        switch (array2D[linha, coluna])
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

                            //Cruzador - hidden
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

                            //Acerto Cruzador
                            case 10:
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" c ");
                                break;
                        }
                        //Reseta a cor do console
                        Console.ForegroundColor = ConsoleColor.White;

                    }

                    Console.WriteLine("| {0}", (linha + 1));
                }
                Console.WriteLine("-----------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(mensagem);
                mensagem = "...";
                Console.WriteLine("Restam {0} jogadas! ", (15 - y));
                Console.WriteLine("Score: {0}", score);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //Encerramento do jogo - renderizacao final 
        Console.WriteLine("  1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10");
        for (int linha = 0; linha < array2D.GetLength(0); ++linha)
        {
            Console.WriteLine("-----------------------------------------");
            for (int coluna = 0; coluna < array2D.GetLength(1); ++coluna)
            {
                switch (array2D[linha, coluna])
                {
                    //Vazio
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

                    //Cruzador
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

                    //Acerto Cruzador
                    case 10:
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" c ");
                        break;
                }
                //Reseta a cor do console
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("| {0}", (linha + 1));
        }
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("Jogo encerrado!");
        Console.WriteLine("Sua pontuação foi de: {0}", score);
    }
}