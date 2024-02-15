using GXPEngine;

namespace arcade
{
    internal class Bullet : AnimationSprite
    {
        Player _player;
        Buttons _buttons;

        int speed = 6;
        int dirX;
        int dirY;
        bool keyA = false;
        bool keyW = false;
        bool keyD = false;
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
            _buttons = MyGame.main.FindObjectOfType<Buttons>();
        }

        public void Update()
        { 
            x += speed * dirX;
            y += speed * dirY;

            if (Input.GetKey(Key.A) && !keyW && !keyD)
            {
                keyA = true;
            }
            else if (Input.GetKey(Key.W) && !keyA && !keyD)
            {
                keyW = true;
            }
            else if (Input.GetKey(Key.D) && !keyA && !keyW)
            {
                keyD = true;
            }
            else
            {
                keyA = false;
                keyW = false;
                keyD = false;
            }
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