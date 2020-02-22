using System;
using BownlingCode;

namespace BusinessLogic
{
    public class PlayBowling
    {
        public int GameSample ()
        {
            // Let's play a bowling game.
            BowlingGame myGame = new BowlingGame();
            
            Random randomizer = new Random();
            int firstItem, secondItem;

            for (int i = 0; i < 10; i++)
            {
                    firstItem = randomizer.Next(0,11); 
                    secondItem = randomizer.Next(0, 11 - firstItem);
                    myGame.roll(firstItem, secondItem);
            }
            return myGame.score();
        }
    }
}