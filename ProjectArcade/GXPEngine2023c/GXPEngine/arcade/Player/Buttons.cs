using System;
using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Buttons : AnimationSprite
    {
        Player _player = MyGame.main.FindObjectOfType<Player>();
        Controller _controller = MyGame.main.FindObjectOfType<Controller>();

        public int side;
        public bool keyA = false;
        public bool keyW = false;
        public bool keyD = false;

        bool attack1 = false;
        bool attack2 = false;
        bool attack3 = false;
        public Buttons(string filename, int c, int r, TiledObject data) : base(filename, 2, 1, -1, false, true)
        {
            side = data.GetIntProperty("side");
        }

        void Update()
        {
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();
            if (_controller == null) _controller = MyGame.main.FindObjectOfType<Controller>();

            if (_controller != null)
            {
                Console.WriteLine(_controller.B1);
                if (_controller.B1 == 1)
                {
                    attack1 = true;
                }
                else attack1 = false;
                if (_controller.B2 == 1)
                {
                    attack2 = true;
                }
                else attack2 = false;
                if (_controller.B3 == 1)
                {
                    attack3 = true;
                } else attack3 = false;
            }

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
                if (attack1 && other.name == "pictures/enemy1.png")
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

                if (attack2 && other.name == "pictures/enemy2.png")
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

                if (attack3 && other.name == "pictures/enemy3.png")
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
