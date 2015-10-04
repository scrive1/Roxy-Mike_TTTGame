using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roxy_MikeTTTGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] playerNames = new string[2];
            string currentPlayerLetter = "X";
            string currentMoveLocation;
            ConsoleView cView = new ConsoleView();

            cView.SetUpConsoleUI();

            cView.DisplaySplashScreen();

            playerNames = cView.GetPlayerNames();

            cView.DisplayGameScreen(currentPlayerLetter, playerNames);

            currentMoveLocation = cView.GetPlayerMove(currentPlayerLetter);

            //Console.WriteLine(playerNames[0] + ", " + playerNames[1]);
            //Console.ReadLine();
        }
    }
}
