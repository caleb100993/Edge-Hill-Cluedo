using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CluedoGame
{
    class Movement
    {
        /*public void playerMove(Player play)
        {
            Console.WriteLine(p1.name + "'s turn");
            if (p1.location.doorway == true)
            {
                Console.WriteLine("You are on a doorway block to " + p1.location.room.blockName + ", type 'room' to enter");
            }
            Console.WriteLine("Please choose your action");
            string keyListen = Console.ReadLine();
            if (keyListen == "r")
            {
                rollDice(p1);
                if (p1.location.doorway == true)
                {
                    Console.WriteLine("would you like to enter the " + p1.location.room.blockName);
                    string ans2 = Console.ReadLine();
                    if (ans2 == "yes")
                    {
                        moveToRoom(p1);
                        Console.WriteLine("Your now in " + p1.location.blockName);
                        endTurn(p1);
                        move();
                    }
                    else if (ans2 == "no")
                    {
                        endTurn(p1);
                        move();
                    }
                }
                endTurn(p1);
                move();
            }
            else if ("a" == keyListen)
            {
                //calls acuse
                endTurn(p1);
                move();
            }
            else if ("help" == keyListen)
            {
                Console.WriteLine("a is to accuse");
                Console.WriteLine("r is to roll the dice");
                Console.WriteLine("s is to suggest");
                Console.WriteLine("e is to end turn");
                Console.WriteLine("room is to enter a room(You can only enter if your on a doorway block)");
                move();
            }
            else if (keyListen == "e")
            {
                endTurn(p1);
                move();
            }
            else if (keyListen == "room")
            {
                if (p1.location.doorway == true)
                {
                    moveToRoom(p1);
                    Console.WriteLine("Your now in the " + p1.location.blockName);
                    endTurn(p1);
                    move();
                }
                else
                {
                    Console.WriteLine("You need to be on a doorway block to enter a room");
                    move();
                }
            }
            else if (keyListen == "show")
            {
                Console.WriteLine(p1.name + "'s Cards");
                Console.Write(p1.playerCards[0] + "\n" + p1.playerCards[1] +
                "\n" + p1.playerCards[2] + "\n" + p1.playerCards[3] +
                "\n" + p1.playerCards[4] + "\n" + p1.playerCards[5] + "\n");
                move();
            }
            else
            {
                Console.WriteLine("Invalide move, please choose again");
                move();
            }
        }*/
    }
}
