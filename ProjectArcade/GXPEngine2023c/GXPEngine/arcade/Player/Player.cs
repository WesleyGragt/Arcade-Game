using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Player : AnimationSprite
    {
        Buttons _button;
        SceneHandler _sceneHandler = MyGame.main.FindObjectOfType<SceneHandler>();

        public int health;
        int startHealth;
        float speed;
        float startSpeed;

        public int score = 0;
        public bool addScore = false;
        public bool perfectScore = false;
        public bool normalScore = false;

        bool keyK = false;
        bool keyL = false;
        public Player(string filename, int c, int r, TiledObject data) : base(filename, 4, 12)
        {
            x = data.X;
            y = data.Y;
            health = data.GetIntProperty("health");
            startHealth = health;
            speed = data.GetFloatProperty("speed");
            startSpeed = speed;
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
                    speed = startSpeed;
                }
                if (_button.keyW && (keyK || keyL))
                {
                    SetCycle(32, 43);
                    speed = startSpeed;
                }
                if (_button.keyD && (keyK || keyL))
                {
                    SetCycle(0, 15);
                    speed = startSpeed;
                }
            }
            if (currentFrame == 14 || currentFrame == 30 || currentFrame == 42)
            {
                SetCycle(44, 45);
                speed = 0.1f;
            }
            Animate(speed);

            if (addScore)
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

            if (health <= 0)
            {
                _sceneHandler.endGame();
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
