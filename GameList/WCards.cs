//using generic system imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//all classes under the same namespace
namespace CluedoGame
{
    /*this class was originally meant to store every card for the weapon however it is only used to store
     * the enveloped weapon now.
     * create by Caleb Mathomes on 25/11/14*/
    class WCards
    {
        //variable to store the eveloped weapon
        private string weapon;

        /*this is a basic set method which will set the weapon card when enveloping. sets the weapon to the passed
         * in arguement value
         * created by Caleb Mathomes on 11/11/14*/
        public void populateWeapons(string newWeapon)
        {
            weapon = newWeapon;
        }//end of populateWeapons

        /*this is a basic get method which will return the value stored in the weapon variable after it has been
         * set when the envelop method is called.
         * created by Caleb Mathomes 11/11/14*/
        public string getWeapon()
        {
            return weapon;
        }//end of getWeapon
    }//end of WCards
}//end of namespace
