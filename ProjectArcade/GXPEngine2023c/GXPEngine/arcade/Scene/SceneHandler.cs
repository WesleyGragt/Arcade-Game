using GXPEngine;
using System;
using System.Collections.Generic;
using TiledMapParser;

namespace arcade
{
    public class SceneHandler : GameObject
    {
        bool hasGameStarted = false;
        //bool hasGameEnded = false;
        bool startScreen = false;
        StartScreen sScreen;
        Level level = MyGame.main.FindObjectOfType<Level>();
        Conductor conductor = MyGame.main.FindObjectOfType<Conductor>();
        Controller controller = MyGame.main.FindObjectOfType<Controller>();
        //EndScreen eScreen;

        public SceneHandler()
        {
            Update();
        }

        void Update()
        {
            if (level == null) level = MyGame.main.FindObjectOfType<Level>();
            if (conductor == null) conductor = MyGame.main.FindObjectOfType<Conductor>();

            if (!startScreen)
            {
                sScreen = new StartScreen();
                AddChild(sScreen);
                Console.WriteLine("screen added");
                startScreen = true; // Set startScreen to true to prevent recreating the screen
            }
            if ((controller.B1 == 1 || controller.B2 == 1 || controller.B3 == 1) && !hasGameStarted)
            {
                startGame();
                hasGameStarted = true;
            }
        }

        void startGame()
        {

            // Load and add the level
            //DestroyAll();
            
            Level level = new Level();
            AddChild(level);

            // Add other game components as needed
            Conductor conductor = new Conductor();
            AddChild(conductor);

            scoreBoard _scoring = new scoreBoard();
            AddChild(_scoring);
        }

        public void endGame()
        {
            List<GameObject> children = new List<GameObject>();
            children = game.GetChildren();
            foreach (GameObject child in children)
            {
                child.Destroy();
            }

            // load and add the end screen
            EndScreen eScreen = new EndScreen();
            AddChild(eScreen);
        }
    }
}
