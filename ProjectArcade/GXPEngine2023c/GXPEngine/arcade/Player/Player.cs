using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Player : AnimationSprite
    {
        Buttons _button;

        public int health;
        int startHealth;
        float speed;

        public int score = 0;
        public bool addScore = false;
        public bool perfectScore = false;
        public bool normalScore = false;

        bool keyK = false;
        bool keyL = false;
        public Player(string filename, int c, int r, TiledObject data) : base(filename, 4, 11)
        {
            x = data.X;
            y = data.Y;
            health = data.GetIntProperty("health");
            startHealth = health;
            speed = data.GetFloatProperty("speed");
        }

        void Update()
        {
            keyK = Input.GetKeyDown(Key.K);
            keyL = Input.GetKeyDown(Key.L);

            if (_button == null)
            {
                _button = MyGame.main.FindObjectOfType<Buttons>();
            }

            if (health > 0)
            {
                if (_button.keyA && (keyK || keyL))
                {
                    SetCycle(16, 31);
                }
                if (_button.keyW && (keyK || keyL))
                {
                    SetCycle(32, 43);
                }
                if (_button.keyD && (keyK || keyL))
                {
                    SetCycle(0, 15);
                }
            }
            if (currentFrame == 14 || currentFrame == 30 || currentFrame == 42)
            {
                SetCycle(0);
            }
            Animate(speed);

            if (addScore && health > 0)
            {
                if (perfectScore)
                {
                    score += 100;
                    perfectScore = false;
                }
                else if (normalScore)
                {
                    score += 50;
                    normalScore = false;
                }
                addScore = false;
            }

            if (health <= 0 && Input.GetKey(Key.B))
            {
                health = startHealth;
                score = 0;
            }
        }

        void OnCollision(GameObject other)
        {
            if (other is Bullet)
            {
                health--;
                other.LateDestroy();
            }
        }
    }
}
