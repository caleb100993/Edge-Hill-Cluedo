//using generic system imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//all classes under the same namespace
namespace CluedoGame
{
    /*this class will be the focal point for the player since it stores the players name, location and cards. It is going
     * to be used to update and change the players location throughout the board as well passed through several methods
     * in order to gain access to the players location.
     * created by Caleb Mathomes 25/11/14*/
    class Player
    {
        //these are the variables which store the players name, location and cards
        //they have been made public for access reasons in the CreateBoard class
        public string name;
        public GameNode location;
        public string[] playerCards = new string[6];

        /*this is a basic set method where the arguement passed in is set to the players name.
         * created by Caleb Mathomes 25/11/14*/
        public void addPLayer(string newName)
        {
            name = newName;
        }//end of addPlayer

        /*this is a basic set location where the GameNode passed in is set to the location of the player changing its
         * location to the new one.
         * Created by Caleb Mathomes 09/12/14*/
        public void setLocation(GameNode newLocation)
        {
            location = newLocation;
        }//end of setLocation

        /*this method will add the cards to the players array when it is being dispensed. It takes the string passed in
         * goes through the loop and checks for null space in the array to add it to. Once added it breaks from the array
         * so it does not continue adding to the deck duplicating cards.
         * created by Caleb Mathomes on 16/12/14*/
        public void addCard(string cardName)
        {
            for (int i = 0; i < 6; i++)
            {
                if (playerCards[i] == null)
                {
                    playerCards[i] = cardName;
                    break;
                }
            }
        }//end of addCard
    }//end of Player
}//end of namespace
