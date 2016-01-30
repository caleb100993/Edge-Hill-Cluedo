//generic imports since we dont require any other import
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace of the whole project
namespace CluedoGame
{
    /*this class will contain all the cards in the game as well as taking 3 of them and eveloping them
     * to store the room card, weapon card and suspect card. it will also shuffle and distribute all the cards 
     * to invidual players in the game.
     * created on the 02/12/14 by Caleb Mathomes*/
    class Cards
    {
        //this will hold the enveloped weapon card from the WCards class
        private WCards envelopWeapon;
        //this will hold the enveloped room card from the RoomCard class
        private RoomCards envelopRoom;
        //this will hold the enveloped suspect card from the SuspectCards class
        private SuspectCards envelopSuspect;
        //each array will hold each deck of cards of each type of card
        public string[] roomCard = new string[7];
        public string[] suspectCard = new string[7];
        public string[] weaponCard = new string[7];
        //this array will store all the remaining cards after enveloping a card from each type
        private string[] allCards = new string[18];

        /*this will return the stored string in the WCards class
         * a temp value will store the string from the weapon cards class which will be returned
         * created by Caleb Mathomes on 16/12/14*/
        public string getEnvelopWeapon()
        {
            string temp = envelopWeapon.getWeapon();
            return temp;
        }//end of getEnvelopWeapon

        /*this will return the stored string in the SuspectCards class
         * a temp value will store the string from the suspect cards class which will be returned
         * created by Caleb Mathomes on 16/12/14*/
        public string getEnvelopSuspect()
        {
            string temp = envelopSuspect.getSuspect();
            return temp;
        }//end of getEnvelopSuspect

        /*this will return the stored string in the RoomCards class
         * a temp value will store the string from the room cards class which will be returned
         * created by Caleb Mathomes on 16/12/14*/
        public string getEnvelopRoom()
        {
            string temp = envelopRoom.getRoom();
            return temp;
        }//end of getEnvelopRoom

        /*this method will set values to the arrays we created globally at the top. This is so we can populate the
         * weapon array,add them to the allCards array, shuffle the values and distribute them to each player.
         * created by Caleb Mathomes on 16/12/14*/
        public void populateWeaponCards()
        {
            weaponCard[0] = "Pen Drive";
            weaponCard[1] = "Power Cable";
            weaponCard[2] = "Keyboard";
            weaponCard[3] = "Stapler";
            weaponCard[4] = "Soldering Iron";
            weaponCard[5] = "Scissors";
            weaponCard[6] = "Powerpoint";
        }//end of populateWeaponCards

        /*this method will set values to the arrays we created globally at the top. This is so we can populate the
         * room array,add them to the allCards array, shuffle the values and distribute them to each player.
         * created by Caleb Mathomes on 16/12/14*/
        public void populateRoomCards()
        {
            roomCard[0] = "Lecture Theatre";
            roomCard[1] = "Research Lab";
            roomCard[2] = "Laptop Lab";
            roomCard[3] = "Network Lab";
            roomCard[4] = "School Office";
            roomCard[5] = "CE011";
            roomCard[6] = "Foyer";
        }//end of populateRoomCards

        /*this method will set values to the arrays we created globally at the top. This is so we can populate the
         * suspect array,add them to the allCards array, shuffle the values and distribute them to each player.
         * created by Caleb Mathomes on 16/12/14*/
        public void populateSuspectCards()
        {
            suspectCard[0] = "Mark";
            suspectCard[1] = "Collette";
            suspectCard[2] = "Chris";
            suspectCard[3] = "Dan";
            suspectCard[4] = "Darryl";
            suspectCard[5] = "Sally";
            suspectCard[6] = "Peter";
        }//end of populateSuspectCards

        /*This is the envelop method which will store 3 cards, 1 from each array being the weaponsCard, SuspectsCard
         * and roomsCard.
         * it takes 3 arguements which will take the arguements, create new instances of the class and pass them to 
         * the populate methods for each card class.
         * created by Caleb Mathomes on 16/12/14*/
        public void envelop(string storeWeaponCard, string storeRoomCard, string storeSuspectCard)
        {
            //instatiate a new weapon class to hold the random weapon card passed in
            envelopWeapon = new WCards();
            envelopWeapon.populateWeapons(storeWeaponCard);
            //instatiate a new room class to hold the random room card passed in
            envelopRoom = new RoomCards();
            envelopRoom.populateRoom(storeRoomCard);
            //instatiate a new suspect class to hold the random suspect card passed in
            envelopSuspect = new SuspectCards();
            envelopSuspect.populateSuspect(storeSuspectCard);
        }//end of envelop

