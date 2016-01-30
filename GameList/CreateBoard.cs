//generic imports since we dont require any other import
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//this is the global namespace we will use to keep all the classes
namespace CluedoGame
{
    //This class is going to contain all the game nodes, players, run time methods such as adding the players to the game
    //setting up the board and making players traverse the board as they roll the dice
    //it was created 02/12/14 by Caleb Mathomes
    class CreateBoard
    {
        //these will be held as global variables of players since they need to be accessed in the cards class
        public static Player p1, p2, p3, p4, p5, p6;
        //these are the booleans which dictate which players turn it is
        private bool p1Play = true, p2Play, p3Play, p4Play, p5Play, p6Play;
        //these booleans will dictate if a player has been knocked out
        private bool p1Out = false, p2Out = false, p3Out = false, p4Out = false, p5Out = false, p6Out = false, win = false;
        //this will be the list each player will be traversing through
        private GameList cList = new GameList();
        //a new instance of cards needs to be made in order to shuffle and deal them out to players and the envelop method
        private Cards createCards = new Cards();
        //this will store the number of players in the game
        private int numberOfPlayers;

        //this method will be adding players to the variables p1, p2 etc at the top to store each players info
        //the user will state how many players there are on the console which will get converted
        //this was created by Caleb Mathomes on 24/11/14
        //amended on the 09/12/14 so it included a try and catch while converting temp players for validation
        //amended on the 11/12/14 so improved validation rule implamented so the user can retry entering 
        //the number of players as well as seperating the add players method which calls check name
        //also added the populateCards method here and dispensed them after creating all the players
        //amended on the 18/12/14 so the booleans updated if there were only 4, 5 and 6 players since the program would
        //recognise as them playing even if they are not in the game
        public void addPlayers()
        {
            //increaments with each player added
            int count = 0;
            Console.WriteLine("Enter number of Players(you can have up to 6 but no less than 3)");
            string tempPlayers = Console.ReadLine();
            if (tempPlayers != "3" && tempPlayers != "4" && tempPlayers != "5" && tempPlayers != "6")
            {
                Console.WriteLine("please enter a valid number of players");
                //calling itself to reinitialize the method
                addPlayers();
            }
            try
            {
                //makes player 4, 5 and 6 out if they are not playing
                numberOfPlayers = Convert.ToInt32(tempPlayers);
                if (numberOfPlayers == 3)
                {
                    p4Out = true;
                    p5Out = true;
                    p6Out = true;
                }
                //makes player 5 and 6 out if they are not playing
                else if (numberOfPlayers == 4)
                {
                    p5Out = true;
                    p6Out = true;
                }
                //makes player 6 out if they are not playing
                else if (numberOfPlayers == 5)
                {
                    p6Out = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured:" + e);
            }
            //once all the players are added and it matchs the numberOfPlayers the user entered, moves to the next method
            //each players location is displayed on a random place once they enter the game
            while (count != numberOfPlayers)
            {
                Console.WriteLine("\n Please enter player name");
                //player 1 is added
                if (count == 0)
                {
                    checkName(ref p1);
                    Console.Write("Player1 is :" + p1.name +
                    "\nyour location is: " + p1.location.blockName + "\n");
                }
                //player 2 is added
                if (count == 1)
                {
                    checkName(ref p2);
                    Console.Write("Player2 is :" + p2.name +
                    "\nyour location is: " + p2.location.blockName + "\n");
                }
                //player 3 is added
                if (count == 2)
                {
                    checkName(ref p3);
                    Console.Write("Player3 is :" + p3.name +
                    "\nyour location is: " + p3.location.blockName + "\n");
                }
                //if player 4 exists, they are added
                if (count == 3)
                {
                    checkName(ref p4);
                    Console.Write("Player4 is :" + p4.name +
                    "\nyour location is: " + p4.location.blockName + "\n");
                }
                //if player 5 exists, they are added
                if (count == 4)
                {
                    checkName(ref p5);
                    Console.Write("Player5 is :" + p5.name +
                    "\nyour location is: " + p5.location.blockName + "\n");
                }
                //if player 6 exists, they are added
                if (count == 5)
                {
                    checkName(ref p6);
                    Console.Write("Player6 is :" + p6.name +
                    "\nyour location is: " + p6.location.blockName + "\n");
                }
                //this will balance the count and number of players so it exits the method if the user enters 6 players
                //the addPlayers method will loop continuously otherwise
                else if (count == 6)
                {
                    count = numberOfPlayers;
                }
                count++;
            }
            //deals all the cards out to the players from the card class
            createCards.dispenseCards();
        }//end of addPlayers

        /*this method is to generate a random spot on the board and place the user on it
        *it loops through the game board from the head and stops at a random interval places the player there
        *it takes a reference of player passed in and sets the reference to the random location
        *created 11/12/14 by Caleb Mathomes*/
        private void checkName(ref Player play)
        {
            //generates a random number between 0 and 23
            Random r = new Random();
            int randomGen = r.Next(0, 23);
            //creats a local node which starts of the beggining of the list
            GameNode current = cList.head;
            //the reference the player passed is instantiated to create the player
            play = new Player();
            //added validation rules are added so the player cannot enter a name which is outside the boounds which
            //are minimum 3 letters and maximum 14. use of recursion added so the player can re-enter these values 
            //if they are outside the bounds the first time
            try
            {
                string tempName = Console.ReadLine();
                if (tempName.Length >= 3 && tempName.Length < 15)
                {
                    play.addPLayer(tempName);
                }
                else
                {
                    Console.WriteLine("Please enter a valid name");
                    checkName(ref play);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured while entering your name" + e);
            }
            //it will loop through the board a random number of times using the random variable starting from the local node created
            for (int i = 0; i <= randomGen; i++)
            {
                current = current.next;
                i++;
            }
            //sets the players location to the new random spot on the board
            play.setLocation(current);
        }//end of check name

        /*this method will create the board the players will traverse through
        *each new instance of a node passes in the new information that node will contain
        *the first value will identify which node it is
        *the second value identifies the name of that node
        *the third identifies whether it is a doorway node or not
        *the fourth identifies if it is a board node and the last value identifies if it is a room node or not*/
        public void populateBoard()
        {
            //these will be the board nodes, 7 of which are doorway nodes as well as board nodes
            GameNode sqaure1 = new GameNode(1, "block 1", false, true, false);
            GameNode sqaure2 = new GameNode(2, "block 2", true, true, false);
            GameNode sqaure3 = new GameNode(3, "block 3", false, true, false);
            GameNode sqaure4 = new GameNode(4, "block 4", true, true, false);
            GameNode sqaure5 = new GameNode(5, "block 5", false, true, false);
            GameNode sqaure6 = new GameNode(6, "block 6", false, true, false);
            GameNode sqaure7 = new GameNode(7, "block 7", false, true, false);
            GameNode sqaure8 = new GameNode(8, "block 8", false, true, false);
            GameNode sqaure9 = new GameNode(9, "block 9", false, true, false);
            GameNode sqaure10 = new GameNode(10, "block 10", true, true, false);
            GameNode sqaure11 = new GameNode(11, "block 11", false, true, false);
            GameNode sqaure12 = new GameNode(12, "block 12", false, true, false);
            GameNode sqaure13 = new GameNode(13, "block 13", false, true, false);
            GameNode sqaure14 = new GameNode(14, "block 14", true, true, false);
            GameNode sqaure15 = new GameNode(15, "block 15", false, true, false);
            GameNode sqaure16 = new GameNode(16, "block 16", true, true, false);
            GameNode sqaure17 = new GameNode(17, "block 17", false, true, false);
            GameNode sqaure18 = new GameNode(18, "block 18", true, true, false);
            GameNode sqaure19 = new GameNode(19, "block 19", false, true, false);
            GameNode sqaure20 = new GameNode(20, "block 20", false, true, false);
            GameNode sqaure21 = new GameNode(21, "block 21", false, true, false);
            GameNode sqaure22 = new GameNode(22, "block 22", true, true, false);
            GameNode sqaure23 = new GameNode(23, "block 23", false, true, false);
            GameNode sqaure24 = new GameNode(24, "block 24", false, true, false);

            //these are the room nodes
            GameNode room1 = new GameNode(17, "Lecture Theatre", false, false, true);
            GameNode room2 = new GameNode(13, "Research Lab", false, true, true);
            GameNode room3 = new GameNode(14, "Laptop Lab", false, true, true);
            GameNode room4 = new GameNode(15, "Network Lab", false, true, true);
            GameNode room5 = new GameNode(16, "School Office", false, true, true);
            GameNode room6 = new GameNode(13, "CEO11", false, true, true);
            GameNode room7 = new GameNode(14, "Foyer", false, true, true);

            //each node is then added to the list
            cList.addNode(sqaure1);
            cList.addNode(sqaure2);
            cList.addNode(sqaure3);
            cList.addNode(sqaure4);
            cList.addNode(sqaure5);
            cList.addNode(sqaure6);
            cList.addNode(sqaure7);
            cList.addNode(sqaure8);
            cList.addNode(sqaure9);
            cList.addNode(sqaure10);
            cList.addNode(sqaure11);
            cList.addNode(sqaure12);
            cList.addNode(sqaure13);
            cList.addNode(sqaure14);
            cList.addNode(sqaure15);
            cList.addNode(sqaure16);
            cList.addNode(sqaure17);
            cList.addNode(sqaure18);
            cList.addNode(sqaure19);
            cList.addNode(sqaure20);
            cList.addNode(sqaure21);
            cList.addNode(sqaure22);
            cList.addNode(sqaure23);
            cList.addNode(sqaure24);

            //each room is added to the list
            cList.addRoom(room1, sqaure2);
            cList.addRoom(room2, sqaure4);
            cList.addRoom(room3, sqaure10);
            cList.addRoom(room4, sqaure14);
            cList.addRoom(room5, sqaure16);
            cList.addRoom(room6, sqaure18);
            cList.addRoom(room7, sqaure22);
            //this final call will link the last node added to the head of the list 
            cList.findLast(cList);
        }//end of populateBoard

        //this method is intended to move the player from the board to the room
        //it passes in a reference of the player where the location of the player is set from its current to the rooms location
        //created on the 09/12/14 by Caleb Mathomes
        private void moveToRoom(ref Player playerPosition)
        {
            playerPosition.location = playerPosition.location.room;
        }//end of moveToRoom

        /*this will move the player a random number of spaces between 1 and 6 through the board
        *a reference of player is passed in so that we can change the location of the player
        *this will return the location of the player onced they have traversed the board
        *created on the 11/12/14 by Caleb Mathomes
        *amended on the 20/12/14 so that it checks the next next node and each players location to see if they match
        *which would break the loop setting the players location to the node before however does not work since
        *it will return saying a player exists in the next done every time the rollDice is called*/
        private GameNode rollDice(ref Player player)
        {
            //random number between 1 and 6
            Random roll = new Random();
            int diceRoll = roll.Next(1, 7);
            //starts from the head of the list
            GameNode current = cList.head;
            Console.WriteLine("You rolled a " + diceRoll);
            //traverses setting the players location to the next node on the board
            for (int i = 0; i < diceRoll; i++)
            {
                /*if ((p1Play == true) && (player.location.block == p2.location.block
                    && player.location.block == p3.location.block && player.location.block == p4.location.block
                    && player.location.block == p5.location.block && player.location.block == p6.location.block))
                {
                    Console.WriteLine("There is someone in " + player.location.next.blockName);
                    break;
                }
                else if ((p2Play == true) && (player.location.block == p1.location.block
                    && player.location.block == p3.location.block && player.location.block == p4.location.block
                    && player.location.block == p5.location.block && player.location.block == p6.location.block))
                {
                    Console.WriteLine("There is someone in " + player.location.next.blockName);
                    break;
                }
                else if ((p3Play == true) && (player.location.block == p1.location.block
                && player.location.block == p2.location.block && player.location.block == p4.location.block
                && player.location.block == p5.location.block && player.location.block == p6.location.block))
                {
                    Console.WriteLine("There is someone in " + player.location.next.blockName);
                    break;
                }
                else if ((p4Play == true) && (player.location.block == p1.location.block
                    && player.location.block == p2.location.block && player.location.block == p3.location.block
                    && player.location.block == p5.location.block && player.location.block == p6.location.block))
                {
                    Console.WriteLine("There is someone in " + player.location.next.blockName);
                    break;
                }
                else if ((p5Play == true) && (player.location.block == p1.location.block
                    && player.location.block == p2.location.block && player.location.block == p3.location.block
                    && player.location.block == p4.location.block && player.location.block == p6.location.block))
                {
                    Console.WriteLine("There is someone in " + player.location.next.blockName);
                    break;
                }
                else if ((p6Play == true) && (player.location.block == p1.location.block
                && player.location.block == p2.location.block && player.location.block == p3.location.block
                && player.location.block == p4.location.block && player.location.block == p5.location.block))
                {
                    Console.WriteLine("There is someone in " + player.location.next.blockName);
                    break;
                }
                else
                {
                    player.location = player.location.next;
                }*/
                player.location = player.location.next;
            }
            //displays the players location after the dice is rolled
            Console.WriteLine("Your location is: " + player.location.blockName + "\n");
            return player.location;
        }//end of rollDice

        /*this method dictates which player turn it is and will assign which player is to go next
         * it will pass in a reference of the player which will be used to assess which player it is by using if statements
         * created on 14/12/14 by Caleb Mathomes
         * ammended on the 16/12/14 to include more if statements to check if a player is out so to move to the next player*/
        private void endTurn(ref Player p)
        {
            //checks if player 1 was passed and player 2 isnt out
            if (p == p1 && p2Out == false)
            {
                //sets player 2 to play next
                p1Play = false;
                p2Play = true;
            }
            //checks if player 1 was passed and player 2 is out
            else if (p == p1 && p2Out == true)
            {
                //sets player 3 to play next
                p1Play = false;
                p3Play = true;
            }
            //checks if player 2 was passed and player 3 isnt out
            else if (p == p2 && p3Out == false)
            {
                //sets player 3 to play next
                p2Play = false;
                p3Play = true;
            }
            //checks if player 2 was passed and player 3 is out
            else if (p == p2 && p3Out == true)
            {
                //sets player 3 to play next
                p2Play = false;
                p4Play = true;
            }
            //checks if player 3 was passed, there are only 3 players and player 1 isnt out
            else if (p == p3 && numberOfPlayers == 3 && p1Out == false)
            {
                //sets player 1 to play next
                p3Play = false;
                p1Play = true;
            }
            //checks if player 3 was passed, there are only 3 players and player 1 is out
            else if (p == p3 && numberOfPlayers == 3 && p1Out == true)
            {
                //sets player 2 to play next
                p3Play = false;
                p2Play = true;
            }
            //checks if player 3 was passed, there are more than 3 players and player 4 isnt out
            else if (p == p3 && numberOfPlayers > 3 && p4Out == false)
            {
                //sets player 4 to play next
                p3Play = false;
                p4Play = true;
            }
            //checks if player 3 was passed, there are more than 3 players and player 4 is out
            else if (p == p3 && numberOfPlayers > 3 && p4Out == true)
            {
                //sets player 5 to play next
                p3Play = false;
                p5Play = true;
            }
            //checks if player 4 was passed, there are only 4 players and player 1 isnt out
            else if (p == p4 && numberOfPlayers == 4 && p1Out == false)
            {
                //sets player 1 to play next
                p4Play = false;
                p1Play = true;
            }
            //checks if player 4 was passed, there are only 4 players and player 1 is out
            else if (p == p4 && numberOfPlayers == 4 && p1Out == true)
            {
                //sets player 2 to play next
                p4Play = false;
                p2Play = true;
            }
            //checks if player 4 was passed, there are more than 4 players and player 5 isnt out
            else if (p == p4 && numberOfPlayers > 4 && p5Out == false)
            {
                //sets player 5 to play next
                p4Play = false;
                p5Play = true;
            }
            //checks if player 4 was passed, there are only 4 players and player 5 is out
            else if (p == p4 && numberOfPlayers > 4 && p5Out == true)
            {
                //sets player 6 to play next
                p4Play = false;
                p6Play = true;
            }
            //checks if player 5 was passed, there are only 5 players and player 1 isnt out
            else if (p == p5 && numberOfPlayers == 5 && p1Out == false)
            {
                //sets player 1 to play next
                p5Play = false;
                p1Play = true;
            }
            //checks if player 5 was passed, there are only 5 players and player 1 is out
            else if (p == p5 && numberOfPlayers == 5 && p1Out == true)
            {
                //sets player 2 to play next
                p5Play = false;
                p2Play = true;
            }
            //checks if player 5 was passed, there are more than 5 players and player 6 isnt out
            else if (p == p5 && numberOfPlayers > 5 && p6Out == false)
            {
                //sets player 6 to play next
                p5Play = false;
                p6Play = true;
            }
            //checks if player 5 was passed, there are more than 5 players and player 6 is out
            else if (p == p5 && numberOfPlayers > 5 && p6Out == true)
            {
                //sets player 1 to play next
                p5Play = false;
                p1Play = true;
            }
            //checks if player 6 was passed and player 1 isnt out
            else if (p == p6 && p1Out == false)
            {
                //sets player 1 to play next
                p6Play = false;
                p1Play = true;
            }
            //checks if player 6 was passed and player 1 is out
            else if (p == p6 && p1Out == true)
            {
                //sets player 2 to play next
                p6Play = false;
                p2Play = true;
            }
            //this is the first version of if statements
            /*if (p == p1)
            {
                p1Play = false;
                p2Play = true;
            }
            else if (p == p2)
            {
                p2Play = false;
                p3Play = true;
            }
            else if (p == p3 && numberOfPlayers == 3)
            {
                p3Play = false;
                p1Play = true;
            }
            else if (p == p3 && numberOfPlayers > 3)
            {
                p3Play = false;
                p4Play = true;
            }
            else if (p == p4 && numberOfPlayers == 4)
            {
                p4Play = false;
                p1Play = true;
            }
            else if (p == p4 && numberOfPlayers > 4)
            {
                p4Play = false;
                p5Play = true;
            }
            else if (p == p5 && numberOfPlayers == 5)
            {
                p5Play = false;
                p1Play = true;
            }
            else if (p == p5 && numberOfPlayers > 5)
            {
                p5Play = false;
                p6Play = true;
            }
            else if (p == p6)
            {
                p6Play = false;
                p1Play = true;
            }*/
        }//end of endTurn

        /*This will be the method which traverses the players through the nodes. It will call most run time commands
         * the user wishes to excecute such as rolling the dice, ending a turn, acuusing and suggesting the weapon, location
         * and suspect as well as displaying the cards they have got.
         * it taks a reference of player which changes passes the player when calling the other methods to manipulate their
         * location as well as using it to get the cards they posses from the cards class.
         * it was created on the 11/12/14 by Caleb Mathomes and ammended again though the week beggining 15/12/14 to 20/12/14
         * to incorporate all the call methods, if a player landed on a doorway node, would be promted to select if they want
         * to enter the room or not and then if they would like to make a suggestion or not to end their turn. It also included
         * checks at the beggining so verify if a player has been eliminated from the game*/
        private void playerMove(ref Player play)
        {
            //these checks conduct whether a player is out and if so ends their turn and moves to the next player
            if (play == p1 && p1Out == true)
            {
                endTurn(ref play);
            }
            else if (play == p2 && p2Out == true)
            {
                endTurn(ref play);
            }
            else if (play == p3 && p3Out == true)
            {
                endTurn(ref play);
            }
            else if (play == p4 && p4Out == true)
            {
                endTurn(ref play);
            }
            else if (play == p5 && p5Out == true)
            {
                endTurn(ref play);
            }
            else if (play == p6 && p6Out == true)
            {
                endTurn(ref play);
            }
            //otherwise it will display who's turn it is
            else
            {
                Console.WriteLine("\n" + play.name + "'s turn");
            }
            //lets the player know they are on a doorway and can enter the room
            if (play.location.doorway == true)
            {
                Console.WriteLine("You are on a doorway block to " + play.location.room.blockName + ", type 'room' to enter");
            }
            //lets the player know they are in a room and now can make an accusation or suggestion
            else if (play.location.roomNode == true)
            {
                Console.WriteLine("You are in " + play.location.blockName + ", you can make a suggestion or accusation");
            }
            Console.WriteLine("Please choose your action");
            try
            {
                string keyListen = Console.ReadLine();
                //this will call the rollDice method and pass the referenced player through
                if (keyListen == "r")
                {
                    rollDice(ref play);
                    //if the player lands on a doorway after rolling, they can enter the room to end their turn
                    if (play.location.doorway == true)
                    {
                        Console.WriteLine("would you like to enter the " + play.location.room.blockName + "? Y/N");
                        try
                        {
                            string ans2 = Console.ReadLine();
                            //if yes calls the moveToRoom method and passes in the referenced player from the parameter and ends their turn
                            if (ans2 == "y" || ans2 == "Y")
                            {
                                moveToRoom(ref play);
                                Console.WriteLine("Your now in the " + play.location.blockName);
                                Console.WriteLine("You can now make an accusation or suggestion on your next turn");
                                endTurn(ref play);
                            }
                            //otherwise it just ends their turn
                            else if (ans2 == "n" || ans2 == "N")
                            {
                                endTurn(ref play);
                            }
                            //if the user enters anything else but y/Y/n/N then it wil display this and end their turn anyway
                            else
                            {
                                Console.WriteLine("Invalide statement");
                                Console.WriteLine("Carrying on the game");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("An error occured while listening to your command" + e);
                        }
                    }
                    endTurn(ref play);
                }
                //this will call the accuse method but can only do this if the user is in a room and ends their turn
                //when returning from the accuse method
                else if ("a" == keyListen && play.location.roomNode == true)
                {
                    accuse(ref play);
                    endTurn(ref play);
                }
                //this will call the suggest method but can only do this if the user is in a room and ends their turn
                //when returning from the accuse method
                else if ("s" == keyListen && play.location.roomNode == true)
                {
                    suggest();
                    endTurn(ref play);
                }
                //this brings up the list of actions the user can take on their turn
                else if ("help" == keyListen)
                {
                    Console.WriteLine("'r' is to roll the dice");
                    Console.WriteLine("'show' is to display all the cards in your hand");
                    Console.WriteLine("'a' is to accuse(you can only accuse if you are in a room)");
                    Console.WriteLine("'s' is to suggest(you can only suggest if you are in a room)");
                    Console.WriteLine("'e' is to end turn");
                    Console.WriteLine("'room' is to enter a room(You can only enter if your on a doorway block)");
                    Console.WriteLine("'help' will display this information again \n");
                    move();
                }
                //this will just move on to the next players turn
                else if (keyListen == "e")
                {
                    endTurn(ref play);
                }
                //this will move the player from their current location to the room
                else if (keyListen == "room")
                {
                    //but can only do it if they are on a doorway
                    if (play.location.doorway == true)
                    {
                        //call to moveToRoom passing in the current player
                        moveToRoom(ref play);
                        //once complete, displays the players new location and if they want to make a suggestion or accusation
                        Console.WriteLine("Your now in the " + play.location.blockName);
                        Console.WriteLine("Would you like to make a suggestion or accusation? Y/N");
                        try
                        {
                            string ans = Console.ReadLine();
                            //if yes they can say whether it is an accusation or suggestion they want to make
                            if (ans == "Y" || ans == "y")
                            {
                                Console.WriteLine("please state 'a' to accuse or 's' to suggest");
                                string ans2 = Console.ReadLine();
                                //if s is selected, they can suggest the suspect, weapon and room cards and ends their turn when returned
                                if (ans2 == "s")
                                {
                                    suggest();
                                    endTurn(ref play);
                                }
                                //otherwise they can make an accusation passing in the player so they can update whether they are 
                                //eliminated or not
                                else if (ans2 == "a")
                                {
                                    accuse(ref play);
                                    endTurn(ref play);
                                }
                                //otherwise if they selected anything else, it displays this info and moves on to the next player
                                else
                                {
                                    Console.WriteLine("Invalide statement");
                                    Console.WriteLine("Carrying on the game");
                                }
                            }



                            //if they say no, it just ends their turn
                            else if (ans == "N" || ans == "n")
                            {
                                endTurn(ref play);
                            }
                            else
                            {
                                //otherwise if they typed anything else, it displays this info and moves on to the next player
                                Console.WriteLine("Invalide statement");
                                Console.WriteLine("Carrying on the game");
                            }
                        }
                        //catches the exception if the program fails while converting the players command
                        catch (Exception e)
                        {
                            Console.WriteLine("An error occured while listening to your command" + e);
                        }

                        endTurn(ref play);
                    }
                    //if the player isnt on doornode then they need to be in order to move to the room
                    else
                    {
                        Console.WriteLine("You need to be on a doorway block to enter a room");
                    }
                }
                //this will show the all the cards in the player
                else if (keyListen == "show")
                {
                    Console.WriteLine(play.name + "'s Cards \n");
                    Console.Write(play.playerCards[0] + "\n" + play.playerCards[1] +
                    "\n" + play.playerCards[2] + "\n" + play.playerCards[3] +
                    "\n" + play.playerCards[4] + "\n" + play.playerCards[5] + "\n");
                }
                else
                {
                    //otherwise it will just re-call itself so the user can start again
                    Console.WriteLine("Invalide move, please choose again");
                    playerMove(ref play);
                }
            }
                //catches the exception if the program fails while converting the players command
            catch (Exception e)
            {
                Console.WriteLine("An error occured while listening to your command" + e);
            }
        }//end of playerMove

        /*this method will ask the player which weapon was used, who did it and where the murder took place
         * if they guess wrong they will be eliminated from the game but they will win if they get it right.
         * it takes a reference of the player and will get their name and display it if they won otherwise it will
         * determin who the player is and set their boolean to true to say they have been eliminated
         * created on the 18/12/14
         * amended on the 20/12/14 to include the disprove method in order to show evidence the user has guessed incorrectly
         * as well as detection of 1 player left in order to determine who has won*/
        private void accuse(ref Player accusePlayer)
        {
            //warns the user of elimination
            Console.WriteLine("WARNING! if you guess incorrectly, you are out of the game");
            //this will hold the value which breaks the loop to disprove
            bool prove = false;
            //will loop through and display all the weapon cards from the cards class
            Console.WriteLine("\nWhat weapon do you think the murderer used?");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(createCards.weaponCard[i]);
            }
            //will set the string to the weapon the player has guessed
            string suggestedWeapon = guessWeapon();
            //will loop through and display all the suspect cards from the cards class
            Console.WriteLine("\nWho do you think the murderer is?");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(createCards.suspectCard[i]);
            }
            //will set the string to the suspect the player has guessed
            string suggestedSuspect = guessSuspect();
            //will loop through and display all the room cards from the cards class
            Console.WriteLine("\nWhere do you think they did it?");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(createCards.roomCard[i]);
            }
            //will set the string to the room the player has guessed
            string suggestedLocation = guessRoom();
            //if guessed correctly, the following information will be outputted, and the win bool set to true to break the loop
            //in the move() method
            if (suggestedWeapon == createCards.getEnvelopWeapon() && suggestedSuspect == createCards.getEnvelopSuspect()
                && suggestedLocation == createCards.getEnvelopRoom())
            {
                Console.WriteLine("You won!!!!! Congratulations " + accusePlayer.name + ". you solved the mystery!");
                Console.WriteLine("It was " + suggestedSuspect + " who used a " + suggestedWeapon + " in the " + suggestedLocation);
                Console.WriteLine("Mark Anderson will reward you with chocolates the next time he see's you!");
                win = true;
                return;
            }
            else
            {
                //this will loop through every card of every player and look for a match between the suggested cards to
                //the cards in the other players hands to disprove their suggestions
                //if the card is found the loop is broken
                while (prove == false)
                {
                    //player 1's cards
                    prove = disprove(ref p1, suggestedWeapon);
                    if (prove == true)
                        break;
                    prove = disprove(ref p1, suggestedSuspect);
                    if (prove == true)
                        break;
                    prove = disprove(ref p1, suggestedLocation);
                    if (prove == true)
                        break;
                    //player 2's cards
                    prove = disprove(ref p2, suggestedWeapon);
                    if (prove == true)
                        break;
                    prove = disprove(ref p2, suggestedSuspect);
                    if (prove == true)
                        break;
                    prove = disprove(ref p2, suggestedLocation);
                    if (prove == true)
                        break;
                    //player 3's cards
                    prove = disprove(ref p3, suggestedWeapon);
                    if (prove == true)
                        break;
                    prove = disprove(ref p3, suggestedSuspect);
                    if (prove == true)
                        break;
                    prove = disprove(ref p3, suggestedLocation);
                    if (prove == true)
                        break;
                    //if there are more than 3 players than looping through the other players cards will be done here
                    if (numberOfPlayers == 4)
                    {
                        //player 4's cards
                        prove = disprove(ref p4, suggestedWeapon);
                        if (prove == true)
                            break;
                        prove = disprove(ref p4, suggestedSuspect);
                        if (prove == true)
                            break;
                        prove = disprove(ref p4, suggestedLocation);
                        if (prove == true)
                            break;
                    }
                    else if (numberOfPlayers == 5)
                    {
                        //player 5's cards
                        prove = disprove(ref p5, suggestedWeapon);
                        if (prove == true)
                            break;
                        prove = disprove(ref p5, suggestedSuspect);
                        if (prove == true)
                            break;
                        prove = disprove(ref p5, suggestedLocation);
                        if (prove == true)
                            break;
                    }
                    else if (numberOfPlayers == 6)
                    {
                        //player 6's cards
                        prove = disprove(ref p6, suggestedWeapon);
                        if (prove == true)
                            break;
                        prove = disprove(ref p6, suggestedSuspect);
                        if (prove == true)
                            break;
                        prove = disprove(ref p6, suggestedLocation);
                        if (prove == true)
                            break;
                    }
                }
                //when the player has been disproven, we then set their boolean to true to say they are out of the game
                Console.WriteLine(accusePlayer.name + " you are out of the game!");
                if (accusePlayer == p1)
                {
                    p1Out = true;
                }
                else if (accusePlayer == p2)
                {
                    p2Out = true;
                }
                else if (accusePlayer == p3)
                {
                    p3Out = true;
                }
                else if (accusePlayer == p4)
                {
                    p4Out = true;
                }
                else if (accusePlayer == p5)
                {
                    p5Out = true;
                }
                else if (accusePlayer == p6)
                {
                    p6Out = true;
                }
                /*these checks will be conducted to see if there is only one player left in the game
                if that is the case, their name is retrieved and outputted that they have won and sets the win to true to break
                the loop in the move() method to end the game*/
                //this checks if player 1 is the only player left
                if (p1Out == false && p2Out == true && p3Out == true && p4Out == true && p5Out == true
                    && p6Out == true)
                {
                    Console.WriteLine("Congratulations " + p1.name + ". You have Won the Game");
                    win = true;
                    return;
                }
                //checks if player 2 is the only player left in the game
                else if (p1Out == true && p2Out == false && p3Out == true && p4Out == true && p5Out == true
                    && p6Out == true)
                {
                    Console.WriteLine("Congratulations " + p2.name + ". You have Won the Game");
                    win = true;
                    return;
                }
                //checks if player 3 is the only player left
                else if (p1Out == true && p2Out == true && p3Out == false && p4Out == true && p5Out == true
                    && p6Out == true)
                {
                    Console.WriteLine("Congratulations " + p3.name + ". You have Won the Game");
                    win = true;
                    return;
                }
                //checks if player 4 is the only player left
                else if (p1Out == true && p2Out == true && p3Out == true && p4Out == false && p5Out == true
                    && p6Out == true)
                {
                    Console.WriteLine("Congratulations " + p4.name + ". You have Won the Game");
                    win = true;
                    return;
                }
                //checks if only player 5 is left
                else if (p1Out == true && p2Out == true && p3Out == true && p4Out == true && p5Out == false
                    && p6Out == true)
                {
                    Console.WriteLine("Congratulations " + p5.name + ". You have Won the Game");
                    win = true;
                    return;
                }
                //checks if only player 6 is left
                else if (p1Out == true && p2Out == true && p3Out == true && p4Out == true && p5Out == true
                    && p6Out == false)
                {
                    Console.WriteLine("Congratulations " + p6.name + ". You have Won the Game");
                    win = true;
                    return;
                }
            }
            //otherwise if there is more than 1 player in the game, the win bool will stay the same to continue the game
            win = false;
        }//end of accuse

