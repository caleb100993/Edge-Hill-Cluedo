//using generic system imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//all classes under the same namespace
namespace CluedoGame
{
    /*this class was originally meant to store every card for the suspect however it is only used to store
     * the enveloped suspect now.
     * create by Caleb Mathomes on 25/11/14*/
    class SuspectCards
    {
        //variable to store the eveloped suspect
        private string suspect;

        /*this is a basic set method which will set the suspect card when enveloping. sets the suspect to the passed
         * in arguement value
         * created by Caleb Mathomes on 11/11/14*/
        public void populateSuspect(string newSuspect)
        {
            suspect = newSuspect;
        }//end of populateSuspect

        /*this is a basic get method which will return the value stored in the suspect variable after it has been
         * set when the envelop method is called.
         * created by Caleb Mathomes 11/11/14*/
        public string getSuspect()
        {
            return suspect;
        }//end of getSuspect
    }//end of SuspectCards
}//end of namespace
