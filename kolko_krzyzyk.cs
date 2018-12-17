using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolko_i_krzyzyk
{
    class Program
    {
        static void Main(string[] args)
        {
            int runda = 1;
            bool play = true;
            String playername1, playername2;
            KolkoKrzyzyk game = new KolkoKrzyzyk
            {
                Field11 = "1",
                Field12 = "2",
                Field13 = "3",
                Field21 = "4",
                Field22 = "5",
                Field23 = "6",
                Field31 = "7",
                Field32 = "8",
                Field33 = "9"
            };

            game.fields[0, 0] = game.Field11;
            game.fields[0, 1] = game.Field12;
            game.fields[0, 2] = game.Field13;
            game.fields[1, 0] = game.Field21;
            game.fields[1, 1] = game.Field22;
            game.fields[1, 2] = game.Field23;
            game.fields[2, 0] = game.Field31;
            game.fields[2, 1] = game.Field32;
            game.fields[2, 2] = game.Field33;

            Console.WriteLine("Witaj w grze w kółko i krzyżyk. Pierwszy gracz gra X, drugi O. Wpisuj maksymalnie jedną cyfrę!\n");

            Console.Write("Podaj imię gracza 1: ");
            playername1 = Console.ReadLine();
            Console.Write("Podaj imię gracza 2: ");
            playername2 = Console.ReadLine();

            Player player1 = new Player(playername1, "X");
            Player player2 = new Player(playername2, "O");

            Console.Clear();

            while (runda <= 9 && play)
            {
                game.PrintGame();
                Console.WriteLine(" ");
                Mechanism.Tura(game, ref runda, player1, player2, ref play);
            };

            Console.ReadKey();
            Console.Clear();
            Console.ReadKey();
        }
    }
    public class KolkoKrzyzyk
    {
        private string field11;
        private string field12;
        private string field13;
        private string field21;
        private string field22;
        private string field23;
        private string field31;
        private string field32;
        private string field33;
        private Player player1;
        private Player player2;
        public string[,] fields = new string[3, 3];

        public string Field11 { get => field11; set => field11 = value; }
        public string Field12 { get => field12; set => field12 = value; }
        public string Field13 { get => field13; set => field13 = value; }

        public string Field21 { get => field21; set => field21 = value; }
        public string Field22 { get => field22; set => field22 = value; }
        public string Field23 { get => field23; set => field23 = value; }

        public string Field31 { get => field31; set => field31 = value; }
        public string Field32 { get => field32; set => field32 = value; }
        public string Field33 { get => field33; set => field33 = value; }

        public Player Player1 { get => player1; set => player1 = value; }
        public Player Player2 { get => player2; set => player2 = value; }

        public KolkoKrzyzyk()
        {
        }

        public void PrintGame()
        {
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", fields[0, 0], fields[0, 1], fields[0, 2]);
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", fields[1, 0], fields[1, 1], fields[1, 2]);
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", fields[2, 0], fields[2, 1], fields[2, 2]);
            Console.WriteLine("       |       |       ");
        }
    }
    public class Player
    {
        private string name;
        private string xoro;

        public string Name { get => name; set => name = value; }
        public string XorO { get => xoro; set => xoro = value; }

        public Player() { }

        public Player(string name, string xoro)
        {
            this.name = name;
            this.xoro = xoro;
        }
    }
    public static class Mechanism
    {
        public static void Tura(KolkoKrzyzyk game, ref int round, Player player1, Player player2, ref bool play)
        {
            string choice;
            if (round > 9)
            {
                Console.WriteLine("Remis!!!");
            }
            else
            {
                if (round % 2 == 1)
                {
                    Console.Write("Tura gracza ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(player1.Name);
                    Console.ResetColor();
                    Console.Write(" - wybierz pole: ");
                    choice = Console.ReadLine();
                    SwitchCase(game, choice, player1, player2, ref round, ref play);
                }
                else
                {
                    Console.Write("Tura gracza ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(player2.Name);
                    Console.ResetColor();
                    Console.Write(" - wybierz pole: ");
                    choice = Console.ReadLine();
                    SwitchCase(game, choice, player2, player1, ref round, ref play);
                }
            }
        }

        public static void SwitchCase(KolkoKrzyzyk game, string choice, Player player1, Player player2, ref int round, ref bool play)
        {
            switch (choice)
            {
                case "1": CheckIfEmpty(game, choice, game.fields[0, 0], player1, player2, ref round, ref play); break;
                case "2": CheckIfEmpty(game, choice, game.fields[0, 1], player1, player2, ref round, ref play); break;
                case "3": CheckIfEmpty(game, choice, game.fields[0, 2], player1, player2, ref round, ref play); break;
                case "4": CheckIfEmpty(game, choice, game.fields[1, 0], player1, player2, ref round, ref play); break;
                case "5": CheckIfEmpty(game, choice, game.fields[1, 1], player1, player2, ref round, ref play); break;
                case "6": CheckIfEmpty(game, choice, game.fields[1, 2], player1, player2, ref round, ref play); break;
                case "7": CheckIfEmpty(game, choice, game.fields[2, 0], player1, player2, ref round, ref play); break;
                case "8": CheckIfEmpty(game, choice, game.fields[2, 1], player1, player2, ref round, ref play); break;
                case "9": CheckIfEmpty(game, choice, game.fields[2, 2], player1, player2, ref round, ref play); break;
                default: Tura(game, ref round, player1, player2, ref play); break;
            }
        }
        public static void CheckIfEmpty(KolkoKrzyzyk game, string choice, string field, Player player1, Player player2, ref int round, ref bool play)
        {
            if (field == "O" || field == "X")
            {
                Console.WriteLine("To pole było już wybrane. Wybierz inne.");
                Tura(game, ref round, player1, player2, ref play);
            }
            else
            {
                Console.Clear();
                switch (choice)
                {
                    case "1": WhichField(game, 0, 0, player1); break;
                    case "2": WhichField(game, 0, 1, player1); break;
                    case "3": WhichField(game, 0, 2, player1); break;
                    case "4": WhichField(game, 1, 0, player1); break;
                    case "5": WhichField(game, 1, 1, player1); break;
                    case "6": WhichField(game, 1, 2, player1); break;
                    case "7": WhichField(game, 2, 0, player1); break;
                    case "8": WhichField(game, 2, 1, player1); break;
                    case "9": WhichField(game, 2, 2, player1); break;
                    default: break;
                }
                round++;
                WinnerCheck(game, player1, player2, ref play, ref round);
            }
        }

        public static void WhichField(KolkoKrzyzyk game, int a, int b, Player player)
        {
            game.fields[a, b] = player.XorO;
        }

        public static void WinnerCheck(KolkoKrzyzyk game, Player player1, Player player2, ref bool play, ref int round)
        {
            if (game.fields[0, 0].Equals(game.fields[0, 1]) && game.fields[0, 0].Equals(game.fields[0, 2]) || game.fields[0, 0].Equals(game.fields[1, 0]) && game.fields[0, 0].Equals(game.fields[2, 0]))
            {
                if (game.fields[0, 0].Equals(player1.XorO))
                {
                    Player1Won(game, player1);
                }
                else
                {
                    Player2Won(game, player2);
                }
                play = false;
            }
            else if (game.fields[2, 0].Equals(game.fields[2, 1]) && game.fields[2, 0].Equals(game.fields[2, 2]) || game.fields[0, 2].Equals(game.fields[1, 2]) && game.fields[0, 2].Equals(game.fields[2, 2]))
            {
                if (game.fields[2, 2].Equals(player1.XorO))
                {
                    Player1Won(game, player1);
                }
                else
                {
                    Player2Won(game, player2);
                }
                play = false;
            }
            else if (game.fields[0, 1].Equals(game.fields[1, 1]) && game.fields[0, 1].Equals(game.fields[2, 1]) || game.fields[1, 0].Equals(game.fields[1, 1]) && game.fields[1, 0].Equals(game.fields[1, 2]))
            {
                if (game.fields[1, 1].Equals(player1.XorO))
                {
                    Player1Won(game, player1);
                }
                else
                {
                    Player2Won(game, player2);
                }
                play = false;
            }
            else if (game.fields[0, 0].Equals(game.fields[1, 1]) && game.fields[0, 0].Equals(game.fields[2, 2]) || game.fields[2, 0].Equals(game.fields[1, 1]) && game.fields[2, 0].Equals(game.fields[0, 2]))
            {
                if (game.fields[1, 1].Equals(player1.XorO))
                {
                    Player1Won(game, player1);
                }
                else
                {
                    Player2Won(game, player2);
                }
                play = false;
            }
            else if (round > 9)
            {
                Console.WriteLine("REMIS!");
            }
        }
        public static void Player1Won(KolkoKrzyzyk game, Player player1)
        {
            game.PrintGame();
            Console.Write("Wygrał gracz ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(player1.Name);
            Console.ResetColor();
            Console.Write("!");
        }
        public static void Player2Won(KolkoKrzyzyk game, Player player2)
        {
            game.PrintGame();
            Console.Write("Wygrał gracz ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(player2.Name);
            Console.ResetColor();
            Console.Write("!");
        }
    }
}