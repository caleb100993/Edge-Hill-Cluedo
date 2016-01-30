//using generic system imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//all classes under the same namespace
namespace CluedoGame
{
    /*this class was originally meant to store every card for the room however it is only used to store
     * the enveloped room now.
     * create by Caleb Mathomes on 25/11/14*/
    class RoomCards
    {
        //variable to store the room suspect
        private string room;

        /*this is a basic set method which will set the room card when enveloping. sets the room to the passed
         * in arguement value
         * created by Caleb Mathomes on 11/11/14*/
        public void populateRoom(string newRooms)
        {
            room = newRooms;
        }//end of populateRoom

        /*this is a basic get method which will return the value stored in the room variable after it has been
         * set when the envelop method is called.
         * created by Caleb Mathomes 11/11/14*/
        public string getRoom()
        {
            return room;
        }//end of getRoom
    }//end of RoomCards
}//end of namespace
