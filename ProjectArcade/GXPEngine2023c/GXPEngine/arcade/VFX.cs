using GXPEngine;
using System.Drawing;

namespace arcade
{
    internal class VFX : GameObject
    {
        Player _player = MyGame.main.FindObjectOfType<Player>();
        EasyDraw canvas = new EasyDraw(1334, 768);
        public VFX()
        {
            AddChild(canvas);
        }

        void Update()
        {
            if (_player == null) _player = MyGame.main.FindObjectOfType<Player>();

            canvas.ClearTransparent();
            canvas.Fill(255);
            canvas.TextSize(32);
            canvas.TextAlign(CenterMode.Min, CenterMode.Center);
            canvas.Text("Score: " + _player.score, 32, 100);
        }
    }
}
