using GXPEngine;
using TiledMapParser;

namespace arcade
{
    internal class ending : AnimationSprite
    {
        public ending (string filename, int c, int r, TiledObject data) : base (filename, 4, 4)
        {
            
        }

        void Update()
        {
            SetCycle(0, 13);
            Animate(0.05f);
        }
    }
}
