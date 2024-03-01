using GXPEngine;

namespace arcade
{
    internal class scoreBoard : GameObject
    {
        Player _player = MyGame.main.FindObjectOfType<Player>();
        EasyDraw canvas = new EasyDraw(1334, 768);

        StartScreen _startscreen = MyGame.main.FindObjectOfType<StartScreen>();
        EndScreen _endscreen = MyGame.main.FindObjectOfType<EndScreen>();

        int textX = 32;
        int textY = 100;

        int score;
        int headScore = 0;
        string bestScore = "HeadScore: ";

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
                    score = _player.score;
                    canvas.Text("Score: " + _player.score, textX, textY + 50);
                }
                canvas.Text(bestScore + headScore, textX, textY);

                if (_endscreen != null)
                {
                    if (headScore < _player.score)
                    {
                        canvas.Fill(255);
                        headScore = _player.score;
                        bestScore = "New Headscore!: ";
                    }
                    else
                    {
                        textX = 32;
                        textY = 525;
                        horizPos = CenterMode.Min;
                        bestScore = "HeadScore: ";
                    }
                }
            }
        }
    }
}
