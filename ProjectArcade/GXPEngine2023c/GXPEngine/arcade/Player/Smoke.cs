using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace arcade
{
    public class Smoke : AnimationSprite
    {
        Buttons _button = MyGame.main.FindObjectOfType<Buttons>();
        int side;
        public Smoke(string filename, int c, int r, TiledObject data) : base (filename, 3, 3)
        {
            side = data.GetIntProperty("side");
        }

        void Update()
        {
            if (_button == null)
            {
                _button = MyGame.main.FindObjectOfType<Buttons>();
            }
            if (_button == null)
            {
                _button = MyGame.main.FindObjectOfType<Buttons>();
            }

            if (_button.keyA && Input.GetKeyDown(Key.K) && side == 1)
            {
                SetCycle(0, 7);
            }
            if (_button.keyW && Input.GetKeyDown(Key.K) && side == 2)
            {
                SetCycle(0, 7);
            }
            if (_button.keyD && Input.GetKeyDown(Key.K) && side == 3)
            {
                SetCycle(0, 7);
            }
            if (currentFrame == 6)
            {
                SetCycle(7);
            }
            Animate(0.2f);
        }
    }
}
