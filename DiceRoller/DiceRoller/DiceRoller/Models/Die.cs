using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller.Models
{
    public class Die
    {
        //name,type, or colour of the die
        public string Name { get; set; }

        //how many sides are the die
        public int NumSides { get; set; }

        //which number is currently up
        public int CurrentSide { get; set; }

        public Die()
        {
            NumSides = 6;
            Name = "d6";
            Roll();
        }

        public Die(int numSides)
        {
            NumSides = numSides;
            Name = "d" + numSides;
            Roll();
        }

        //public void SetSide() { }
        

        public void Roll()
        {
            Random r = new Random();
            CurrentSide = r.Next(NumSides) + 1;
        }
    }
}
