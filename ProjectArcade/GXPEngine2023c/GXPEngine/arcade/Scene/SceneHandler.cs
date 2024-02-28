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
        EndScreen eScreen;

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
            if (Input.GetKeyDown(Key.A) && !hasGameStarted)
            {
                //DestroyAll();
                startGame();
                hasGameStarted = true;
            }
            /*if (Input.GetKeyDown(Key.L))
            {
                hasGameEnded = true;
                hasGameStarted = false;
                Console.WriteLine("pressed l");
            }
            if (hasGameEnded)
            {
                endGame();
                hasGameEnded = false;
                Console.WriteLine("ga")
            }*/
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

        /*void DestroyAll()
        {
            List<GameObject> children= new List<GameObject>();
            children = game.GetChildren();
            foreach ( GameObject child in children )
            {
                Console.WriteLine(child);
                child.Destroy();
            }
        }*/
    }
}
