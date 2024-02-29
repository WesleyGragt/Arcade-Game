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

        int center = 0;
        bool dir1;
        bool dir2;
        bool dir3;
        public Buttons(string filename, int c, int r, TiledObject data) : base(filename, 2, 1, -1, false, true)
        {
            side = data.GetIntProperty("side");
        }

        void Update()
        {
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();
            if (_controller == null) _controller = MyGame.main.FindObjectOfType<Controller>();

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

            if (_controller.DiskRotation > center - 15 && _controller.DiskRotation < center - 5)
            {
                dir1 = true;
            }
            else dir1 = false;
            if (_controller.DiskRotation > center - 5 && _controller.DiskRotation < center + 5)
            {
                dir2 = true;
            }
            else dir2 = false;
            if (_controller.DiskRotation > center + 5 && _controller.DiskRotation < center + 15)
            {
                dir3 = true;
            }
            else dir3 = false;

            if (_controller.DiskRotation < center - 25)
            {
                center = center - 25;
            }
            else if (_controller.DiskRotation > center + 25)
            {
                center = center + 25;
            }

            if (dir1)
            {
                keyA = true;
            } 
            else keyA = false;
            if (dir2)
            {
                keyW = true;
            } 
            else keyW = false;
            if (dir3)
            {
                keyD = true;
            }
            else keyD = false;

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
