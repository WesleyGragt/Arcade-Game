using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace arcade
{
    internal class ending : AnimationSprite
    {
        public ending (string filename, int c, int r, TiledObject data) : base (filename, 3, 4)
        {
            
        }

        void Update()
        {
            SetCycle(0, 13);
            Animate(0.1f);
        }
    }
}
