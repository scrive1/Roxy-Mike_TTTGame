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
            ConsoleView cView = new ConsoleView();

            cView.SetUpConsoleUI();
            cView.DisplaySplashScreen();
            playerNames = cView.GetPlayerNames();

            //Console.WriteLine(playerNames[0] + ", " + playerNames[1]);
            //Console.ReadLine();
        }
    }
}
