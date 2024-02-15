using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Buttons : AnimationSprite
    {
        public int side;
        public bool keyA = false;
        public bool keyW = false;
        public bool keyD = false;
        public Buttons(string filename, int c, int r, TiledObject data) : base(filename, 2, 2, -1, false, true)
        {
            side = data.GetIntProperty("side");
        }

        void Update()
        {
            if (Input.GetKey(Key.A) && !keyW && !keyD)
            {
                keyA = true;
            }
            else if (Input.GetKey(Key.A) == false)
            {
                keyA = false;
            }
            if (Input.GetKey(Key.W) && !keyA && !keyD)
            {
                keyW = true;
            }
            else if (Input.GetKey(Key.W) == false)
            {
                keyW = false;
            }
            if (Input.GetKey(Key.D) && !keyA && !keyW)
            {
                keyD = true;
            }
            else if (Input.GetKey(Key.D) == false)
            {
                keyD = false;
            }

            if (keyA && !keyW && !keyD && side == 1)
            {
                SetCycle(3);
            }
            else if (!keyA && side == 1)
            {
                SetCycle(0);
            }

            if (keyW && !keyA && !keyD && side == 2)
            {
                SetCycle(3);
            }
            else if (!keyW && side == 2)
            {
                SetCycle(1);
            }

            if (keyD && !keyA && !keyW && side == 3)
            {
                SetCycle(3);
            }
            else if (!keyD && side == 3)
            {
                SetCycle(2);
            }
        }
    }
}
