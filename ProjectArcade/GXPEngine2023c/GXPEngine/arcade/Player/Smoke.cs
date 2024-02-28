using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Smoke : AnimationSprite
    {
        Buttons _button = MyGame.main.FindObjectOfType<Buttons>();
        Player _player = MyGame.main.FindObjectOfType<Player>();

        int side;
        bool keyK = false;
        bool keyL = false;

        public Smoke(string filename, int c, int r, TiledObject data) : base (filename, 3, 3)
        {
            side = data.GetIntProperty("side");
        }

        void Update()
        {
            keyK = Input.GetKeyDown(Key.K);
            keyL = Input.GetKeyDown(Key.L);

            if (_button == null) _button = MyGame.main.FindObjectOfType<Buttons>();
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();

            if (_player.health > 0)
            {
                if (_button.keyA && (keyK || keyL) && side == 1)
                {
                    SetCycle(0, 7);
                }
                if (_button.keyW && (keyK || keyL) && side == 2)
                {
                    SetCycle(0, 7);
                }
                if (_button.keyD && (keyK || keyL) && side == 3)
                {
                    SetCycle(0, 7);
                }
            }
            if (currentFrame == 6)
            {
                SetCycle(7);
            }

            Animate(0.2f);
        }
    }
}
