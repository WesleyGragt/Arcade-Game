using System;
using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Smoke : AnimationSprite
    {
        Buttons _button = MyGame.main.FindObjectOfType<Buttons>();
        Player _player = MyGame.main.FindObjectOfType<Player>();
        Controller _controller = MyGame.main.FindObjectOfType<Controller>();
        SoundChannel hit;

        int side;
        bool keyK = false;
        bool keyL = false;

        bool hasAttacked1 = false;
        bool hasAttacked2 = false;
        bool hasAttacked3 = false;

        bool attack1;
        bool attack2;
        bool attack3;

        bool playing1 = false;
        bool playing2 = false;
        bool playing3 = false;

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

            if (_controller.B1 == 1 && !attack2 && !attack3)
            {
                attack1 = true;
            }
            else if (_controller.B1 == 0)
            {
                attack1 = false;
                hasAttacked1 = false;
            }
            if (_controller.B2 == 1 && !attack1 && !attack3)
            {
                attack2 = true;
            }
            else if (_controller.B2 == 0)
            {
                attack2 = false;
                hasAttacked2 = false;
            }
            if (_controller.B3 == 1 && !attack1 && !attack2)
            {
                attack3 = true;
            }
            else if (_controller.B3 == 0)
            {
                attack3 = false;
                hasAttacked3 = false;
            }

            if (_player.health > 0)
            {
                if (_button.keyA && (keyK || keyL || attack1 || attack2 || attack3) && side == 1 && !hasAttacked1 && !hasAttacked2 && !hasAttacked3)
                {
                    SetCycle(0, 7);
                    if (!playing1)
                    {
                        playing1 = true;
                        hit = new Sound("music/hit.wav", false, false).Play();
                    } else if (playing1 && hit.IsPlaying == false)
                    {
                        playing1 = false;
                    }
                    hasAttacked1 = true;
                    hasAttacked2 = true;
                    hasAttacked3 = true;
                }
                if (_button.keyW && (keyK || keyL || attack1 || attack2 || attack3) && side == 2 && !hasAttacked1 && !hasAttacked2 && !hasAttacked3)
                {
                    SetCycle(0, 7);
                    if (!playing2)
                    {
                        playing2 = true;
                        hit = new Sound("music/hit.wav", false, false).Play();
                    }
                    else if (playing2 && hit.IsPlaying == false)
                    {
                        playing2 = false;
                    }
                    hasAttacked1 = true;
                    hasAttacked2 = true;
                    hasAttacked3 = true;
                }
                if (_button.keyD && (keyK || keyL || attack1 || attack2 || attack3) && side == 3 && !hasAttacked1 && !hasAttacked2 && !hasAttacked3)
                {
                    SetCycle(0, 7);
                    if (!playing3)
                    {
                        playing3 = true;
                        hit = new Sound("music/hit.wav", false, false).Play();
                    }
                    else if (playing3 && hit.IsPlaying == false)
                    {
                        playing3 = false;
                    }
                    hasAttacked1 = true;
                    hasAttacked2 = true;
                    hasAttacked3 = true;
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
