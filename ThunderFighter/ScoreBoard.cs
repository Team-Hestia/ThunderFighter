using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFighter
{
    public class ScoreBoard
    {
        public ScoreBoard()
        {
        }

        public int Score { get; set; }
        public int HighScore { get; set; }
        public int Lives { get; set; }
        public GameLevel Level { get; set; }
    }
}