using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roxy_MikeTTTGame
{
    class ConsoleView
    {
        #region FIELDS

        //array is initially set location calls to be shown for example on the rules screen
        //array should be reset to only hold spaces at the start of a game
        private string[] GBLocations = new string[9]{" ", " ", " ", " ", " ", " ", " ", " ", " "};
        const int WINDOW_HEIGHT = 38;
        const int WINDOW_WIDTH = 62;
        const string APP_TITLE = "TIC TAC TOE";

        #endregion

        #region PROPERTIES
        #endregion

        #region CONSTRUCTORS
        #endregion

        #region METHODS

        /// <summary>
        /// Sets console text to centered
        /// Code snippet from https://social.msdn.microsoft.com/Forums/vstudio/en-US/153af4c9-3166-404d-b04c-ef6ac0b52f6f/how-to-automatically-center-text-in-a-console-application?forum=csharpgeneral
        /// </summary>
        private void ConsoleWriteCenter(string text)
        {
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + text.Length / 2) + "}", text);
        }

        public void SetUpConsoleUI()
        {
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            Console.BufferWidth = WINDOW_WIDTH;
            Console.BufferHeight = WINDOW_HEIGHT;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = APP_TITLE;
        }

        /// <summary>
        /// Display the splash (welcome) screen and get and respond to user input
        /// </summary>
        public void DisplaySplashScreen()
        {
            ConsoleKeyInfo keyPressed;

            Console.WriteLine();
            ConsoleWriteCenter("WELCOME TO THE TIC TAC TOE GAME!\n");
            ConsoleWriteCenter("Created by Mike Thompson and Roxy Scrivener\n\n\n");
            ConsoleWriteCenter("Press:\n");
            ConsoleWriteCenter("ENTER to begin the game\n");
            ConsoleWriteCenter("R to view the rules\n");
            ConsoleWriteCenter("Esc to exit");

            //get and respond to user input
            keyPressed = Console.ReadKey();
            switch (keyPressed.Key)
            {
                case ConsoleKey.R:
                    DisplayRulesScreen();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            return;
        }

        /// <summary>
        /// Display Rules screen and get and respond to user input
        /// </summary>
        private void DisplayRulesScreen()
        {
            ConsoleKeyInfo keyPressed;

            Console.Clear();

            Console.WriteLine();
            ConsoleWriteCenter("TIC TAC TOE GAME RULES\n\n\n");
            Console.WriteLine("This is a two player game. Player one will be always be Xs and\n" +
                "player two will always be Os.");
            Console.WriteLine("Starting with player one, each player will take their turn\n" +
                "selecting a location on the gameboard. Gameboard locations are\n selected by row" +
                "letter (A, B, C) and column number (1, 2, 3).\n\n");

            //show example gameboard
            DrawGameBoard(GBLocations);

            Console.WriteLine("\n\n For example, if player one wants to place her X in the top\n" +
                "left space on the board, she would type 'A1' and press ENTER.\n\n");
            ConsoleWriteCenter("Press:\n");
            ConsoleWriteCenter("ENTER to begin the game\n");
            ConsoleWriteCenter("ESC to exit");

            //get and respond to user input
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Display the game screen
        /// Uses the name of the player and X or O depending on the player
        /// </summary>
        /// <param name="playerLetter"></param>
        /// <param name="playerName"></param>
        public void DisplayGameScreen(string playerLetter, string[] playerName)
        {
            int currentPlayerNumber;

            Console.Clear();

            //assign currentPlayerLetter bassed on playerNumber
            if (playerLetter == "X")
            {
                currentPlayerNumber = 1;
            }
            else
            {
                currentPlayerNumber = 2;
            }

            Console.WriteLine();
            ConsoleWriteCenter("LET'S PLAY!\n\n");

            DrawGameBoard(GBLocations);

            Console.WriteLine("\n\n\n");
            Console.WriteLine(playerName[currentPlayerNumber] + ", please enter the coordinates where\n" +
                "you would like to place your " + playerLetter + ":\n\n");
        }

        public string GetPlayerMove(string playerLetter)
        {
            string currentPlayerMove;

            currentPlayerMove = Console.ReadLine();

            //update game board array
            switch (currentPlayerMove)
            {
                case "A1":
                    GBLocations[0] = playerLetter;
                    break;
                case "A2":
                    GBLocations[1] = playerLetter;
                    break;
                case "A3":
                    GBLocations[2] = playerLetter;
                    break;
                case "B1":
                    GBLocations[3] = playerLetter;
                    break;
                case "B2":
                    GBLocations[4] = playerLetter;
                    break;
                case "B3":
                    GBLocations[5] = playerLetter;
                    break;
                case "C1":
                    GBLocations[6] = playerLetter;
                    break;
                case "C2":
                    GBLocations[7] = playerLetter;
                    break;
                case "C3":
                    GBLocations[8] = playerLetter;
                    break;
                default:
                    break;
            }

            return currentPlayerMove;
        }

        /// <summary>
        /// Initial draw or redraw the gameboard after each move
        /// </summary>
        /// <param name="array"></param>
        private void DrawGameBoard(string[] array)
        {
            ConsoleWriteCenter("   1   2   3 \n");
            ConsoleWriteCenter("     |   |   ");
            ConsoleWriteCenter("A  " + array[0] + " | " + array[1] + " | " + array[2] + " ");
            ConsoleWriteCenter("  ___|___|___");
            ConsoleWriteCenter("     |   |   ");
            ConsoleWriteCenter("B  " + array[3] + " | " + array[4] + " | " + array[5] + " ");
            ConsoleWriteCenter("  ___|___|___");
            ConsoleWriteCenter("     |   |   ");
            ConsoleWriteCenter("C  " + array[6] + " | " + array[7] + " | " + array[8] + " ");
            ConsoleWriteCenter("     |   |   ");
        }

        /// <summary>
        /// Sets all of the gameboard locations in the GBLocations array to a string containing
        /// only a space (placeholder for player moves)
        /// </summary>
        /// <param name="array"></param>
        private void ResetGameBoard(ref string[] array)
        {
            for (int i = 0; i < 9; i++)
            {
                array[i] = " ";
            }
        }

        public string[] GetPlayerNames()
        {
            string[] names = new string[2];

            Console.Clear();

            Console.WriteLine("Please enter player one's name:\n");
            names[0] = Console.ReadLine();
            Console.WriteLine("\n\nPlease enter player two's name:\n");
            names[1] = Console.ReadLine();

            Console.WriteLine("\n\n");
            ConsoleWriteCenter("Press ENTER to continue.");
            Console.ReadLine();

            return names;
        }

        #endregion


    }
}
