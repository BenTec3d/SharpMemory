using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpMemory
{
    public class Game
    {
        public Card[] Cards { get; set; }
        public int[] Taken { get; set; }
        public bool Pending { get; set; }
        public int LastFlipped { get; set; }
        public int MoveCounter { get; set; }
        public bool Won { get; set; }

        public Game()
        {
            Init();
        }

        void Init()
        {
            //Init Properties
            Cards = new Card[12];
            Taken = new int[12];
            Pending = false;
            LastFlipped = -1;
            MoveCounter = 0;
            Won = false;

            //Loops through all cards in the Cards array
            for (int i = 0; i < 12; i++)
            {
                //Endless loop unless break point is reached
                while (true)
                {
                    //Creates random number generator
                    Random rng = new Random();
                    //Sets num to random number >= 1 and < 7
                    int num = rng.Next(1, 7);
                    //Creates a counter that is used to check how often a number has been taken already
                    int counter = 0;

                    //Goes through all numbers in the Taken array
                    foreach (int i2 in Taken)
                    {
                        //Checks if the generated number is equal to a number in the Taken Array
                        if (i2 == num)
                        {
                            counter++;
                        }
                    }

                    //Runs if the generated number is in the Taken array less than twice
                    if (counter < 2)
                    {
                        //Adds number to Taken array
                        Taken[i] = num;
                        //Creates corresponding card and adds it to the Cards array
                        Cards[i] = new Card("/Images/image00" + num + ".jpg");
                        //Breaks out the the loop to do the next card
                        break;
                    }
                }
            }
        }

        public void Click(int id)
        {
            //Makes sure the clicked image has not already been solved.
            //Makes sure the clicked image is not the same as the LastFlipped IF there is a pending move
            if (Cards[id].Solved == false && !(id == LastFlipped && Pending == true))
            {
                //Checks if there is a pending move and runs if there is not
                if (!Pending)
                {
                    //Loops through all cards
                    foreach (Card c in Cards)
                    {
                        //Checks if the currently looped over card has been solved
                        if (c.Solved == true)
                        {
                            //Removes the images so they don't show anymore
                            c.ShownImage = "";
                        }

                        //Else for cards that have not been solved
                        else
                        {
                            //Resets shown image
                            c.ShownImage = "/Images/image000.jpg";
                            //Resets turned status
                            c.Turned = false;
                        }
                    }
                }

                //Reveals hidden image
                Cards[id].ShownImage = Cards[id].HiddenImage;

                //Sets Turned status to true
                Cards[id].Turned = true;

                //Checks if there is a pending move and runs if there is not
                if (!Pending)
                {
                    //Sets pending status to true as there is now one flipped card
                    Pending = true;
                    //Sets LastFlipped to the current card's id
                    LastFlipped = id;
                }

                //Else if there is a pending move
                else
                {
                    //Runs if the cards are a pair
                    if (Cards[id].HiddenImage == Cards[LastFlipped].HiddenImage)
                    {
                        //Sets both cards to solved
                        Cards[id].Solved = true;
                        Cards[LastFlipped].Solved = true;

                    }

                    //Move completed, sets Pending back to false
                    Pending = false;
                    MoveCounter++;

                    //Used in the loop below to check if there are cards left unsolved
                    bool unsolvedCards = false;
                    //Loops through all cards
                    foreach (Card c in Cards)
                    {
                        if (c.Solved == false)
                        {
                            unsolvedCards = true;
                        }
                    }

                    //Checks if the user won the game
                    if (!unsolvedCards)
                    {
                        Won = true;
                        //Loops through all cards
                        foreach (Card c in Cards)
                        {
                            c.ShownImage = "";
                        }

                        //Restarts Game (To be replaced later)
                        Init();
                    }
                }
            }
        }
    }
}
