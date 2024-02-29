using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using arcade;
using System.IO.Ports;

public class MyGame : Game {
    public MyGame() : base(1334, 768, false, true)     // Create a window that's 800x600 and NOT fullscreen
	{
        //Controller controller = new Controller();
        //AddChild(controller);

        targetFps = 100;

		SceneHandler sceneHandler = new SceneHandler();	
		AddChild(sceneHandler);
       
        Console.WriteLine("My game initialized");
    }

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
        Console.WriteLine(currentFps);
    }

    static void Main()                          // Main() is the first method that's called when the program is run
	{
        new MyGame().Start();                   // Create a "MyGame" and start it
	}
}