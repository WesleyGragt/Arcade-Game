using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Smoke : AnimationSprite
    {
        Buttons _button = MyGame.main.FindObjectOfType<Buttons>();
        Player _player = MyGame.main.FindObjectOfType<Player>();
        Controller _controller = MyGame.main.FindObjectOfType<Controller>();

        int side;
        bool keyK = false;
        bool keyL = false;

        bool attack1;
        bool attack2;
        bool attack3;

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
            if (_controller == null) _controller = MyGame.main.FindObjectOfType<Controller>();

            if (_controller.B1 == 1)
            {
                attack1 = true;
            } else attack1 = false;
            if (_controller.B2 == 1)
            {
                attack2 = true;
            } 
            else attack2 = false;
            if (_controller.B3 == 1)
            {
                attack3 = true;
            }
            else attack3 = false;

            if (_player.health > 0)
            {
                if (_button.keyA && (keyK || keyL || attack1 || attack2 || attack3) && side == 1)
                {
                    SetCycle(0, 7);
                }
                if (_button.keyW && (keyK || keyL || attack1 || attack2 || attack3) && side == 2)
                {
                    SetCycle(0, 7);
                }
                if (_button.keyD && (keyK || keyL || attack1 || attack2 || attack3) && side == 3)
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
