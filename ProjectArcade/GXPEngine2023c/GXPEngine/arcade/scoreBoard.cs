using GXPEngine;
using System.Drawing;

namespace arcade
{
    internal class scoreBoard : GameObject
    {
        Player _player = MyGame.main.FindObjectOfType<Player>();
        EasyDraw canvas = new EasyDraw(1334, 768);

        int textX = 32;
        int textY = 100;
        int headScore = 0;
        string bestScore = "HeadScore: ";

        int timer = 1000;
        int color = 255;

        CenterMode horizPos = CenterMode.Min;        
        public scoreBoard()
        {
            AddChild(canvas);
        }

        void Update()
        {
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();

            canvas.ClearTransparent();
            canvas.Fill(255);
            canvas.TextSize(32);
            canvas.TextAlign(horizPos, CenterMode.Center);
            canvas.Text("Score: " + _player.score, textX, textY+50);
            canvas.Text(bestScore + headScore, textX, textY);

            if (_player.health <= 0 )
            {
                textX = MyGame.main.width/2;
                textY = MyGame.main.height/2-125;
                horizPos = CenterMode.Center;

                canvas.Fill(255);
                canvas.Text("Game Over!", textX, textY-50);

                if (Time.time > timer+1000 && color == 255)
                {
                    color = 0;
                    timer = Time.time;
                } else if (Time.time > timer+1000 && color == 0)
                {
                    color = 255;
                    timer = Time.time;
                }
                canvas.Fill(color);
                canvas.Text("Press R to restart", textX, textY - 100);

                if (headScore < _player.score)
                {
                    canvas.Fill(255);
                    headScore = _player.score;
                    bestScore = "New Headscore!: ";
                }
            } else
            {
                textX = 32;
                textY = 100;
                horizPos = CenterMode.Min;
                bestScore = "HeadScore: ";
                color = 255;
            }
        }
    }
}
