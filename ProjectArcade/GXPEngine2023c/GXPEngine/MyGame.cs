using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using Arcade;

public class MyGame : Game {
	public MyGame() : base(800, 600, false, false, 800, 600, true)     // Create a window that's 800x600 and NOT fullscreen
	{
        EasyDraw canvas = new EasyDraw(800, 600, false);
        
		Level level = new Level();

		AddChild(level);
        AddChild(canvas);

        Console.WriteLine("My game initialized");
	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
		
	}

	static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}