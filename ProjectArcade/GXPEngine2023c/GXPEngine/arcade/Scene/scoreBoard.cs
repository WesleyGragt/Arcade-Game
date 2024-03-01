using GXPEngine;

namespace arcade
{
    internal class scoreBoard : GameObject
    {
        Player _player = MyGame.main.FindObjectOfType<Player>();
        EasyDraw canvas = new EasyDraw(1334, 768);

        StartScreen _startscreen = MyGame.main.FindObjectOfType<StartScreen>();
        EndScreen _endscreen = MyGame.main.FindObjectOfType<EndScreen>();

        int textX = 64;
        int textY = 115;

        CenterMode horizPos = CenterMode.Min;        
        public scoreBoard()
        {
            AddChild(canvas);
        }

        void Update()
        {
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();
            _startscreen = MyGame.main.FindObjectOfType<StartScreen>();
            _endscreen = MyGame.main.FindObjectOfType<EndScreen>();

            if (_startscreen == null)
            {
                canvas.ClearTransparent();
                canvas.Fill(255);
                canvas.TextSize(32);
                canvas.TextAlign(horizPos, CenterMode.Center);
                if (_player != null)
                {
                    canvas.Text("Score: " + _player.score, textX, textY);
                }
            }

            if (_endscreen != null)
            {
                textX = 40;
                textY = 497;
            }
        }
    }
}