        /* this method is to add all cards to the allCards array. Each loop adds one card from each array
         * into the allCards, increamenting i with each loop and increamenting j with each if statement.
         * the method takes no arguements and returns no value since it is just populating the allCards array.
         * this method was created by Martin McCaslin which helped adopted it into my game. */
        public void collectCards()
        {
            //i will increment with each loop adding the indexed card to the allCards Array
            int i = 0;
            //j will increment with each if statement so the data is stored to a new index each time a card
            //is stored to the allCards array
            int j = 0;

            //loop seven times for each card in each card array
            while(i < 7)
            {
                //the the index of the room card does not match the one in the envelop then it can store
                //the data from the roomCard array to the allCard array
                if(roomCard[i] != envelopRoom.getRoom())
                {
                    allCards[j] = roomCard[i];
                    j++;
                }
                //the the index of the weapon card does not match the one in the envelop then it can store
                //the data from the weaponCard array to the allCard array
                if (weaponCard[i] != envelopWeapon.getWeapon())
                {
                    allCards[j] = weaponCard[i];
                    j++;
                }
                //the the index of the suspect card does not match the one in the envelop then it can store
                //the data from the suspectCard array to the allCard array
                if (suspectCard[i] != envelopSuspect.getSuspect())
                {
                    allCards[j] = suspectCard[i];
                    j++;
                }
                i++;
            }
        }//end of collectCards

        /*this will take a random index from each array and assign the value stored in that array and pass them to
         * the envelop method which will store 3 random cards and store them in the WCards, RoomCards and SuspectCards
         * classes.
         * created on the 18/12/14*/
        public void setEnvelope()
        {
            //the random generator
            Random r = new Random();
            //random number between 0 and 7 which will set its value to the index of the weaponCard Array
            int randomCard = r.Next(0, 7);
            string tempWeapon = weaponCard[randomCard];
            //random number between 0 and 7 which will set its value to the index of the roomCard Array
            randomCard = r.Next(0, 7);
            string tempRoom = roomCard[randomCard];
            //random number between 0 and 7 which will set its value to the index of the suspectCard Array
            randomCard = r.Next(0, 7);
            string tempSuspect = suspectCard[randomCard];
            //evelopes these 3 random cards from each array to be stored in seperate classes
            envelop(tempWeapon, tempRoom, tempSuspect);
        }//end of setEnvelope

