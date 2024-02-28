using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;

namespace arcade
{
    public class StartScreen : GameObject
    {
        public static string start = "start.tmx";

        public StartScreen()
        {
            TiledLoader loader = new TiledLoader(start);
            loader.LoadTileLayers();
            loader.autoInstance = true;
            loader.LoadObjectGroups();
        }


    }
}
