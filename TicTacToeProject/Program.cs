namespace TicTacToeProject
{
    internal class Program
    {
        static string[,] ticTacToe =
        {
            { "1", "2", "3" },
            { "4", "5", "6" },
            { "7", "8", "9" },
        };

        public static bool Checker()
        {
            // TODO
            // Horizontal
            string value = "";
            int counter;
            int _;
            for (int i = 0; i < ticTacToe.GetLength(0); i++) //rows
            {
                if (int.TryParse(ticTacToe[i, i], out _))
                {
                    continue;
                }
                value = ticTacToe[i, 0];
                counter = 1;
                for (int j = 1; j < ticTacToe.GetLength(1); j++) //columns
                {
                    if (!(ticTacToe[i, j].Equals(value)))
                    {
                        break;
                    }
                    counter++;
                }
                if (counter == 3)
                {
                    ShowGrid();
                    Console.WriteLine($"Winner {value}");
                    return true;
                }
            }

            // Vertical
            for (int i = 0; i < ticTacToe.GetLength(1); i++) //columns
            {
                if (int.TryParse(ticTacToe[i, i], out _))
                {
                    continue;
                }
                value = ticTacToe[0, i];
                counter = 1;
                for (int j = 1; j < ticTacToe.GetLength(0); j++) //rows
                {
                    if (!(ticTacToe[j, i].Equals(value)))
                    {
                        break;
                    }
                    counter++;
                }
                if (counter == 3)
                {
                    ShowGrid();
                    Console.WriteLine($"Winner {value}");
                    return true;
                }
            }

            // First diagonal
            counter = 0;
            value = ticTacToe[0, 0];
            for (int i = 0; i < ticTacToe.GetLength(0); i++) // rows and columns
            {
                if (int.TryParse(ticTacToe[i, i], out _))
                {
                    continue;
                }
                if (!(ticTacToe[i, i].Equals(value)))
                {
                    break;
                }
                value = ticTacToe[i, i];
                counter++;
            }
            if (counter == 3)
            {
                ShowGrid();
                Console.WriteLine($"Winner {value}");
                return true;
            }

            // Second diagonal
            counter = 0;
            value = ticTacToe[0, 2];
            for (int i = 0, j = ticTacToe.GetLength(0) - 1; i < ticTacToe.GetLength(0); i++, j--) // rows and columns
            {
                if (int.TryParse(ticTacToe[i, j], out _))
                {
                    continue;
                }
                if (!(ticTacToe[i, j].Equals(value)))
                {
                    break;
                }
                value = ticTacToe[i, j];
                counter++;
            }
            if (counter == 3)
            {
                ShowGrid();
                Console.WriteLine($"Winner {value}");
                return true;
            }
            return false;
        }

        static void ResetGame()
        {
            int counter = 1;
            for (int i = 0; i < ticTacToe.GetLength(0); i++)
            {
                for (int j = 0; j < ticTacToe.GetLength(1); j++)
                {
                    ticTacToe[i, j] = counter.ToString();
                    counter++;
                }
            }
        }

        static void ShowGrid()
        {
            Console.Clear();
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", ticTacToe[0,0], ticTacToe[0, 1], ticTacToe[0, 2]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", ticTacToe[1, 0], ticTacToe[1, 1], ticTacToe[1, 2]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", ticTacToe[2, 0], ticTacToe[2, 1], ticTacToe[2, 2]);
            Console.WriteLine("   |   |   ");
        }

        //static void ShowGrid()
        //{
        //    Console.Clear();
        //    int row = 0;
        //    int col = 0;
        //    for (int i = 0; i < 9; i++)
        //    {
        //        for (int j = 0; j < 12; j++)
        //        {

        //            //Fill up empty lines
        //            if (i == 0 || i == 3 || i == 6 || i == 8)
        //            {
        //                if (j == 3 || j == 7)
        //                {
        //                    Console.Write("|");
        //                    continue;
        //                }
        //                Console.Write(" ");
        //                continue;
        //            }

        //            //Fill up lines with horizontal separators
        //            if (i == 2 || i == 5)
        //            {
        //                if (j == 3 || j == 7)
        //                {
        //                    Console.Write("|");
        //                    continue;
        //                }
        //                Console.Write("_");
        //                continue;
        //            }

        //            //Fill up the lines with values
        //            if (j == 1 || j == 5 || j == 9)
        //            {
        //                Console.Write(ticTacToe[row, col]);
        //                col++;
        //                if (col > 2)
        //                {
        //                    col = 0;
        //                    row++;
        //                    if (row > 2)
        //                    {
        //                        row = 0;
        //                    }
        //                }
        //                continue;
        //            }
        //            if (j == 3 || j == 7)
        //            {
        //                Console.Write("|");
        //                continue;
        //            }
        //            Console.Write(" ");
        //            continue;
        //        }
        //        //Move to the next lines
        //        Console.WriteLine("");
        //        continue;
        //    }
        //}

        static bool EnterValue(string? value, bool player1Turn)
        {
            int numericValue;
            if (!int.TryParse(value, out numericValue))
            {
                Console.WriteLine("Enter a correct value");
                return false;
            }
            if (!((numericValue > 0) && (numericValue < 10)))
            {
                Console.WriteLine("Enter a correct value");
                return false;
            }

            bool positionFound = false;
            for (int i = 0; i < ticTacToe.GetLength(0); i++)
            {
                for (int j = 0; j < ticTacToe.GetLength(1); j++)
                {
                    if (value.Equals(ticTacToe[i, j]))
                    {
                        ticTacToe[i, j] = player1Turn ? "X" : "O";
                        positionFound = true;
                        break;
                    }
                }
            }
            if (!positionFound)
            {
                Console.WriteLine("The position is already taken. Choose another one!");
            }
            return positionFound;

        }

        static bool CheckTie()
        {
            foreach (string element in ticTacToe)
            {
                if (int.TryParse(element, out _))
                {
                    return false;
                }
            }
            ShowGrid();
            Console.WriteLine("It is a tie!");
            return true;
        }
        static void Main()
        {
            string? continuePlaying;
            bool player1Turn = true;
            do
            {
                ResetGame();
                do
                {
                    ShowGrid();
                    string? position;
                    do
                    {
                        string activePlayer = player1Turn ? "Player 1 (X)" : "Player 2 (O)";
                        Console.WriteLine($"{activePlayer} enter the position.");
                        position = Console.ReadLine();
                    } while (!EnterValue(position, player1Turn));
                    player1Turn = !player1Turn;
                } while (!Checker() && !CheckTie());

                Console.WriteLine("To stop playing enter 'N'");
                continuePlaying = Console.ReadLine();
            } while (continuePlaying == null || !continuePlaying.ToLower().Equals("n"));
        }
    }
}