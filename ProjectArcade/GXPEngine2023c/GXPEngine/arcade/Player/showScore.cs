using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace arcade
{
    internal class showScore : AnimationSprite
    {
        Buttons _button = MyGame.main.FindObjectOfType<Buttons>();


        public bool perfAnim = false;
        public bool normAnim = false;

        float speed = 0.1f;
        public showScore(string filename, int c, int r, TiledObject data) : base(filename, 2, 5, -1, false, false)
        {

        }

        void Update()
        {
            if (_button == null) _button = MyGame.main.FindObjectOfType<Buttons>();
            //Console.WriteLine(_button.normAnim + ", " + _button.perfAnim);
            if (normAnim)
            {
                SetCycle(0, 5);
                speed = 0.1f;
                normAnim = false;
            }
            else if (perfAnim)
            {
                SetCycle(5, 8);
                speed = 0.095f;
                perfAnim = false;
            }
            else if (currentFrame == 4 || currentFrame == 7)
            {
                SetCycle(8);
            }
            Animate(speed);
        }
    }
}
