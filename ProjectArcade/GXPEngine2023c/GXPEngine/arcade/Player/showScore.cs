using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arcade
{
    internal class showScore : AnimationSprite
    {
        Player _player = MyGame.main.FindObjectOfType<Player>();
        public showScore(string filename, int c, int r) : base (filename, 2, 4)
        {

        }

        void Update()
        {
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();
            if (_player.perfectScore)
            {
                SetCycle(0, 3);
            } else if (_player.normalScore)
            {
                SetCycle(4, 7);
            }
        }
    }
}
