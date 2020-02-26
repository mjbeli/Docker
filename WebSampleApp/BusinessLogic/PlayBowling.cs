using System;
using System.Collections.Generic;
using BownlingCode;

namespace BusinessLogic
{
    public class PlayBowling
    {
        public int GameSample (out IList<FrameDto> results)
        {
            // Let's play a bowling game.
            BowlingGame myGame = new BowlingGame();
            results = new List<FrameDto>(); // store the results
            
            Random randomizer = new Random();
            int firstItem, secondItem;

            for (int i = 0; i < 10; i++)
            {
                    firstItem = randomizer.Next(0,11); 
                    secondItem = randomizer.Next(0, 11 - firstItem);
                    myGame.roll(firstItem, secondItem);
                    results.Add(new FrameDto(firstItem,secondItem));
            }
            return myGame.score();
        }
    }
}