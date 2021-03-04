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

        public Game()
        {
            Cards = new Card[12];
            Taken = new int[12];
            Init();
        }

        void Init()
        {   
            //Loops through all cards in the Cards array
            for(int i = 0; i < 12; i++)
            {
                //Endless loop unless break point is reached
                while(true)
                {
                    //Creates random number generator
                    Random rng = new Random();
                    //Sets num to random number >= 1 and < 7
                    int num = rng.Next(1, 7);
                    //Creates a counter that is used to check how often a number has been taken already
                    int counter = 0;
                    //Goes through all numbers in the Taken array
                    foreach(int i2 in Taken)
                    {
                        //Runs if the generated number is equal to a number in the Taken Array
                        if(i2 == num)
                        {
                            counter++;
                        }
                    }
                    
                    //Runs if the generated number is in the Taken array less than twice
                    if(counter < 2)
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
            Cards[id].ShownImage = Cards[id].HiddenImage;
        }
    }
}
