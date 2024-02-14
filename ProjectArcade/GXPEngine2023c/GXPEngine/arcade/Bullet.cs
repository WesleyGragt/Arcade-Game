using System;
using GXPEngine;

namespace arcade
{
    internal class Bullet : AnimationSprite
    {
        Player _player;
        int speed = 6;
        int dirX;
        int dirY;
        bool keyDown = false;

        public Bullet(float pX, float pY, int directX, int directY) : base("pictures/circle.png", 1, 1)
        {
            SetOrigin(width/2, height/2);
            height = 20;
            width = 20;
            dirX = directX;
            dirY = directY;
            x = pX;
            y = pY;
            _player = MyGame.main.FindObjectOfType<Player>();
        }

        public void Update()
        { 
            x += speed * dirX;
            y += speed * dirY;
        }
        void OnCollision(GameObject other)
        {
            if (other is Player)
            {
                if (_player != null)
                {
                    _player.health -= 1;
                }
                LateDestroy();
            }

            if (other is Buttons)
            {
                if (Input.GetKey(Key.A) && !keyDown && dirX == 1 && Input.GetKeyDown(Key.K))
                {
                    LateDestroy();
                    keyDown = true;
                } else if (Input.GetKey(Key.W) && !keyDown && dirX == 0 && Input.GetKeyDown(Key.K))
                {
                    LateDestroy();
                    keyDown = true;
                } else if (Input.GetKey(Key.D) && !keyDown && dirX == -1 && Input.GetKeyDown(Key.K))
                {
                    LateDestroy();
                    keyDown = true;
                }
                else keyDown = false;
            }
        }
    }
}