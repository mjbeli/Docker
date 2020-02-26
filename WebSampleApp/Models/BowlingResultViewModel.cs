using System.Collections.Generic;
using BownlingCode;

namespace WebSampleApp.Models
{
    public class BowlingResultViewModel
    {
        public int resultBowlingGame { get; set; }

        public IList<FrameDto> thisIsMyGame {get; set;}
    }
}
