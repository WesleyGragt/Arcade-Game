using GXPEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace arcade
{
    public class EndScreen : GameObject
    {
        public static string end = "end.tmx";

        public EndScreen()
        {
            TiledLoader loader = new TiledLoader(end);
            loader.LoadTileLayers();
            loader.autoInstance = true;
            loader.LoadObjectGroups();
        }
    }
}
