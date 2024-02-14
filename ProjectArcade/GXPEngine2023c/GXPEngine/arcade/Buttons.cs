using GXPEngine;
using GXPEngine.Core;
using System;
using System.Security.Principal;
using TiledMapParser;

namespace arcade
{
    public class Buttons : AnimationSprite
    {
        int side;
        public Buttons(string filename, int c, int r, TiledObject data) : base(filename, 2, 2, -1, false, true)
        {
            side = data.GetIntProperty("side");
        }

        void Update()
        {
            if (Input.GetKey(Key.A) && side == 1)
            {
                SetCycle(3);
            }
            else if (Input.GetKey(Key.A) == false && side == 1)
            {
                SetCycle(0);
            }

            if (Input.GetKey(Key.W) && side == 2)
            {
                SetCycle(3);
            }
            else if (Input.GetKey(Key.W) == false && side == 2)
            {
                SetCycle(1);
            }

            if (Input.GetKey(Key.D) && side == 3)
            {
                SetCycle(3);
            }
            else if (Input.GetKey(Key.D) == false && side == 3)
            {
                SetCycle(2);
            }
        }
    }
}
