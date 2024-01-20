using System;
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
        string Jogador1, Jogador2;
        string Escolha1, Escolha2;
        int vez;
        int jogada;

        Console.WriteLine("O jogo vai começar!");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine("Insira o nome do Jogador 1: ");
        Jogador1 = Console.ReadLine();
        Console.WriteLine("Insira a forma do Jogador 1: ");
        Escolha1 = Console.ReadLine();

        Console.WriteLine("Insira o nome do Jogador 2: ");
        Jogador2 = Console.ReadLine();
        Console.WriteLine("Insira a forma do Jogador 2: ");
        Escolha2 = Console.ReadLine();

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
        while (Fim_de_Jogo(m) == false)
        {
            Mostrar_Jogo(m);
            vez = Vez_Jogador(sorteio);

            do
            {
                Console.WriteLine("Insira sua jogada: ");
                jogada = int.Parse(Console.ReadLine());
            } while (jogada > 10 && jogada < 0);
            Marcar_Jogada(m, jogada, j1.getEscolha());

        }
        

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

    static int Vez_Jogador(int s) //usar ref
    {
        if (s == 1)
        {
            Console.WriteLine("\nJogador{0}: ", s);
            return 1;
        } else {
            Console.WriteLine("\nJogador{0}: ", s);
            return 2;
        }
    }
    static bool Fim_de_Jogo(string[,] m)
    {
        for(int c = 0; c <3; c++)
        {
            for(int i = 0; i < 3; i++)
            {

            }
        }
        return false;
    }

    static void Marcar_Jogada(string[,] m, int j, string e)
    {
        for(int i = 0; i < m.GetLength(0); i++)
        {

            for(int c = 0; c < m.GetLength(1); c++)
            {
                if (m[i,c] == Convert.ToString(j))
                {
                    m[i, c] = e;
                }
            }
        }
    }

}
