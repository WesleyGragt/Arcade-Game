using GXPEngine;
using TiledMapParser;

namespace arcade
{
    internal class ending : AnimationSprite
    {
        scoreBoard _scoreboard = MyGame.main.FindObjectOfType<scoreBoard>();

        public ending (string filename, int c, int r, TiledObject data) : base (filename, 4, 4)
        {
            
        }

        void Update()
        {
            if (_scoreboard == null)
            {
                _scoreboard = MyGame.main.FindObjectOfType<scoreBoard>();
            }

            SetCycle(0, 13);
            Animate(0.05f);
        }
    }
}
