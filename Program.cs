using System;
using System.Linq;
using System.Runtime.CompilerServices;

class Jogador
{
    private string nome;
    private string escolha;

   public Jogador(string n, string e)
    {
        this.nome = n;
        this.escolha = e;
    }

    public string getEscolha()
    {
        return escolha;
    }

    public string getNome()
    {
        return nome;
    }

    public void setEscolha(string escolha)
    {
        this.escolha = escolha;
    }

    public void setNome(string nome)
    {
        this.nome = nome;
    }
}

class Jogo {

static void Main()
    {
        Random rnd = new Random();
        string[,] m = new string[3, 3];
        int sorteio = rnd.Next(1,3), index = 0;
        int[] marcados = new int[9];
        string Jogador1, Jogador2;
        string Escolha1, Escolha2;
        int vez, jogada;
        string vencedor;

        Console.WriteLine("O jogo vai começar!");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Insira o nome do Jogador 1: ");
        Jogador1 = Console.ReadLine();
        Console.WriteLine("Insira a forma do Jogador 1: ");
        Escolha1 = Console.ReadLine();
            while(Escolha1 != "X" && Escolha1 != "O")
            {
                Console.WriteLine("As escolhas podem ser X/O! Escolha novamente");
                Escolha1 = Console.ReadLine();
            }

        Console.WriteLine("Insira o nome do Jogador 2: ");
        Jogador2 = Console.ReadLine();
        Console.WriteLine("Insira a forma do Jogador 2: ");
        Escolha2 = Console.ReadLine();
        while (Escolha2 != "X" && Escolha2 != "O" || Escolha2 == Escolha1)
        {
            Console.WriteLine("As escolhas podem ser X/O e não podem se repetir! Escolha novamente");
            Escolha2 = Console.ReadLine();
        }

        Jogador j1 = new Jogador(Jogador1, Escolha1);
        Jogador j2 = new Jogador(Jogador2, Escolha2);

        for (int i = 0; i < 3; i++)
        {
            
            for(int c = 0; c < 3; c++)
            {
                index++;
                m[i, c] = index.ToString();    
            }
        }


        Console.WriteLine("-----------------------------------------");
        while (Fim_de_Jogo(m, ref marcados) == false)
        {
            Mostrar_Jogo(m);
            vez = Vez_Jogador(ref sorteio);

            do
            {                
                Console.WriteLine("Insira sua jogada: ");
                jogada = int.Parse(Console.ReadLine());
            } while (jogada > 10 && jogada < 0);
            if (sorteio == 2)
            {
                if (marcados.Contains(jogada))
                {
                    while (marcados.Contains(jogada))
                    {
                        Console.Write("Jogada não disponível!. Selecione novamente: ");
                        jogada = int.Parse(Console.ReadLine());
                    }
                }
                Marcar_Jogada(m, jogada, j1.getEscolha(), ref marcados);
                Console.Clear();
            }
            else
            {
                if (marcados.Contains(jogada))
                {
                    while (marcados.Contains(jogada))
                    {
                        Console.Write("Jogada não disponível!. Selecione novamente: ");
                        jogada = int.Parse(Console.ReadLine());
                    }
                }
                Marcar_Jogada(m, jogada, j2.getEscolha(), ref marcados);
                Console.Clear();
            }
        }
        if(Vencedor(m) == j1.getEscolha()) {
            vencedor = j1.getNome();
        } else if (Vencedor(m) == j2.getEscolha()) {
            vencedor = j2.getNome();
        } else {
            vencedor = "-";
        }
        Console.WriteLine("Jogo Finalizado!");
        Console.WriteLine("-------------------------------------------------------");
        if (vencedor != "-") {
            Console.WriteLine("{0} VENCEU!", vencedor);
        } else
        {
            Console.WriteLine("EMPATE!");
        }
        Console.WriteLine("-------------------------------------------------------");
    }

    static void Mostrar_Jogo(string[,] m)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            Console.WriteLine();
            for (int c = 0; c < m.GetLength(1); c++)
            {
                Console.Write("\t" + m[i, c] + " ");
            }
        }
    }

    static int Vez_Jogador(ref int s)
    {
        if (s == 1)
        {
            Console.WriteLine("\nJogador{0}: ", s);
            s = 2;
            return 1;
        } else {
            Console.WriteLine("\nJogador{0}: ", s);
            s = 1;
            return 2;
        }
    }
    static bool Fim_de_Jogo(string[,] m, ref int[] marcados)
    {
        for (int c = 0; c <3; c++)
        {
                 if (m[c,0] == m[c, 1] && m[c, 1] == m[c, 2] ||
                     m[0,c] == m[1, c] && m[1, c] == m[2, c])
            {

                return true;
            }

        if (m[0,0] == m[1,1] && m[1, 1] == m[2, 2] || m[0,2] == m[1,1] && m[1, 1] == m[2, 0])
            {
                return true;
            }

            if (marcados[8] != 0)
            {
                return true;
            }
        }
        return false;
    }

    static void Marcar_Jogada(string[,] m, int j, string e, ref int[] marcados)
    {
        int aux = 0;
        for(int i = 0; i < m.GetLength(0); i++)
        {

            for(int c = 0; c < m.GetLength(1); c++)
            {
                    if (m[i, c] == Convert.ToString(j))
                    {
                        m[i, c] = e;
                    }
            }
        }

       for (int i = 0; i < marcados.Length; i++)
        {
            if (marcados[i] == 0)
            {
                aux = i;
                break;
            }
        }
        marcados[aux] = j;
    }

    static string Vencedor(string[,] m)
    {
        for (int c = 0; c < 3; c++)
        {
            if (m[c, 0] == m[c,1] && m[c,1] == m[c, 2]){
                return m[c, 0];
            }

            if (m[0, c] == m[1, c] && m[1, c] == m[2, c])
            {
                return m[0, c];
            }
            if (m[0,0] == m[1,1] && m[1,1]  == m[2, 2])
            {
                return m[0, 0];
            }
            if (m[0, 2] == m[1, 1] && m[1, 1] == m[2, 0])
            {
                return m[0, 2];
            }
        }
        return "Empate";
    }
}
