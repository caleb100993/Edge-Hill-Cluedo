//generic imports since we dont require any other import
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//this is the global namespace we will use to keep all the classes
namespace CluedoGame
{
    /*this class will contain the main method where the CreateBoard class will be created and instatiated and calls all methods
     * relating to that class.
     * created by Caleb Mathomes 16/12/14*/
    class InitiateGame
    {
        /*the main method where the program begins from. This will instatiate the welcome screen which displays all the rules
         * and aims. a while loop is also created which will server as the loop if the user feels to have begin a new game.
         * the repeat value affects whether the loop is broken or if the user wishes to continue.
         * created by Caleb Mathomes on 11/11/14*/
        private static void Main(string[] args)
        {
            bool repeat = true;
            Welcome w = new Welcome();
            w.welcome();
            while(repeat == true)
            {
                CreateBoard cb = new CreateBoard();
                cb.populateBoard();
                cb.addPlayers();
                cb.move();
                Console.WriteLine("New Game?(Y/N)");
                string again = Console.ReadLine();
                //changes reapeat based on the users answer
                if (again == "y" || again == "Y")
                {
                    repeat = true;
                }
                else
                {
                    repeat = false;
                }
            }
        }//end of main
    }//end of IntiateGame
}//end of namespace
