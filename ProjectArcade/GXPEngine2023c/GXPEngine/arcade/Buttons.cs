using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Buttons : AnimationSprite
    {
        Player _player = MyGame.main.FindObjectOfType<Player>();

        public int side;
        public bool keyA = false;
        public bool keyW = false;
        public bool keyD = false;
        public Buttons(string filename, int c, int r, TiledObject data) : base(filename, 2, 1, -1, false, true)
        {
            side = data.GetIntProperty("side");
        }

        void Update()
        {
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();

            if (Input.GetKey(Key.A) && !keyW && !keyD)
            {
                keyA = true;
            }
            else if (Input.GetKey(Key.A) == false)
            {
                keyA = false;
            }
            if (Input.GetKey(Key.W) && !keyA && !keyD)
            {
                keyW = true;
            }
            else if (Input.GetKey(Key.W) == false)
            {
                keyW = false;
            }
            if (Input.GetKey(Key.D) && !keyA && !keyW)
            {
                keyD = true;
            }
            else if (Input.GetKey(Key.D) == false)
            {
                keyD = false;
            }

            if (keyA && !keyW && !keyD && side == 1)
            {
                SetCycle(1);
            }
            else if (!keyA && side == 1)
            {
                SetCycle(0);
            }

            if (keyW && !keyA && !keyD && side == 2)
            {
                SetCycle(1);
            }
            else if (!keyW && side == 2)
            {
                SetCycle(0);
            }

            if (keyD && !keyA && !keyW && side == 3)
            {
                SetCycle(1);
            }
            else if (!keyD && side == 3)
            {
                SetCycle(0);
            }
        }

        void OnCollision(GameObject other)
        {
            if (other is Bullet)
            {
                if (Input.GetKeyDown(Key.K) && other.name == "pictures/enemy1.png")
                {
                    if (keyA && side == 1)
                    {
                        if (x < other.x && x + 8 > other.x)
                        {
                            _player.perfectScore = true;
                        }
                        else _player.normalScore = true;
                        _player.addScore = true;
                        other.LateDestroy();
                    }
                    if (keyW && side == 2)
                    {
                        if (x < other.x && x + 8 > other.x)
                        {
                            _player.perfectScore = true;
                        }
                        else _player.normalScore = true;
                        _player.addScore = true;
                        other.LateDestroy();
                    }
                    if (keyD && side == 3)
                    {
                        if (x < other.x && x + 8 > other.x)
                        {
                            _player.perfectScore = true;
                        }
                        else _player.normalScore = true;
                        _player.addScore = true;
                        other.LateDestroy();
                    }
                }

                if (Input.GetKeyDown(Key.L) && other.name == "pictures/enemy2.png")
                {
                    if (keyA && side == 1)
                    {
                        if (x < other.x && x + 8 > other.x)
                        {
                            _player.perfectScore = true;
                        }
                        else _player.normalScore = true;
                        _player.addScore = true;
                        other.LateDestroy();
                    }
                    if (keyW && side == 2)
                    {
                        if (x < other.x && x + 8 > other.x)
                        {
                            _player.perfectScore = true;
                        }
                        else _player.normalScore = true;
                        _player.addScore = true;
                        other.LateDestroy();
                    }
                    if (keyD && side == 3)
                    {
                        if (x < other.x && x + 8 > other.x)
                        {
                            _player.perfectScore = true;
                        }
                        else _player.normalScore = true;
                        _player.addScore = true;
                        other.LateDestroy();
                    }


                }

                if (Input.GetKeyDown(Key.J) && other.name == "pictures/enemy3.png")
                {
                    if (keyA && side == 1)
                    {
                        if (x < other.x && x + 8 > other.x)
                        {
                            _player.perfectScore = true;
                        }
                        else _player.normalScore = true;
                        _player.addScore = true;
                        other.LateDestroy();
                    }
                    if (keyW && side == 2)
                    {
                        if (x < other.x && x + 8 > other.x)
                        {
                            _player.perfectScore = true;
                        }
                        else _player.normalScore = true;
                        _player.addScore = true;
                        other.LateDestroy();
                    }
                    if (keyD && side == 3)
                    {
                        if (x < other.x && x + 8 > other.x)
                        {
                            _player.perfectScore = true;
                        }
                        else _player.normalScore = true;
                        _player.addScore = true;
                        other.LateDestroy();
                    }


                }
            }
        }
    }
}