        /*this will find cards in other players hands and compare it to the suggestion the player has made. If it finds the card
         * it will return which player has the card and return true to disprove
         * the method takes 2 parameters, a reference of the player and the players suggested card. It will take the player and search
         * through the deck of cards they have comparing the suggestion card.
         * this method will return a bool value which will be true if the suggested card is found in the players array, otherwise
         * false since it can't prove the player does have the card
         * created on 19/12/14 By Caleb */
        private bool disprove(ref Player play, string suggestedCard)
        {
            //loops through the players card array and if the suggestion cards matches on of the cards
            //it returns the players name and return true;
            for (int i = 0; i < play.playerCards.Length; i++)
            {
                if (suggestedCard == play.playerCards[i])
                {
                    Console.WriteLine(play.name + " has " + play.playerCards[i] + " Card");
                    return true;
                }
            }
            //otherwise false if it cant disprove
            return false;
        }//end of disprove

        /*suggest will ask the player which 3 cards they think belongs to the murderer. It will give the user a hint if they
         * are both correct and incorrect with their suggested cards. If they are correct, we wont be able to disprove them
         * and just leave them with hmmmm otherwise we will disprove them by showing one of the cards they have suggested from
         * player who has the card in their hand.
         * created on 16/12/14 By Caleb Mathomes and amended on the 19/12/14 to make seperate methods for the guessing of 
         * weapons, suspects and rooms. */
        private void suggest()
        {
            //the bool which holds the value to break the disprove loop
            bool prove = false;
            //displays all the weapons the player can choose from
            Console.WriteLine("\nWhat weapon do you think the murderer used?");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(createCards.weaponCard[i]);
            }
            //sets the string the player thinks is the murder weapon
            string suggestedWeapon = guessWeapon();
            //displays all the suspects the player can choose from
            Console.WriteLine("\nWho do you think the murderer is?");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(createCards.suspectCard[i]);
            }
            //sets the string the player thinks is the murderer
            string suggestedSuspect = guessSuspect();
            //displays all the rooms the player can choose from
            Console.WriteLine("\nWhere do you think they did it?");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(createCards.roomCard[i]);
            }
            //sets the string the player thinks is the murder location
            string suggestedLocation = guessRoom();

            //a hint is given if the user guesses the correct cards since these are the cards equal to the envelop cards
            if (suggestedWeapon == createCards.getEnvelopWeapon() && suggestedSuspect == createCards.getEnvelopSuspect()
                && suggestedLocation == createCards.getEnvelopRoom())
            {
                Console.WriteLine("Hmmmmmmmmm");
            }
            else
            {
                //otherwise loop through each players card to disprove the player and show them the player has the card in their hand
                //the loop will break once the card has been proven by another player
                while (prove == false)
                {
                    prove = disprove(ref p1, suggestedWeapon);
                    if (prove == true)
                        break;
                    prove = disprove(ref p1, suggestedSuspect);
                    if (prove == true)
                        break;
                    prove = disprove(ref p1, suggestedLocation);
                    if (prove == true)
                        break;
                    prove = disprove(ref p2, suggestedWeapon);
                    if (prove == true)
                        break;
                    prove = disprove(ref p2, suggestedSuspect);
                    if (prove == true)
                        break;
                    prove = disprove(ref p2, suggestedLocation);
                    if (prove == true)
                        break;
                    prove = disprove(ref p3, suggestedWeapon);
                    if (prove == true)
                        break;
                    prove = disprove(ref p3, suggestedSuspect);
                    if (prove == true)
                        break;
                    prove = disprove(ref p3, suggestedLocation);
                    if (prove == true)
                        break;
                    if (numberOfPlayers == 4)
                    {
                        prove = disprove(ref p4, suggestedWeapon);
                        if (prove == true)
                            break;
                        prove = disprove(ref p4, suggestedSuspect);
                        if (prove == true)
                            break;
                        prove = disprove(ref p4, suggestedLocation);
                        if (prove == true)
                            break;
                    }
                    else if (numberOfPlayers == 5)
                    {
                        prove = disprove(ref p5, suggestedWeapon);
                        if (prove == true)
                            break;
                        prove = disprove(ref p5, suggestedSuspect);
                        if (prove == true)
                            break;
                        prove = disprove(ref p5, suggestedLocation);
                        if (prove == true)
                            break;
                    }
                    else if (numberOfPlayers == 6)
                    {
                        prove = disprove(ref p6, suggestedWeapon);
                        if (prove == true)
                            break;
                        prove = disprove(ref p6, suggestedSuspect);
                        if (prove == true)
                            break;
                        prove = disprove(ref p6, suggestedLocation);
                        if (prove == true)
                            break;
                    }
                }
            }
        }//end of suggest

        /*this will read what the player suggests the murder location is and will firstly check that it matches the list of
         * location cards and will ask the player to re-enter their suggestion if it does not. If it does then the string
         * saved as the seggestion is returned.
         * the method takes no arguments however does require a string to be return which will store the value in the suggestion
         * and accusation methods
         * created on 19/12/14 by Caleb Mathomes*/
        public string guessRoom()
        {
            //will attemp to read the suggestion the user enters
            try
            {
                //stores the guess to this string value and checks it against the rest of the room cards in the cards class
                string playerGuess = Console.ReadLine();
                if (playerGuess != createCards.roomCard[0] && playerGuess != createCards.roomCard[1]
                    && playerGuess != createCards.roomCard[2] && playerGuess != createCards.roomCard[3]
                    && playerGuess != createCards.roomCard[4] && playerGuess != createCards.roomCard[5]
                    && playerGuess != createCards.roomCard[6])
                {
                    Console.WriteLine("Miss Match - please choose from the following \n");
                    for (int i = 0; i < 7; i++)
                    {
                        Console.WriteLine(createCards.roomCard[i]);
                    }
                    //if it doesnt match then the user will be asked to enter it again
                    guessRoom();
                }
                return playerGuess;
            }
                //catches the error if it occures while reading the players input and returns nothing
            catch (Exception e)
            {
                Console.WriteLine("There was an error while reading your guess" + e);
                return null;
            }
        }//end of guessRoom

        /*this method is the exact same as the guessRoom however it applies to the weapon array in the cards class
         * again it doesnt require an arguements as its only checking the array in the cards class but requires a
         * string value to be returned which will be the players guess
         * created on 19/12/14 by Caleb Mathomes*/
        public string guessWeapon()
        {
            //attemps to read the players input and checks the values to the values in the weapon cards array in the cards class
            try
            {
                string playerGuess = Console.ReadLine();
                if (playerGuess != createCards.weaponCard[0] && playerGuess != createCards.weaponCard[1]
                    && playerGuess != createCards.weaponCard[2] && playerGuess != createCards.weaponCard[3]
                    && playerGuess != createCards.weaponCard[4] && playerGuess != createCards.weaponCard[5]
                    && playerGuess != createCards.weaponCard[6])
                {
                    Console.WriteLine("\n Miss Match - please choose from the following");
                    for (int i = 0; i < 7; i++)
                    {
                        Console.WriteLine(createCards.weaponCard[i]);
                    }
                    //if the guess does not match the weapons from the array, the player is asked to re-enter their guess
                    guessWeapon();
                }
                return playerGuess;
            }
                //this will get the error and throw a new exception if it fails to read the players input and return nothing
            catch (Exception e)
            {
                Console.WriteLine("There was an error while reading your guess" + e);
                return null;
            }
        }//end of guessWeapon

        /*this method is the exact same as the guessRoom however it applies to the suspect array in the cards class
         * again it doesnt require an arguements as its only checking the array in the cards class but requires a
         * string value to be returned which will be the players guess
         * created on 19/12/14 by Caleb Mathomes*/
        public string guessSuspect()
        {
            //attemps to read the players input and checks the values to the values in the suspect cards array in the cards class
            try
            {
                string playerGuess = Console.ReadLine();
                if (playerGuess != createCards.suspectCard[0] && playerGuess != createCards.suspectCard[1]
                    && playerGuess != createCards.suspectCard[2] && playerGuess != createCards.suspectCard[3]
                    && playerGuess != createCards.suspectCard[4] && playerGuess != createCards.suspectCard[5]
                    && playerGuess != createCards.suspectCard[6])
                {
                    Console.WriteLine("\n Miss Match - please choose from the following");
                    for (int i = 0; i < 7; i++)
                    {
                        Console.WriteLine(createCards.weaponCard[i]);
                    }
                    //if the guess does not match the suspects from the array, the player is asked to re-enter their guess
                    guessSuspect();
                }
                return playerGuess;
            }
            //this will get the error and throw a new exception if it fails to read the players input and return nothing
            catch (Exception e)
            {
                Console.WriteLine("There was an error while reading your guess" + e);
                return null;
            }
        }//end of guessSuspect

        /*this method will determine who's turn it is and set the next player to move and passes them to the playerMove Method
         * this will also contain the loop which will constantly be checked everytime it returns back to this method to see
         * if a player has won the game which will either be through the right guess or is the only player left in the game
         * the method requires no arguements since it assigns players and doesnt require infortion to be passed in through the
         * main method where it is called.
         * created on 09/12/14 By Caleb Mathomes and amended through the week beginning 15/12/14 which has been broken down several
         * times so it is calling the playerMove method instead of having it within this method.*/
        public void move()
        {
            //while there is still more than one player left in the game and no one has accused the correct weapon, suspect and room
            //the loop will continue
            while (win == false)
            {
                //player 1's turn
                if (p1Play == true)
                {
                    playerMove(ref p1);
                    //checks everytime that no one has won yet and if they have break the loop
                    if (win == true)
                        break;
                }
                //player 2's turn
                else if (p2Play == true)
                {
                    playerMove(ref p2);
                    if (win == true)
                        break;
                }
                //player 3's turn
                else if (p3Play == true)
                {
                    playerMove(ref p3);
                    if (win == true)
                        break;
                }
                //player 4's turn
                else if (p4Play == true)
                {
                    playerMove(ref p4);
                    if (win == true)
                        break;
                }
                //player 5's turn
                else if (p5Play == true)
                {
                    playerMove(ref p5);
                    if (win == true)
                        break;
                }
                //player 6's turn
                else if (p6Play == true)
                {
                    playerMove(ref p6);
                    if (win == true)
                        break;
                }
            }
        }//end of move
    }//end of class
}//end of namespace