using GXPEngine;
using System;

namespace arcade
{
    internal class Bullet : AnimationSprite
    {
        Player _player;
        Buttons _buttons;

        int speed = 3;
        int dirX;
        int dirY;

        public Bullet(float pX, float pY, int directX, int directY, string filename) : base(filename, 2, 1)
        {
            SetOrigin(width/2, height/2);
            height = 75;
            width = 75;
            dirX = directX;
            dirY = directY;
            x = pX;
            y = pY;
            _player = MyGame.main.FindObjectOfType<Player>();
            _buttons = MyGame.main.FindObjectOfType<Buttons>();
        }

        public void Update()
        { 
            x += speed * dirX;
            y += speed * dirY;
            SetCycle(0, 2);
            Animate(0.1f);
        }
        void OnCollision(GameObject other)
        {
            if (other is Player)
            {
                if (_player != null)
                {
                    _player.health--;
                }
                LateDestroy();
            }

            if (other is Buttons)
            {
                if (_buttons.keyA && Input.GetKeyDown(Key.K) && dirX == 1)
                {
                    LateDestroy();
                }
                if (_buttons.keyW && Input.GetKeyDown(Key.K) && dirX == 0)
                {
                    LateDestroy();
                }
                if (_buttons.keyD && Input.GetKeyDown(Key.K) && dirX == -1)
                {
                    LateDestroy();
                }
            }
        }
    }
}