using System;

namespace TTTConsole
{
    class MainClass
    {
        static char choice;
        static char Turn = 'X';
        static int row, col;
        static bool draw = false;
        static char[,] board = new char[3,3] {{'1','2','3'}, {'4','5','6'}, {'7','8','9'}};

        public static void Main(string[] args)
        {

            while (GameOver())
            {
                BoardDesign();
                PlayerTurn();
                GameOver();
            }

            if(Turn == 'X' && draw == false)
            {
                Console.WriteLine("Player2 [O] Wins");
            }
            else if (Turn == 'O' && draw == false)
            {
                Console.WriteLine("Player1 [X] Wins");
            }
            else
            {
                Console.WriteLine("Game Draw");
            }


            Console.ReadKey();
        }


        public static void BoardDesign()
        {
            Console.Clear();
            Console.WriteLine("__________________");

            Console.WriteLine("|     |     |    |");

            Console.WriteLine("|  {0}  |  {1}  |  {2} |", board[0,0], board[0,1], board[0,2]);

            Console.WriteLine("|_____|_____|____|");

            Console.WriteLine("|     |     |    |");

            Console.WriteLine("|  {0}  |  {1}  |  {2} |", board[1,0], board[1,1], board[1,2]);

            Console.WriteLine("|_____|_____|____|");

            Console.WriteLine("|     |     |    |");

            Console.WriteLine("|  {0}  |  {1}  |  {2} |", board[2,0], board[2,1], board[2,2]);

            Console.WriteLine("|_____|_____|____|");
            Console.WriteLine();
            Console.WriteLine();

        }



        public static void PlayerTurn()
        {
            if(Turn == 'X')
            {
                Console.WriteLine("Player1 [X] turn :  ");
            }
            if(Turn == 'O')
            {
                Console.WriteLine("Player2 [O] turn : ");
            }
            

            choice = Convert.ToChar(Console.ReadLine());

            switch (choice)
            {
                case '1': row = 0; col = 0; break;
                case '2': row = 0; col = 1; break;
                case '3': row = 0; col = 2; break;
                case '4': row = 1; col = 0; break;
                case '5': row = 1; col = 1; break; 
                case '6': row = 1; col = 2; break;
                case '7': row = 2; col = 0; break;
                case '8': row = 2; col = 1; break;
                case '9': row = 2; col = 2; break;
                default:
                    Console.WriteLine("Invalid choice : ");
                    break;

            }

            if(Turn == 'X' && board[row,col]!='X' && board[row,col]!='O')
            {
                board[row, col] = 'X';
                Turn = 'O';
            }
           else if (Turn == 'O' && board[row, col] != 'X' && board[row, col] != 'O')
            {
                board[row, col] = 'O';
                Turn = 'X';
            }
            else
            {
                Console.WriteLine("Already filled, Try Again :");
                PlayerTurn();
            }

            BoardDesign();
        }



        public static bool GameOver()
        {
            for(int i=0; i<3; i++)
            {
                if(board[i,0] == board[i,1] && board[i,0] == board[i,2] || board[0, i] == board[1, i] && board[0, i] == board[2, i])
                {
                    return false;
                }
            }

            if(board[0,0] == board[1,1] && board[0,0] == board[2, 2] || board[0,2] == board[1,1] && board[0,2] == board[2,0])
            {
                return false;
            }

            for(int i=0; i<3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(board[i,j] != 'X' && board[i,j] != 'O')
                    {
                        return true;
                    }
                }
            }

            draw = true;
            return false;
        }

    }
}
