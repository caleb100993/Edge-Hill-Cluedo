//using generic system imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//all classes under the same namespace
namespace CluedoGame
{
    /*this is the welcome class. All the rules, aim and actions are created here and is called in the main method to display
     * right at the very start.
     * created by Caleb Mathomes on 21/12/14*/
    class Welcome
    {
        public void welcome()
        {
            Console.WriteLine("Welcome to Edge Hill Cluedo");
            Console.WriteLine("Can you find out who commited the murder?");
            Console.WriteLine("Aims:");
            Console.WriteLine("You need to guess the 3 cards in the envelop, 1 for the Suspect, 1 for the Weapon and 1 for the Location");
            Console.WriteLine("You will be given a set of cards which help you narrow down who the real culprit, weapon and location is");
            Console.WriteLine("You can then make a suggestion which another player then needs to disprove if they have the card you suggested");
            Console.WriteLine("If you think you deffinately know which 3 cards are in the envelope you can make an accusation");
            Console.WriteLine("If you geuss right or you are the only remaining player, you win!");
            Console.WriteLine("Rules:");
            Console.WriteLine("You can have up to 6 players but no less than 3");
            Console.WriteLine("You then type each players name into the system");
            Console.WriteLine("during the game you can type 'help' which will show you your options available");
            Console.WriteLine("tip make sure you hide your screen when typing 'show'");
            Console.WriteLine("This will show all your cards so keep them hidden!");
            Console.WriteLine("You will be placed on a random block before you start");
            Console.WriteLine("if you land on a block with a doorway, you can enter the secret room...ooooooo");
            Console.WriteLine("There you will be promt if you would like to make a suggestion or accustion");
            Console.WriteLine("but....make sure you deffinately know who it is otherwise you are eliminated from the game");
            Console.WriteLine("Actions:");
            Console.WriteLine("'r' is to roll the dice");
            Console.WriteLine("'show' is to display all the cards in your hand");
            Console.WriteLine("'a' is to accuse(you can only accuse if you are in a room)");
            Console.WriteLine("'s' is to suggest(you can only suggest if you are in a room)");
            Console.WriteLine("'e' is to end turn");
            Console.WriteLine("'room' is to enter a room(You can only enter if your on a doorway block)");
            Console.WriteLine("'help' will display this information again \n");
        }//end of welcome
    }//end of Welcome
}//end of namespace
