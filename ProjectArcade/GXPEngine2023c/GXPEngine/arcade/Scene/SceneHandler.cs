﻿using GXPEngine;
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
        EndScreen screenEnd = MyGame.main.FindObjectOfType<EndScreen>();
        Level level = MyGame.main.FindObjectOfType<Level>();
        Conductor conductor = MyGame.main.FindObjectOfType<Conductor>();
        Controller controller = MyGame.main.FindObjectOfType<Controller>();
        SoundChannel start = new Sound("music/mainMenu.mp3", true, false).Play();
        SoundChannel end;
        //EndScreen eScreen;

        bool restart = false;

        public static SceneHandler main;

        public SceneHandler()
        {
            main = this;
            Update();
        }

        void Update()
        {
            if (level == null) level = MyGame.main.FindObjectOfType<Level>();
            if (conductor == null) conductor = MyGame.main.FindObjectOfType<Conductor>();
            if (screenEnd == null) screenEnd = MyGame.main.FindObjectOfType<EndScreen>();

            /*if (screenEnd != null && (controller.B1 == 1 || controller.B2 == 1 || controller.B3 == 1) && restart)         Getting to restart the game
            {
                List<GameObject> children = new List<GameObject>();
                children = SceneHandler.main.GetChildren();
                foreach (GameObject child in children)
                {
                    child.Destroy();
                }

                restart = false;
                startScreen = false;
                hasGameStarted = false;
            }*/

            if (!startScreen)
            {
                sScreen = new StartScreen();
                AddChild(sScreen);
                Console.WriteLine("screen added");
                startScreen = true; // Set startScreen to true to prevent recreating the screen
            }
            if ((controller.B1 == 1 || controller.B2 == 1 || controller.B3 == 1) && !hasGameStarted)
            {
                List<GameObject> children = new List<GameObject>();
                children = SceneHandler.main.GetChildren();
                foreach (GameObject child in children)
                {
                    child.Destroy();
                }

                start.Stop();
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
        }

        public void endGame()
        {
            List<GameObject> children = new List<GameObject>();
            children = SceneHandler.main.GetChildren();
            foreach (GameObject child in children)
            {
                child.Destroy();
            }
            
            // load and add the end screen
            EndScreen eScreen = new EndScreen();
            end = new Sound("music/ending.wav", false, false).Play();
            AddChild(eScreen);

            restart = true;
        }
    }
}
