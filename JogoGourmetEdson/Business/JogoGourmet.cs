using JogoGourmetEdson.Entidades;

namespace JogoGourmetEdson.Business
{
    public class JogoGourmet
    {
        private readonly Noh raiz;

        public JogoGourmet()
        {
            raiz = new Noh("massa");
            raiz.Sim = new Noh("lasanha");
        }

        public void Iniciar()
        {
            Console.WriteLine($"     _  ___   ____  ___     ____  ___  _   _ ____  __  __ _____ _____ \r\n    | |/ _ \\ / ___|/ _ \\   / ___|/ _ \\| | | |  _ \\|  \\/  | ____|_   _|\r\n _  | | | | | |  _| | | | | |  _| | | | | | | |_) | |\\/| |  _|   | |  \r\n| |_| | |_| | |_| | |_| | | |_| | |_| | |_| |  _ <| |  | | |___  | |  \r\n \\___/ \\___/ \\____|\\___/   \\____|\\___/ \\___/|_| \\_\\_|  |_|_____| |_|  ");
            Console.WriteLine($")  (\r\n     (   ) )\r\n      ) ( (\r\n   _______)_\r\n .-'---------|  \r\n( C|/\\/\\/\\/\\/|\r\n '-./\\/\\/\\/\\/|\r\n   '_________'\r\n    '-------'");
            Console.WriteLine("Pense em um prato e eu tentarei adivinhar (Quando estiver pronto pressione enter)\nPressione qualquer outra tecla para sair do programa");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                while (true)
                {
                    AdvinharPrato(raiz);

                    Console.WriteLine("Deseja jogar novamente? (sim/nao)");
                    string resposta = Console.ReadLine();

                    if (resposta?.ToLower() != "sim")
                    {
                        Console.WriteLine("Encerrando o jogo. Até a próxima!");
                        Environment.Exit(0);
                    }

                }
            }
            else
            {
                Console.WriteLine("Fechando...");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        private void AdvinharPrato(Noh noh)
        {
            if (noh.EhPrato)
            {
                Console.WriteLine($"Você está pensando em {noh.Nome}? (sim/não)");
                if (Console.ReadLine()?.ToLower() == "sim")
                {
                    Console.WriteLine("Acertei!");
                }
                else
                {
                    AdicionarNovoPrato(noh);
                }
            }
            else
            {
                Console.WriteLine($"Você está pensando em uma {noh.Nome}? (sim/não)");
                if (Console.ReadLine()?.ToLower() == "sim")
                {
                    AdvinharPrato(noh.Sim);
                }
                else
                {
                    if (noh.Nao == null)
                    {
                        AdicionarNovaCategoria(noh);
                    }
                    else
                    {
                        AdvinharPrato(noh.Nao);
                    }
                }
            }
        }

        private static void AdicionarNovoPrato(Noh noh)
        {
            Console.WriteLine("Qual prato você estava pensando?");
            string novoPrato = Console.ReadLine();

            Console.WriteLine($"{novoPrato} é ______, mas {noh.Nome} não.");
            string novaDiferenca = Console.ReadLine();


            Noh pratoAntigo = new Noh(noh.Nome);
            Noh pratoNovo = new Noh(novoPrato);


            noh.Nome = novaDiferenca;
            noh.Sim = pratoNovo;
            noh.Nao = pratoAntigo;
        }

        private static void AdicionarNovaCategoria(Noh noh)
        {
            Console.WriteLine("Qual prato você estava pensando?");
            string novoPrato = Console.ReadLine();

            Console.WriteLine($"{novoPrato} é ______, mas {noh.Nome} não.");
            string novaDiferenca = Console.ReadLine();

            Noh novaCategoria = new Noh(novaDiferenca);
            novaCategoria.Sim = new Noh(novoPrato);
            novaCategoria.Nao = new Noh("lasanha");

            noh.Nao = novaCategoria;
        }
    }

}
