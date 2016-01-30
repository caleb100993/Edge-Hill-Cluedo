//using generic system imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//all classes under the same namespace
namespace CluedoGame
{
    /*this class will contain the list which will start from the first node which is the head and set the pointers of each node
     * from the head to the next node in the list.
     * created by Caleb Mathomes on 11/11/14*/
    public class GameList
    {
        //this will always hold the first value in the list or the first node added to the list
        public GameNode head;    

        /*the constructor to the GameList which will always set the value of the head to null
         * created by Caleb Mathomes on 11/11/14*/
        public GameList()
        {
            head = null;
        }//end of GameList

        /*this will begin pointing nodes from the head to the tail of the list by setting the first node to the head
         * and each time just setting the next pointer to the new node added to the list
         * it takes in the new node and checks if there is a head. If its empty, that new node is set to the head of the
         * list otherwise it will look at where the next pointer is until it reaches the tail and sets the tail to the new
         * node.
         * created by Caleb Mathomes on 11/11/14 */
        public void addNode(GameNode newNode)
        {
            //checks the head
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                //otherwise traverse to the tail
                GameNode current = head;
                while (current.getNode() != null)
                {
                    current = current.getNode();
                }
                current.setNode(newNode);
                //newNode.setPrevNode(current);
            }
        }

        /*this method sets the pointer from a board node to a room node
         * it takes two GameNode arguements which points the board node to the room and the rooms pointer back to the board node
         * created on 25/11/14 by Caleb Mathomes*/
        public void addRoom(GameNode roomNode, GameNode currentNode)
        {
            currentNode.room = roomNode;
            roomNode.next = currentNode;
        }//end of addRoom

        /*this method was to find the current location of the player and return it. 
         * it will take two arguements, the players location node as well as the list. It will start from the head and traverse
         * throught the list until the location matches the node in the list which it will return.
         * created by Caleb Mathomes on 17/12/14*/
        public GameNode findLocation(GameNode location, GameList list)
        {
            GameNode current = list.head;
            while (location != current)
            {
                current = current.next;
            }
            return current;
        }//end of findLocation

        /*this method is set to link the tail of the list to the head. It takes in the list as an arguement which will set
         * a local not to its head, traverse to the tail and set the other local node to the tail which will then set
         * that end node to the head linking the tail to the head.
         * this bit of code was created jointly Martin McCaslin and ammended on 25/11/14 by Caleb Mathomes*/
        public void findLast(GameList newList)
        {
            GameNode node = newList.head;
            GameNode tail = null;
            while (node.getNode() != null)
            {
                node = node.getNode();
            }
            tail = node;
            node.next = head;
        }//end findLast
    }//end of GameList
}//end of namespace