        /*dispense cards is set to call all populate methods so there are cards to deal out, Evelops the 3 random
         * cards and collects all the remaining cards into the allCards array which will then be shuffled and dealt.
         * this method was created on 18/12/14 by Caleb Mathomes*/
        public void dispenseCards()
        {
            //Calls to all the other methods in this class
            populateWeaponCards();
            populateRoomCards();
            populateSuspectCards();
            setEnvelope();
            collectCards();

            shuffleCards(allCards);

            //deals the cards if there are only 3 players
            if (CreateBoard.p4 == null && CreateBoard.p5 == null && CreateBoard.p6 == null)
            {
                CreateBoard.p1.addCard(allCards[0]);
                CreateBoard.p1.addCard(allCards[1]);
                CreateBoard.p1.addCard(allCards[2]);
                CreateBoard.p1.addCard(allCards[3]);
                CreateBoard.p1.addCard(allCards[4]);
                CreateBoard.p1.addCard(allCards[5]);

                CreateBoard.p2.addCard(allCards[6]);
                CreateBoard.p2.addCard(allCards[7]);
                CreateBoard.p2.addCard(allCards[8]);
                CreateBoard.p2.addCard(allCards[9]);
                CreateBoard.p2.addCard(allCards[10]);
                CreateBoard.p2.addCard(allCards[11]);

                CreateBoard.p3.addCard(allCards[12]);
                CreateBoard.p3.addCard(allCards[13]);
                CreateBoard.p3.addCard(allCards[14]);
                CreateBoard.p3.addCard(allCards[15]);
                CreateBoard.p3.addCard(allCards[16]);
                CreateBoard.p3.addCard(allCards[17]);
            }

                //deals the cards if there are 4 players
            else if (CreateBoard.p4 != null && CreateBoard.p5 == null && CreateBoard.p6 == null)
            {
                CreateBoard.p1.addCard(allCards[0]);
                CreateBoard.p2.addCard(allCards[1]);
                CreateBoard.p3.addCard(allCards[2]);
                CreateBoard.p4.addCard(allCards[3]);
                CreateBoard.p1.addCard(allCards[4]);
                CreateBoard.p2.addCard(allCards[5]);
                CreateBoard.p3.addCard(allCards[6]);
                CreateBoard.p4.addCard(allCards[7]);
                CreateBoard.p1.addCard(allCards[8]);
                CreateBoard.p2.addCard(allCards[9]);
                CreateBoard.p3.addCard(allCards[10]);
                CreateBoard.p4.addCard(allCards[11]);
                CreateBoard.p1.addCard(allCards[12]);
                CreateBoard.p2.addCard(allCards[13]);
                CreateBoard.p3.addCard(allCards[14]);
                CreateBoard.p4.addCard(allCards[15]);
                CreateBoard.p1.addCard(allCards[16]);
                CreateBoard.p2.addCard(allCards[17]);
            }
                //deals the cards if 5 players exist
            else if (CreateBoard.p4 != null && CreateBoard.p5 != null && CreateBoard.p6 == null)
            {
                CreateBoard.p1.addCard(allCards[0]);
                CreateBoard.p2.addCard(allCards[1]);
                CreateBoard.p3.addCard(allCards[2]);
                CreateBoard.p4.addCard(allCards[3]);
                CreateBoard.p5.addCard(allCards[4]);
                CreateBoard.p1.addCard(allCards[5]);
                CreateBoard.p2.addCard(allCards[6]);
                CreateBoard.p3.addCard(allCards[7]);
                CreateBoard.p4.addCard(allCards[8]);
                CreateBoard.p5.addCard(allCards[9]);
                CreateBoard.p1.addCard(allCards[10]);
                CreateBoard.p2.addCard(allCards[11]);
                CreateBoard.p3.addCard(allCards[12]);
                CreateBoard.p4.addCard(allCards[13]);
                CreateBoard.p5.addCard(allCards[14]);
                CreateBoard.p1.addCard(allCards[15]);
                CreateBoard.p2.addCard(allCards[16]);
                CreateBoard.p3.addCard(allCards[17]);
            }
                //otherwise just deal to all 6 players
            else
            {
                CreateBoard.p1.addCard(allCards[0]);
                CreateBoard.p2.addCard(allCards[1]);
                CreateBoard.p3.addCard(allCards[2]);
                CreateBoard.p4.addCard(allCards[3]);
                CreateBoard.p5.addCard(allCards[4]);
                CreateBoard.p6.addCard(allCards[5]);
                CreateBoard.p1.addCard(allCards[6]);
                CreateBoard.p2.addCard(allCards[7]);
                CreateBoard.p3.addCard(allCards[8]);
                CreateBoard.p4.addCard(allCards[9]);
                CreateBoard.p5.addCard(allCards[10]);
                CreateBoard.p6.addCard(allCards[11]);
                CreateBoard.p1.addCard(allCards[12]);
                CreateBoard.p2.addCard(allCards[13]);
                CreateBoard.p3.addCard(allCards[14]);
                CreateBoard.p4.addCard(allCards[15]);
                CreateBoard.p5.addCard(allCards[16]);
                CreateBoard.p6.addCard(allCards[17]);
            }
        }//end of dispenseCards

        /*this method takes in the allCards array and will begin a loop. creates a integer value which stores the multiplication
         *if the index of the for loop plus a random number between 1 or 0 by the length of the allCards array minus the index
         *<T> is then stored from allCards index generated from i. With each loop the index of Card changes and sets it to the
         *index of the loop.*/
        //referenced by http://www.dotnetperls.com/fisher-yates-shuffle
        static void shuffleCards<T>(T[] cards)
        {
            Random rand = new Random();
            for (int i = 0; i < cards.Length; i++)
            {
                int r = i + (int)(rand.NextDouble() * (cards.Length - i));
                T t = cards[r];
                cards[r] = cards[i];
                cards[i] = t;
            }
        }//end of shuffle
    }//end of Cards
}//end of namespace
