//using generic system imports
using System;

//all classes under the same namespace
namespace CluedoGame
{
    /* This class will contain the information needed to place each node on the board. It will contain the values of each node
     * so the player can traverse through the board and know which location they are in.
     * It was created on tuesday 11/11/14 by Caleb Mathomes. Amendments we created on 25/11/14 so the data values where global
     * instead of stored into a struct and more inforamtion was added to each node. These are passed through the constructor.*/
    public class GameNode
    {
        //this is the pointer to the next nodes
        public GameNode next;
        //public GameNode prev;
        //this is the pointer to the room nodes
        public GameNode room;

        //these will be global due to access needed from the CreateBoard Class
        //identifies the number of the block
        public int block;
        //identifies the name of the node
        public string blockName;
        //identifies if the node is a doorway
        public bool doorway;
        //identifies whether the node is a boardNode
        public bool boardNode;
        //identifies whether the node is a roomNode
        public bool roomNode;

        /* Constructor which will set the nodes values in the createBoard class when each node is created individually
         * it passes the block number which identifies which block it is, the block name, if it is a doorway node, board
         * node or room node
         * create on 11/11/14 by Caleb Mathomes and amended on the 25/11/14 to include the new values*/
        public GameNode(int newBlock, string newBlockName, Boolean newDoorway, Boolean newBoardNode, Boolean newRoomNode)
        {
            block = newBlock;
            blockName = newBlockName;
            doorway = newDoorway;
            boardNode = newBoardNode;
            roomNode = newRoomNode;
        }//end of GameNode

        /*this method is intended to get the name of the node on the board and return blockName.
         * created by Caleb Mathomes on 11/11/14*/
        public string getBlockName()
        {
            return blockName;
        }//end of getBlockName

        /*this method will set the node that has been passed in to point to the next node 
         * it takes a single argument which is used to set to the next value.
         * created on 11/11/14 by Caleb Mathomes*/
        public void setNode(GameNode newNode)
        {
            this.next = newNode;
        }//end of setNode

        /*this will return the next values pointer so that when you can set the next pointer to the next
         * created by Caleb Mathomes on 11/11/14*/
        public GameNode getNode()
        {
            return next;
        }//end of getNode

        //these were to set the pointers to the previous nodes however it was not required
        /*public void setPrevNode(GameNode newNode)
        {
            this.prev = newNode;
        }

        public GameNode getPrevNode()
        {
            return prev;
        }*/
    }//end of GameNode
}//end of namespace
