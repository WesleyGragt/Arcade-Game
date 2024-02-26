
using GXPEngine;

namespace arcade
{
    public class Conductor : GameObject
    {
        public Conductor ()
        {
            Song1 song1 = new Song1();
            AddChild (song1);
        }
    }
}
