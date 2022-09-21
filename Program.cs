/*Criar um programa que simule o jogo Batalha Naval .

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
        Random randNum = new Random();
        int i = 1;
        new Program();
        decimal[,] array2D = new decimal[10, 10];

        //Posicionar 10 porta aviões(case1)
        while (i <= 10)
        {
            int x = randNum.Next(0, 10);
            int y = randNum.Next(0, 10);
            int z = 1;

            if (array2D[y, x] == 0)
            {
                array2D[y, x] = z;
                i++;
            }

        }

        i = 1;
        //Posicionar 3 rebocadores(case2)
        while (i <= 1)
        {
            int x = randNum.Next(0, 10);
            int y = randNum.Next(0, 10);
            int z = 2;

            if (array2D[y, x] == 0)
            {
                array2D[y, x] = z;
                i++;
            }
        }

        i = 1;
        //Posicionar 3 rebocadores(case3)
        while (i <= 3)
        {
            int x = randNum.Next(0, 10);
            int y = randNum.Next(0, 10);
            int z = 3;

            if (array2D[y, x] == 0)
            {
                array2D[y, x] = z;
                i++;
            }
        }


        for (int linha = 0; linha < array2D.GetLength(0); ++linha)
        {
            Console.WriteLine("-----------------------------------------");
            for (int coluna = 0; coluna < array2D.GetLength(1); ++coluna)
            {

                //Console.Write("| {0} ", array2D[linha, coluna]);
                switch (array2D[linha, coluna])
                {
                    case 0:
                        Console.Write("|   ");
                        break;
                    case 1:
                        Console.Write("| P ");
                        break;
                    case 2:
                        Console.Write("| C ");
                        break;
                    case 3:
                        Console.Write("| R ");
                        break;
                }
            }

            Console.WriteLine("|");
        }
        Console.WriteLine("-----------------------------------------");

    }
}