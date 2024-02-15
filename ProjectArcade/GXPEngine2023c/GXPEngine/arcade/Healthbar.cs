using System;
using GXPEngine;
using TiledMapParser;

namespace arcade
{
    public class Healthbar : AnimationSprite
    {
        int hey;
        public Healthbar(string filename, int c, int r, TiledObject data) : base(filename, 1, 1)
        {
            data.textField.text = "Yo";
            hey = data.GetIntProperty("hey");
        }

        void Update()
        {
            Console.WriteLine(hey);
        }
    }
}
